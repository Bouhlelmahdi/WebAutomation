using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestTechnique
{
    public class DriverHelper : IDisposable
    {
        public IWebDriver Driver { get; set; }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
