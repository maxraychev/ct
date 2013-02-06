Feature: SetUpAndLaunchNewProject
	I want to be able to create a new project
	And launch it with no questionnaries set
@newProject
Scenario: Create a new project	
	When I create a new project with name: "My Test Project"
	Then I should see that "My Test Project" displayed
	And I should see that project status indicator text is: "Project status: Design"
	And I should see the error message "Questionnaire is required" on attempt to launch the proejct
