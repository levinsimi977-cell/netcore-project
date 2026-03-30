using MusicSimi.Entities;

namespace MusicSimi.Models
{
    public class LessonPostModel
    {
        public string name { get; set; }
        public int day { get; set; }
        public TimeOnly start { get; set; }
        public TimeOnly end { get; set; }
        public TeacherPostModel teachers { get; set; }

    }
}
