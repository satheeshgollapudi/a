@employer
Feature: Edit Article
	As an employer,
	I should be able to edit article scheduler

@EditArticleScheduler
Scenario: Edit an existing template
	Given I login as 'employer'
	And I navigate to 'article scheduler' page
	Given I am on ArticleSheduler page
	Then I click on Edit button
	And I entered the inputs
	Then I saved the edited template
	Then the record should be edited to the list succesfully

@EditbyDeletingArticlefromtemplate
Scenario: Edit an existing template by deleting the article
	Given I login as 'employer'
	And I navigate to 'article scheduler' page
	Given I am on ArticleSheduler page
	Then I click on Edit button
	And I deleted an article
	Then I saved the edited template
	Then  the edited record should not be added to the list