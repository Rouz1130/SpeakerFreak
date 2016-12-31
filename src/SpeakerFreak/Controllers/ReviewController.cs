using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpeakerFreak.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SpeakerFreak.Controllers
{
    public class ReviewController : Controller
    {
        // GET: /<controller>/
        private ApplicationDbContext db = new ApplicationDbContext();
        private ReviewModel theView = new ReviewModel();


        public IActionResult Index()
        {
            //add arrange blog by newest first 
            var thisReview = db.Reviews.OrderByDescending(model => model.ReviewId);
            //return list of blogs 
            return View(thisReview.ToList());
        }
        public IActionResult Details(int id)
        {
            var thisReview = db.Reviews.FirstOrDefault(model => model.ReviewId == id);
            return View(thisReview);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}