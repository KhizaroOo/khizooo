using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using revamp_khizooo.Models;

namespace revamp_khizooo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        #region Layout Settings

        ViewBag.TopNavbar = new TopNavbar() { ModalTile = "Landing Page", CategoryTypeTitle = "Myself", PageTitle = "Informations about me" };

        #endregion

        return View();
    }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

