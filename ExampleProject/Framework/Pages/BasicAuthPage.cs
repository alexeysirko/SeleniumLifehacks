using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    internal class BasicAuthPage : Form
    {
        private const string PageName = "Basic Auth";

        private readonly ILabel succesMessage = ElementFactory.GetLabel(By.XPath(string.Format(LocatorConstants.PartialTextLocator, "Congratulations! You must have the proper credentials.")), "Success Message");
        public BasicAuthPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, PageName)), PageName)
        {
        }
        
        public bool IsSuccessMessageDisplayed()
        {
            return succesMessage.State.IsDisplayed;
        }
    }
}
