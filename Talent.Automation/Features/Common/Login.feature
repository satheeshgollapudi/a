Feature: Login
	Features that related to account service

	@valid @talent
Scenario:Login as talent
	Given I login as 'talent'
	Then I should be navigated to 'dashBoard' page

	@valid @recruiter
Scenario:Login as recruiter
	Given I login as 'recruiter'
	Then I should be navigated to 'dashBoard' page

	@valid @employer
Scenario:Login as employer
	Given I login as 'employer'
	Then I should be navigated to 'dashBoard' page

	@invalid
Scenario: Login with invalid credensials
	Given I login with invalid credentials 
	Then I should receive error message "You have entered an invalid username or password"
	And I shouldn't be allowed to login to the website


