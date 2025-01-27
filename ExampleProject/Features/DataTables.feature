Feature: DataTables



Background: 
	Given The main page is opened

Scenario: Sort data dable
	When Click on 'Sortable Data Tables' link
	Then Data Tables page is opened

	When Find "jsmith@gmail.com" value in the "Email" column in the second table and save with key "EMAIL_VALUE"   
	Then Value with key "EMAIL_VALUE" is saved as "jsmith@gmail.com"

	When Sort the table by "First Name" column
	Then Data table is sorted by "First Name" column
		And Value by key "EMAIL_VALUE" is displayed in second table in the "Email" column
		And Save values in the "Last Name" column as list with key "EXPECTED_NAMES":
	| Last Name |
	| Smith     |
	| Bach      |
	| Doe       |
	| Conway    |
