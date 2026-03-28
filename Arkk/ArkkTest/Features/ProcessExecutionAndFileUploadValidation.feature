Feature: ProcessExecutionAndFileUploadValidation

Verifies the End-to-End process can be completed

Scenario: I Can Upload Activity And Convert Correctly
	Given I Have Logged In To The Platform
	Given I Navigate Through The Tax Automation Page
	Given I Navigate To Workflows
	When I Click To Create A New Schedule
	When I Create A New Schedule With Basic Information
	When I Navigate To Processes
	When I Filter The Process To Show The Stored Process
	When I Open The Correct Process
	When I Successfully Upload The Activity File
	When I Navigate To SQL Transform Activity Tab
	Then I Verify The Data In The Table:
		| Country  | ReverseCharge | TaxCode  | TransDate  | APAR   | Gross | Net   | VAT   | GoodsOrServices |
		| Country1 | RevChar1      | TaxCode1 | TransDate1 | AP1AR1 | 15.00 | 17.00 | 19.00 | Goods1          |
		| Country2 | RevChar2      | TaxCode2 | TransDate2 | AP1AR2 | 16.00 | 18.00 | 20.00 | Goods2          |