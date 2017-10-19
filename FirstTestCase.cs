using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace seleniumTest
{
    class FirstTestCase
    {
        static void Main(string[] args){
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://bluesourcestaging.herokuapp.com";

        }


        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://bluesourcestaging.herokuapp.com/";
            verificationErrors = new StringBuilder();
        }
        
       // [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
           // Assert.AreEqual("", verificationErrors.ToString());
        }
        
        //[Test]
        public void TheWebTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.CssSelector("div.btn-group.pull-right > button.btn.btn-default")).Click();
            driver.FindElement(By.Id("employee_first_name")).Clear();
            driver.FindElement(By.Id("employee_first_name")).SendKeys("asddd");
            driver.FindElement(By.Id("employee_last_name")).Clear();
            driver.FindElement(By.Id("employee_last_name")).SendKeys("dfddf");

            driver.FindElement(By.CssSelector("#modal_1 > div.modal-dialog > div.modal-content > div.modal-header > button.close")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }

    }
}
