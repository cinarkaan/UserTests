Feature: User Service Tests

As a product owner
In order to keep track of users
I would like to create,delete,update and get users

@Negative
Scenario: Create user which has null value variable
	Given New user who has her/his firstname 'null' and surname 'null' will be created
	Then Create User response will be gotten http code is 'InternalServerError'

@Negative
Scenario: Set the status value of user which is not exist 
	Given The user who is not exist will be initiliazed
	When Status will be updated as 'true'
	Then User status response will be gotten http code is 'InternalServerError'

@Negative
Scenario: Get status from user who is not exist
	Given The user who is not exist will be initiliazed
	When Status value of user will be taken
	Then User status response will be gotten http code is 'InternalServerError'

Scenario: Create user with empty parameters and http code is ok
	Given New user who has her/his firstname '' and surname ' ' will be created
	Then Get create user response http code is 'OK'

Scenario: Create user which has 5 digits lenghts
	Given New user who has her/his firstname '97841' and surname '35064' will be created
	Then Get create user response http code is 'OK'

Scenario: Create user who has his/her attributes speacial chars 
	Given New user who has her/his firstname '-*/*-(?' and surname '?\-_&' will be created
	Then Get create user response http code is 'OK'

Scenario: Create user using only a char
	Given New user who has her/his firstname 'R' and surname 'R' will be created
	Then Get create user response http code is 'OK'

Scenario: Create user which has his/her attributes hundered symbol lenghts with random value
	Given New user will be created as randomly
	Then Get create user response http code is 'OK'

Scenario: Create user which has uppercase char fields
	Given New user who has her/his firstname 'EDWARD' and surname 'DAILY' will be created
	Then Get create user response http code is 'OK'
	
@Negative
Scenario: Delete the user who is not exist 
	Given The user who is not exist will be initiliazed
	When The user who was created will be deleted
	Then Delete user response will be gotten as 'InternalServerError'

#When it created , it's status already will have been as default false  
Scenario: Delete the user which was not activated
	Given New user will be created 
	When Status value of user will be taken
	And The user who was created will be deleted
	Then Delete user response will be gotten as 'OK'

Scenario: Create user and then check out it's default status whether false 
	Given New user will be created
	When Status value of user will be taken
	Then User status will be validated as 'false'

Scenario: Create user and then change it's status value from false to true
	Given New user will be created
	When Status will be updated as 'true'
	And Status value of user will be taken
	Then User status will be validated as 'true'

Scenario: Create user and then change it's status value from false to true then again to false
	Given New user will be created
	When Status will be updated as 'true'
	And Status value of user will be taken
	Then User status will be validated as 'true'
	When Status will be updated as 'false'
	And Status value of user will be taken
	Then User status will be validated as 'false'

Scenario: Create user and then update it's status value four times
	Given New user will be created
	When Status will be updated as 'true'
	And Status value of user will be taken
	Then User status will be validated as 'true'
	When Status will be updated as 'false'
	And Status value of user will be taken
	Then User status will be validated as 'false'
	When Status will be updated as 'true'
	And Status value of user will be taken
	Then User status will be validated as 'true'
	When Status will be updated as 'false'
	And Status value of user will be taken
	Then User status will be validated as 'false'

Scenario: Update the status value of user which is already true again to true  
	Given The user who is already exist will be taken
	When Status value of user will be taken
	Then User status will be validated as 'true'

Scenario: Create user and check the returning value that is whether autoincrement 
	Given The users count which has been created so far will be gotten
	When Last two user will be gotten
	Then User ids will be checked out whether is consecutive




