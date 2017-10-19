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
    class AddEmployeePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "employee_username")]
        private IWebElement userNameForm;
        [FindsBy(How = How.Id, Using = "employee_first_name")]
        private IWebElement firstNameForm;
        [FindsBy(How = How.Id, Using = "employee_last_name")]
        private IWebElement lastNameForm;
        [FindsBy(How = How.Name, Using = "commit")]
        private IWebElement createEmployeeButton;

        public AddEmployeePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
        
       public MainPage fillOutMinimumFormParameters(string username, string firstName, string lastName)
       {
           WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromMinutes(10));
           wait.Until(ExpectedConditions.ElementToBeClickable(userNameForm));
           userNameForm.SendKeys(username);
           firstNameForm.SendKeys(firstName);
           lastNameForm.SendKeys(lastName);
           createEmployeeButton.Click();
           return new MainPage(driver);
       }
    }
}
