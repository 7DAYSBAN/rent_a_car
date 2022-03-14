using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rent_a_car.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginIndex()
        {
            return View();
        }

        public IActionResult RegisterIndex()
        {
            return View();
        }
    }
}
