using MusicSimi.Entities;

namespace MusicSimi.Models
{
    public class LessonPostModel
    {

        public int id { get; set; }       // ה-ID של המורה (למשל 8)
        public int userId { get; set; }   // ה-ID של המשתמש (למשל 22)
        public string name { get; set; }
        public int day { get; set; }
        public TimeSpan start { get; set; }
        public TimeSpan end { get; set; }
        public int teacherId { get; set; } 
    }
}
