Feature: Validate_Title_Of_The_Article_Matches_With_Title_In_The_Carousel

This feature ensure that title of the carousel matches
with the title of article

@tag1
Scenario: Validate article matches
    Given I navigate to the EPAM website
    When I click on 'Insights' link
    And I click the 'Next' button in the Continuum slider two tims
    And I get the active slider text
    And I click on 'Read More' button
    Then I validate that the Continuum page title matches the active slider text
