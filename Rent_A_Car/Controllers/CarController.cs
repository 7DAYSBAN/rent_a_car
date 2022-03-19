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

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult BrandsIndex()
        {
            IEnumerable<Rent_A_Car.CarBrand> objList = _db.CarBrands;
            return View(objList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Car ojc)
         {
            _db.Cars.Add(ojc);
            _db.SaveChanges();
            return RedirectToAction("CarIndex");
         }
    }
}
