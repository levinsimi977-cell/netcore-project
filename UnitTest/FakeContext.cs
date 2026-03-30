//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MusicSimi;
//using MusicSimi.Entities;

//namespace UnitTest
//{
//    public class FakeContext : IDataContext
//    {
//        public List<Students> Students { get; set; }
//        public List<Teachers> Teachers { get; set; }
//        public List<Slots> Slots { get; set; }
//        public List<Lessons> Lessons { get; set; }
//        public FakeContext() {
//        List<Slots> slots = new List<Slots> { new Slots { id = 1, lessonid = 1, studentid = 1 } };
//        List<Lessons> lessons = new List<Lessons> { new Lessons { id = 1, teacherId = 1, name = "organ", day = 1, start = new TimeOnly(4, 30), end = new TimeOnly(5, 30) } };
//        List<Teachers> teachers = new List<Teachers> { new Teachers { id = 1, name = "hgf", age = 12, phone = "76976976", email = "fjh@dt" } };
//         List<Students> students = new List<Students> { new Students { id = 1, name = "hgf", age = 12, phone = "76976976", email = "fjh@dt" } };
//    }
//}
//}
