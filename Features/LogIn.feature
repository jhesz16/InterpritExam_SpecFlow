Feature: LogIn

Scenario: Verify user can log in successfully
	Given valid username and password
	When user sends POST request for log in
	Then log in response should be OK
	And Token will be generated

	
Scenario: Verify POST unsuccessful Login request
	Given invalid username and password
	When user sends POST request for log in
	Then log in response should be BadRequest
	And response message should be Missing password
		