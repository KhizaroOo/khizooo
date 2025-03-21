using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using revamp_khizooo.Models;

namespace revamp_khizooo.Controllers
{
    public class PortfolioController : Controller
    {

        // VIEW
        public IActionResult Index()
        {

            #region Layout Settings

            ViewBag.TopNavbar = new TopNavbar() { ModalTile = "My Portfolio", CategoryTypeTitle = "Myself", PageTitle = "Informations about me" };

            #endregion

            return View();
        }
    }
}

