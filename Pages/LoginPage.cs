using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestTechnique.Pages
{
    public class LoginPage
    {
        private DriverHelper _driverHelper;
        public LoginPage(DriverHelper driverHelper) => this._driverHelper = driverHelper;

        public static By Connect = By.XPath("//*[@type='submit']/input");
        public static By UserName = By.Name("username");
        public static By PassWord = By.Name("password");


        public void InsertUsername(string username)
        {
            _driverHelper.Driver.FindElement(UserName).SendKeys(username);
        }
        public void InsertPassword(string password)
        {
            _driverHelper.Driver.FindElement(PassWord).SendKeys(password);
        }
        public void SubmitCredentials()
        {
            _driverHelper.Driver.FindElement(Connect).Click();
        }

    }
}
