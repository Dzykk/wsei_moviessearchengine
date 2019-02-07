using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Search_Engine_Library;
using Movie_Search_Engine;

namespace Unit_Tests
{
    [TestClass]
    public class UnitTests
    {
        [DataTestMethod]
        [DataRow("Admin", "aaa", "Admin", "bbb")]
        [DataRow("User", "ccc", "User", "ddd")]
        [DataRow("123456", "aaa", "123456", "bbb")]
        public void User_Equals(string username, string password, string username2, string password2)
        {
            User User = new User(username, password);
            User User2 = new User(username2, password2);
            Assert.AreEqual(User, User2);

        }

        [DataTestMethod]
        [DataRow("Admin", "aaa", "Admin1", "bbb")]
        [DataRow("1User", "ccc", "User", "ddd")]
        [DataRow("123456", "aaa", "123356", "bbb")]
        public void User_NotEquals(string username, string password, string username2, string password2)
        {
            User User = new User(username, password);
            User User2 = new User(username2, password2);
            Assert.AreNotEqual(User, User2);

        }

        [DataTestMethod]
        [DataRow("Admin", "aaa", "Admin1", "bbb")]
        [DataRow("User", "ccc", "Uzytkownik", "ddd")]
        [DataRow("123456", "aaa", "User", "bbb")]
        public void User_CompareTo_U1LessThanU2(string username, string password, string username2, string password2)
        {
            User User = new User(username, password);
            User User2 = new User(username2, password2);
            Assert.IsTrue(User > User2);

        }

        [DataTestMethod]
        [DataRow("Wo10", "aaa", "Admin", "bbb")]
        [DataRow("55443", "ccc", "112233", "ddd")]
        [DataRow("Admin", "aaa", "Aadmin", "bbb")]
        public void User_CompareTo_U1MoreThanU2(string username, string password, string username2, string password2)
        {
            User User = new User(username, password);
            User User2 = new User(username2, password2);
            Assert.IsTrue(User < User2);
        }

        [DataTestMethod]
        [DataRow("Admin", "aaa", "Admin", "bbb")]
        [DataRow("User", "ccc", "Uzytkownik", "ddd")]
        [DataRow("55443", "aaa", "55443", "bbb")]
        public void User_CompareTo_U1MoreOrEqualsThanU2(string username, string password, string username2, string password2)
        {
            User User = new User(username, password);
            User User2 = new User(username2, password2);
            Assert.IsTrue(User <= User2);
        }


    }
}
