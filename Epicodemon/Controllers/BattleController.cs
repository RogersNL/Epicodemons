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
      Message.DeleteAll();
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
      if(player.GetHitpoints() == 0 || computer.GetHitpoints() == 0)
      {
        return RedirectToAction("End");
      }
      else
      {
        return View(model);
      }
    }
    [HttpPost("/Battle/Combat/{id}")]
    public ActionResult CheckSpeed(int id)
    {
      Battle player = Battle.FindPlayer();
      Battle computer = Battle.FindComputer();
      int tie = 0;
      if (computer.GetSpeed() == player.GetSpeed())
      {
        Random speedTie = new Random();
        tie = speedTie.Next(1,3);
      }
      if(player.GetSpeed() > computer.GetSpeed() || tie == 1)
      {
        return RedirectToAction("PlayerFirst", new { id });
      }
      else if (player.GetSpeed() < computer.GetSpeed() || tie == 2)
      {
        return RedirectToAction("ComputerFirst", new { id });
      }
      else
      {
        return RedirectToAction("Combat");
      }
    }
    // [HttpPost("/Battle/Combat/Player/{id}")]
    // public ActionResult PlayerFirstPost(int id)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Battle player = Battle.FindPlayer();
    //   Battle computer = Battle.FindComputer();
    //   List<Move> playerMoves = Mon.Find(player.GetMon_Id()).GetMoves();
    //   List<Message> turnMessages = Message.GetAllMessages();
    //
    //   model.Add("player", player);
    //   model.Add("computer", computer);
    //   model.Add("playerMoves", playerMoves);
    //   model.Add("turnMessages", turnMessages);
    //
    //   // Battle.PlayerSequence1(id);
    //
    //   return View(model);
    // }
    [HttpGet("/Battle/Combat/Player/{id}")]
    public ActionResult PlayerFirst(int id)
    {
      Message.DeleteAll();
      Battle.PlayerSequence1(id);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Battle player = Battle.FindPlayer();
      Battle computer = Battle.FindComputer();
      List<Move> playerMoves = Mon.Find(player.GetMon_Id()).GetMoves();
      Message newMessage = new Message("<a href='/Battle/Combat/Computer2/" + id + "'>Continue</a>");
      newMessage.Save();
      List<Message> turnMessages = Message.GetAllMessages();

      Move usedMove = Move.Find(id);

      model.Add("player", player);
      model.Add("computer", computer);
      model.Add("playerMoves", playerMoves);
      model.Add("turnMessages", turnMessages);
      model.Add("usedMove", usedMove);

      return View(model);
    }
    [HttpGet("/Battle/Combat/Computer2/{id}")]
    public ActionResult ComputerSecond(int id)
    {

      Battle computer = Battle.FindComputer();
      List<Move> computerMoves = Mon.Find(computer.GetMon_Id()).GetMoves();
      Random move = new Random();
      Move computerMove = computerMoves[move.Next(computerMoves.Count)];
      Message.DeleteAll();
      if(computer.GetHitpoints() == 0)
      {
        return RedirectToAction("Win");
      }
      else
      {
        Battle.ComputerSequence2(id, computerMove);
        Battle player = Battle.FindPlayer();
        Dictionary<string, object> model = new Dictionary<string, object>();
        List<Move> playerMoves = Mon.Find(player.GetMon_Id()).GetMoves();
        Message newMessage = new Message("<a href='/Battle/Combat'>Continue</a>");
        newMessage.Save();
        List<Message> turnMessages = Message.GetAllMessages();


        model.Add("player", player);
        model.Add("computer", computer);
        model.Add("playerMoves", playerMoves);
        model.Add("turnMessages", turnMessages);
        model.Add("computerMove", computerMove);
        return View(model);
      }
    }
    // [HttpPost("/Battle/Combat/{id}")]
    // public ActionResult TurnSequence(int id)
    // {
    //   Battle.Sequence(id);
    //   Battle player = Battle.FindPlayer();
    //   Battle computer = Battle.FindComputer();
    //   if(player.GetHitpoints() == 0 || computer.GetHitpoints() == 0)
    //   {
    //     return RedirectToAction("End");
    //   }
    //   else
    //   {
    //     return RedirectToAction("Combat");
    //   }
    // }
    [HttpGet("/Battle/Win")]
    public ActionResult Win()
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
  }
}
