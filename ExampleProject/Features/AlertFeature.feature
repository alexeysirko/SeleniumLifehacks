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
