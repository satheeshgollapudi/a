Feature: Navigation
	As a user
	I should be able to navigate to pages through links

@login
Scenario: Navigate to Login Page by link
	Given I navigate to 'login' page
	Then I should be navigated to 'login' page

@dashboard
@talent
@recruiter
@employer
Scenario: Navigate to Dashboard Page by link
	Given I login as '<role>'
	And I navigate to 'dashboard' page
	Then I should be navigated to 'dashboard' page
	Examples: 
	| role      |
	| talent    |
	| employer  |
	| recruiter |

@profile
@talent
Scenario: Navigate to Profile Page by Link
	Given I login as 'talent'
	And I navigate to 'profile' page
	Then I should be navigated to 'profile' page

@jobWatchList
@talent
Scenario: Navigate to jobs watch list Page by Link
	Given I login as 'talent'
	And I navigate to 'jobs watch list' page
	Then I should be navigated to 'jobs watch list' page

@jobs
@employer
@recruiter
Scenario Outline: Navigate to jobs Page by Link
	Given I login as '<role>'
	And I navigate to 'jobs' page
	Then I should be navigated to 'jobs' page
	Examples: 
	| role      |
	| employer  |
	| recruiter |

#@talentfeed
#@employer
#@recruiter
#Scenario Outline: Navigate to talent feed Page by Link
#	Given I login as '<role>'
#	And I navigate to 'talent feed' page
#	Then I should be navigated to 'talent feed' page
#	Examples: 
#	| role      |
#	| employer  |
#	| recruiter |