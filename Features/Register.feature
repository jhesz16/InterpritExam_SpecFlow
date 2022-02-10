Feature: Register

Scenario: Verify POST register request
	Given unregistered username and password
	When user sends POST request for register
	Then log in response should be OK
	And Token will be generated

Scenario: Verify POST unsuccessful register request
	Given invalid username and password
	When user sends POST request for register
	Then log in response should be BadRequest
	And response message should be Missing password