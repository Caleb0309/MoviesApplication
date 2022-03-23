using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesApplication.Models;

namespace MoviesApplication.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public List<UserModel> PutValue()
        {
            var users = new List<UserModel>
            {
                new UserModel{Id=1,Username="Michael",Password="123"},
                new UserModel{Id=2,Username="Warrick",Password="1234"},
                new UserModel{Id=3,Username="Caleb",Password="12345"},
            };

            return users;
        }

        [HttpPost]
        public IActionResult Verify(UserModel usr)
        {
            var u = PutValue();

            var ue = u.Where(u => u.Username.Equals(usr.Username));

            var up = ue.Where(p => p.Password.Equals(usr.Password));

            if (up.Count() == 1)
            {
                ViewBag.message = "Index";
                return this.RedirectToAction("Index","Movies");
            }
            else
            {
                ViewBag.message = "Login Failed";
                return View("Login");
            }

        }
    }
}
