Feature: Resources

Scenario: Verify GET Resource response
	Given resource exists
	When user sends GET request
	Then response should be OK

	
Scenario: Verify GET Resource by page response
	Given resource page exists
	When user sends GET request
	Then response should be OK
	
	
Scenario: Verify GET Resouce response if Resouce not found
	Given resource does not exist
	When user sends GET request
	Then response should be NotFound

	