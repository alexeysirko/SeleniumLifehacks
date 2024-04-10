using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace ExampleProject
{
    internal class BaseTest
    {
        protected WebDriver driver;

        protected static readonly string url = "https://the-internet.herokuapp.com/";
        protected static readonly string preciseTextXpath = "//*[text()='{0}']";
        protected static readonly string partialTextXpath = "//*[contains(text(),'{0}')]";
        protected static readonly string relativePathFolder = @"Resources\"; //Path was fixed a little
        protected WebDriverWait wait = null;
        protected static readonly int maxWait = 10;

        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            string fullPath = Path.GetFullPath(relativePathFolder);
            chromeOptions.AddUserProfilePreference("download.default_directory", fullPath);
            driver = new ChromeDriver(chromeOptions);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWait));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
