using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rent_A_Car.Data;

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
            IEnumerable<BookedCar> objList = _db.BookedCars;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit()
        {

            return View();
        }
        public IActionResult Delete()
        {

            return View();
        }
    }
}
