Feature: FindPetsByStatus

A feature to test the API Endpoint /pet/findByStatus

Scenario Outline: FindPetsByStatus returns correctly with individual statuses
	Given I call FindByStatus with the status "<status>"
	Then The responses have status code "200"
	Then There are a greater than 0 number of responses
	Then The pets returned only have status "<status>"

Examples:
	| status    |
	| available |
	| pending   |
	| sold      |

Scenario Outline: FindPetsByStatus returns correctly with multiple statuses
	Given I call FindByStatus with the status "<statuses>"
	Then The responses have status code "200"
	Then There are a greater than 0 number of responses
	Then There are pets returned with the multiple status options of "<statuses>"
	Then There are no pets returned outside of the multiple status options of "<statuses>"

Examples:
	| statuses               |
	| available,pending      |
	| available,sold         |
	| pending,sold           |
	| available,pending,sold |
	| pending,available      |
	| sold,sold              |

	##Fails as API returns 200 regardless of invalid status used. Documentation states 400 when invalid status used
	@ExpectedFail
Scenario: FindPetsByStatus returns 400 when an invalid status is used
	Given I call FindByStatus with the status "123"
	Then The responses have status code "400"
	Then The responses have description of "Invalid status value"

	