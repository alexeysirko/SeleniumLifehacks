using System;
using TechTalk.SpecFlow;

namespace ExampleProject.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        [Given(@"I navigate to the login page")]
        public void GivenINavigateToTheLoginPage()
        {
            // Code to navigate to the login page
        }

        [When(@"I enter ""(.*)"" and ""(.*)""")]
        public void WhenIEnterUsernameAndPassword(string username, string password)
        {
            Console.WriteLine($"Sensetive information: username is {username}, password is {password}");
        }

        [Then(@"I should see the welcome message")]
        public void ThenIShouldSeeTheWelcomeMessage()
        {
            // Code to verify the welcome message
        }
    }
}
