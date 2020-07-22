Feature: ArticleManageEmployer
	In order to manage my articles
	As an employer
	I want to add, edit, and delete my articles

@employer
Scenario: Create articles
	Given I login as 'employer'
	And I navigate to 'manage article' page
	When I press the add new article button,fill up all the information and click save button
	Then the new article I just wrote should be shown on the article list

@employer
	Scenario: Edit articles
	Given I login as 'employer'
	And I navigate to 'manage article' page
	When I press the edit button on the first article, update the information of this article
	Then the article's information should be my updated information

	
@employer
	Scenario: Delete articles
	Given I login as 'employer'
	And I navigate to 'manage article' page
	When I press the delete button on the first article
	Then the article should be deleted
