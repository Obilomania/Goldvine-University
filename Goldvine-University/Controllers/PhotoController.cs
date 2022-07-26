using Goldvine_University.Data;
using Goldvine_University.Models;
using Goldvine_University.Repositiory.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Goldvine_University.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public PhotoController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Models.Photo> studentList = _unitOfWork.Photo.GetAll();
            return View(studentList);
        }

        //CREATE CONTROLLER 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Photo photo, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\student");
                    var extension = Path.GetExtension(file.FileName);

                    if (photo.Image != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, photo.Image.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    photo.Image = @"\images\student\" + fileName + extension;
                }
                if (photo.Id == 0)
                {
                    _unitOfWork.Photo.Add(photo);

                }
                _unitOfWork.Save();
                return RedirectToAction("Register", "Account");
            }
            return View(photo);
        }


        ////EDIT CONTROLLER
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var studentFromDb = _unitOfWork.Photo.GetFirstOrDefault(l => l.Id == id);
        //    if (studentFromDb == null)
        //    {
        //        return BadRequest();
        //    }
        //    return View(studentFromDb);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(Models.Photo photo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Photo.Update(photo);
        //        _unitOfWork.Save();
        //        return RedirectToAction("Index");
        //    }
        //    return View(photo);
        //}


        ////DELETE CONTROLLER
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var photoFromDb = _unitOfWork.Photo.GetFirstOrDefault(l => l.Id == id);
        //    if (photoFromDb == null)
        //    {
        //        return BadRequest();
        //    }
        //    return View(photoFromDb);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteUser(int? id)
        //{
        //    var photoFromDb = _unitOfWork.Photo.GetFirstOrDefault(l => l.Id == id);
        //    if (photoFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.Photo.Remove(photoFromDb);
        //    _unitOfWork.Save();
        //    return RedirectToAction("Index");

        //}

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
