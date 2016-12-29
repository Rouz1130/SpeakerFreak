using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpeakerFreak.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SpeakerFreak.Controllers
{
    public class MusicController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public MusicController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Musicians.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisMusic = _db.Musicians.FirstOrDefault(Musicians => Musicians.Id == id);
            return View(thisMusic);
        }
    }
}
