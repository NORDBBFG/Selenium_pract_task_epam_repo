Feature: Validate_global_search_works_as_expected

This feature ensure that global search works as expected
with several different inputs

@tag1
Scenario Outline: Validate global search
	Given I navigate to the EPAM website
	When I click on 'Magnifier' icon
	And I set text <searchFieldValue> to 'Input' search field
	Then I click 'Find' button
	And I validate that all searched links contain <searchFieldValue>
Examples: 
    | searchFieldValue | 
    | BLOCKCHAIN | 
    | Cloud | 
	| Automation | 