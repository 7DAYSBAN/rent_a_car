using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rent_A_Car.Data;
using System.Collections.Generic;

namespace Rent_A_Car.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CarController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult CarIndex()
        {
            IEnumerable<Car> objList = _db.Cars;
            return View(objList);
        }

        // GET  - DELETE
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Cars.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST - DELETE
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Cars.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Cars.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("CarIndex");
        }


        // GET  - EDIT
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Cars.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST - EDIT
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Car obj)
        {
            _db.Cars.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("CarIndex");
        }


        //GET - CREATE
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        //POST -  CREATE
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car obj)
        {
            _db.Cars.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("CarIndex");
        }
    }
}

