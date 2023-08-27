using Microsoft.AspNetCore.Mvc;
using ServiceRadar.MVC.Models;
using System.Diagnostics;

namespace ServiceRadar.MVC.Controllers;
public class HomeController : Controller
{
    public IActionResult NoAccess()
    {
        return View();
    }
    public IActionResult NoPage()
    {
        Response.StatusCode = 404;
        return View();
    }

    public IActionResult Privacy()
    {
        var model = new Privacy()
        {
            Title = "Privacy Policy",
            Description = "Privacy policy details:",
            Tags = new List<string>() {
                "We do not collect or store personal information.",
                "Your privacy is our priority.",
                "No data sharing with third parties."
            }
        };
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
