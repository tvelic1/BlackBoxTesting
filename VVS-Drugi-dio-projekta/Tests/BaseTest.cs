using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVS_Drugi_dio_projekta.Core;

namespace VVS_Drugi_dio_projekta.Tests
{
    [TestFixture]
    class BaseTest
    {
        public IWebDriver driver;
        public BaseTest()
        {

        }
        [SetUp]
        public void SetUp()
        {
            driver = SingletonWebDriver.GetInstance;
        }
        [TearDown]
        public void Cleanup()
        {
            SingletonWebDriver.KillInstance();

        }

    }
}
