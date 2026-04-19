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
        private readonly IStudentRepository _studentRepository; 
        public LessonService(ILessonsRepository lessonRepository, IStudentRepository studentRepository)
            {
            _studentRepository = studentRepository; // 3. אתחול המשתנה
            _lessonRepository = lessonRepository;
            }

            public async Task<List<Lessons>> GetAllAsync()
            {
                return await _lessonRepository.GetAllAsync();
            }
        public async Task RegisterStudentToLessonAsync(int lessonId, int studentId)
        {
            var lesson = await _lessonRepository.GetByIdAsync(lessonId);
            var student = await _studentRepository.GetByIdAsync(studentId);

            if (lesson != null && student != null)
            {
                if (lesson.students == null) lesson.students = new List<Students>();

                if (!lesson.students.Any(s => s.id == studentId))
                {
                    lesson.students.Add(student);
                    // אין צורך לקרוא ל-UpdateLessonsAsync! 
                    // ה-EF כבר יודע שה-lesson השתנה כי הוא עוקב אחריו.
                    await _lessonRepository.SaveAsync();
                }
            }
            else { throw new Exception("שיעור או תלמיד לא נמצאו"); }
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
