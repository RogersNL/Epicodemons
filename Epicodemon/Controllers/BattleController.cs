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

      model.Add("player", player);
      model.Add("computer", computer);
      model.Add("playerMoves", playerMoves);
      return View(model);
    }
    [HttpPost("/Battle/Combat/{id}")]
    public ActionResult TurnSequence(int id)
    {
      Battle player = Battle.FindPlayer();
      Battle computer = Battle.FindComputer();
      Move playerMove = Move.Find(id);
      List<Move> computerMoves = Mon.Find(computer.GetMon_Id()).GetMoves();

      //Speed Check
      int tie = 0;
      if (computer.GetSpeed() == player.GetSpeed())
      {
        Random speedTie = new Random();
        tie = speedTie.Next(1,3);
      }
      if(player.GetSpeed() > computer.GetSpeed() || tie == 1)
      {
        int newHP = computer.GetHitpoints() - Battle.BaseDamage(player.GetBattleId(), playerMove);
        if(newHP > 0)
        {
          computer.SetNewHP(newHP);
          Random move = new Random();
          Move computerMove = computerMoves[move.Next(computerMoves.Count - 1)];
          int otherHP = player.GetHitpoints() - Battle.BaseDamage(player.GetBattleId(), computerMove);
          if(otherHP > 0)
          {
            player.SetNewHP(otherHP);
            return RedirectToAction("Combat");
          }
        }
        else
        {
          computer.SetNewHP(0);
          return RedirectToAction("End");
        }
      }
      else if (player.GetSpeed() < computer.GetSpeed() || tie == 2)
      {
        Random move = new Random();
        Move computerMove = computerMoves[move.Next(computerMoves.Count - 1)];
        int otherHP = player.GetHitpoints() - Battle.BaseDamage(computer.GetBattleId(), computerMove);
        if(otherHP > 0)
        {
          player.SetNewHP(otherHP);
          int newHP = computer.GetHitpoints() - Battle.BaseDamage(player.GetBattleId(), playerMove);
          if(newHP > 0)
          {
            computer.SetNewHP(newHP);
            return RedirectToAction("Combat");
          }
          else
          {
            computer.SetNewHP(0);
            return RedirectToAction("End");
          }
        }
        else
        {
          player.SetNewHP(0);
          return RedirectToAction("End");
        }
      }

      return RedirectToAction("Index");
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
