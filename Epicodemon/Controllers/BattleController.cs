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
      List<Mon> allMons = Mon.GetAllMons();
      model.Add("monone", mon1);
      model.Add("montwo", mon2);
      model.Add("monthree", mon3);
      model.Add("allMons", allMons);

      return View(model);
    }
    [HttpPost("/Battle/{id}/Battle")]
    public ActionResult DoBattle(int id)
    {
      Battle.DeleteAll();
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
      if(player.GetHitpoints() == 0)
      {
        return RedirectToAction("Lose");
      }
      else if (computer.GetHitpoints() == 0)
      {
        return RedirectToAction("Win");
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
      Battle computer = Battle.FindComputer();
      computer.SetLastHitpoints();
      Battle.PlayerSequence1(id);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Battle player = Battle.FindPlayer();
      computer = Battle.FindComputer();
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
    [HttpGet("/Battle/Combat/Computer/{id}")]
    public ActionResult ComputerFirst(int id)
    {
      Battle player = Battle.FindPlayer();
      Battle computer = Battle.FindComputer();
      List<Move> computerMoves = Mon.Find(computer.GetMon_Id()).GetMoves();
      Random move = new Random();
      Move computerMove = computerMoves[move.Next(computerMoves.Count)];
      player.SetLastHitpoints();
      Message.DeleteAll();

      Battle.ComputerSequence1(id, computerMove);
      player = Battle.FindPlayer();
      Dictionary<string, object> model = new Dictionary<string, object>();
      Message newMessage = new Message("<a href='/Battle/Combat/Player2/" + id + "'>Continue</a>");
      newMessage.Save();
      List<Message> turnMessages = Message.GetAllMessages();


      model.Add("player", player);
      model.Add("computer", computer);
      model.Add("turnMessages", turnMessages);
      model.Add("computerMove", computerMove);
      return View(model);

    }
    [HttpGet("/Battle/Combat/Player2/{id}")]
    public ActionResult PlayerSecond(int id)
    {
      Battle player = Battle.FindPlayer();
      if(player.GetHitpoints() == 0)
      {
        return RedirectToAction("Lose");
      }
      else
      {

        Message.DeleteAll();
        Battle computer = Battle.FindComputer();
        computer.SetLastHitpoints();
        Battle.PlayerSequence2(id);
        Dictionary<string, object> model = new Dictionary<string, object>();
        player = Battle.FindPlayer();
        computer = Battle.FindComputer();
        List<Move> playerMoves = Mon.Find(player.GetMon_Id()).GetMoves();
        Message newMessage = new Message("<a href='/Battle/Combat/'>Continue</a>");
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
    }

    [HttpGet("/Battle/Combat/Computer2/{id}")]
    public ActionResult ComputerSecond(int id)
    {

      Battle computer = Battle.FindComputer();
      Battle player = Battle.FindPlayer();
      List<Move> computerMoves = Mon.Find(computer.GetMon_Id()).GetMoves();
      Random move = new Random();
      Move computerMove = computerMoves[move.Next(computerMoves.Count)];
      player.SetLastHitpoints();
      Message.DeleteAll();
      if(player.GetHitpoints() == 0)
      {
        return RedirectToAction("Lose");
      }
      else
      {
        Battle.ComputerSequence2(id, computerMove);
        player = Battle.FindPlayer();
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
    [HttpGet("/Battle/Lose")]
    public ActionResult Lose()
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
