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
    class MainPage
    {

        private IWebDriver driver;
        private WebDriverWait wait;

        private int tableIterator = 0;

        [FindsBy(How = How.CssSelector, Using = "div.btn-group.pull-right > button.btn.btn-default")]
        private IWebElement addEmployeeButton;
        [FindsBy(How = How.ClassName, Using = "form-control")]
        private IWebElement searchBar;
        [FindsBy(How = How.CssSelector, Using = "td")]
        private IWebElement topFirstName;
        
        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            wait = new WebDriverWait(driver, System.TimeSpan.FromMinutes(10));
            this.searchBar.
        }

        public AddEmployeePage pressAddEmployeeButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(this.addEmployeeButton)).Click();
            return new AddEmployeePage(driver);
        }
   
        public MainPage typeIntoSearchBar(String searchInput)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(this.searchBar));
            this.searchBar.SendKeys(searchInput);
            return this;
        }

        public String getTopFirstName()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(this.topFirstName));
            return this.topFirstName.Text;
        }
         /*
        public String getNextTableEntryName()
        {
            tableIterator++;
            return 
        }*/
    }
}
