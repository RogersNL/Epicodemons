using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Epicodemon.Models;

namespace Epicodemon.Tests
{
  [TestClass]
  public class MonTests : IDisposable
  {
    public void Dispose()
    {
      Mon.DeleteAll();
    }
    public MonTests()
    {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=epicodemons_test;";
    }
    [TestMethod]
    public void Save_GetAllMons_Test()
    {
      //Arrange
      Mon newMon = new Mon("Pikachu", 1, 2, 3, 4, 5, 6, 10);
      Mon newMon1 = new Mon("Raichu", 2, 4, 6, 8, 10, 12, 20);
      newMon.Save();
      newMon1.Save();

      //Act
      List<Mon> expectedResult = new List<Mon>{newMon, newMon1};
      List<Mon> result = Mon.GetAllMons();

      //Assert
      CollectionAssert.AreEqual(expectedResult, result);
    }
    [TestMethod]
    public void Find_Test()
    {
      //Arrange
      Mon newMon = new Mon("Snorlax", 4, 2, 4, 3, 5, 6, 22);
      newMon.Save();

      //Act
      Mon result = Mon.Find(newMon.GetMonId());

      //Assert
      Console.WriteLine(result.GetMonName());
      Console.WriteLine(result.GetLevel());
      Console.WriteLine(result.GetHitpoints());
      Console.WriteLine(result.GetAttack());
      Console.WriteLine(result.GetDefense());
      Console.WriteLine(result.GetSpecialattack());
      Console.WriteLine(result.GetSpecialdefense());
      Console.WriteLine(result.GetSpeed());


      Assert.AreEqual(newMon, result);
    }

    [TestMethod]
    public void Edit_Test()
    {
      //Arrange
      Mon newMon = new Mon("Electrode", 43, 24, 31, 61, 32, 23, 23);
      newMon.Save();
      Mon expectedMon = new Mon("Electrode", 43, 24, 32, 61, 32, 23, 20, newMon.GetMonId());
      //Act
      newMon.Edit("Electrode", 43, 24, 32, 61, 32, 23, 20);

      //Assert
      Assert.AreEqual(expectedMon, newMon);
    }
    [TestMethod]
    public void Delete_Test()
    {
      //Arrange
      Mon newMon = new Mon("Chansey", 43, 24, 32, 61, 32, 23, 20);
      newMon.Save();
      Mon newMon1 = new Mon("Togepi", 1, 2, 4, 2, 3, 4, 20);
      newMon1.Save();

      //Act
      newMon.Delete();
      List<Mon> result = Mon.GetAllMons();
      List<Mon> expectedResult = new List<Mon>{newMon1};
      //Assert
      CollectionAssert.AreEqual(expectedResult, result);
    }
  }
}
