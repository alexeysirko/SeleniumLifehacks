using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
namespace ExampleProject.Framework.Pages
{
    internal class MainPage : Form
    {
        private ILink navigationLink(string navigation) => ElementFactory.GetLink(
            By.XPath(string.Format(LocatorConstants.PreciseTextLocator, navigation)), "Navigation link");
        public MainPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, "Welcome to the-internet")), "Main page")
        {
        }

        public void ClickNavigationLink(string navigationName)
        {
            navigationLink(navigationName).Click();
        }
    }
}
