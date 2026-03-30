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
    public class StudentRepositories : IStudentRepository
    {
        private readonly DataConext _context;

        public StudentRepositories(DataConext context)
        {
            _context = context;
        }
        public async Task<List<Students>> GetAllAsync()
        {

            return await _context.Students.ToListAsync();
        }

        public async Task<Students> GetByIdAsync(int id)
        {
            return await _context.Students.FirstAsync(s => s.id == id);

        }
        public async Task AddStudentAsync(Students s)
        {
            //var st = await _context.Students.FirstAsync(s => s.id == s.id);
            //if (st != null)
            //{
                _context.Students.Add(s);
            //}
            //409 - קונפליקט בבקשה
        }
        public async Task UpdateStudentAsync(Students s, int id)
        {
            var student = await _context.Students.FirstAsync(l => l.id == id);
            if (student != null)
            {
                student.name = s.name;
                student.age = s.age;
                student.phone = s.phone;
                student.email = s.email;
            }

        }
        public async Task DeleteStudentAsync(int id)
        {
            var student1 = await _context.Students.FirstAsync(l => l.id == id);
            if (student1 != null)
            {
                _context.Students.Remove(student1);

            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
