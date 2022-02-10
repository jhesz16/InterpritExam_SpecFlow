Feature: Users Test

Scenario: Verify GET User response if single user found
	Given single user exists
	When user sends GET request
	Then response should be OK
		
Scenario: Verify GET User response if single user not found
	Given user does not exist
	When user sends GET request
	Then response should be NotFound

Scenario: Verify POST User response
	Given user has a payload
	When user sends Post request
	Then response should be Created
	
Scenario: Verify PUT User response  
	Given user has a payload
	When user sends PUT request
	Then response should be OK
	
Scenario: Verify PATCH User response  
	Given user has a payload
	When user sends PATCH request
	Then response should be OK
	
Scenario: Verify DELETE User response if single user not found
	Given single user exists
	When user sends DELETE request
	Then response should be NoContent
	
Scenario:  Verify delayed response
	Given single user exists
	When user sends GET request
	Then response should be OK