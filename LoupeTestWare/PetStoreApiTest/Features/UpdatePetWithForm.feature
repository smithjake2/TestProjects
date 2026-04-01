Feature: UpdatePetWithForm

A feature that tests the endpoint /pet/{id} for updating a single pet by Id

@DeletePet
Scenario Outline: UpdatePet returns correctly when updating a pet
	Given I have the add pet endpoint with the following parameters
		| Name     | PhotoUrls       | Id   | Category            | Tags                | Status    |
		| testName | photoUrls34test | <id> | testName;1154658257 | testName;1154658257 | available |
	Given I call the add pet endpoint
	Given I call GetPetById with the id "<id>" with success
	When I call UpdatePetWithForm with the id "<id>" and update name to "<updatedName>" and status to "<updatedStatus>"
	When I call GetPetById with the id "<id>" with success
	Then The responses have status code "200"
	Then There are exactly 4 responses
	Then The error response includes message "<id>"
	Then The updated pet returned only has Name "<updatedName>"
	Then The updated pet returned only has status "<updatedStatus>"

Examples:
	| id           | updatedName | updatedStatus |
	| 563332458745 | updatedName | sold          |
