using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace VVS_Drugi_dio_projekta.Core
{
    public static class SingletonWebDriver
    {
        private static IWebDriver _instanceOfSingleton;
        public static IWebDriver GetInstance
        {
            get
            {
                if(_instanceOfSingleton == null)
                {
                    CreateInstance();
                }
                return _instanceOfSingleton;
            }
        }
        private static void CreateInstance()
        {
            _instanceOfSingleton = new ChromeDriver();
            _instanceOfSingleton.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _instanceOfSingleton.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
        }
        public static void KillInstance()
        {
            _instanceOfSingleton.Quit();
            _instanceOfSingleton = null;
        }
    }
}
