using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IlligalParking.Data;
using IlligalParking.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IlligalParking.Controllers
{
    [Authorize]
    public class ComplainController : Controller
    {
        private IRepositoryWrapper wrapper;
        public ComplainController(IRepositoryWrapper _wrapper)
        {
            wrapper = _wrapper;
        }

        public IActionResult Index()
        {
            return View(wrapper.Complain.FindAll());
        }
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Create(Complain complain)
        {
            if (ModelState.IsValid)
            {
                wrapper.Complain.Create(complain);
                wrapper.Complain.Save();

                return RedirectToAction("Completed");
            }
            return View(complain);
        }
        [AllowAnonymous]
        public IActionResult Completed()
        {
            return View();
        }

        public IActionResult Delete(int ComplainID)
        {
            var complain = wrapper.Complain.GetById(ComplainID);
            return View(complain);
        }
        [HttpPost]
        public IActionResult Delete(Complain complain)
        {
            if (ModelState.IsValid)
            {
                var rep = wrapper.Complain.FindByCondition(s => s.CarRegistration ==
                complain.CarRegistration).FirstOrDefault();
                wrapper.Complain.Delete(rep);
                wrapper.Complain.Save();
                TempData["Message"] = $"Report for Vehicle: {complain.CarRegistration} has been attended.";
                return RedirectToAction("Index");
            }
            TempData["Message"] = "An Error occured in the process of your Request.";
            return View(complain);
        }
        public IActionResult Details(int ComplainID)
        {
            var complain = wrapper.Complain.GetById(ComplainID);
            return View(complain);
        }
    }
}
