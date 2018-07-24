using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Epicodemon.Models;

namespace Epicodemon.Controllers
{
  public class EpicodexController : Controller
  {
    [HttpGet("/Epicodex")]
    public ActionResult Index()
    {
      return View();
    }
    [HttpGet("/Epicodex/Mons")]
    public ActionResult Mons()
    {
      return View(Mon.GetAllMons());
    }
  }
}
