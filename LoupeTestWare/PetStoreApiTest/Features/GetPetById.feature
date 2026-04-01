Feature: GetPetById

A feature that tests the endpoint /pet/{id} for retrieving a single pet by Id

Scenario: GetPetById returns correctly when a valid Id is used
	Given I call GetPetById with the id "1154658257" with success
	Then The responses have status code "200"
	Then There is exactly 1 response
	Then There is exactly 1 pet returned
	Then The pets returned only have Name "testName"
	Then The pets returned only have status "available"


Scenario: GetPetById returns error when Pet is not found
	Given I call GetPetById with the id "115465899998" with failure
	Then The responses have status code "404"
	Then There is exactly 1 response
	Then There are exactly 0 pets returned
	Then The error response includes message "Pet not found"

	@ExpectedFail
	Scenario: GetPetById returns error when invalid Id format is used
	Given I call GetPetById with the id "asda" with failure
	Then The responses have status code "400"
	Then There is exactly 1 response
	Then There are exactly 0 pets returned