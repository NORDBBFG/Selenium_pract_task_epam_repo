Feature: Validate_navigation_to_services_section

This feature ensure that 'Services' section contains proper information
using several categories as an example

@tag1
Scenario Outline: Validate services section
	Given I navigate to the EPAM website
	When I click on the 'Services' link in the main navigation menu
	And I click on a specific service category <text> from the Services dropdown
	Then I validate that the page contains the correct title: <text>
	And I validate that the section 'Our Related Expertise' is displayed on the page
Examples: 
    | text          | 
    | Generative AI | 
    | Responsible AI | 