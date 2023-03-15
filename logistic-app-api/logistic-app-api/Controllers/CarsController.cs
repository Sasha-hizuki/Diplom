using AutoMapper;
using logistic_app_api.Data;
using logistic_app_api.Dtos.Cars;
using logistic_app_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarsRepository _repository;
        private readonly IMapper _mapper;
        public CarsController(IRepository<Car> repository, IMapper mapper)
        {
            _repository = (CarsRepository)repository;
            _mapper = mapper;
        }

        //GET api/cars
        [HttpGet]
        public ActionResult<IEnumerable<CarsReadDto>> GetAll()
        {
            var cars = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<CarsReadDto>>(cars));
        }

        //GET api/cars/{id}
        [HttpGet("{id}")]
        public ActionResult<CarReadDto> GetById(int id)
        {
            var car = _repository.GetById(id);
            if (car != null)
            {
                return Ok(_mapper.Map<CarReadDto>(car));
            }
            return NotFound();
        }

        //POST api/cars
        [HttpPost]
        public ActionResult<CarReadDto> Create(CarCreateDto _car)
        {
            var car = _mapper.Map<Car>(_car);
            _repository.Create(car);
            _repository.SaveChanges();

            var response = _mapper.Map<CarReadDto>(car);

            return Ok(response);
        }

        //PUT api/cars/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, CarUpdateDto carUpdateDto)
        {
            var carFromRepo = _repository.GetById(id);
            if (carFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(carUpdateDto, carFromRepo);
            _repository.Update(carFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/cars/{id}
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
