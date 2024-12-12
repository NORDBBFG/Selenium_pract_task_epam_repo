Feature: Validate_File_Download_Function_Works_As_Expected

This feature ensure that download function works and download correct file

@DeleteFile
Scenario: Validate dowload function
	Given I navigate to the EPAM website
	When I click on 'About' link in the main navigation menu
	And I click on 'Download' button
	Then I validate that downloaded file name is 'EPAM_Corporate_Overview_Q4_EOY.pdf'