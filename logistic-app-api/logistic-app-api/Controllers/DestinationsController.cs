using AutoMapper;
using logistic_app_api.Data;
using logistic_app_api.Dtos.Destinations;
using logistic_app_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Controllers
{
    [Route("api/destinations")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly DestinationsRepository _repository;
        private readonly IMapper _mapper;
        public DestinationsController(IRepository<Destination> repository, IMapper mapper)
        {
            _repository = (DestinationsRepository)repository;
            _mapper = mapper;
        }

        //GET api/destinations
        [HttpGet]
        public ActionResult<IEnumerable<DestinationsReadDto>> GetAll()
        {
            var destinations = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<DestinationsReadDto>>(destinations));
        }

        //GET api/destinations/{id}
        [HttpGet("{id}")]
        public ActionResult<DestinationReadDto> GetById(int id)
        {
            var destination = _repository.GetById(id);
            if (destination != null)
            {
                return Ok(_mapper.Map<DestinationReadDto>(destination));
            }
            return NotFound();
        }

        //POST api/destinations
        [HttpPost]
        public ActionResult<DestinationReadDto> Create(DestinationCreateDto _client)
        {
            var destination = _mapper.Map<Destination>(_client);
            _repository.Create(destination);
            _repository.SaveChanges();

            var response = _mapper.Map<DestinationReadDto>(destination);

            return Ok(response);
        }

        //PUT api/destinations/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, DestinationUpdateDto destinationUpdateDto)
        {
            var destinationFromRepo = _repository.GetById(id);
            if (destinationFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(destinationUpdateDto, destinationFromRepo);
            _repository.Update(destinationFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/destinations/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var destinationFromRepo = _repository.GetById(id);
            if (destinationFromRepo == null)
            {
                return NotFound();
            }
            _repository.Delete(destinationFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
