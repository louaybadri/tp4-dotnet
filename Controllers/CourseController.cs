
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP4.Data;
using TP4.Models;

namespace TP4.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {


            UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
            StudentRepository studentRepository = new StudentRepository(universityContext);
            foreach (String s in studentRepository.GetCourses())
                Debug.WriteLine(s);

            return View(studentRepository.GetCourses());
        }

        public IActionResult GetCourse(string id)
        {
            UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
            StudentRepository studentRepository = new StudentRepository(universityContext);
            IEnumerable<Student> res = (IEnumerable<Student>)studentRepository.Find(v => v.course.ToLower() == id.ToLower());
            //foreach (Student s in res)
            //{
            //    Debug.WriteLine(s.id);
            //} 

            if (res.Count() != 0) ViewBag.Id = res.First().course;
            return View(res);
        }
    }
}
