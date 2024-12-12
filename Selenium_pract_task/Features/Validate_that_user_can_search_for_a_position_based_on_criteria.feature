Feature: Validate_that_user_can_search_for_a_position_based_on_criteria

This feature ensure that user can search for a position base on criteria
based on several different positions

@tag1
Scenario Outline: Validate position search based on criteria
	Given I navigate to the EPAM website
	When I click on the 'Careers' link in the main navigation menu
	And I check the remout check box
	And I fill input search field with programming language <programinLanguage>
	And I select 'All Locations' in location drop down menu
	Then I click button 'Find'
	And I click button 'View and apply' on the last element found
	And I verify job title contains programmin language <programinLanguage>
Examples:
	| programinLanguage | 
    | Java | 
    | .Net | 
	| JavaScript | 