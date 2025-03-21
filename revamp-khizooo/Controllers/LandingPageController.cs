using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using revamp_khizooo.Models;

namespace revamp_khizooo.Controllers
{
    public class LandingPageController : Controller
    {
        //VIEW
        public IActionResult Index()
        {

            #region Layout Settings

            ViewBag.TopNavbar = new TopNavbar() { ModalTile = "Landing Page", CategoryTypeTitle = "Myself", PageTitle = "Informations about me" };

            #endregion


            return View();
        }
    }
}

