using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IlligalParking.Data;
using IlligalParking.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IlligalParking.Controllers
{
    [Authorize(Roles = "Security")]
    public class SecurityController : Controller
    {
        private IRepositoryWrapper wrapper;
        public SecurityController(IRepositoryWrapper _wrapper)
        {
            wrapper = _wrapper;
        }
        public IActionResult Index()
        {
            return View(wrapper.Vehicle.FindAll());
        }
        public IActionResult Create()
        {
            ViewBag.Title = "Add User";
            return View(new Vehicle());
        }
        [HttpPost]
        public IActionResult Create(Vehicle user)
        {
            if (ModelState.IsValid)
            {
                wrapper.Vehicle.Create(user);
                wrapper.Vehicle.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
        }
        public IActionResult Edit(int ID)
        {
            var vehicle = wrapper.Vehicle.GetById(ID);
            ViewBag.Title = "Edit";
            return View("Create", vehicle);
        }
        [HttpPost]
        public IActionResult Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    wrapper.Vehicle.Update(vehicle);
                    wrapper.Vehicle.Save();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again and if the problem continues, " +
                        "contact your system administrator.");
                }
            }
            return View(vehicle);
        }
        public IActionResult Details(int ID)
        {
            var user = wrapper.Vehicle.GetById(ID);
            if (user == null)
                return NotFound();
            else
            {
                return View(user);
            }
        }
        public IActionResult Delete(int ID)
        {
            var user = wrapper.Vehicle.GetById(ID);
            if (user == null)
                return NotFound();
            else
            {
                return View(user);
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(Vehicle vehicle)
        {
            if (vehicle != null)
            {
                wrapper.Vehicle.Delete(vehicle);
                wrapper.Vehicle.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError
                    ("", "Unable to Delete");
                return View(vehicle);
            }

        }
    }

}
