using AutoMapper;
using logistic_app_api.Data;
using logistic_app_api.Dtos.Declarants;
using logistic_app_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Controllers
{
    [Route("api/declarants")]
    [ApiController]
    public class DeclarantsController : ControllerBase
    {
        private readonly DeclarantsRepository _repository;
        private readonly IMapper _mapper;
        public DeclarantsController(IRepository<Declarant> repository, IMapper mapper)
        {
            _repository = (DeclarantsRepository)repository;
            _mapper = mapper;
        }

        //GET api/declarants
        [HttpGet]
        public ActionResult<IEnumerable<DeclarantsReadDto>> GetAll()
        {
            var declarants = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<DeclarantsReadDto>>(declarants));
        }

        //GET api/declarants/{id}
        [HttpGet("{id}")]
        public ActionResult<DeclarantReadDto> GetById(int id)
        {
            var declarant = _repository.GetById(id);
            if (declarant != null)
            {
                return Ok(_mapper.Map<DeclarantReadDto>(declarant));
            }
            return NotFound();
        }

        //POST api/declarants
        [HttpPost]
        public ActionResult<DeclarantReadDto> Create(DeclarantCreateDto _client)
        {
            var declarant = _mapper.Map<Declarant>(_client);
            _repository.Create(declarant);
            _repository.SaveChanges();

            var response = _mapper.Map<DeclarantReadDto>(declarant);

            return Ok(response);
        }

        //PUT api/declarants/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, DeclarantUpdateDto declarantUpdateDto)
        {
            var declarantFromRepo = _repository.GetById(id);
            if (declarantFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(declarantUpdateDto, declarantFromRepo);
            _repository.Update(declarantFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/declarants/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var declarantFromRepo = _repository.GetById(id);
            if (declarantFromRepo == null)
            {
                return NotFound();
            }
            _repository.Delete(declarantFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
