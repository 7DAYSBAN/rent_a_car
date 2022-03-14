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

        public IActionResult AddCar()
        {
            return View();
        }
    }
}
