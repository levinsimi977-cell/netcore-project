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
    public class LessonService: ILessonService
    {
       
            private readonly ILessonsRepository _lessonRepository;
            public LessonService(ILessonsRepository lessonRepository)
            {
            _lessonRepository = lessonRepository;
            }

            public async Task<List<Lessons>> GetAllAsync()
            {
                return await _lessonRepository.GetAllAsync();
            }

            public async Task AddLessonsAsync(Lessons newL)
            {
                //var stu =await _lessonRepository.find(s => s.id == newL.id);
                //if (stu == null)
                //{
                 await _lessonRepository.AddLessonsAsync(newL);
                //}
            await  _lessonRepository.SaveAsync();


        }
        public async Task UpdateLessonsAsync(Lessons updateL, int id)
            {
                          await _lessonRepository.UpdateLessonsAsync(updateL, id);
                 await    _lessonRepository.SaveAsync();

        }
        public async Task DeleteLessonsAsync(int id)
            {
              

                  await _lessonRepository.DeleteLessonsAsync(id);
              
            _lessonRepository.SaveAsync();

        }


    }
}
