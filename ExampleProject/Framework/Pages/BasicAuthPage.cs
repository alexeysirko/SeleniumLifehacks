using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    internal class BasicAuthPage : Form
    {
        private const string PageName = "Basic Auth";
        private IButton clickForJSAlertBtn => ElementFactory.GetButton(By.XPath("//button[@onclick='jsAlert()']"), "Click for JS Alert btn");
        private ILabel successMessageLbl => ElementFactory.GetLabel(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, "You successfully clicked an alert")), "Success message text");


        public BasicAuthPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, PageName)), PageName)
        {
        }

        public void CLickJSAlertBtn() => clickForJSAlertBtn.Click();
        public bool IsSuccessMessageDisplayed() => successMessageLbl.State.IsDisplayed;
        //Commit 1 
        //Commit 2
        //Commit 3
    }
}
