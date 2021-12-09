using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TestTechnique.Pages;

namespace TestTechnique.Steps
{
    [Binding]
    public sealed class MentionSteps
    {
        private DriverHelper _driverHelper;
        LoginPage loginPage;
        HomePage homepage;
        Utility Tools;
        public MentionSteps(DriverHelper driverHelper)
        {
            this._driverHelper = driverHelper;
            loginPage = new LoginPage(_driverHelper);
            homepage = new HomePage(_driverHelper);
            Tools = new Utility(driverHelper);
        }
        [Given(@"Im on mention's website")]
        public void GivenImOnMentionSWebsite()
        {
            _driverHelper.Driver.Navigate().GoToUrl("https://web.mention.com/");
        }

        [When(@"I Login a username and a password")]
        public void WhenILoginAUsernameAndAPassword(Table table)
        {
            Tools.WaitElementtoBeVisible(LoginPage.UserName);
            foreach (TableRow Row in table.Rows)
            {
                loginPage.InsertUsername(Row[0]);
                loginPage.InsertPassword(Row[1]);
            }
            loginPage.SubmitCredentials();

        }

        [Then(@"I should see an alert named '(.*)' in the sidebar")]
        public void ThenIShouldSeeAnAlertNamedInTheSidebar(string p0)
        {
            Tools.WaitElementtoBeVisible(HomePage.SideBarAlert);
            homepage.VerifyAlertName(p0);
        }

        [Then(@"I should see a mention with content '(.*)'")]
        public void ThenIShouldSeeAMentionWithContentLenovoThinkPad(string p0)
        {
            Tools.WaitElementtoBeVisible(HomePage.MentionDescription);
            bool Status = homepage.VerifyRandomMentionContent(p0);
            if (Status == false)
            throw new Exception(p0 + " Not Found");
        }

        [When(@"I enter the keyword '(.*)' in the search field, and submit the search")]
        public void WhenIEnterTheKeywordInTheSearchFieldAndSubmitTheSearch(string p0)
        {
            homepage.SearchMentionContent(p0);
            Tools.PressEnter();
        }

        [Then(@"I Should see a mention with content '(.*)'")]
        public void ThenIShouldSeeAMentionWithContent(string p0)
        {
            Tools.WaitElementtoBeVisible(HomePage.MentionDescription);
            bool Status = homepage.VerifyRandomMentionContent(p0);
            if (Status == false)
                throw new Exception(p0 + " Not Found");
        }

    }
}
