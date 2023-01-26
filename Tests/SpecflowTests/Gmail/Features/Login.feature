Feature: Login
	As a use
	I want to login to gmail using my credentials
	So that, after login, inbox page will be visible

@Gmail
@Login
Scenario Outline: User should be able to login to the Gmail successfully
	Given user open gmail login page
	| url                     | language | title |
	| https://mail.google.com | english  | Gmail |
		Then verify that login page opened
	When change page language
		Then verify that page language set correctly
	When insert '<username>' into then email field
	And click next button
		Then verify that page contains password field
	When insert '<password>' into then password field
	And click next button
		Then verify that main page opened successfully and title contains 'inbox'


Examples:
| username          | password     |
| qy54313@gmail.com | Aa123456____ |