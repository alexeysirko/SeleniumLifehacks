using Aquality.Selenium.Browsers;
using ExampleProject.Framework.Pages;
using ExampleProject.Framework.Tests;
using OpenQA.Selenium.DevTools.V123.DOM;
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
    internal class MainPageStep
    {
       private MainPage mainpage = new();

        [Given(@"I go to '(.*)' on the Main Page")]
        
        public void GoToThePage(string link) 
        {
            mainpage.ClickNavigationLink(link);
        }

    }
}
