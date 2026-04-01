Feature: FindPetsByTags

A feature to test the endpoint /pet/findByTags

Scenario Outline: FindByTags returns correctly with valid individual tags
	Given I call FindByTags with the tag "<tag>"
	Then The responses have status code "200"
	Then There are a greater than 0 number of responses
	Then The pets returned only have tag "<tag>"

Examples:
	| tag              |
	| test1154658254js |
	| test1154658255js |

Scenario Outline: FindByTags returns correctly with multiple statuses
	Given I call FindByTags with the tag "<tags>"
	Then The responses have status code "200"
	Then There are a greater than 0 number of responses
	Then There are pets returned with the multiple tag options of "<tags>"
	Then There are no pets returned outside of the multiple tag options of "<tags>"

Examples:
	| tags                                               |
	| test1154658254js,test1154658255js                  |
	| test1154658254js,test1154658255js,test1154658256js |

Scenario: FindByTags returns correctly with an empty list of pets when unused tag is selected
	Given I call FindByTags with the tag "238615f7-ba30-470b-a1e2-57d6093119eb"
	Then The responses have status code "200"
	Then There are a greater than 0 number of responses
	Then There are no pets returned