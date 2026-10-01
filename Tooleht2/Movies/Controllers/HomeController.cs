using Microsoft.AspNetCore.Mvc;
namespace MvcMovie.Controllers;
public class HomeController : Controller
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => Problem("Päringu töötlemisel tekkis viga.");
}
