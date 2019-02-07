using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Search_Engine_Library;
using Movie_Search_Engine;
using System.Drawing;
using System.IO;

namespace Unit_Tests
{
    [TestClass]
    public class UnitTests2
    {
        [TestMethod]
        public void Movie_Equals()
            {
                Movie m1 = new Movie(5, "Gladiator");
                Movie m2 = new Movie(5, "Gladiator");
            
                Assert.AreEqual(m1, m2);
            }

        [TestMethod]
        public void Movie_NotEquals()
        {
            Movie m1 = new Movie(5, "Gladiator");
            Movie m2 = new Movie(6, "Gladiators");          
            Assert.AreNotEqual(m1, m2);
        }

        [TestMethod]
        public void Movie_CompareTo_M1LessThanM2()
        {
            Movie m1 = new Movie(5, "Gladiator", DateTime.Parse("16/04/2000"));
            Movie m2 = new Movie(6, "Gladiator", DateTime.Parse("16/04/2008"));

            Assert.IsTrue(m1 < m2);
        }

        [TestMethod]
        public void Movie_CompareTo_M1MoreThanM2()
        {
            Movie m1 = new Movie(5, "Waiting", DateTime.Parse("16/04/2008"));
            Movie m2 = new Movie(6, "Gladiator", DateTime.Parse("16/04/2008"));

            Assert.IsTrue(m1 > m2);
        }

        [TestMethod]
        public void Movie_CompareTo_M1LessOrEqualsThanM2()
        {
            Movie m1 = new Movie(5, "Gladiator", DateTime.Parse("16/04/2008"));
            Movie m2 = new Movie(6, "Gladiator", DateTime.Parse("16/04/2008"));

            Assert.IsTrue(m1 <= m2);
        }

        [TestMethod]
        public void Movie_CompareTo_M1MoreOrEqualsThanM2()
        {
            Movie m1 = new Movie(5, "Waiting", DateTime.Parse("16/04/2008"));
            Movie m2 = new Movie(6, "Gladiator", DateTime.Parse("16/04/2008"));

            Assert.IsTrue(m1 >= m2);
        }

      




    }
}
