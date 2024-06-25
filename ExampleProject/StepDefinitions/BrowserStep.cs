using Aquality.Selenium.Browsers;
using ExampleProject.Framework.Tests;
using NLog.LayoutRenderers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ExampleProject.StepDefinitions
{
    [Binding]
    internal class BrowserStep
    {
        [When(@"I accept the alert")]
        public void AcceptTheAlert()
        {
            AqualityServices.Browser.HandleAlert(AlertAction.Accept);
        }
    }
}
