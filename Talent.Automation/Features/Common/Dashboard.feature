Feature: Dashboard
	As a user
	I should be able to navigate to different page through menus.

@Logout
@talent
@employer
@recruiter
Scenario Outline: Logout 
	Given I login as '<role>'
	And I am on Dashboard Page
	When I click logout button
	Then I should be navigated to 'login' page
	Examples: 
	| role      |
	| talent    |
	| employer  |
	| recruiter |

@profile
@talent
Scenario: Navigate to Profile Page by menu
	Given I login as 'talent'
	And I am on Dashboard Page
	When I click on Profile menu
	Then I should be navigated to 'profile' page

@jobswatchlist
@talent
Scenario: Nagivate to Jobs Watch List Page by menu
	Given I login as 'talent'
	And I am on Dashboard Page
	When I click on Jobs watch list menu
	Then I should be navigated to 'jobsWatchList' page

@jobs
@recruiter
@employer
Scenario: Nagivate to Jobs Page by menu
	Given I login as '<role>'
	And I am on Dashboard Page
	When I click on Jobs menu
	Then I should be navigated to 'jobs' page
	Examples: 
	| role      |
	| employer  |
	| recruiter |
