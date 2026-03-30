using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace MusicSimi.Entities
{
    public class Lessons
    {

        [Key]
        public int id { get; set; }
        
        public int teacherId { get; set; }
        public string name { get; set; }
        public int day { get; set; }
        public TimeOnly start { get; set; }
        public TimeOnly end { get; set; }
        public List<Students> students { get; set; } = new();
        public Teachers teachers { get; set; }

    }
}
