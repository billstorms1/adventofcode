using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoxItUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxItUp.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        public List<string> testData = new List<string>(){"abcdefg","abcdefgga","abccdddeeffggg"};

        [TestMethod()]
        public void GetCheckSum_GoodData()
        {
            //Act
            var result = Program.GetCheckSum(testData);

            //Assert
            Assert.AreEqual(result,2);
        }
    }
}