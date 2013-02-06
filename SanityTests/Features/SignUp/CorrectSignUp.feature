 Feature: CorrectSignUp
	In order to use all the CoolTool features
	I want to create a new account
	And I want to be logged in immedieately 
@newUser
Scenario: Correct SignUp
	Given I have gmail test account with email: "cooltooltestlogin@gmail.com" and password: "12#%cooltooltestlogin"
	When I use these for creation of new account 
	Then I should see an alert box with message: "Account has been created. Please check you email for an activation link."
	And I should see the link to my profile with my name
	And I should see "Your First Test Project" on my dashboard
	And on attempt to launch this project I should see the message: "Your email is not confirmed. You will not be able to start a project or sell items in marketplace. Please check you email for an activation link."
Scenario: Validate Connfirmation
	When  I open the confirmation e-mail and click the confirmation link
	Then I should be redirected to my CoolTool home page
	And I should be able to launch the sample project seeing dialog box with text "Your project launched. Thank you!"
	And I should see that project status indicator contains text "Project status: Run"

