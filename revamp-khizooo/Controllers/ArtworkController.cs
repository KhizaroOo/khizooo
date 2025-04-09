using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using revamp_khizooo.Models;

namespace revamp_khizooo.Controllers;

public class ArtworkController : Controller
{
    private readonly ILogger<ArtworkController> _logger;

    public ArtworkController(ILogger<ArtworkController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        #region Layout Settings

        ViewBag.TopNavbar = new TopNavbar() { ModalTile = "Landing Page", CategoryTypeTitle = "Porrtfolio", PageTitle = "Informations about me" };

        #endregion

        return View();
    }

    public IActionResult Detail()
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

