using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavAutomation.Pages
{
    public class LoginPage
    {
        //private IWebDriver _Driver;

        //public LoginPage(IWebDriver Driver) => this._Driver = Driver;

        private DriverHelper _driverHelper;

        public LoginPage(DriverHelper driverHelper) => this._driverHelper = driverHelper;

        public static By LoginButton = By.XPath("//*[@data-testid='loginButton']");
        public static By UserName = By.XPath("//*[@name='Username']");
        public static By PassWord = By.XPath("//*[@name='Password']");
        public static By Login = By.XPath("//*[@class='btn btn-primary large']");
        public static By LoginError = By.XPath("//*[@class='alert alert-danger']");
        public static By NavQuestHome = By.XPath("//*[@class='GridLayout-sc-1fpu0kd-0 cdQofX']");

        //IWebElement HomeLogin => _Driver.FindElement(By.TagName("Button"));

        public void ClickLogin(By Element)
        {
            _driverHelper.Driver.FindElement(Element).Click();
        }

        public void EnterUsername(String Username)
        {
            _driverHelper.Driver.FindElement(UserName).SendKeys(Username);
        }

        public void EnterPassword(String Password)
        {
            _driverHelper.Driver.FindElement(PassWord).SendKeys(Password);
        }

        public IWebElement WaitElementtoBeVisible(By Element)
        {
            WebDriverWait wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(10));
            IWebElement PageElem = wait.Until(e => e.FindElement(Element));
            return PageElem;
        }

        public void SubmitLogin()
        {
            _driverHelper.Driver.FindElement(Login).Click();
        }
        
    }
}
