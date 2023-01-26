Feature: ComposeMail
	As a user
	I want to be able to open compose new mail dialog
	So that I will be able to see empty dialog opened

Background: 
	Given user logs in to Gmail

@Gmail
@Compose
@LoginRequired
@UI
Scenario: Verify that new mail dialog openet after compose button clicked
	When click compose button
	Then verify that new mail dialog opened
	And verify that all to, subject and body fields are empty
