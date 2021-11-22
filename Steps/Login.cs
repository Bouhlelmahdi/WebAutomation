using NavAutomation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace NavAutomation.Steps
{
    [Binding]
    public sealed class Login
    {
        private DriverHelper _driverHelper;
        LoginPage loginPage;

        public Login(DriverHelper driverHelper)
        {
            this._driverHelper = driverHelper;
            loginPage = new LoginPage(_driverHelper);
        }

        
        
        [Given(@"Im on the LoginPage")]
        public void GivenImOnTheLoginPage()
        {
            _driverHelper.Driver.Navigate().GoToUrl("https://localhost:7001/");
        }

        [When(@"I click on HomeLogin")]
        public void WhenIClickOnHomeLogin()
        {
            loginPage.WaitElementtoBeVisible(LoginPage.LoginButton).Click();
            //loginPage.ClickLogin(LoginPage.LoginButton);
        }

        [Then(@"The Redirection Page is loaded")]
        public void ThenTheRedirectionPageIsLoaded()
        {
            loginPage.WaitElementtoBeVisible(LoginPage.UserName);
        }

        [When(@"I enter a username and a password")]
        public void WhenIEnterAUsernameAndAPassword(Table table)
        {
            foreach (TableRow Row in table.Rows)
            {
                loginPage.EnterUsername(Row[0]);
                loginPage.EnterPassword(Row[1]);
            }
        }

        [When(@"I click on Login")]
        public void WhenIClickOnLogin()
        {
            loginPage.ClickLogin(LoginPage.Login);
        }

        [Then(@"I should be logged in")]
        public void ThenIShouldBeLoggedIn()
        {
            loginPage.WaitElementtoBeVisible(LoginPage.NavQuestHome);
        }

        [Then(@"I should not be logged in")]
        public void ThenIShouldNotBeLoggedIn()
        {
            loginPage.WaitElementtoBeVisible(LoginPage.LoginError);
        }
    }
}
