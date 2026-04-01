Feature: AddPet

A feature to test the endpoint /pet that verifies adding a pet

Scenario: AddPet returns correctly when submitted with valid data
	Given I have the add pet endpoint with the following parameters
		| Name     | PhotoUrls       | Id         | Category            | Tags                | Status    |
		| testName | photoUrls34test | 1154658257 | testName;1154658257 | testName;1154658257 | available |
	When I call the add pet endpoint
	Then The responses have status code "200"
	Then There are a greater than 0 number of responses

Scenario: AddPet creates Pet when submitted with valid data
	Given I give the Pet a valid Guid as the Name
	Given I give the Pet the PhotoUrls "photoUrls34test"
	Given I give the Pet the Category "testName;1154658257"
	Given I give the Pet the Tags "testName;1154658257"
	Given I give the Pet the Status "available"
	Given I give the Pet the Id "1145554"
	When I call the add pet endpoint with custom parameters
	When I get the newly created Pet via the Status and unique Name
	Then The responses have status code "200"
	Then There are exactly 2 responses
	Then The newly created Pet matches the request