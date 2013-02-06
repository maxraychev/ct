Feature: BuyProject
	In order to start my work in CoolTool more quickly
	I want to be able to buy some ready to use project using MarketPlace

@buyProject
Scenario: Buy Employee Satisfaction project
	Given that I navigage to "Marketplace / projects"
	And I should be able to see "Employee satisfaction" in the free projects
	When I buy the project "Employee satisfaction"
	Then I should see the message "Free item was copied successfully."
	And the project "Employee satisfaction" should be available in My projects list
