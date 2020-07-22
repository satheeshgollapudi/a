 @recruiter
 @employer
Feature: Jobs
	As a recuiter/employer, 
	I should be able to filter, view and manage the jobs.

 @closejob
Scenario Outline: Close job 
	Given I login as '<role>'
	And I navigate to 'jobs' page
	Given I am on Jobs page 
	When I click the job switch button on the first job card
	Then The first job status should update and the job switch button should update
	When I click the job switch button on the first job card
	Then The first job status should update and the job switch button should update
	Examples:
	| role      |
	| recruiter |
	| employer  |

# @searchbyjobtitle
#Scenario Outline: Search job By job title
#	Given I login as '<role>'
#	And I navigate to 'jobs' page
#	Given I am on Jobs page
#	When I add a filter search Job title 'test'
#	Then The results should match the Job Title 'test'
#	Examples: 
#	| role      |
#	| recruiter |
#	| employer  |



