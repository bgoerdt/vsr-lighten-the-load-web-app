Feature: Registar 
	As a new user I wish to sign up for this grand website


Scenario: Signup
	Given I am on the signup page
	And I have added "gunnar-m@uiowa.edu" to the Username 
	And I have added "gunnar-m@uiowa.edu" to the email 
	And I have added "gunnar-m@uiowa.edu" to the password 
	And I have added "gunnar-m@uiowa.edu" to the confirm passwork 
	When I press Registar
	Then I should go to the home page 
	

