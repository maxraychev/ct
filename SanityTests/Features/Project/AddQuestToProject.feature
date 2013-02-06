Feature: AddQuestToProject
	In order to use my project
	I want to add bought questionnarie to the project

@addQuest
Scenario: Add a Demographic information quest to My Test Project
	Given I have "My Test Project" avaialble in my projects list
	And I have no questionnaries set to it
	When I open "My questionnaires" list
	And click "set as current" for "Demographic information" quest
	Then I should see that "Demographic information" quest added to "My Test Project"
