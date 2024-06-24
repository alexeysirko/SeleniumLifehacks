using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    internal class DynamicControlsPage : Form
    {
        //implement class itself
        public DynamicControlsPage() : base(By.XPath("locator"), "name")
        {
        }
    }
}
