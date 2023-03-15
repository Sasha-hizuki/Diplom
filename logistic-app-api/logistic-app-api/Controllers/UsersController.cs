using AutoMapper;
using logistic_app_api.Data;
using logistic_app_api.Dtos.Users;
using logistic_app_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersRepository _repository;
        private readonly IMapper _mapper;
        public UsersController(IRepository<User> repository, IMapper mapper)
        {
            _repository = (UsersRepository)repository;
            _mapper = mapper;
        }

        //GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<UsersReadDto>> GetAll()
        {
            var users = _repository.GetAll();

            var a = _mapper.Map<IEnumerable<UsersReadDto>>(users);
            return Ok(a);
        }

        //GET api/users/{id}
        [HttpGet("{id}")]
        public ActionResult<UserReadDto> GetById(int id)
        {
            var user = _repository.GetById(id);
            if (user != null)
            {
                return Ok(_mapper.Map<UserReadDto>(user));
            }
            return NotFound();
        }

        //POST api/users
        [HttpPost]
        public ActionResult<UserReadDto> Create(UserCreateDto _user)
        {
            var user = _mapper.Map<User>(_user);
            _repository.Create(user);
            _repository.SaveChanges();

            var response = _mapper.Map<UserReadDto>(user);

            return Ok(response);
        }

        //PUT api/users/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, UserUpdateDto userUpdateDto)
        {
            var userFromRepo = _repository.GetById(id);
            if (userFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(userUpdateDto, userFromRepo);
            _repository.Update(userFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/users/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var userFromRepo = _repository.GetById(id);
            if (userFromRepo == null)
            {
                return NotFound();
            }
            _repository.Delete(userFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
