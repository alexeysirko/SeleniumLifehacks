using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    internal class DynamicLoadPage : Form
    {
        private static By _startBtnLocator = By.XPath("//*[@id='start']//button");
        private IButton _startBtn = ElementFactory.GetButton(_startBtnLocator, nameof(_startBtn));
        private ILabel _loadingBar = ElementFactory.GetLabel(By.Id("loading"), nameof(_loadingBar));
        private ILabel _finishLabel = ElementFactory.GetLabel(By.Id("finish"), nameof(_finishLabel));

        public DynamicLoadPage() : base(_startBtnLocator, nameof(DynamicLoadPage))
        {
        }

        public void ClickStartBtn() => _startBtn.Click();
        public bool WaitLoadingBarForDisplayed() => _loadingBar.State.WaitForDisplayed();
        public string GetFinishLabelText()
        {
            _finishLabel.State.WaitForDisplayed();
            return _finishLabel.GetText();
        }
    }
}
