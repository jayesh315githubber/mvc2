using DAL;
using BLL;
using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{

    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        AppManager am = new AppManager();
        List<Hospital> allHospital = am.geAllHopitals();
        ViewData["Hospitals"] = allHospital;
        return View();
    }

    public IActionResult ShowAllHospitals()
    {
        AppManager am = new AppManager();
        List<Hospital> allHospital = am.geAllHopitals();
        ViewData["Hospitals"] = allHospital;


        return View();
    }

    public IActionResult AllProducts()
    {

        return View();
    }


    [HttpGet]
    public IActionResult InsertFormofHospital()
    {
        return View();
    }

   [HttpPost]
    public IActionResult InsertFormofHospital(string name, string email, string pin)
    {
        AppManager ap = new AppManager();
        bool status = ap.InsertHospital(name, email, pin);
        Console.WriteLine(status);
        if (status)
        {
            return RedirectToAction("ShowAllHospitals");
        }

        return View();
    }

}