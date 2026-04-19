using AutoMapper;
using MusicSimi.Core.DTOs;
using MusicSimi.Entities;
using MusicSimi.Models;

namespace MusicSimi.Core // וודאי שה-Namespace תואם למה שמוגדר ב-Program.cs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // --- 1. DTOs (עבור שליפת נתונים - GET) ---
            CreateMap<Students, StudentDTO>().ReverseMap();
            CreateMap<Lessons, LessonDTO>().ReverseMap();
            CreateMap<Teachers, TeacherDTO>().ReverseMap();

            // --- 2. PostModels (עבור יצירה ועדכון - POST/PUT) ---

            // מיפוי סטודנטים: מחלץ את ה-ID מהיוזר לתוך ה-Model ומגן מפני null
            CreateMap<Students, StudentPostModel>()
                .ForMember(dest => dest.userId, opt => opt.MapFrom(src => src.user != null ? src.user.Id : 0))
                .ReverseMap()
                .ForMember(dest => dest.user, opt => opt.Ignore());

            // מיפוי מורים: מחלץ את ה-ID מהיוזר לתוך ה-Model ומגן מפני null
            CreateMap<Teachers, TeacherPostModel>()
                .ForMember(dest => dest.userId, opt => opt.MapFrom(src => src.user != null ? src.user.Id : 0))
                .ReverseMap()
                .ForMember(dest => dest.user, opt => opt.Ignore());

            // מיפוי שיעורים
            CreateMap<Lessons, LessonPostModel>().ReverseMap();

            // --- 3. המרות טיפוסים מיוחדים (זמן) ---
            // המרה בין TimeSpan (שנמצא ב-Models) ל-TimeOnly (שנמצא ב-Entities)
            CreateMap<TimeSpan, TimeOnly>().ConvertUsing(ts => TimeOnly.FromTimeSpan(ts));
            CreateMap<TimeOnly, TimeSpan>().ConvertUsing(to => to.ToTimeSpan());
        }
    }
}