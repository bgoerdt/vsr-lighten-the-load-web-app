Feature: DistributionRules
	In order to manage the distribution rules
	As a user
	I want to be able to view, edit, delete and create distribution rules

Scenario: View Distribution Rules
	Given I am a user
	When I go navigate to /DistributionRules
	Then the result should be a list of distribution rules

Scenario: View Edit Distribution Rules Page
	Given I am a user
	And I have navigated to /DistributionRules
	When I push 'Edit' for a rule
	Then I should see the Edit page

Scenario: Edit Distribution Rules
	Given I am a user
	And I have navigated to /DistributionRules
	And I have pushed 'Edit' for a rule
	When I edit the rule
	Then the updated rule should be seen on the Index page

Scenario: View Create Distribution Rules Page
	Given I am a user
	And I have navigated to /DistributionRules
	When I push 'Create New'
	Then I should see the Create page

Scenario: Create Distribution Rules
	Given I am a user
	And I have navigated to /DistributionRules
	And I have pushed 'Create New'
	When I create a new rule
	Then the new rule should be seen on the Index page

Scenario: View Delete Distribution Rules Page
	Given I am a user
	And I have navigated to /DistributionRules
	When I push 'delete' for a rule
	Then I should see the Delete page

Scenario: Delete Distribution Rules
	Given I am a user
	And I have navigated to /DistributionRules
	And I have pushed 'Delete' for a rule
	When I delete the rule
	Then I should not see the rule on the Index page
