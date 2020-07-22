@employer
Feature: Delete Article
	As an employer,
	I should be able to delete a template in article scheduler

@DeleteArticle
Scenario: Delete a template
	Given I login as 'employer'
	And I navigate to 'article scheduler' page
	Given I am on ArticleSheduler page
	Then I click on Delete button
	And I confirmed deletion
	Then the record should be deleted from the list succesfully

@CancelDeleteArticle
Scenario: Cancel Deletion of a template
	Given I login as 'employer'
	And I navigate to 'article scheduler' page
	Given I am on ArticleSheduler page
	Then I click on Delete button
	And I cancel deletion
	Then the record should not be deleted