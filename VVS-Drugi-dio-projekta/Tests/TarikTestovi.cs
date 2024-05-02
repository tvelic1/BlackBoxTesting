using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VVS_Drugi_dio_projekta.Tests
{
    [TestFixture]
    class TarikTestovi : BaseTest
    {
        [Test]
        public void DodavanjeProizvodaUCompareListuIPregledCompareListe()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/");

            IWebElement compareProductDugme = driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div[1]/form/div/div[2]/div[2]/button[3]"));
            ScrollToElement(compareProductDugme);
            WaitUntillElementIsClickable(compareProductDugme);
            ClickOnElement(compareProductDugme);

            Thread.Sleep(5000);

            driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=product/compare&language=en-gb");

            // Provjera da li je element dodan u compare listu. Compare lista treba biti prazna prije testa
            IWebElement compareListPraznaLabel = driver.FindElement(By.XPath("//*[@id=\"content\"]/p"));
            Assert.IsFalse(compareListPraznaLabel.Displayed);
        }
        [Test]
        public void DodavanjeProizvodaUWishListuIPregledWishListe()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/");

            IWebElement wishListDugme = driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div[1]/form/div/div[2]/div[2]/button[2]"));
            ScrollToElement(wishListDugme);
            WaitUntillElementIsClickable(wishListDugme);
            ClickOnElement(wishListDugme);

            Thread.Sleep(5000);

            IWebElement otvoriWishList = driver.FindElement(By.XPath("//*[@id=\"wishlist-total\"]"));
            ScrollToElement(otvoriWishList);
            WaitUntillElementIsClickable(otvoriWishList);
            ClickOnElement(otvoriWishList);

            Thread.Sleep(5000);

            Assert.AreEqual("https://demo.opencart.com/index.php?route=account/login&language=en-gb", driver.Url);
        }
        private void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", element);
        }
        private void WaitUntillElementIsClickable(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
        private void ClickOnElement(IWebElement element)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].click();", element);
        }
    }
}