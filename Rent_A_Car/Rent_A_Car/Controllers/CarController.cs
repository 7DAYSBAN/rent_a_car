﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rent_A_Car.Data;
using System.Collections.Generic;
using System.Linq;

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


        //GET - CREATE
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        //POST -  CREATE
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car obj)
        {
            _db.Cars.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("CarIndex");
        }

        // GET  - EDIT
        [HttpGet]
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
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Car obj)
        {
            var car = _db.Cars.FirstOrDefault(x => x.CarId == obj.CarId);
            var booking = _db.BookedCars.Find(obj.CarId);

            if (booking.CarId == 0)
            {
                return RedirectToAction("CarIndex");
            }
            else
            {
                car = new Car()
                {
                    CarYear = obj.CarYear,
                    Description = obj.Description,
                    PricePerDay = obj.PricePerDay,
                    Brand = obj.Brand,
                    Model = obj.Model
                };

                booking.Car = car;

                _db.SaveChanges();
                return RedirectToAction("CarIndex");
            }
        }

        // GET  - DELETE
        [HttpGet]
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
    }
}

