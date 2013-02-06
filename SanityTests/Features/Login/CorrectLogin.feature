Feature: CorrectLogin
	As a registered user I should be able to login and proceed to My Projects page
@login
Scenario: Correct Login as a registered user
	When I loging in with correct email:"maxray@ukr.net" and password "qa1234qa"
	Then I should see My Projects
