using Microsoft.AspNetCore.Mvc;
using Rent_A_Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rent_a_car.Controllers
{
    public class CarController : Controller
    {
        private readonly RentACarContext _db;
        public CarController (RentACarContext db)
        {
            _db = db;
        }
        public IActionResult CarIndex()
        {
            IEnumerable<Car> objList = _db.Cars;
            return View(objList);
        }

        // GET  - DELETE
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Cars.Find(id);
            if(obj ==  null)
            {
                return NotFound();
            }
            _db.Cars.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("CarIndex");
        }


        // GET  - EDIT
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Cars.Find(id);
            if(obj == null)
            {
                return NotFound(); 
            }    
            return View(obj);
        }

        // POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (Car obj)
        {
            _db.Cars.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("CarIndex");
        }


        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST -  CREATE
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
