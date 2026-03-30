using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSimi.Core.Entities
{
    public class User
    {

        [Key]
        
            public int Id { get; set; }
            public string name { get; set; }
            public string password { get; set; }
            public eRole Role { get; set; }
    }

        public enum eRole
        {
            Student,Teacher
        }


    
}
