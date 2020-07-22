Feature: TalentUpdateEducationExperienceAndCertificate
	In order to up date some profile infomation
	As a talent
	I want to update my Education, experience and certificate information

@talent
Scenario: update my education experience certificate information as a telant
	Given I login as 'talent'
	And I navigate to 'profile' page
    Then I should able to update my Education information
	Then I should able to update my experience information
	Then I should able to update my certificate information
