using AutoMapper;
using logistic_app_api.Data;
using logistic_app_api.Dtos.DeliveryTasks;
using logistic_app_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Controllers
{
    [Route("api/deliverytasks")]
    [ApiController]
    public class DeliveryTasksController : ControllerBase
    {
        private readonly DeliveryTasksRepository _repository;
        private readonly IMapper _mapper;
        public DeliveryTasksController(IRepository<DeliveryTask> repository, IMapper mapper)
        {
            _repository = (DeliveryTasksRepository)repository;
            _mapper = mapper;
        }

        //GET api/deliverytasks
        [HttpGet]
        public ActionResult<IEnumerable<DeliveryTasksReadDto>> GetAll()
        {
            var deliveryTasks = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<DeliveryTasksReadDto>>(deliveryTasks));
        }

        //GET api/deliverytasks/{id}
        [HttpGet("{id}")]
        public ActionResult<DeliveryTaskReadDto> GetById(int id)
        {
            var deliveryTask = _repository.GetById(id);
            if (deliveryTask != null)
            {
                return Ok(_mapper.Map<DeliveryTaskReadDto>(deliveryTask));
            }
            return NotFound();
        }

        //POST api/deliverytasks
        [HttpPost]
        public ActionResult<DeliveryTaskReadDto> Create(DeliveryTaskCreateDto _deliveryTask)
        {
            try
            {
                var deliveryTask = _mapper.Map<DeliveryTask>(_deliveryTask);
                _repository.Create(deliveryTask);
                _repository.SaveChanges();

                var response = _mapper.Map<DeliveryTaskReadDto>(deliveryTask);

                return Ok(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //PUT api/deliverytasks/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, DeliveryTaskUpdateDto deliveryTaskUpdateDto)
        {
            var deliveryTaskFromRepo = _repository.GetById(id);
            if (deliveryTaskFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(deliveryTaskUpdateDto, deliveryTaskFromRepo);
            _repository.Update(deliveryTaskFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/deliverytasks/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deliveryTaskFromRepo = _repository.GetById(id);
            if (deliveryTaskFromRepo == null)
            {
                return NotFound();
            }
            _repository.Delete(deliveryTaskFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
