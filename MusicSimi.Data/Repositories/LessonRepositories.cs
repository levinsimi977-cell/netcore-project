using Microsoft.EntityFrameworkCore;
using MusicSimi.Core.Repositories;
using MusicSimi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSimi.Data.Repositories
{
    public class LessonRepositories:ILessonsRepository
    {
        private readonly DataConext _context;
        public LessonRepositories(DataConext context)
        {
            _context = context;
        }

        public async Task<List<Lessons>> GetAllAsync()
        {

            return await _context.Lessons.ToListAsync();
        }

        public async Task AddLessonsAsync(Lessons newL)
        {
            var stu =await _context.Lessons.FirstAsync(s => s.id == newL.id);
            if (stu == null)
            {
               
                _context.Lessons.Add(newL);
            }

        }
        public async Task UpdateLessonsAsync(Lessons updateL, int id)
        {
            var lesson =await _context.Lessons.FirstAsync(l => l.id == id);
            if (lesson != null)
            {
                lesson.teacherId = updateL.teacherId;
                lesson.name = updateL.name;
                lesson.day = updateL.day;
                lesson.start = updateL.start;
                lesson.end = updateL.end;
            }
        }
        public async Task DeleteLessonsAsync(int id)
        {
            var lesson =await _context.Lessons.FirstAsync(l => l.id == id);
            if (lesson != null)
            {

                _context.Lessons.Remove(lesson);
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
