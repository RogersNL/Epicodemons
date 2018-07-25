using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Epicodemon.Models;
using System;

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
      List<Move> playerMoves = Mon.Find(player.GetMon_Id()).GetMoves();
      List<Message> turnMessages = Message.GetAllMessages();

      model.Add("player", player);
      model.Add("computer", computer);
      model.Add("playerMoves", playerMoves);
      model.Add("turnMessages", turnMessages);
      return View(model);
    }
    [HttpPost("/Battle/Combat/{id}")]
    public ActionResult TurnSequence(int id)
    {
      Battle.Sequence(id);
      Battle player = Battle.FindPlayer();
      Battle computer = Battle.FindComputer();
      if(player.GetHitpoints() == 0 || computer.GetHitpoints() == 0)
      {
        return RedirectToAction("End");
      }
      else
      {
        return RedirectToAction("Combat");
      }
    }
    [HttpGet("/Battle/End")]
    public ActionResult End()
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Battle player = Battle.FindPlayer();
      Battle computer = Battle.FindComputer();
      List<Move> playerMoves = Mon.Find(player.GetMon_Id()).GetMoves();

      model.Add("player", player);
      model.Add("computer", computer);
      model.Add("playerMoves", playerMoves);
      return View(model);
    }
  }
}
