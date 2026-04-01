Feature: DeletePet

A feature that tests the endpoint /pet/{id} for deleting a single pet by Id

Scenario Outline: DeletePet returns correctly and deletes the pet
	Given I have the add pet endpoint with the following parameters
		| Name     | PhotoUrls       | Id   | Category            | Tags                | Status    |
		| testName | photoUrls34test | <id> | testName;1154658257 | testName;1154658257 | available |
	Given I call the add pet endpoint
	Given I call GetPetById with the id "<id>" with success
	When I call DeletePetById with the id "<id>"
	Then The responses have status code "200"
	Then There are exactly 3 responses
	Then The error response includes message "<id>"
	Then The error response includes code 200

Examples:
	| id            |
	| 1154658257888 |

Scenario: DeletePet returns 404 when the id cannot be found
	Given I call DeletePetById with the id "1256487965321"
	Then The responses have status code "404"
