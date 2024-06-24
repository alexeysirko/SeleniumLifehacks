using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    internal class FileDownloadPage : Form
    {
        private const string PageName = "File Download";
        //implement locator
        private IButton downloadLink(string filename) => ElementFactory.GetButton(By.XPath($"locator with {filename}"), "Element name");
        public FileDownloadPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, PageName)), PageName)
        {
        }

        public void ClickFileDownloadLink(string name)
        {
            downloadLink(name).Click();
        }

        public bool IsFileDownloadLinkDisplayed(string name)
        {
            //to implement
            return false;
        }
    }
}
