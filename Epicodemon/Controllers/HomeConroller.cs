using Microsoft.AspNetCore.Mvc;
using Epicodemon.Models;

namespace Epicodemon.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}
