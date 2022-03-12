using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClothesStore.Models;

namespace ClothesStore.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ApplicationUser _auc;

        public RegistrationController(ApplicationUser auc)
        {
            _auc = auc;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User uc)
        {
            _auc.Add(uc);
            _auc.SaveChanges();
            ViewBag.message = "The user " + uc.Username + " is saved successfully";
            return View();
        }
        public IActionResult LogIN()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogIN(User uc)
        {
            var log = _auc.UserRegistration.SingleOrDefault(t => t.Email == uc.Email && t.Pwd == uc.Pwd);
            if (log != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Email or Password is wrong");
            }
            return View();
        }
    }
}
