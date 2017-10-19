using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace seleniumTest.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "employee_username")]
        private IWebElement username;
        [FindsBy(How = How.Id, Using = "employee_password")]
        private IWebElement password;
        [FindsBy(How = How.Name, Using = "commit")]
        private IWebElement loginButton;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public MainPage loginAs(String username, String password)
        {
            this.username.SendKeys(username);
            this.password.SendKeys(password);
            this.loginButton.Click();
            return new MainPage(driver);
        }
    }
}
