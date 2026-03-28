Feature: NavigationAndVerification

A short summary of the feature

@tag1
Scenario: I Can Navigate To Processes And Verify The Data
Given I Have Logged In To The Platform
Given I Navigate To The Process Page
Given I Have The Process Stored
When I Filter The Process To Show The Stored Process
When I Open The Correct Process
When I Navigate To SQL Transform Activity Tab
Then I Verify The Data In The Table:
| Country  | ReverseCharge | TaxCode  | TransDate  | APAR   | Gross | Net | VAT | GoodsOrServices |
| Country1 | RevChar1      | TaxCode1 | TransDate1 | AP1AR1 | 15    | 17  | 19  | Goods1          |
| Country2 | RevChar2      | TaxCode2 | TransDate2 | AP1AR2 | 16    | 18  | 20  | Goods2          |

