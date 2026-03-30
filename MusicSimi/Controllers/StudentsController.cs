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
using System.Xml.Linq;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicSimi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Student")]
    public class StudentsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IStudentServics _studentService;
        private readonly IMapper _mapper;

        public StudentsController(IStudentServics studentservice, IUserService userService, IMapper mapper)
        {
            _studentService = studentservice;
            _userService = userService;
            _mapper = mapper;

        }
        // GET: api/<StudentsController>
        [HttpGet]
        public async Task<List<StudentPostModel>> Get()
        {
            var sList =await _studentService.GetAllAsync();
            var sDTOList = new List<StudentPostModel>();
            sDTOList = _mapper.Map<List<StudentPostModel>>(sList);
            return sDTOList;

        }
        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public async Task<StudentPostModel> Get(int id)
        {
           await _studentService.GetAllAsync();
            var st =await _studentService.GetByIdAsync(id);
           var sDTO = _mapper.Map<StudentPostModel>(st);
            return sDTO;

        }

        // POST api/<StudentsController>
        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Post([FromBody] StudentPostModel value)
        {


            var user = new User { name = value.name, password = value.password, Role = eRole.Student };
            var User = await _userService.AddUserAsync(user);
            var newStudent = _mapper.Map<Students>(value);
            newStudent.user = User;
            newStudent.id = User.Id;
            //var Castomer = await _studentService.GetByIdAsync(newStudent.id);
            //if (Castomer != null)
            //{
            //    return Conflict();
            //}
            await _studentService.AddStudentAsync(newStudent);
            return Ok(); ;


        }
       


        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] StudentPostModel s)
        {
            var student =await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            student.name = s.name;
            student.age = s.age;
            student.phone = s.phone;
            student.email = s.email;
            return Ok();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student1 =await _studentService.GetByIdAsync(id);
            if (student1 == null)
            {
                return NotFound();
            }
            await  _studentService.DeleteStudentAsync(id);
            return Ok();
        }
       
    }
}
