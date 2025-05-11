using Microsoft.AspNetCore.Mvc;
using StudentMangwentUsingJenkins.Models;

namespace StudentMangwentUsingJenkins.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>{
            new Student{ Id=1,Name="Anudeep", Address="Mancherial"},
            new Student{ Id=2,Name="Abhilsah", Address="Microsoft"}
            };
        public IActionResult Index()
        {
            return View(students);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public  IActionResult Create(Student student)
        {
            student.Id = students.Count + 1;
            students.Add(student);
            return RedirectToAction("Index");
        }

        public IActionResult Delete() {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id) { 
           var student = students.FirstOrDefault(x=>x.Id==id);
            if (student != null)
            {
                students.Remove(student);
            }
           
            return RedirectToAction("Index");
        }

    }
}
