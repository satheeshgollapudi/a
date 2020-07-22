@talent
Feature: Profile
	As a talent, 
	I should be able edit and save my profile.
#Note: Profile feature, pages and steps need to be updated once new changes are applied

#@profiledetails
#@contact
#Scenario Outline: Edit Primary Contact Details
#	Given I login as 'talent'
#	And I navigate to 'profile' page
#	Given I am on Profile Page
#	When I edit and save Primary Contact Details as '<FirstName>', '<LastName>', '<Email>', '<Phone>'
#	Then I should see success message
#	Then I should see the profile page display the updated contact details '<FirstName>', '<LastName>', '<Email>', '<Phone>'
#	Given I refresh the page
#	Then I should see the profile page display the updated contact details '<FirstName>', '<LastName>', '<Email>', '<Phone>'
#	Given I reset Primary Contact Details as 'defaultDetails'
#	Examples: 
#	| FirstName | LastName | Email                   | Phone     |
#	| TestTalent| TestMVP  | TestTalent@mvp.studio	 | 123456789 |
#
#@profiledetails 
#@address
#Scenario Outline: Edit Address Details
#	Given I login as 'talent'
#	And I navigate to 'profile' page	
#	Given I am on Profile Page
#	When I edit and save Address as '<Number>', '<Street>', '<Suburb>', '<Country>', '<City>', '<Postcode>'
#	Then I should see success message
#	Then I should see the profile page display the updated address '<Number>', '<Street>', '<Suburb>', '<Country>', '<City>', '<Postcode>'
#	Given I refresh the page
#	Then I should see the profile page display the updated address '<Number>', '<Street>', '<Suburb>', '<Country>', '<City>', '<Postcode>'
#	Given I reset Address as 'defaultDetails'
#	Examples: 
#	| Number | Street       | Suburb    | Country   | City      | Postcode |
#	| 235A   | Queen Street | Melbourne | Australia | Melbourne | 3000     |
#	| 235    | Queen Street | Melbourne | Australia | Melbourne | 3000     |
#
#@profiledetails
#@nationality
#Scenario Outline: Edit Nationality 
#	Given I login as 'talent'
#	And I navigate to 'profile' page
#	Given I am on Profile Page
#	When I edit and save nationality as '<Nationality>'
#	Then I should see success message
#	Then I should see the profile page display the updated nationality '<Nationality>'
#	Given I refresh the page
#	Then I should see the profile page display the updated nationality '<Nationality>'
#	Given I reset Nationality as 'defaultDetails'
#
#	Examples: 
#	| Nationality |
#	| Australia   |
#
#@profiledetails
#@socialmedia
#Scenario Outline: Edit Social Media Accounts
#	Given I login as 'talent'
#	And I navigate to 'profile' page
#	Given I am on Profile Page
#	When I edit and save Social Media Accounts As '<LinkedIn>' '<GitHub>'
#	Then I should see success message
#	Then I should see the profile page display the updated Social Media Accounts '<LinkedIn>' '<GitHub>'
#	Given I refresh the page
#	Then I should see the profile page display the updated Social Media Accounts '<LinkedIn>' '<GitHub>'
#	Given I reset Social Media Acccounts as 'defaultDetails'
#	Examples: 
#	| LinkedIn                               | GitHub                        |
#	| https://www.linkedin.com/in/testtalent | https://github.com/testtalent |
#
#@skills
#@addskills
#@valid
#Scenario Outline: Add a new skill
#	  Given I login as 'talent'
#	  And I navigate to 'profile' page
#	  Given I am on Profile Page
#	  When I add a new skill '<skillName>' '<skillLevel>'
#	  Then I should see success message
#	  Then I should see the skill '<skillName>' '<skillLevel>' in the Skill list 
#	  Given I refresh the page
#	  Then I should see the skill '<skillName>' '<skillLevel>' in the Skill list 
#	  Given I delete the skill '<skillName>'
#	  Examples: 
#	  | skillName | skillLevel   |
#	  | Selenium  | Intermediate |
#	  | C++       | Expert       |
#
#@skills
#@addskills
#@invalid name
#Scenario Outline: Add a new skill with invalid name
#	  Given I login as 'talent'
#	  And I navigate to 'profile' page
#	  Given I am on Profile Page
#	  When I add a new skill '<skillName>' '<skillLevel>'
#	  Then I should see error message 'Please enter valid skill'  
#	  Examples: 
#	  | skillName | skillLevel |
#	  | 123       |            |
#	  | VB        |            |
#
#@skills
#@addskills
#@incompletefields
#Scenario: Add a new skill with incomplete fields
#      Given I login as 'talent'
#	  And I navigate to 'profile' page
#	  Given I am on Profile Page
#      When I add a new skill '<skillName>' '<skillLevel>'
#	  Then I should see error message 'Please complete all fields'  
#	  Examples: 
#	  | skillName | skillLevel |
#	  | Selenium  |            |
#	  |           | Beginner   |
#
#@skills
#@duplicateaddskills
#Scenario: Add duplicated skills
#     Given I login as 'talent'
#	 And I navigate to 'profile' page
#	 Given I am on Profile Page
#	 When I add a new skill 'Selenium' 'Intermediate'
#	 Then I should see success message
#	 Then I should see the skill 'Selenium' 'Intermediate' in the Skill list 
#	 When I add a new skill 'Selenium' 'Beginner'
#	 Then I should see error message 'This skill already exist, Please Enter an other Skill.'
#	 Given I delete the skill 'Selenium'
#
#@skills
#@editskills
#Scenario: Edit Skill
#  	  Given I login as 'talent'
#	  And I navigate to 'profile' page
#	  Given I am on Profile Page
#	  When I add a new skill 'Selenium' 'Intermediate'
#	  Then I should see success message
#	  Given I refresh the page
#	  Then I should see the skill 'Selenium' 'Intermediate' in the Skill list
#	  When I update the skill 'Selenium' to 'Python' 'Expert' 
#	  Then I should see success message
#	  Then I should see the skill 'Python' 'Expert' in the Skill list  
#	  Given I refresh the page
#	  Then I should see the skill 'Python' 'Expert' in the Skill list  
#	  Given I delete the skill 'Python'
#
#@skills
#@deleteskills
#Scenario: DeleteSkill
#	  Given I login as 'talent'
#	  And I navigate to 'profile' page
#	  Given I am on Profile Page
#	  When I add a new skill 'Selenium' 'Intermediate'
#	  Then I should see the skill 'Selenium' 'Intermediate' in the Skill list 
#	  Given I delete the skill 'Selenium'
#	  Then I should see success message
#	  Then I should not see the skill 'Selenium' 'Intermediate' in the skill list
#
