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
        {
            var student = studentList.Where(s => s.StudentId == id).FirstOrDefault();

            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: Students/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
