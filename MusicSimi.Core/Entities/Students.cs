using MusicSimi.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace MusicSimi.Entities

{

    public class Students

    {
        [Key]
        public int id { get; set; }

        public string name{ get; set; }

        public int age { get; set; }

        public string phone { get; set; }

        public string email { get; set; }
        public List<Lessons> lessons { get; set; } = new();
        public User user { get; set; }

    }
}