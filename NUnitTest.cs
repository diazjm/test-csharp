using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using seleniumTest.PageObjects;

namespace seleniumTest
{
    class NUnitTest
    {

        IWebDriver driver;
       
        // test Strings
	    private String testURL = "http://bluesourcestaging.herokuapp.com/login";
	    private String username = "company.admin";
	    private String password = "anything";
        private String employeeUsername = "JDTest";
	    private String firstName = "JDTestF";
	    private String lastName = "JDTestL";
        private int randomStringLength = 6;

        [SetUp]
        public void Initialize()
        {
            driver = new FirefoxDriver();
        }
        [Test]
        public void AddEmployeeTest()
        {
            employeeUsername = employeeUsername + CreateRandomString(randomStringLength);
            firstName = firstName + CreateRandomString(randomStringLength);
            lastName = lastName + CreateRandomString(randomStringLength);

            driver.Url = testURL;
            LoginPage loginPage = new LoginPage(driver);
            MainPage mainPage = loginPage.loginAs(username, password);
            AddEmployeePage addEmployeePage = mainPage.pressAddEmployeeButton();
            mainPage = addEmployeePage.fillOutMinimumFormParameters(employeeUsername, firstName, lastName);
            mainPage = mainPage.typeIntoSearchBar(firstName);
            Assert.AreEqual(firstName.Substring(0, 1).ToUpper() + firstName.Substring(1).ToLower(), mainPage.getTopFirstName());
 
        }
        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }

        private String CreateRandomString(int stringLength)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[stringLength];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }
    }
}
