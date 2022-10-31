using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IlligalParking.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IlligalParking.Controllers
{
    [Authorize]
    public class ParkingController : Controller
    {
        private IRepositoryWrapper wrapper;
        public ParkingController(IRepositoryWrapper wrapper)
        {
            this.wrapper = wrapper;
        }
        public IActionResult Index()
        {
            return View(wrapper.Parking.FindAll());
        }
    }
}
