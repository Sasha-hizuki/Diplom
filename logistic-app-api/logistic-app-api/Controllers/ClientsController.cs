using AutoMapper;
using logistic_app_api.Data;
using logistic_app_api.Dtos.Clients;
using logistic_app_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientsRepository _repository;
        private readonly IMapper _mapper;
        public ClientsController(IRepository<Client> repository, IMapper mapper)
        {
            _repository = (ClientsRepository)repository;
            _mapper = mapper;
        }

        //GET api/clients
        [HttpGet]
        public ActionResult<IEnumerable<ClientsReadDto>> GetAll()
        {
            var clients = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<ClientsReadDto>>(clients));
        }

        //GET api/clients/{id}
        [HttpGet("{id}")]
        public ActionResult<ClientReadDto> GetById(int id)
        {
            var client = _repository.GetById(id);
            if (client != null)
            {
                return Ok(_mapper.Map<ClientReadDto>(client));
            }
            return NotFound();
        }

        //POST api/clients
        [HttpPost]
        public ActionResult<ClientReadDto> Create(ClientCreateDto _client)
        {
            var client = _mapper.Map<Client>(_client);
            _repository.Create(client);
            _repository.SaveChanges();

            var response = _mapper.Map<ClientReadDto>(client);

            return Ok(response);
        }

        //PUT api/clients/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, ClientUpdateDto clientUpdateDto)
        {
            var clientFromRepo = _repository.GetById(id);
            if (clientFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(clientUpdateDto, clientFromRepo);
            _repository.Update(clientFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/clients/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var clientFromRepo = _repository.GetById(id);
            if (clientFromRepo == null)
            {
                return NotFound();
            }
            _repository.Delete(clientFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
