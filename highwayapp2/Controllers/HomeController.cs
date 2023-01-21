using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using highwayapp2.Models;
using BLL;

namespace highwayapp2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult validate(string username, string password)
    {

        AppManager am = new AppManager();

        if (am.doValidate(username, password))
        {
            return Redirect("WelcomeAdmin");
        }
        return RedirectToAction("Login");
    }

     public IActionResult WelcomeAdmin()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
