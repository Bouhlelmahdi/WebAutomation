Feature: Login
	Login to Navquest with valid and invalid user

@Valid
Scenario: Login With Valid User

	Given Im on the LoginPage
	When I click on HomeLogin
	Then The Redirection Page is loaded
	When I enter a username and a password
		| username | password |
		| sa_lvts  | G##dw#rk |
	And I click on Login
	Then I should be logged in

@tag
Scenario: Login With InValid User
	Given Im on the LoginPage
	When I click on HomeLogin
	Then The Redirection Page is loaded
