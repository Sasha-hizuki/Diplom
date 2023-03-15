using AutoMapper;
using logistic_app_api.Data;
using logistic_app_api.Dtos.Custom;
using logistic_app_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Controllers
{
    [Route("api/customs")]
    [ApiController]
    public class CustomsController : ControllerBase
    {
        private readonly CustomsRepository _repository;
        private readonly IMapper _mapper;
        public CustomsController(IRepository<Customs> repository, IMapper mapper)
        {
            _repository = (CustomsRepository)repository;
            _mapper = mapper;
        }

        //GET api/customs
        [HttpGet]
        public ActionResult<IEnumerable<CustomsReadDto>> GetAll()
        {
            var customs = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<CustomsReadDto>>(customs));
        }

        //GET api/customs/{id}
        [HttpGet("{id}")]
        public ActionResult<CustomsReadDto> GetById(int id)
        {
            var custom = _repository.GetById(id);
            if (custom != null)
            {
                return Ok(_mapper.Map<CustomsReadDto>(custom));
            }
            return NotFound();
        }

        //POST api/customs
        [HttpPost]
        public ActionResult<CustomsReadDto> Create(CustomsCreateDto _custom)
        {
            var custom = _mapper.Map<Customs>(_custom);
            _repository.Create(custom);
            _repository.SaveChanges();

            var response = _mapper.Map<CustomsReadDto>(custom);

            return Ok(response);
        }

        //PUT api/customs/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, CustomsUpdateDto customsUpdateDto)
        {
            var customFromRepo = _repository.GetById(id);
            if (customFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(customsUpdateDto, customFromRepo);
            _repository.Update(customFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/customs/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var customFromRepo = _repository.GetById(id);
            if (customFromRepo == null)
            {
                return NotFound();
            }
            _repository.Delete(customFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
