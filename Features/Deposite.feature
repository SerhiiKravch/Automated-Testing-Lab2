Feature: Deposite
As a customer
I want to login on my account
So that I can access my deposite 

@add_deposite
Scenario: Successful deposite with valid data  
	Given Customer with: <Name>, <Deposite>, <Account_Number>
	When I log in my personal page
	And I choose my Account
	And I press "Deposite" button
	And fill the data
	And submit changes
	Then I receive the messege: Deposite Successful

Examples: 
| Name                 | Deposite | Account_Number |
| 'Harry Potter'       | '1005'   | '1005'         |
| 'Hermoine Granger'   | '10000'  | '1002'         |
| 'Ron Weasly'         | '120'    | '1008'         |
| 'Albus Dumbledore'   | '100'    | '1010'         |
| 'Neville Longbottom' | '1000'   | '1014'         |

@add_deposite_error
Scenario: Unsuccessful deposite with wrong data
	Given Customer with: <Name>, <Deposite>, <Account_Number> 
	When I log in my personal page
	And I choose my Account
	And I press "Deposite" button
	And fill the data
	And submit changes
	Then I don`t receive the messege: Deposite Successful
Examples: 
| Name                 | Deposite | Account_Number |
| 'Harry Potter'       | '-1005'  | '1005'         |
| 'Hermoine Granger'   | ''       | '1002'         |
| 'Ron Weasly'         | '-120'   | '1008'         |
| 'Albus Dumbledore'   | '0'      | '1010'         |
| 'Neville Longbottom' | ''       | '1014'         |