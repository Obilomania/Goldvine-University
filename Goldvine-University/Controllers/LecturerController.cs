//using Goldvine_University.Data;
//using Goldvine_University.Models;
//using Goldvine_University.Repositiory.IRepository;
//using Microsoft.AspNetCore.Mvc;

//namespace Goldvine_University.Controllers
//{
//    public class LecturerController : Controller
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        public LecturerController(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }
//        public IActionResult Index()
//        {
//            IEnumerable<Lecturer> lecturerList = _unitOfWork.Lecturer.GetAll();
//            return View(lecturerList);
//        }

//        //CREATE CONTROLLER 
//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Create(Lecturer lecturer)
//        {
//            if (ModelState.IsValid)
//            {
//                _unitOfWork.Lecturer.Add(lecturer);
//                _unitOfWork.Save();
//                return RedirectToAction("Index");
//            }
//            return View(lecturer);
//        }


//        //EDIT CONTROLLER
//        public IActionResult Edit(int? id)
//        {
//            if (id == null || id == 0)
//            {
//                return NotFound();
//            }
//            var lecturerFromDb = _unitOfWork.Lecturer.GetFirstOrDefault(l => l.Id == id);
//            if (lecturerFromDb == null)
//            {
//                return BadRequest();
//            }
//            return View(lecturerFromDb);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(Lecturer lecturer)
//        {
//            if (ModelState.IsValid)
//            {
//                _unitOfWork.Lecturer.Update(lecturer);
//                _unitOfWork.Save();
//                return RedirectToAction("Index");
//            }
//            return View(lecturer);
//        }


//        //DELETE CONTROLLER
//        public IActionResult Delete(int? id)
//        {
//            if (id == null || id == 0)
//            {
//                return NotFound();
//            }
//            var lecturerFromDb = _unitOfWork.Lecturer.GetFirstOrDefault(l => l.Id == id);
//            if (lecturerFromDb == null)
//            {
//                return BadRequest();
//            }
//            return View(lecturerFromDb);
//        }

//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public IActionResult DeleteUser(int? id)
//        {
//            var lecturerFromDb = _unitOfWork.Lecturer.GetFirstOrDefault(l => l.Id == id);
//            if (lecturerFromDb == null)
//            {
//                return NotFound();
//            }
//            _unitOfWork.Lecturer.Remove(lecturerFromDb);
//            _unitOfWork.Save();
//            return RedirectToAction("Index");

//        }

//        //DETAIL CONTROLLER
//        //public IActionResult Detail(int? id)
//        //{
//        //    if (id == null || id == 0)
//        //    {
//        //        return NotFound();
//        //    }
//        //    var post = _unitOfWork.Post.GetFirstOrDefault(p => p.Id == id);
//        //    if (post == null)
//        //    {
//        //        return NotFound();
//        //    }
//        //    return View(post);
//        //}
//    }
//}
