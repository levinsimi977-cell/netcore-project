using MusicSimi.Models;
using AutoMapper;
using MusicSimi.Core.DTOs;
using MusicSimi.Entities;
namespace MusicSimi
{
    public class MappingProfileModel:Profile
    {
        public MappingProfileModel()
        {
            CreateMap<Students, StudentPostModel>().ReverseMap();
            CreateMap<Lessons, LessonPostModel>().ReverseMap();
            CreateMap<Teachers,TeacherPostModel>().ReverseMap();
        }
    }
}
