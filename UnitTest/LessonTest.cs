//using Microsoft.AspNetCore.Mvc;
//using MusicSimi.Controllers;
//using MusicSimi.Entities;
//using System.Xml.Linq;


//namespace UnitTest
//{
//    public class LessonTest
//    {
//        private FakeContext fakeContext = new FakeContext();

//        [Fact]
//        public void Get_LessonList()
//        {
//            var controller = new LessonsController(fakeContext);
//            var result = controller.Get();
//            Assert.IsType<List<Lessons>>(result);
//        }
//        [Fact]
//        public void Post_addlesson()
//        {
//            Lessons lessons1 = new Lessons { id = 1, teacherId = 1, name = "organ", day = 1, start = new TimeOnly(4, 30), end = new TimeOnly(5, 30) };
//            var controller = new LessonsController(fakeContext);

//            var result = controller.Post(lessons1);

//            controller.Post(lessons1);
//            Assert.IsType<ConflictResult>(result); // Expecting a 409 Conflict
//        }
//        [Fact]
//        public void Put_Leasson()
//        {
//            {
//                Lessons lessons = new Lessons{ id = 1, teacherId = 1, name = "organ", day = 1, start = new TimeOnly(4, 30), end = new TimeOnly(5, 30)};
//                var controller = new LessonsController(fakeContext);
//                 var result = controller.Put(1, lessons);

//                // Assert
//                Assert.IsType<OkResult>(result);
//            }

           
//        }
//        [Fact]
//        public void Delete_Lesson()
//        {
//                var controller = new LessonsController(fakeContext);

//                var result = controller.Delete(1);

//            Assert.IsType<OkResult>(result);
//        }

//    }
//};
         
