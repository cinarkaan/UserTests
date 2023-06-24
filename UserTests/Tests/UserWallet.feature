Feature: User's wallet feature

As a product owner
In order to keep track of users accouts 
I would like to charge,balance,transaction process of user accounts

Background: User will be initialized 
	Given New user will be created as randomly

Scenario: Get transaction count which is 0 amount balance
	When Status will be updated as 'true'
	And The transactions which belongs on this user will be gotten
	Then The transaction will be validated as '0'
	When The balance which belongs on this user will be gotten
	Then The balance will be validated as '0'

Scenario: Get transaction which transaction count is one 
	When Status will be updated as 'true'
	And The user who has just created will be deposited '500' amount
	And The transactions which belongs on this user will be gotten
	Then The transaction will be validated as '1'
	When The balance which belongs on this user will be gotten
	Then The balance will be validated as '500'

Scenario: Get transaction list after request revert operation 
	When Status will be updated as 'true'
	And The user who has just created will be deposited '1200' amount
	And The transaction which is processed last time will be reverted
	And The transactions which belongs on this user will be gotten
	Then The transaction will be validated as '2'
	When The balance which belongs on this user will be gotten
	Then The balance will be validated as '0'

Scenario: Get transaction which is no transaction 
	When Status will be updated as 'true'
	And The transactions which belongs on this user will be gotten
	Then The transaction will be validated as '0'

Scenario: Revert transaction which is equal 10m balance amount
	When Status will be updated as 'true'
	And The user who has just created will be deposited '10000000' amount
	And The transaction which is processed last time will be reverted
	And The transactions which belongs on this user will be gotten
	Then The transaction will be validated as '2'
	When The balance which belongs on this user will be gotten
	Then The balance will be validated as '0'

Scenario: Revert transaction which is equal 0.01m balance amount
	When Status will be updated as 'true'
	And The user who has just created will be deposited '0.01' amount
	And The transaction which is processed last time will be reverted
	And The transactions which belongs on this user will be gotten
	Then The transaction will be validated as '2'
	When The balance which belongs on this user will be gotten
	Then The balance will be validated as '0'
	
Scenario: Make charge -n times amount which is equal to n
	When Status will be updated as 'true'
	And The user who has just created will be deposited '600' amount
	And The balance which belongs on this user will be gotten
	Then The balance will be validated as '600'
	When The user who has just created will be deposited '-600' amount
	And The balance which belongs on this user will be gotten
	Then The balance will be validated as '0'

# n is indicated as 1599 in this scenario
Scenario: Make charge minus n amount which is amount greater to n 
	When Status will be updated as 'true'
	And The user who has just created will be deposited '1600' amount
	And The balance which belongs on this user will be gotten
	Then The balance will be validated as '1600'
	When The user who has just created will be deposited '-1599' amount
	And The balance which belongs on this user will be gotten
	Then The balance will be validated as '1'

Scenario: Make balance request which is equal to 0.01m quantity
	When Status will be updated as 'true'
	And The user who has just created will be deposited '0.01' amount
	And The balance which belongs on this user will be gotten
	Then The balance will be validated as '0.01'

Scenario: Make balance request which has both 0.01 quatity and one transaction
	When Status will be updated as 'true'
	And The user who has just created will be deposited '0.01' amount
	And The balance which belongs on this user will be gotten
	Then The balance will be validated as '0.01'
	When The transactions which belongs on this user will be gotten
	And The transactions which belongs on this user will be gotten
	Then The transaction will be validated as '1'

@Negative
Scenario: Make balance request to user who has just created
	When The balance which belongs on this user will be gotten
	Then The balance status will be given as 'InternalServerError'

@Negative
Scenario: Make balance request from user who is not active 
	When Status will be updated as 'false'
	And The balance which belongs on this user will be gotten
	Then The balance status will be given as 'InternalServerError'

@Negative
Scenario: Get balance -10000000.01 amount from user who has one transaction
	When Status will be updated as 'true'
	And The user who has just created will be deposited '-10000000.01' amount
	Then The charge status will be given as 'InternalServerError'

@Negative
Scenario: Charge balance request which is equal to minus 30
	When Status will be updated as 'true'
	And The user who has just created will be deposited '-30' amount
	Then The charge status will be given as 'InternalServerError'
	
# n is indicated as 170 in this scenario 
@Negative
Scenario: Make charge request which is less than the (n) * (-1) balance which is equal to n  
	When Status will be updated as 'true'
	And The user who has just created will be deposited '170' amount
	And The balance which belongs on this user will be gotten
	Then The balance will be validated as '170'
	When The user who has just created will be deposited '-170.01' amount
	Then The charge status will be given as 'InternalServerError'


# n is indicated as -45 in this scenario
@Negative
Scenario: Make charge n times amount which is equal to -n 
	When Status will be updated as 'true'
	And The user who has just created will be deposited '-30' amount
	Then The charge status will be given as 'InternalServerError'

