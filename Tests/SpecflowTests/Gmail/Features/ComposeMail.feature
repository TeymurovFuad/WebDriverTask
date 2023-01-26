Feature: ComposeMail
	As a user
	I want to be able to open compose new mail dialog
	So that I will be able to see empty dialog opened

@Gmail
@Compose
@LoginRequired
Scenario: Verify that new mail dialog openet after compose button clicked
	Given email and password and page details
	| email          | password     | url                     | language | title |
	| qy54313@gmail.com | Aa123456____ | https://mail.google.com | english  | Gmail |
	When click compose button
	Then verify that new mail dialog opened
	And verify that all to, subject and body fields are empty
