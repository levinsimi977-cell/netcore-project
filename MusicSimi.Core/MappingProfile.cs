using AutoMapper;
using MusicSimi.Core.DTOs;
using MusicSimi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSimi.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Students, StudentDTO>().ReverseMap();
            CreateMap<Lessons,LessonDTO>().ReverseMap();
            CreateMap<Teachers, TeacherDTO>().ReverseMap();

        }
    }
}
