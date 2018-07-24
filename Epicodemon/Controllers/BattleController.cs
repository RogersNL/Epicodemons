using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Epicodemon.Models;

namespace Epicodemon.Controllers
{
  public class BattleController : Controller
  {
    [HttpGet("/Battle")]
    public ActionResult Index()
    {
      Battle.DeleteAll();
      Dictionary<string, object> model = new Dictionary<string, object>();
      Mon mon1 = Mon.Find(1);
      Mon mon2 = Mon.Find(2);
      Mon mon3 = Mon.Find(3);

      model.Add("monone", mon1);
      model.Add("montwo", mon2);
      model.Add("monthree", mon3);

      return View(model);
    }
    [HttpPost("/Battle/{id}/Battle")]
    public ActionResult DoBattle(int id)
    {
      Mon playerMon = Mon.Find(id);
      Battle newPlayer = playerMon.GetAllTrueStats();
      newPlayer.Save();
      newPlayer.SetPlayerMon();
      newPlayer.SetActiveMon();
      Battle.ComputerChoice(id);
      return RedirectToAction("Combat");
    }
    [HttpGet("/Battle/Combat")]
    public ActionResult Combat()
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Battle player = Battle.FindPlayer();
      Battle computer = Battle.FindComputer();

      model.Add("player", player);
      model.Add("computer", computer);

      return View(model);
    }
    [HttpPost("/Battle/TurnSequence")]
    public ActionResult TurnSequence()
    {
      return RedirectToAction("Combat");
    }
  }
}
