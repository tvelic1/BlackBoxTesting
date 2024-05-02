using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace VVS_Drugi_dio_projekta.Tests
{
    [TestFixture]
    class AminaTestovi : BaseTest
    {
        [Test]
        public void OtvaranjeDetaljaOUredjaju_UpsjesanPrikaz()
        {
            // Otvaranje početne stranice aplikacije
            driver.Navigate().GoToUrl("https://demo.opencart.com/");

            // Pronalazak linka sa imenom uređaja za prvi uređaj u listi, scroll do elementa i čekanje da bude vidljiv prije nego što se klikne
            IWebElement linkElement = driver.FindElement(By.XPath("//*[@id='content']/div[2]/div[1]/form/div/div[2]/div[1]/h4/a"));
            ScrollToElement(linkElement);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(linkElement));

            // Realizacija klika na link kako bi se otvorile informacije o uređaju
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].click();", linkElement);

            // Da bi se osiguralo da se klik obradi prije sljedeće naredbe, sačekamo
            Thread.Sleep(5000);

            // Da li su se otvorile informacije o kliknutom uređaju
            string ocekivaniURL = "https://demo.opencart.com/index.php?route=product/product&language=en-gb&product_id=43";
            Assert.AreEqual(ocekivaniURL, driver.Url);
        }
        [Test]
        public void DodavanjeProizvodaUKorpuIPregledKorpe()
        {
            // Otvaranje početne stranice aplikacije
            driver.Navigate().GoToUrl("https://demo.opencart.com/");

            // Pronalazak dugmeta koje dodaje element u korpu za prvi element u listi, scroll do elementa i čekanje da bude vidljiv prije nego što se klikne
            IWebElement addToCartButton = driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div[1]/form/div/div[2]/div[2]/button[1]"));
            ScrollToElement(addToCartButton);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(addToCartButton));

            // Klik na dugme za dodavnje u korpu
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].click();", addToCartButton);

            // Da bi se osiguralo da se klik obradi prije sljedeće naredbe, sačekamo
            Thread.Sleep(5000);

            // Tražimo link iz menija koji otvara korpu kako bismo provjerili da li se element dodao u korpu
            IWebElement openCart = driver.FindElement(By.XPath("//*[@id=\"top\"]/div[2]/div[2]/ul/li[4]/a"));
            ScrollToElement(openCart);
            wait.Until(ExpectedConditions.ElementToBeClickable(openCart));

            // Klik na link i čekanje
            jsExecutor.ExecuteScript("arguments[0].click();", openCart);
            Thread.Sleep(5000);

            // Provjera da li ima elemenata u korpi (preduslov je da prije testa bude prazna)
            IWebElement korpaPraznaInfo = driver.FindElement(By.XPath("//*[@id=\"content\"]/p"));
            Assert.IsFalse(korpaPraznaInfo.Displayed); 
        }
        private void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", element);
        }
    }
}
