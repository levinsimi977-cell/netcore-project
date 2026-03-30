//using Microsoft.AspNetCore.Mvc;
//using MusicSimi.Controllers;
//using MusicSimi.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace UnitTest
//{
//    public class TeacherTest
//    {
//        private FakeContext fakeContext = new FakeContext();

//        [Fact]
//        public void Get_TeacherList()
//        {
//            var controller = new TeachersController(fakeContext);
//            var result = controller.Get();
//            Assert.IsType<List<Teachers>>(result);
//        }
//        [Fact]
//        public void Post_AddTeacher()
//        {
//            Teachers teacher = new Teachers { id = 1, name = "John Doe", age = 30, phone = "1234567890", email = "john@example.com" };
//            var controller = new TeachersController(fakeContext);

//            var result = controller.Post(teacher);

//            var conflictResult = controller.Post(teacher);
//            Assert.IsType<ConflictResult>(conflictResult); 
//        }
//        [Fact]
//        public void Put_Teacher()
//        {
//            Teachers teacher = new Teachers { id = 1, name = "John Doe Updated", age = 31, phone = "0987654321", email = "john.updated@example.com" };
//            var controller = new TeachersController(fakeContext);

//            var notFoundResult = controller.Put(1, teacher);
//            Assert.IsType<OkResult>(notFoundResult);
//        }
//        [Fact]
//        public void Delete_Teacher()
//        {
//            var controller = new TeachersController(fakeContext);
//            var result = controller.Delete(1);
//            Assert.IsType<OkResult>(result);

//        }


//    }
//}
