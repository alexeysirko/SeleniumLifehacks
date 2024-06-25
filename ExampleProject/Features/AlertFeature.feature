Feature: AlertFeature

As a user of the-internet
I want to interact with alerts
To accept important messages

@TC25
Scenario: Alert Handling
Given I go to 'JavaScript Alerts' on the Main Page
When I generate JS alert on the Javascript alert page
And I accept the alert
Then Success message displayed on the alert page

@Status
Scenario: Passing test
Given Test passing step


@Status
Scenario: Fails test
When Test fails

  Scenario Outline: Successful login with valid credentials
    Given I navigate to the login page
    When I enter "<username>" and "<password>"
    Then I should see the welcome message

    Examples:
      | username | password |
      | user1    | pass1    |
      | user2    | pass2    |
      | user3    | pass3    |


Scenario: Calculate date in the future
Given today is 2024-06-25
When I add in 3 days
Then the date should be 2024-06-28