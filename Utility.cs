using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestTechnique
{
    public class Utility
    {
        private DriverHelper _driverHelper;
        public Utility(DriverHelper driverHelper) => this._driverHelper = driverHelper;
        
        public IWebElement WaitElementtoBeVisible(By Element)
        {
            WebDriverWait wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(10));
            IWebElement PageElem = wait.Until(e => e.FindElement(Element));
            return PageElem;
        }
        public void PressEnter()
        {
            Actions Action = new Actions(_driverHelper.Driver);
            Action.SendKeys(Keys.Enter).Build().Perform();
        }
    }
}
