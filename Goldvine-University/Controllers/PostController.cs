
using Goldvine_University.Models;
using Goldvine_University.Repositiory.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Goldvine_University.Controllers
{
    public class PostController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PostController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Post> posts = _unitOfWork.Post.GetAll();
            return View(posts);
        }


        //Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Post.Add(post);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        //Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var post = _unitOfWork.Post.GetFirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {

                _unitOfWork.Post.Update(post);

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(post);
        }


        ////UPSERT
        //public IActionResult Upsert(int? id)
        //{
        //    Post post = new Post();
        //    if (id == null || id == 0)
        //    {
        //        return View(post);
        //    }
        //    else
        //    {

        //    }

        //    return View(post);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Upsert(Post post)
        //{
        //    if (ModelState.IsValid)
        //    {




        //        _unitOfWork.Post.Update(post);
        //        _unitOfWork.Save();
        //        return RedirectToAction("Index");
        //    }
        //    return View(post);
        //}



        //DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var post = _unitOfWork.Post.GetFirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var post = _unitOfWork.Post.GetFirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            _unitOfWork.Post.Remove(post);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }



        //DETAIL
        public IActionResult Detail(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var post = _unitOfWork.Post.GetFirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
    }
}
