using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestTechnique.Pages
{
    public class HomePage
    {
        private DriverHelper _driverHelper;
        public HomePage(DriverHelper driverHelper) => this._driverHelper = driverHelper;

        public static By SideBarAlert = By.XPath("//*[@class='SidebarAlertItemName__DescriptionTooltip-sc-17w4p33-4 dVJsZM']");
        public static By SearchField = By.XPath("//*[@placeholder='Search in alert history']");
        public static By MentionDescription = By.XPath("//*[@class='mnt-FeedMentionDescription']");

        public bool VerifyAlertName(string Alert)
        {
            string AlertName = _driverHelper.Driver.FindElement(SideBarAlert).Text;
            return (String.Equals(Alert, AlertName));
        }
        public bool VerifyRandomMentionContent(string Content)
        {
            //A JS Query or a loop can be added to scroll and search for the item with the specific content if the item is not visible
            IList<IWebElement> MentionText = _driverHelper.Driver.FindElements(MentionDescription);
            foreach (IWebElement Element in MentionText)
            {
                if (Element.Text.Contains(Content))
                {
                    return true;
                }
            }
            return false;
        }
        public void SearchMentionContent(string Keyword)
        {
            _driverHelper.Driver.FindElement(SearchField).SendKeys(Keyword);
        }
    }
}
