using MusicSimi.Entities;

namespace MusicSimi.Models
{
    public class LessonPostModel
    {
        public string name { get; set; }
        public int day { get; set; }
        public TimeSpan start { get; set; }
        public TimeSpan end { get; set; }
        public int teacherId { get; set; } 
    }
}
