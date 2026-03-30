using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicSimi.Core.DTOs;
using MusicSimi.Core.Entities;
using MusicSimi.Core.Repositories;
using MusicSimi.Core.Serivecs;
using MusicSimi.Entities;
using MusicSimi.Models;
using MusicSimi.Service;
using System.Collections.Generic;
using System.Linq;


namespace MusicSimi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Student,Teacher")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teachersService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public TeachersController(ITeacherService teachersservice, IUserService userService, IMapper mapper)
        {
            _teachersService = teachersservice;
            _userService = userService;
            _mapper = mapper;

        }
        // GET: api/<TeachersController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<List<TeacherPostModel>> Get()
        {
            var sList =await _teachersService.GetAllAsync();
            var sDTOList = new List<TeacherPostModel>();
            sDTOList = _mapper.Map<List<TeacherPostModel>>(sList);/////////
            return sDTOList;


        }

        // GET api/<TeachersController>/5
        [HttpGet("{id}")]
        public async Task<TeacherPostModel> Get(int id)
        {
           

            await _teachersService.GetAllAsync();
            var st =await _teachersService.GetByIdAsync(id);
            var sDTO = _mapper.Map<TeacherPostModel>(st);
            return sDTO;

        }

        // POST api/<TeachersController>
        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Post([FromBody] TeacherPostModel t)
        {

            var user = new User { name = t.name, password = t.password, Role = eRole.Teacher };
            var User = await _userService.AddUserAsync(user);
            var newCastomer = _mapper.Map<Teachers>(t);
            newCastomer.user = User;
            newCastomer.id = User.Id;
            var Castomer = await _teachersService.GetByIdAsync(newCastomer.id);
            if (Castomer != null)
            {
                return Conflict();
            }
            await _teachersService.AddTeacherAsync(newCastomer);
            return Ok(); ;



        }

        // PUT api/<TeachersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TeacherPostModel t)
        {
            var teacher =await _teachersService.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            teacher.name = t.name;
            teacher.age = t.age;
            teacher.phone = t.phone;
            teacher.email = t.email;
            await _teachersService.UpdateTeacherAsync(teacher,id);
            return Ok();
        }

        // DELETE api/<TeachersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher =await _teachersService.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            await _teachersService.DeleteTeacherAsync(id);
            return Ok();
        }
    }
}