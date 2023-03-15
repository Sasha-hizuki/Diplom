using AutoMapper;
using logistic_app_api.Data;
using logistic_app_api.Dtos.BorderCrossings;
using logistic_app_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Controllers
{
    [Route("api/bordercrossings")]
    [ApiController]
    public class BorderCrossingsController : ControllerBase
    {
        private readonly BorderCrossingsRepository _repository;
        private readonly IMapper _mapper;
        public BorderCrossingsController(IRepository<BorderCrossing> repository, IMapper mapper)
        {
            _repository = (BorderCrossingsRepository)repository;
            _mapper = mapper;
        }

        //GET api/bordercrossings
        [HttpGet]
        public ActionResult<IEnumerable<BorderCrossingReadDto>> GetAll()
        {
            var borderCrossings = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<BorderCrossingReadDto>>(borderCrossings));
        }

        //GET api/bordercrossings/{id}
        [HttpGet("{id}")]
        public ActionResult<BorderCrossingReadDto> GetById(int id)
        {
            var borderCrossing = _repository.GetById(id);
            if (borderCrossing != null)
            {
                return Ok(_mapper.Map<BorderCrossingReadDto>(borderCrossing));
            }
            return NotFound();
        }

        //POST api/bordercrossings
        [HttpPost]
        public ActionResult<BorderCrossingReadDto> Create(BorderCrossingCreateDto _borderCrossing)
        {
            var borderCrossing = _mapper.Map<BorderCrossing>(_borderCrossing);
            _repository.Create(borderCrossing);
            _repository.SaveChanges();

            var response = _mapper.Map<BorderCrossingReadDto>(borderCrossing);

            return Ok(response);
        }

        //PUT api/bordercrossings/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, BorderCrossingUpdateDto borderCrossingUpdateDto)
        {
            var borderCrossingFromRepo = _repository.GetById(id);
            if (borderCrossingFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(borderCrossingUpdateDto, borderCrossingFromRepo);
            _repository.Update(borderCrossingFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/bordercrossings/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var carFromRepo = _repository.GetById(id);
            if (carFromRepo == null)
            {
                return NotFound();
            }
            _repository.Delete(carFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
