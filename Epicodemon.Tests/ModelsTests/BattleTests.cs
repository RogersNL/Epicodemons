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
      Battle newBattle = new Battle("Pikachu", 1, 2, 3, 4, 5, 6, 10, 10, 12, 15);
      Battle newBattle1 = new Battle("Raichu", 2, 4, 6, 8, 10, 12, 20, 20, 24, 30);
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
      Battle newBattle = new Battle("Snorlax", 4, 2, 4, 3, 5, 6, 22, 52, 32, 12);
      newBattle.Save();

      //Act
      Battle result = Battle.Find(newBattle.GetBattleId());

      //Assert
      Assert.AreEqual(newBattle, result);
    }

    [TestMethod]
    public void Edit_Test()
    {
      //Arrange
      Battle newBattle = new Battle("Electrode", 43, 24, 31, 61, 32, 23, 20, 20, 24, 30);
      newBattle.Save();
      Battle expectedBattle = new Battle("Electrode", 43, 24, 32, 61, 32, 23, 20, 20, 24, 30, newBattle.GetBattleId());
      //Act
      newBattle.Edit("Electrode", 43, 24, 32, 61, 32, 23, 20, 20, 24, 30);

      //Assert
      Assert.AreEqual(expectedBattle, newBattle);
    }
    [TestMethod]
    public void Delete_Test()
    {
      //Arrange
      Battle newBattle = new Battle("Chansey", 43, 24, 32, 61, 32, 23, 20, 20, 24, 30);
      newBattle.Save();
      Battle newBattle1 = new Battle("Togepi", 1, 2, 4, 2, 3, 4, 20, 20, 23, 5);
      newBattle1.Save();

      //Act
      newBattle.Delete();
      List<Battle> result = Battle.GetAllBattles();
      List<Battle> expectedResult = new List<Battle>{newBattle1};
      //Assert
      CollectionAssert.AreEqual(expectedResult, result);
    }
  }
}
