using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rent_A_Car.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Rent_A_Car;

namespace Rent_A_Car.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                IEnumerable<BookedCar> objList = _db.BookedCars;
                ViewData["CarId"] = new SelectList(_db.Cars, "CarId", "Brand");
                ViewData["UserId"] = new SelectList(_db.Cars, "Users", "Users");
                return View(objList);
            }
            else
            {
                IEnumerable<BookedCar> objList = _db.BookedCars.Where(x => x.UserId == User.Identity.GetUserId());
                ViewData["CarId"] = new SelectList(_db.Cars, "CarId", "Brand");
                ViewData["UserId"] = new SelectList(_db.Cars, "Users", "Users");
                return View(objList);
            }
        }

        //  GET - CREATE
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_db.Cars, "CarId", "Model");
            ViewData["UserId"] = new SelectList(_db.Cars, "Users", "Users");
            return View();
        }
        // POST - CREATE
        [HttpPost]
        public IActionResult Create(BookedCar obj) 
        {
                var id = User.Identity.GetUserId();
                if (ModelState.IsValid && id != null) 
                {
                     obj.UserId = id; 

                    _db.BookedCars.Add(obj);
                    _db.SaveChanges();
                    return View("Index");
                }
            ViewData["CarId"] = new SelectList(_db.Cars, "CarId", "Model");
            ViewData["UserId"] = new SelectList(_db.Cars, "Users", "Users");
            return View();
        }

        // GET  - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.BookedCars.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_db.Cars, "CarId", "Model");
            ViewData["UserId"] = new SelectList(_db.Cars, "Users", "Users");
            return View(obj);
        }

        // POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookedCar obj)
        {
            ViewData["CarId"] = new SelectList(_db.Cars, "CarId", "Model");
            ViewData["UserId"] = new SelectList(_db.Cars, "Users", "Users");
            _db.BookedCars.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET - DELETE
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.BookedCars.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.BookedCars.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.BookedCars.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
