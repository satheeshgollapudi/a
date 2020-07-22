@employer
Feature: Add Article
	As an employer,
	I should be able to add article scheduler

@AddArticleScheduler @ValidInput
Scenario: Add a new template
	Given I login as 'employer'
	And I navigate to 'article scheduler' page
	Given I am on ArticleSheduler page
	Then I clicked on Add template button
	And I entered template name and description
	Then I search for an article and choosed it
	And I Added rules to the template
	Then I saved the template
	Then the record should be added to the list succesfully

@NegativeTestCase @WithoutAnArticle
Scenario:Add a new template without an article
	Given I login as 'employer'
	And I navigate to 'article scheduler' page
	Given I am on ArticleSheduler page
	Then I clicked on Add template button
	And I entered template name and description
	Then I saved the template
	Then  the record should not be added to the list

@WithoutAddRules
Scenario:Add a new template without an AddRule
	Given I login as 'employer'
	And I navigate to 'article scheduler' page
	Given I am on ArticleSheduler page
	Then I clicked on Add template button
	And I entered template name and description
	Then I search for an article and choosed it
	Then I saved the template
	Then the record should be added to the list succesfully