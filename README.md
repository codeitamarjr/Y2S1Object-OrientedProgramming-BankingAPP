### Features
This is a project of my Bsc in Computing from Object Oriented Programming
It is a Banking System Program on C# and the Features are:
- A Welcome login page for employees and customers;
- From the employee side they can: Create, delete and update customers accouns( Lodge, Withdraw and Trasnfer beetwen accounts);
- From the customer side they can: It's possible to login with their name, account and pin, see statements, lodge, withdraw and transfer beetween accounts;

# Banking System
[TOCM]

[TOC]

# How The System Works
## Welcome Screen
At the first screen the user needs to infome if he's a employee of the bank or a customer.
## Login as Employee
As employee the user will be asked to input a password(A1234), after the successul password the System's will shows the options for the employee:
- Create a New Customer;
It'll be necessary provide the First Name, Last Name and Email Address, the program will generate an account number based on the customer full name:
The account number will have the formate xx-nn-yy-zz, where xx is the initials of the customer, nn is the length of the total name (first name and last name), yy is the alphabetical position of the first initial and zz is the alphabetical position of the second initial (see table below same as CHAR starting from 1), together yy-zz they make up the pin number.

A	B	C	D	E	F	G	H	I	J	K	L	M	N	O	P	Q	R	S	T	U	V	W	X	Y	Z

1	2	3	4	5	6	7	8	9	10	11	12	13	14	15	16	17	18	19	20	21	22	23	24	25	26

Also, the program will add the customers data into the customers.txt file and, the program will create two txt files, one for the current account and another one for savings account following the rule xx-nn-yy-zz-current.txt and xx-nn-yy-zz-savings.txt.

Both text files will log each moviment of the account on the format:

        Date	Operation	Ammount	        Balance
        23-01-2017	Starting	0		0
        24-01-2017	Lodgement	100		100
        24-02-2017	Withdraw	-50		50



- Delete a Customer;

The option to delete a customer will ask for his account number xx-nn-yy-zz( format explained above), after check if current and savings is zero the program will delete the entry of this account number from the customers.txt file and delete the current.txt and savings.txt files of this account.
If the balance is above 0 the systems will shows the balance with a error, trhowing the user to the employee menu.

- Lodge Current Account;

The employee will be able to lodge a specific current account, the program will ask for the account number and ammount to lodge, the program will log this moviment to the current.txt file that belongs to this customer, following the log format ( Date + Operation + Ammount + Balance)

- Withdraw Current Account;

The employee will be able to withdraw for a current account, the program will ask for the account number and ammount to withdraw, if the ammount is above the balance of this account, an error will appear showing the balance of this customer current account have not suficient balance to complete the operation.

- List Customers Data;

The employee will be able to list all the customer with their data( Full name and email)

- List Customers Balance;

The employee also will be able to see all the account numbers and their balances for savings and current account.

- List Statemetnts Balance;

The employee will be able to print an account statement of a specific account, the program will ask for the account number and print the current and savings statements( With all the detais: DATA Operation Ammount Balance)


## Login as User
To login as a user, the user will have to input his first name, last name, account number and PIN, if all the data matches with the customers.txt, the User System Menu will appear, otherwise the program will show the customer menu again to imput the correct data.

As the user logged into the system, the following features will be avaiable:

- Retrieve the Transactions History;

This option will show statements of the current and savings account.

- Lodge;

The user will be able to lodge into his current account, the program will add the data to the current.txt files of his account number.

- Withdraw;

The user will be able to withdraw, the program will check if the current account have suficient balance to withdraw(To not be negative), otherwise will show an error message with the user current account balance.

- Transfer from Current to Savings;

The user will be able to transfer an ammount of his balance from the Current to Savings, the program will check the suficiente balance and add logs for both current.txt and savings.txt files, first one will show a negative value and update the balance and the second one will show a transfer as positive value and update balance as well.

- Transfer from Savings to Current;

The user will be able to transfer an ammount of his balance from the Savings to Current, the program will check the suficient balance on his savings account and add logs for both savings.txt and current.txt files.

###H3 header
####H4 header
#####H5 header
######License

