using MusicSimi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSimi.Core.Repositories
{
    public interface ITeacherRepository
    {
        public Task<List<Teachers>> GetAllAsync();

        public Task<Teachers> GetByIdAsync(int id);
        public Task AddTeacherAsync(Teachers teacher);
        public Task UpdateTeacherAsync(Teachers teacher, int id);
        public Task DeleteTeacherAsync(int id);
        public Task SaveAsync();



    }
}
