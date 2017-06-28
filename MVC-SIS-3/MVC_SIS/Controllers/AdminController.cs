using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {

        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new Major());
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            if(ModelState.IsValid)
            {
                MajorRepository.Add(major.MajorName);
                return RedirectToAction("Majors");
            }
            else
            {
                return View(new Major());
            }

        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {
           if(ModelState.IsValid)
            {
                MajorRepository.Edit(major);
                return RedirectToAction("Majors");
            }
            else
            {
                var majo = MajorRepository.Get(major.MajorId);
                return View(majo);
            }
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult ListStates()
        {
            var model = StateRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddState()
        {
            return View(new State());
        }

        [HttpPost]
        public ActionResult AddState(State state)
        {
            if (ModelState.IsValid)
            {
                StateRepository.Add(state);
                return RedirectToAction("ListStates");
            }
            else
            {
                return View(new State());
            }
        }

        [HttpGet]
        public ActionResult EditState(string stateAbreviation)
        {
            var model = StateRepository.Get(stateAbreviation);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditState(State state)
        {
            if(ModelState.IsValid)
            {
                StateRepository.Edit(state);
                return RedirectToAction("ListStates");
            }
            else
            {
                var model = StateRepository.Get(state.StateAbbreviation);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteState(string stateAbreviation)
        {
            var state = StateRepository.Get(stateAbreviation);
            return View(state);
        }

        [HttpPost]
        public ActionResult DeleteState(State state)
        {
            StateRepository.Delete(state.StateAbbreviation);
            return RedirectToAction("ListStates");
        }

        [HttpGet]
        public ActionResult Courses()
        {
            var model = CourseRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            return View(new Course());
        }

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                CourseRepository.Add(course.CourseName);
                return RedirectToAction("Courses");
            }
            else
            {
                return View(new Course());
            }
        }

        [HttpGet]
        public ActionResult EditCourse(int courseId)
        {
            var course = CourseRepository.Get(courseId);
            return View(course);
        }

        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                CourseRepository.Edit(course);
                return RedirectToAction("Courses");
            }
            else
            {
                var cours = CourseRepository.Get(course.CourseId);
                return View(cours);
            }
        }

        [HttpGet]
        public ActionResult DeleteCourse(int courseId)
        {
          var course =  CourseRepository.Get(courseId);
            return View(course);
        }

        [HttpPost]
        public ActionResult DeleteCourse(Course course)
        {
            CourseRepository.Delete(course.CourseId);
            return RedirectToAction("Courses");
        }
    }
}