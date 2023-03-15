using AutoMapper;
using logistic_app_api.Data;
using logistic_app_api.Dtos.Trailers;
using logistic_app_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Controllers
{
    [Route("api/trailers")]
    [ApiController]
    public class TrailersController : ControllerBase
    {
        private readonly TrailersRepository _repository;
        private readonly IMapper _mapper;
        public TrailersController(IRepository<Trailer> repository, IMapper mapper)
        {
            _repository = (TrailersRepository)repository;
            _mapper = mapper;
        }

        //GET api/trailers
        [HttpGet]
        public ActionResult<IEnumerable<TrailersReadDto>> GetAll()
        {
            var cars = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<TrailersReadDto>>(cars));
        }

        //GET api/trailers/{id}
        [HttpGet("{id}")]
        public ActionResult<TrailerReadDto> GetById(int id)
        {
            var car = _repository.GetById(id);
            if (car != null)
            {
                return Ok(_mapper.Map<TrailerReadDto>(car));
            }
            return NotFound();
        }

        //POST api/trailers
        [HttpPost]
        public ActionResult<TrailerReadDto> Create(TrailerCreateDto _trailer)
        {
            var trailer = _mapper.Map<Trailer>(_trailer);
            _repository.Create(trailer);
            _repository.SaveChanges();

            var response = _mapper.Map<TrailerReadDto>(trailer);

            return Ok(response);
        }

        //PUT api/trailers/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, TrailerUpdateDto trailerUpdateDto)
        {
            var trailerFromRepo = _repository.GetById(id);
            if (trailerFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(trailerUpdateDto, trailerFromRepo);
            _repository.Update(trailerFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/trailers/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var trailerFromRepo = _repository.GetById(id);
            if (trailerFromRepo == null)
            {
                return NotFound();
            }
            _repository.Delete(trailerFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
