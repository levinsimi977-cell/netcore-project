using MusicSimi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSimi.Core.Serivecs
{
    public interface IStudentServics
    {
        public Task<List<Students>> GetAllAsync();

        public Task<Students> GetByIdAsync(int id);
        public Task AddStudentAsync(Students student);
        public Task UpdateStudentAsync(Students student, int id);
        public Task DeleteStudentAsync(int id);

    }
}
