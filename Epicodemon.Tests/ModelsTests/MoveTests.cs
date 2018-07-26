using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Epicodemon.Models;

namespace Epicodemon.Tests
{
  [TestClass]
  public class MoveTests : IDisposable
  {
    public void Dispose()
    {
      Move.DeleteAll();
    }
    public MoveTests()
    {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=epicodemons_test;";
    }
    [TestMethod]
    public void Save_GetAllMoves_Test()
    {
      //Arrange
      Move newMove = new Move("thunderbolt", 95, "special", "zappy boi", "par 10", 15, 85);
      Move newMove1 = new Move("flamethrower", 95, "special", "flamey boi", "brn 10", 15, 95);
      newMove.Save();
      newMove1.Save();

      //Act
      List<Move> expectedResult = new List<Move>{newMove, newMove1};
      List<Move> result = Move.GetAllMoves();

      //Assert
      CollectionAssert.AreEqual(expectedResult, result);
    }
    [TestMethod]
    public void Find_Test()
    {
      //Arrange
      Move newMove = new Move("ice beam", 95, "special", "icy boi", "frz 10", 15, 80);
      newMove.Save();

      //Act
      Move result = Move.Find(newMove.GetMoveId());

      //Assert
      Assert.AreEqual(newMove, result);
    }

    [TestMethod]
    public void Edit_Test()
    {
      //Arrange
      Move newMove = new Move("psycic", 95, "special", "telekenetic boi", "spdef 10", 15, 80);
      newMove.Save();
      Move expectedMove = new Move("psychic", 95, "special", "telekenetic boi", "spdef 10", 15, 90, newMove.GetMoveId());
      //Act
      newMove.Edit("psychic", 95, "special", "telekenetic boi", "spdef 10", 15, 75);

      //Assert
      Assert.AreEqual(expectedMove, newMove);
    }
    [TestMethod]
    public void Delete_Test()
    {
      //Arrange
      Move newMove = new Move("tackle", 35, "physical", "tackly boi", "none", 35, 70);
      newMove.Save();
      Move newMove1 = new Move("scratch", 35, "physical", "scratchy boi", "none", 45, 75);
      newMove1.Save();

      //Act
      newMove.Delete();
      List<Move> result = Move.GetAllMoves();
      List<Move> expectedResult = new List<Move>{newMove1};
      //Assert
      CollectionAssert.AreEqual(expectedResult, result);
    }
  }
}
