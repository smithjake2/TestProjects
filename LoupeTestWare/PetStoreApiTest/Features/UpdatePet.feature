Feature: UpdatePet

A feature that tests the endpoint /pet for updating a single pet by Id

@DeletePet
Scenario Outline: UpdateForm can update basic information and return successfully
	Given I have the add pet endpoint with the following parameters
		| Name     | PhotoUrls       | Id   | Category            | Tags                | Status    |
		| testName | photoUrls34test | <id> | testName;1154658257 | testName;1154658257 | available |
	Given I call the add pet endpoint
	Given I call GetPetById with the id "<id>" with success
	When I call UpdatePet and update name to "<updatedName>" and status to "<updatedStatus>"
	When I call GetPetById with the id "<id>" with success
	Then The responses have status code "200"
	Then There are exactly 4 responses
	Then The updated pet returned only has Name "<updatedName>"
	Then The updated pet returned only has status "<updatedStatus>"

Examples:
	| id           | updatedName     | updatedStatus |
	| 563332458748 | updatedTestName | pending       |

@DeletePet
Scenario Outline: UpdateForm can update all information besides id on a pet
	Given I have the add pet endpoint with the following parameters
		| Name     | PhotoUrls       | Id   | Category            | Tags                | Status    |
		| testName | photoUrls34test | <id> | testName;1154658257 | testName;1154658257 | available |
	Given I call the add pet endpoint
	Given I call GetPetById with the id "<id>" with success
	Given I give the Pet the Id "<id>"
	Given I give the Pet the Name "testUpdateName12"
	Given I give the Pet the PhotoUrls "photoUrls34testUpdate"
	Given I give the Pet the Category "testUpdateName;115465825766"
	Given I give the Pet the Tags "testNameUpdate;11546582572"
	Given I give the Pet the Status "sold"
	When I call the update pet endpoint with custom parameters
	Then The responses have status code "200"
	Then There are exactly 3 responses
	Then The updated Pet matches the request

Examples:
	| id           |
	| 563332458748 |

@DeletePet @ExpectedFail
Scenario: UpdateForm returns 404 correctly when pet does not exist
	Given I give the Pet the Id "115465825338875"
	Given I give the Pet the Name "testUpdateName12"
	Given I give the Pet the PhotoUrls "photoUrls34testUpdate"
	Given I give the Pet the Category "testUpdateName;115465825766"
	Given I give the Pet the Tags "testNameUpdate;11546582572"
	Given I give the Pet the Status "sold"
	When I call the update pet endpoint with custom parameters
	Then The responses have status code "404"
	Then The error response includes message "Pet not found"
