using Mvc_Student_Memory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Student_Memory.Controllers
{
    public class StudentsController : Controller
    {
        static List<Student> studentList = new List<Student>
        {
            new Student
            {
                StudentId =1,
                Name = "Vipul",
                DateOfBirth = new DateTime(1997,11,25),
                Gender = Gender.male
            },
             new Student
            {
                StudentId =2,
                Name = "Tushar",
                DateOfBirth = new DateTime(1998,03,29),
                Gender = Gender.male
            },
              new Student
            {
                StudentId =3,
                Name = "Parth",
                DateOfBirth = new DateTime(1998,08,26),
                Gender = Gender.male
            },
                  new Student
            {
                StudentId =4,
                Name = "Jigyasa",
                DateOfBirth = new DateTime(1998,01,01),
                Gender = Gender.female
            }
        };
        // GET: Students
        public ActionResult Index()
        { 
            return View(studentList);
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        static int counter = 3;
        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                // server-side validation
                if (ModelState.IsValid)
                {
                    //insert 
                    counter++;
                    student.StudentId = counter;
                    studentList.Add(student);
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View(); // to be on th same view
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {   //use any of the technique
            //var student0 = studentList.Where(s => s.StudentId == id).FirstOrDefault();
            //var student1 = studentList.FirstOrDefault();
            //var studendt2 = (from student in studentList where student.StudentId == id select student).FirstOrDefault();
            var student3 = studentList.Find(s => s.StudentId == id);
            {
                if (student3 == null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(student3);
            
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(id == student.StudentId)
                    {
                        var current = studentList.Find(s => s.StudentId == id);
                        current.Name = student.Name;
                        current.DateOfBirth = student.DateOfBirth;
                        current.Gender = student.Gender;
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            var student = studentList.Find(s => s.StudentId == id);
            if(student == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Student student1)
        {
            try
            {
                // TODO: Add delete logic here
                var student = studentList.Find(s => s.StudentId == id);
                if(student == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                if (studentList.Remove(student))
                {
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult StudentbyGenre()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StudentbyGenre(Gender gender)
        {
            var students = studentList.FindAll(s => s.Gender == gender);
            return View(students);
        }
    }
}
