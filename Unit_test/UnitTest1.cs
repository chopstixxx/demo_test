using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Configuration;
using WindowsFormsApp1;
using System.Data;

namespace Unit_test
{
    [TestClass]
    public class UnitTest1
    {
        DB db = new DB();
        [TestMethod]
        public void Test_conn_open_true()
        {
            db.Open_conn();
            Assert.AreEqual(ConnectionState.Open, db.Get_conn().State);
        }
        [TestMethod]
        public void Test_conn_open_false()
        {
            db.Open_conn();
            Assert.AreEqual(ConnectionState.Closed, db.Get_conn().State);
        }
    }
}

