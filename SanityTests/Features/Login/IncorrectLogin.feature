Feature: IncorrectLoginValidation
	I want to ensure that the application doesn't allow to login with unregistered credentials
	Also I want to verify that correct error messages are shown
@incorrectLogin
Scenario: Login with blank Email
	When I perform Login with blank Email
	Then alertBox containing text "Email is required" is displayed
	And after dismiss alertBox I shoud be returned to Login again
