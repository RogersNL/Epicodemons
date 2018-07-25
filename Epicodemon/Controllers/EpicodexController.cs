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
    [HttpGet("/Epicodex/Mons/{id}/View")]
    public ActionResult View(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Mon selectedMon = Mon.Find(id);
      List<Move> monsmoves = selectedMon.GetMoves();

      model.Add("mon", selectedMon);
      model.Add("moves", monsmoves);

      return View(model);
    }
    [HttpGet("/Epicodex/Moves")]
    public ActionResult Moves()
    {
      return View(Move.GetAllMoves());
    }
    [HttpGet("/Epicodex/Dev")]
    public ActionResult Dev()
    {
      return View();
    }
    [HttpGet("/Epicodex/Dev/MonCreateForm")]
    public ActionResult MonCreateForm()
    {
      return View();
    }
    [HttpPost("/Epicodex/Dev/AddMon")]
    public ActionResult AddNewMon(string monname, int monlevel, int monhp, int monattack, int mondefense, int monspecialattack, int monspecialdefense, int monspeed, string montype1, string montype2, string move1, string move2, string move3, string move4)
    {
      int move1int = int.Parse(move1);
      int move2int = int.Parse(move2);
      int move3int = int.Parse(move3);
      int move4int = int.Parse(move4);
      MonType typeOne = MonType.Find(montype1);
      Mon newMon = new Mon(monname, monlevel, monhp, monattack, mondefense, monspecialattack, monspecialdefense, monspeed);
      Move monmove1 = Move.Find(move1int);

      newMon.Save();
      newMon.AddMonType(typeOne);
      newMon.AddMove(monmove1);


      if(montype2 != "NOOOO")
      {
        MonType typeTwo = MonType.Find(montype2);
        newMon.AddMonType(typeTwo);
      }
      if(move2int != 0)
      {
        Move monmove2 = Move.Find(move2int);
        newMon.AddMove(monmove2);
      }
      if(move3int != 0)
      {
        Move monmove3 = Move.Find(move3int);
        newMon.AddMove(monmove3);
      }
      if(move4int != 0)
      {
        Move monmove4 = Move.Find(move4int);
        newMon.AddMove(monmove4);
      }


      return RedirectToAction("Dev");
    }
    [HttpGet("/Epicodex/Dev/MoveCreateForm")]
    public ActionResult MoveCreateForm()
    {
      return View();
    }
    [HttpPost("/Epicodex/Dev/AddMove")]
    public ActionResult AddNewMon(string movename, string movedescription, int movebasepower, int movepp, int moveaccuracy, string movetype, string movestyle, string secondaryeffect)
    {
      Move newMove = new Move(movename, movebasepower, movestyle, movedescription, secondaryeffect, movepp, moveaccuracy);

      newMove.Save();

      return RedirectToAction("Dev");
    }
  }
}
