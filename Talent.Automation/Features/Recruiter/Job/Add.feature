Feature: Posting a job as Recruiter
	As a recruiter
	I should be able to post a new job

# Assumption here is that since this feature is specifically for a recruiter
# User is assumed to be already logged in as recruiter
Background: 
	Given I am on Job post page


#------------------------------------------------------------------------------------------------
@recruiter @jobs
Scenario: Posting a new job with valid data
	When I post a new job
	Then the job management page displays the newly added job


#------------------------------------------------------------------------------------------------
@recruiter @jobs
Scenario: Cancel posting a job
	When I cancel posting a new job
	Then the job management page does not display the newly added job


#------------------------------------------------------------------------------------------------
@recruiter @jobs
Scenario Outline: Posting a job outside the expected range for years of experience
	When I fill out a job post with a requirement of '<YearsOfExperienceInput>' years of experience
	Then the years of experience is converted to '<SavedYearsOfExperience>'

Examples:
	| YearsOfExperienceInput | SavedYearsOfExperience |
	| -1					 | 0                      |
	| 26                     | 25                     |


#------------------------------------------------------------------------------------------------
@recruiter @jobs
Scenario: Posting a job without entering mandatory fields
	When I post a new job without entering any data
	Then the job is not posted
		And all the mandatory fields are highlighted in red with appropriate error messages


#------------------------------------------------------------------------------------------------
@ignore
@recruiter @jobs
# This does not yet work and requires TC-411 to be done
Scenario Outline: Posting a job with only white-spaces for text fields
	When I post a new job with ' ' for '<Field>'
	Then the job is not posted
		And the error message '<Error>' is displayed


Examples:
	| Field       | Error                            |
	| Title       | Please enter a title for the job |
	| Summary     | Please enter a job summary       |
	| Description | Please enter a job description   |


#------------------------------------------------------------------------------------------------
@recruiter @jobs
Scenario Outline: Posting a job with invalid years of experience
	When I post a new job with a requirement of '<YearsOfExperience>' years of experience 
	Then the job is not posted 
		And the error message 'Please enter the experience' is displayed

Examples:
	| YearsOfExperience |
	| !@#               |
	| two               |
	| ""  ""            |


#------------------------------------------------------------------------------------------------
@recruiter @jobs
Scenario Outline: Posting a job with dates with invalid format
	When I fill out a job post with the following details:
		| StartDate      | EndDate      | ExpiryDate      |
		| <JobStartDate> | <JobEndDate> | <JobExpiryDate> |
	Then those date fields are not changed

Examples:
	| JobStartDate | JobEndDate | JobExpiryDate |
	| 202-01-01    | 202-12-31  | 202-12-31     |
	| 20-01-01     | 20-12-31   | 20-12-31      |
	| 01-01-2020   | 31-12-2020 | 31-12-2020    |
	| 2020/01/01   | 2020/12/31 | 2020/12/31    |
	| 2020-13-31   | 2020-13-31 | 2020-13-31    |
	| 2020-00-01   | 2020-00-01 | 2020-00-01    |
	| 2020-01-32   | 2020-12-32 | 2020-12-32    |