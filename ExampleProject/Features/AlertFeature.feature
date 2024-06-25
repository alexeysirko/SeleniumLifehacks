Feature: AlertFeature

A short summary of the feature
@tag1
Scenario: Alert Handling
Given I go to 'JavaScript Alerts' on the Main Page
When I generate JS alert on the Javascript alert page
And I accept the alert
Then Success message displayed on the alert page
