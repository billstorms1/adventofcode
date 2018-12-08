using System.Collections.Generic;
using BoxItUp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoxItUpTests
{
    [TestClass()]
    public class ProgramTests
    {
        public List<string> TestData = new List<string>(){"abcdefg","abcdefn", "abcdefgga","abccdddeeffggg"};

        [TestMethod()]
        public void GetCheckSum_GoodData()
        {
            //Act
            var result = Program.GetCheckSum(TestData);

            //Assert
            Assert.AreEqual(result,2);
        }

        [TestMethod()]
        public void GetCommonCharaters_GoodData()
        {
            //Act
            var result = Program.GetCommonCharacters(TestData);

            //Assert
            Assert.AreEqual(result,"abcdef");
        }
    }

}