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
            // במקום לגשת ל-newL.teachers.id (שזורק שגיאה), נשתמש בשדה ה-ID הישיר
            // במידה והשדה בישות נקרא teacherId (באות קטנה או גדולה לפי ה-Entity שלך)
            var tId = newL.teacherId;

            // חיפוש המורה בבסיס הנתונים
            var existingTeacher = await _context.Teachers.FindAsync(tId);

            if (existingTeacher != null)
            {
                // שיוך השיעור למורה הקיימת
                newL.teachers = existingTeacher;
            }
            else
            {
                // אם לא נמצא מורה (למשל שלחת ID שלא קיים), כדאי לטפל בזה או לזרוק שגיאה
                throw new Exception($"Teacher with ID {tId} not found.");
            }

            _context.Lessons.Add(newL);
            await _context.SaveChangesAsync();
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
        public async Task<Lessons> GetByIdAsync(int id)
        {
            return await _context.Lessons.Include(l => l.students).FirstOrDefaultAsync(l => l.id == id);
        }

        public async Task UpdateAsync(Lessons lesson)
        {
            _context.Lessons.Update(lesson);
        }
    }
}
