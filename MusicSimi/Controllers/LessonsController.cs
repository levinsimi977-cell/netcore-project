using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicSimi.Core.DTOs;
using MusicSimi.Core.Repositories;
using MusicSimi.Core.Serivecs;
using MusicSimi.Entities;
using MusicSimi.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicSimi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {


        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;


        public LessonsController(ILessonService lessonservice, IMapper mapper)
        {
            _lessonService = lessonservice;
            _mapper = mapper;
        }
        // GET: api/<LessonsController>
        [HttpGet]
        public async Task<IEnumerable<LessonDTO>> Get()
        {
            var lessons = await _lessonService.GetAllAsync();
            var ldto = new List<LessonDTO>();
            ldto = _mapper.Map<List<LessonDTO>>(lessons);
            return ldto;

        }
        // POST api/<LessonsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LessonPostModel newL)
        {
            var lesson = _mapper.Map<Lessons>(newL);

            lesson.teacherId = newL.teacherId;

            await _lessonService.AddLessonsAsync(lesson);
            return Ok(newL);
        }
        // PUT api/<LessonsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LessonPostModel updateL)
        {
            var lessons = await _lessonService.GetAllAsync();
            var lessonEntity = lessons.FirstOrDefault(l => l.id == id);

            if (lessonEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(updateL, lessonEntity);

            lessonEntity.teacherId = updateL.teacherId;

            await _lessonService.UpdateLessonsAsync(lessonEntity, id);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var lesson = _lessonRepository.FirstAsync(l => l.id == id);
            //if (lesson == null)
            //{
            //    return NotFound();
            //}
            await _lessonService.DeleteLessonsAsync(id);
            return Ok();
        }
    }
}
