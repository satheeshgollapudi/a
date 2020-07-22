Feature: UpdateEmployerSkill
	As a employer 
	I can update my skill

Background: Login as employer
	Given I login as 'employer'
	Then I should be navigated to 'dashBoard' page

@employer @profile @editskill
Scenario Outline: Update Existing Skill
	Given I am on Employer Profile
	And I add the skill with <Name> and <Level>
	When I edit the old skill <Name> and <Level> with new skill <New Name> and <New Level>
	Then The skill should be sucessfully updated with new skill <New Name> and <New Level>

	Examples:
		| Name | Level  | New Name | New Level |
		| Java | Expert | Phython  | Beginner  |

@employer @profile @update @cancelskill
Scenario Outline: Cancel the Editing Skill
	Given I am on Employer Profile
	And I add the skill with <Name> and <Level>
	When I cancel the old skill <Name> and <Level> with new skill <New Name> and <New Level>
	Then The skill <Name> should not be sucessfully updated with new skill <New Name> and <New Level>

	Examples:
		| Name | Level  | New Name | New Level |
		| Java | Expert | C#       | Beginner  |