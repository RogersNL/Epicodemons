using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Epicodemon.Models;

namespace Epicodemon.Tests
{
  [TestClass]
  public class BattleTests : IDisposable
  {
    public void Dispose()
    {
      Battle.DeleteAll();
    }
    public BattleTests()
    {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=epicodemons_test;";
    }
    [TestMethod]
    public void Save_GetAllBattles_Test()
    {
      //Arrange
      Battle newBattle = new Battle(4, "Pikachu",5, 4, 6, 1, 2, 3, 4, 5, 6, 10, 10, 12, 15, true, false, true);
      Battle newBattle1 = new Battle(5, "Raichu",5, 5, 6, 2, 4, 6, 8, 10, 12, 20, 20, 24, 30, false, true, false);
      newBattle.Save();
      newBattle1.Save();

      //Act
      List<Battle> expectedResult = new List<Battle>{newBattle, newBattle1};
      List<Battle> result = Battle.GetAllBattles();

      //Assert
      CollectionAssert.AreEqual(expectedResult, result);
    }
    [TestMethod]
    public void Find_Test()
    {
      //Arrange
      Battle newBattle = new Battle(4, "Snorlax", 4, 2, 4, 3, 5, 6, 22, 52, 32, 12);
      newBattle.Save();

      //Act
      Battle result = Battle.Find(newBattle.GetBattleId());

      //Assert
      Assert.AreEqual(newBattle, result);
    }

    // [TestMethod]
    // public void Edit_Test()
    // {
    //   //Arrange
    //   Battle newBattle = new Battle("Electrode", 43, 24, 31, 61, 32, 23, 20, 20, 24, 30);
    //   newBattle.Save();
    //   Battle expectedBattle = new Battle("Electrode", 43, 24, 32, 61, 32, 23, 20, 20, 24, 30, newBattle.GetBattleId());
    //   //Act
    //   newBattle.Edit("Electrode", 43, 24, 32, 61, 32, 23, 20, 20, 24, 30);
    //
    //   //Assert
    //   Assert.AreEqual(expectedBattle, newBattle);
    // }
    [TestMethod]
    public void Delete_Test()
    {
      //Arrange
      Battle newBattle = new Battle(4, "Chansey", 43, 24, 32, 61, 32, 23, 20, 20, 24, 30);
      newBattle.Save();
      Battle newBattle1 = new Battle(3, "Togepi", 1, 2, 4, 2, 3, 4, 20, 20, 23, 5);
      newBattle1.Save();

      //Act
      newBattle.Delete();
      List<Battle> result = Battle.GetAllBattles();
      List<Battle> expectedResult = new List<Battle>{newBattle1};
      //Assert
      CollectionAssert.AreEqual(expectedResult, result);
    }
    // [TestMethod]
    // public void GetMons_Test()
    // {
    //   //Arrange
    //   Battle newBattle = new Battle("Togepi", 1, 2, 4, 2, 3, 4, 20, 20, 23, 5);
    //   newBattle.Save();
    //   Mon newMon = new Mon("Rattata", 50, 30, 56, 35, 25, 35, 72);
    //   newMon.Save();
    //   Mon newMon1 = new Mon("Chansey", 43, 24, 32, 61, 32, 23, 20);
    //   newMon1.Save();
    //
    //   //Act
    //   newBattle.AddMon(newMon);
    //   newBattle.AddMon(newMon1);
    //
    //   List<Mon> expectedResult = new List<Mon>{newMon, newMon1};
    //   List<Mon> result = newBattle.GetMons();
    //
    //   //Assert
    //   CollectionAssert.AreEqual(expectedResult, result);
    // }
    [TestMethod]
    public void BaseDamage()
    {
      //Arrange
      Move newMove = new Move("thunderbolt", 95, "special", "zappy boi", "par 10", 15, 70);
      Mon attackingMon = new Mon("Raichu-Alola", 50, 60, 85, 50, 95, 85, 110);
      attackingMon.Save();

      Mon defendingMon = new Mon("Golduck", 50, 80, 82, 78, 95, 80, 85);
      defendingMon.Save();

      Battle attacking = attackingMon.GetAllTrueStats();
      Battle defending = defendingMon.GetAllTrueStats();
      attacking.Save();
      attacking.SetPlayerMon();
      attacking.SetActiveMon();
      defending.Save();
      defending.SetComputerMon();
      defending.SetActiveMon();

      //Act
      int result = Battle.BaseDamage(attacking.GetBattleId(), newMove);
      List<Battle> emptyList = new List<Battle>{};
      //Assert
      Console.WriteLine(result);
      Assert.AreEqual(50, result);

    }
  }
}
