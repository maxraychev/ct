Feature: BuyQuestionnarie
	In order to add some questionnary to my project
	I want to be able to buy some in the Marketplace

@buyQuestionnary
Scenario: Buy Demographic Information Quest
	Given that I navigagete to "Marketplace / quests"
	And should be able to see "Demographic information" in the free quests
	When I buy the "Demographic information" quest
	Then I should see the message: "Free item was copied successfully."
	And I should see the "Demographic information" in my questlist
