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
        public List<int> Changes = new List<int>() { +3, -4, +9, -8, +1 };
               
        [TestMethod()]
        public void CalculateTest_HappyPath()
        {
            //Act
            var calculate =  Program.Calculate(Changes);
            //Assert
            Assert.AreEqual(calculate,1);
            Assert.AreNotEqual(calculate, 5);
        }

        [TestMethod()]
        public void FindFirstDupeTest_HappyPath()
        {
            //Act
            var calculate = Program.FindFirstDuplicateFrequency(Changes);
            //Assert
            Assert.AreEqual(calculate, 0);
            Assert.AreNotEqual(calculate, 2);
        }
    }
}