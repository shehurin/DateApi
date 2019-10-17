using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateApi.Controllers.Tests
{
    [TestClass()]
    public class DateWebApiControllerTests
    {
        [TestMethod()]
        public void PostTest()
        {
            //arrangre
            string from = "2018-01-01";
            string to = "2018-02-01";
            bool expected = true;

            // act
            DateTime dateFrom = Convert.ToDateTime(from);
            DateTime dateTo = Convert.ToDateTime(to);
            bool actual = dateFrom <= dateTo ? true : false;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsCorectData()
        {
            //arrangre
            string from = "2018-01-01";
            string to = "2018-02-01";

            // act
            DateTime dateFrom = Convert.ToDateTime(from);
            DateTime dateTo = Convert.ToDateTime(to);

            // assert
            Assert.IsNotNull(dateFrom);
            Assert.IsNotNull(dateTo);
        }
    }
}