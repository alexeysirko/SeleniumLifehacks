using ExampleProject.Framework.Pages;
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
