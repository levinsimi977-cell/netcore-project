using MusicSimi.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSimi.Core.DTOs
{
    public class LessonDTO
    {
        [Key]
        public int id { get; set; }

        public int teacherId { get; set; }
        public string name { get; set; }
        public int day { get; set; }
        public TimeOnly start { get; set; }
        public TimeOnly end { get; set; }
       

    }
}
