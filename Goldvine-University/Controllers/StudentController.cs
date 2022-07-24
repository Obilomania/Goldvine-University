using Goldvine_University.Data;
using Goldvine_University.Models;
using Goldvine_University.Repositiory.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Goldvine_University.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> studentList = _unitOfWork.Student.GetAll();
            return View(studentList);
        }

        //CREATE CONTROLLER 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Student.Add(student);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(student);
        }


        //EDIT CONTROLLER
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var studentFromDb = _unitOfWork.Student.GetFirstOrDefault(l => l.Id == id);
            if (studentFromDb == null)
            {
                return BadRequest();
            }
           return View(studentFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Student.Update(student);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(student);
        }


        //DELETE CONTROLLER
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var studentFromDb = _unitOfWork.Student.GetFirstOrDefault(l => l.Id == id);
            if (studentFromDb == null)
            {
                return BadRequest();
            }
            return View(studentFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUser(int? id)
        {
            var studentFromDb = _unitOfWork.Student.GetFirstOrDefault(l => l.Id == id);
            if (studentFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Student.Remove(studentFromDb);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            
        }

        //DETAIL CONTROLLER
        //public IActionResult Detail(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var post = _unitOfWork.Post.GetFirstOrDefault(p => p.Id == id);
        //    if (post == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(post);
        //}
    }
}
