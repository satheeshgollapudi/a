Feature: DeleteEmployerSkill
    As a employer
     I can delete a skill

Background: Login as employer
	Given I login as 'employer'
	Then I should be navigated to 'dashBoard' page

@employer @profile @deleteskill
Scenario Outline: Delete Existing Skill
	Given I am on Employer Profile
	And I add the skill with <Name> and <Level>
	When I delete the skill <Name>
	Then the skill <Name> should be deleted sucessfully

	Examples:
		| Name | Level  |
		| C#   | Expert |

@employer @profile @delete @cancelskill 
Scenario Outline: Cancel Deleting Skill
	Given I am on Employer Profile
	And I add the skill with <Name> and <Level>
	When I cancel the skill <Name>
	Then The skill <Name> should be not deleted sucessfully

	Examples:
		| Name | Level  |
		| C#   | Expert |