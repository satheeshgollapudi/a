Feature: AddEmployerSkill
    As a employer
     I can add a skill

Background: Login as employer
	Given I login as 'employer'
	Then I should be navigated to 'dashBoard' page

#------------Positive Scenarios---------------------#
@employer @profile @addskill
Scenario Outline: Add a Skill
	Given I am on Employer Profile
	When I add a skill <Name> and level <Level>
	Then the skill <Name> should be added sucessfully

	Examples:
		| Name | Level  |
		| C#   | Expert |

@employer @profile @cancelskill
Scenario Outline: Cancel the adding skill
	Given I am on Employer Profile
	When I cancel a skill <Name> and level <Level>
	Then The skill <Name> should not be added successfully

	Examples:
		| Name | Level  |
		| Java | Expert |

#-------------------End Postive Scenario--------------------#

#------------Negative Scenarios-----------------------------#
@employer @profile @duplicateskill
Scenario Outline: Add a Duplicate Skill
	Given I am on Employer Profile
	And I add the skill with <Name> and <Level>
	When I add the same skill <Name> and level <Level>
	Then A error message 'This skill already exist, Please Enter an other Skill.' should be displayed
	And The skill <Name> should not be added successfully

	Examples:
		| Name | Level  |
		| C#   | Expert |

@employer @profile @incompletefield
Scenario Outline: Add a Skill with incomplete fields
	Given I am on Employer Profile
	When I add a skill <Name> and level <Level>
	Then A error message 'Please complete all fields.' should be displayed

	Examples:
		| Name | Level  |
		| Java |        |
		|      | Expert |

@employer @profile @invalidskill
Scenario Outline: Add a Skill with invaild values
	Given I am on Employer Profile
	When I add a skill <Name> and level <Level>
	Then The skill <Name> should not be added successfully

	Examples:
		| Name        | Level        |
		| !2we        | Expert       |
		| 99(??...,,) | Intermediate |

@employer @profile @addshortskill
Scenario: Add a skill with some description
	Given I am on Employer Profile
	When I add a skill more than 30 characters
	Then The skill should added with only 30 characters

#------------End Negative Scenarios----------------------------#