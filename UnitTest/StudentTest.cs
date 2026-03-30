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
//    public class StudentTest
//    {
//        private FakeContext fakeContext = new FakeContext();

//        [Fact]
//        public void Get_StudentList()
//        {
//            var controller = new StudentsController(fakeContext);
//            var result = controller.Get();
//            Assert.IsType<List<Students>>(result);
//        }

//        [Fact]
//        public void Post_AddStudent()
//        {
//            Students student1 = new Students { id = 1, name = "Jane Doe", age = 25, phone = "1234567890", email = "jane@example.com" };
//            var controller = new StudentsController(fakeContext);

           
//            var conflictResult = controller.Post(student1);
//            Assert.IsType<ConflictResult>(conflictResult);
//        }

//        [Fact]
//        public void Put_Student()
//        {
//            Students student = new Students { id = 1, name = "Jane Doe Updated", age = 26, phone = "0987654321", email = "jane.updated@example.com" };
//            var controller = new StudentsController(fakeContext);
           
//            var result = controller.Put(1, student);
//            Assert.IsType<OkResult>(result);
//        }

//        [Fact]
//        public void Delete_Student()
//        {
//            var controller = new StudentsController(fakeContext);

           
//            var result = controller.Delete(1);
//            Assert.IsType<OkResult>(result);

         
//        }
//    }
//}
