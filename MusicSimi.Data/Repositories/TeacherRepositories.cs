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
    public class TeacherRepositories : ITeacherRepository
    {
        private readonly DataConext _context;

        public TeacherRepositories(DataConext context)
        {
            _context = context;
        }
        public async Task<List<Teachers>> GetAllAsync()
        {
                    return await _context.Teachers.ToListAsync();

        }
        public async Task<Teachers> GetByIdAsync(int id)
        {
            return await _context.Teachers.FirstOrDefaultAsync(t => t.id == id);
        }

       
    public async Task AddTeacherAsync(Teachers t)
    {
          var existingTeacher =await _context.Teachers.FirstOrDefaultAsync(t1 => t1.id == t.id);
            if (existingTeacher == null)
            {
                _context.Teachers.Add(t);

             }
       
    }
        public async Task UpdateTeacherAsync(Teachers t,int id)
{
        var teacher =await _context.Teachers.FirstOrDefaultAsync(l => l.id == id);
        if (teacher != null)
        {
            teacher.name = t.name;
            teacher.age = t.age;
            teacher.phone = t.phone;
            teacher.email = t.email;
        }
        
    }
        public async Task DeleteTeacherAsync(int id)
    {
        var teacher =await _context.Teachers.FirstOrDefaultAsync(l => l.id == id);
        if (teacher != null)
        {
            _context.Teachers.Remove(teacher);
        }
    }
       
        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

    }
}
