using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Search_Engine_Library;
using Movie_Search_Engine;

namespace Unit_Tests
{
    [TestClass]
    public class UnitTests2
    {
        [TestMethod]
        public void Movie_Equals()
            {
                Movie m1 = new Movie();
                Movie m2 = new Movie();
            m1.Id = 5;
            m2.Id = 5;
                Assert.AreEqual(m1, m2);
            }

        [TestMethod]
        public void Movie_NotEquals()
        {
            Movie m1 = new Movie();
            Movie m2 = new Movie();
            m1.Id = 2;
            m2.Id = 5;
            Assert.AreNotEqual(m1, m2);
        }




    }
}
