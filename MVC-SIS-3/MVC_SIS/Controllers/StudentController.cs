using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {



        /// <summary>
        /// /Make controler specific validation for states and majors
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Add(studentVM.Student);

                return RedirectToAction("List");
            }
            else
            {
                var viewModel = new StudentVM();
                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());
                return View(viewModel);
            }

        }

        [HttpGet]
        public ActionResult Edit(int studentId)
        {
            var student = StudentRepository.Get(studentId);
            var model = new StudentVM();
            model.Student = student;
            model.SetCourseItems(CourseRepository.GetAll());
            model.SetMajorItems(MajorRepository.GetAll());
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(StudentVM studentVM, string command)
        {
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();
                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));
                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);
                StudentRepository.Edit(studentVM.Student);
                StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);
                return RedirectToAction("List");
            }
            else
            {
                var student = StudentRepository.Get(studentVM.Student.StudentId);
                var model = new StudentVM();
                model.Student = student;
                model.SetCourseItems(CourseRepository.GetAll());
                model.SetMajorItems(MajorRepository.GetAll());
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Delete(int studentId)
        {
            var student = StudentRepository.Get(studentId);
            StudentVM viewstudent = new StudentVM();
            viewstudent.Student = student;
            return View(viewstudent);
        }

        [HttpPost]
        public ActionResult Delete(StudentVM studentVM)
        {
          StudentRepository.Delete(studentVM.Student.StudentId);
            return RedirectToAction("List");
        }
    }
}