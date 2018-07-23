using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Epicodemon.Models;

namespace Epicodemon.Tests
{
  [TestClass]
  public class MonTypeTests : IDisposable
  {
    public void Dispose()
    {
      MonType.DeleteAll();
    }
    public MonTypeTests()
    {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=epicodemons_test;";
    }
    [TestMethod]
    public void Save_GetAllMonTypes_Test()
    {
      //Arrange
      MonType newMonType = new MonType("grass");
      MonType newMonType1 = new MonType("electric");
      newMonType.Save();
      newMonType1.Save();

      //Act
      List<MonType> expectedResult = new List<MonType>{newMonType, newMonType1};
      List<MonType> result = MonType.GetAllMonTypes();

      //Assert
      CollectionAssert.AreEqual(expectedResult, result);
    }
    [TestMethod]
    public void Find_Test()
    {
      //Arrange
      MonType newMonType = new MonType("fairy");
      newMonType.Save();

      //Act
      MonType result = MonType.Find(newMonType.GetMonTypeId());

      //Assert
      Assert.AreEqual(newMonType, result);
    }

    [TestMethod]
    public void Edit_Test()
    {
      //Arrange
      MonType newMonType = new MonType("fighting");
      newMonType.Save();
      MonType expectedMonType = new MonType("flying", newMonType.GetMonTypeId());
      //Act
      newMonType.Edit("flying");

      //Assert
      Assert.AreEqual(expectedMonType, newMonType);
    }
    [TestMethod]
    public void Delete_Test()
    {
      //Arrange
      MonType newMonType = new MonType("ice");
      newMonType.Save();
      MonType newMonType1 = new MonType("fire");
      newMonType1.Save();

      //Act
      newMonType.Delete();
      List<MonType> result = MonType.GetAllMonTypes();
      List<MonType> expectedResult = new List<MonType>{newMonType1};
      //Assert
      CollectionAssert.AreEqual(expectedResult, result);
    }
  }
}
