using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddEmUp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddEmUp.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        //Arrange
        public List<int> Changes = new List<int>() { +4, -3, +9 };
               
        [TestMethod()]
        public void CalculateTest()
        {
            //Act
            var calculate =  Program.Calculate(Changes);
            //Assert
            Assert.AreEqual(calculate,10);
        }
    }
}