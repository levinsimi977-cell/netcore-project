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
    public class StudentService : IStudentServics
    {


        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<Students>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }
        public async Task<Students> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student != null)
            {
                return student;
            }
            return null;

        }

        public async Task AddStudentAsync(Students s)
        {
            //var newL = await _studentRepository.GetByIdAsync(s.id);
            //if (newL == null)
            //{
            await _studentRepository.AddStudentAsync(s);
            //}
            await _studentRepository.SaveAsync();


        }
        public async Task UpdateStudentAsync(Students s, int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student != null)
            {
                student.name = s.name;
                student.age = s.age;
                student.phone = s.phone;
                student.email = s.email;
            }
            await _studentRepository.SaveAsync();

        }
        public async Task DeleteStudentAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student != null)
            {

                await _studentRepository.DeleteStudentAsync(id);
            }
            await _studentRepository.SaveAsync();

        }




    }

}
