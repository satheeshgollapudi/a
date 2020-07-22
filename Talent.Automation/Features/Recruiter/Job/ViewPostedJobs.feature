Feature: ViewPostedJobs
	As a recruiter, 
	I can see all the jobs (active or closed) that posted by me

Background: Login as recruiter
	Given I login as 'recruiter'
	Then I should be navigated to 'dashBoard' page

#------------Positive Scenarios---------------------------#
@recruiter
Scenario Outline: View all jobs 
	Given I hover on Job Tab
	When I click on Job
	Then All jobs should be listed successfully 

#-------------------End Postive Scenario--------------------#