### Features
This is a project of my Bsc in Computing from Object Oriented Programmin

It's a Banking System Program on C# and the Features are:
It'll be possible to login as an employee or as a customer
- From the employee side: Create, delete and update customers( also their current and savings account);
- From the customer side: It's possible to login with their full name, account number and pin, see statements, lodge, withdraw and transfer beetween accounts.;

# Banking System

[TOCM]

[TOC]

# How The System Works
At the first screen the user needs to infome if he's a employee of the bank or a user
## Login as Employee
As employee the user will be asked to input a password(A1234), after the successul password the System's will show the options for the employee:
- Create a New Customer;

It'll be necessary provide the First Name, Last Name and Email Address, the program will generate an account number based on the customer full name:
xx-nn-yy-zz where xx is the initials of the customer, nn is the length of the total name (first name and last name), yy is the alphabetical position of the first initial and zz is the alphabetical position of the second initial (see table below same as CHAR starting from 1) - together they make up the pin number.
A	B	C	D	E	F	G	H	I	J	K	L	M	N	O	P	Q	R	S	T	U	V	W	X	Y	Z
1	2	3	4	5	6	7	8	9	10	11	12	13	14	15	16	17	18	19	20	21	22	23	24	25	26
Also, the program will add these data into the customers.txt file and, the program will create two text files, one for the current account and another for savings account following the rule xx-nn-yy-zz-current.txt and xx-nn-yy-zz-savings.txt.
Both text files will store the data on the format:
        Date				Operation	Ammount	Balance
        23-01-2017	Withdrawal	25.67		100.17

- Delete a Customer;

The option to delete a customer will ask for his account number xx-nn-yy-zz( format explained above), after check if current and savings is zero the program will delete the entry of this account number from the customers.txt file and delete the current.txt and savings.txt files of this account.
If the balance is above 0 the systems will shows the balance with a error, trhowing the user to the employee menu.

- Lodge Current Account;

The employee will be able to lodge a current account, the program will ask for the account number and ammount to lodge in.
The program will add the entry to the current.txt account numbers file and update the balance on this file.

- Withdraw Current Account;

The employee will be able to withdraw for a current account, the program will ask for the account number and ammount to withdraw, if the ammount is above the balance of this account an error will appear showing the balance of this customer current account.

- List Customers Data;

The employee will be able to list all the customer with their data( Full name and email)

- List Customers Balance;

The employee also will be able to see all the accounts and their balances for savings and current account.

## Login as User

To login as a user the user will have to input the first name, last name, account number and PIN, if all the data was imputed as the customers.txt file has stored the User System Menu will appear, otherwise the program will show the customer menu again to imput the correct data, as the user logged into the system, the following features is avaiable:

- Retrieve the Transactions History;

This option will show statements of the current and savings account.

- Lodge;

The user will be able to lodge into his account, the program will add the data to the current.txt files of his account number

- Withdraw;

The user will be able to withdraw, the program will check if the current account have suficient balance to withdraw, otherwise will show an error message with the user account current balance.

- Transfer from Current to Savings;

The user will be able to transfer the balance from the Current to Savings, the program will check the suficiente balance and add entries for both current.txt and savings.txt files with the ammount removed and add to the second file.

- Transfer from Savings to Current;

The user will be able to transfer the balance from the Savings to Current, the program will check the suficient balance and add entries for both savings.txt and current.txt files with the ammount removes and add to the second file.

###H3 header
####H4 header
#####H5 header
######License

