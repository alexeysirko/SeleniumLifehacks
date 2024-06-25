using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    internal class DynamicControlsPage : Form
    {

        private const string PageName = "Dynamic Controls";
        private IButton enableBtn = ElementFactory.GetButton(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, "Enable")), "Statuc Enable");
        private ITextBox inputField = ElementFactory.GetTextBox((By.XPath("//*[@id='input-example']//input")), "input Element");
        public DynamicControlsPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, PageName)), PageName)
        {

        }


        public void clickEnableBtn()
        {
            enableBtn.Click();
        }

        public bool isInputEnabled()
        {
            return inputField.State.WaitForEnabled();
        }

        public void inputText(string text)
        {
            inputField.ClearAndType(text);
        }

        public string getInputTextValue()
        {
            return inputField.Value;
        }
    }
}
