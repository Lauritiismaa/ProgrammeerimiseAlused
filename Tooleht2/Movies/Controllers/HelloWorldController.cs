using Microsoft.AspNetCore.Mvc;
namespace MvcMovie.Controllers;

public class HelloWorldController : Controller
{
    public IActionResult Index() => View();
    public IActionResult Welcome(string name, int numTimes = 1)
    {
        ViewData["Message"] = $"Tere, {name}!";
        ViewData["NumTimes"] = Math.Clamp(numTimes, 0, 100);
        return View();
    }
}
