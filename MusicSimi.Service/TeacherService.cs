using MusicSimi.Core.Repositories;
using MusicSimi.Core.Serivecs;
using MusicSimi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSimi.Service
{
    public class TeacherService:ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<List<Teachers>> GetAllAsync()
        {
            return await _teacherRepository.GetAllAsync();
        }
        public async Task<Teachers> GetByIdAsync(int id)
        {
            var teacher =await _teacherRepository.GetByIdAsync(id);
            if (teacher != null)
            {
                return teacher;
            }
            return null;

        }

        public async Task AddTeacherAsync(Teachers s)
        {
            var newL =await _teacherRepository.GetByIdAsync(s.id);
            if (newL == null)
            {
              await _teacherRepository.AddTeacherAsync(s);
            }
            await _teacherRepository.SaveAsync();


        }
        public async Task UpdateTeacherAsync(Teachers t, int id)
        {
            var teacher =await _teacherRepository.GetByIdAsync(id);
            if (teacher != null)
            {
                teacher.name = t.name;
                teacher.age = t.age;
                teacher.phone = t.phone;
                teacher.email = t.email;
            }
            await _teacherRepository.SaveAsync();

        }
        public async Task DeleteTeacherAsync(int id)
        {
            var teacher =await _teacherRepository.GetByIdAsync(id);
            if (teacher != null)
            {

               await _teacherRepository.DeleteTeacherAsync(id);
            }
            await _teacherRepository.SaveAsync();

        }



    }
}
