using MusicSimi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSimi.Core.Repositories
{
    public interface ILessonsRepository
    {
        public Task<List<Lessons>> GetAllAsync();

        public Task AddLessonsAsync(Lessons lessons);
        public Task UpdateLessonsAsync(Lessons lessons,int id);
        public Task DeleteLessonsAsync(int id);
        public Task SaveAsync();

    }
}
