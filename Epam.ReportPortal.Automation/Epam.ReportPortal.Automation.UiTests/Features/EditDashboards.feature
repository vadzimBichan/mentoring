Feature: Edit Dashboards

User should be able to change name and description of the existing dashboard. 

 Background: 
	Given Test User is logged in
 	And   New dashboard is created with properties and opened
	| Name                | Description                |
	| Test Dashboard Name | Test Dashboard Description |

@Smoke
Scenario: It is possible to change dashboard name
	Given User edits dashboard name to 'Updated Dashboard Name' and clicks save changes
	Then  Edit dialog is closed on the Dashboard Page
	And   Dashboard name is displayed as 'Updated Dashboard Name' on the Dashboard Page
	When  User navigates to All Dashboards Page
	Then  Dashboard with name 'Updated Dashboard Name' and description 'Test Dashboard Description' exists in the table on All Dashboards Page
	And   Dashboard with name 'Test Dashboard Name' and description 'Test Dashboard Description' does NOT exist in the table on All Dashboards Page

@Smoke
Scenario: It is possible to change dashboard description
	Given User edits dashboard description to 'Updated Dashboard Description' and clicks save changes
	Then  Edit dialog is closed on the Dashboard Page
	When  User navigates to All Dashboards Page
	Then  Dashboard with name 'Test Dashboard Name' and description 'Updated Dashboard Description' exists in the table on All Dashboards Page
	And   Dashboard with name 'Test Dashboard Name' and description 'Test Dashboard Description' does NOT exist in the table on All Dashboards Page

@Extended
Scenario: It is NOT possible to change dashboard name to already existing one
	Given Additional dashboard is created with properties and opened
	| Name                  | Description                  |
	| Test Dashboard Name 2 | Test Dashboard Description 2 |
	And   User edits dashboard name to 'Test Dashboard Name' and clicks save changes
	Then  Edit dialog is NOT closed on the Dashboard Page
	When  User closes Edit Dashboard dialog on the Dashboard Page
	Then  Dashboard name is still displayed as 'Test Dashboard Name 2' on the Dashboard Page
	When  User navigates to All Dashboards Page
	Then  Dashboard with name 'Test Dashboard Name' and description 'Test Dashboard Description' exists in the table on All Dashboards Page
	And   Dashboard with name 'Test Dashboard Name 2' and description 'Test Dashboard Description 2' exists in the table on All Dashboards Page

@Extended
Scenario Outline: It is NOT possible to change dashboard name to new one having less than three symbols
	Given User edits dashboard name to '<Invalid Dashboard Name>' and clicks save changes
	Then  Edit dialog is NOT closed on the Dashboard Page
	When  User closes Edit Dashboard dialog on the Dashboard Page
	Then  Dashboard name is still displayed as 'Test Dashboard Name 2' on the Dashboard Page
	When  User navigates to All Dashboards Page
	Then  Dashboard with name 'Test Dashboard Name' and description 'Test Dashboard Description' exists in the table on All Dashboards Page
	And   Dashboard with name '<Invalid Dashboard Name>' and description 'Test Dashboard Description' does NOT exist in the table on All Dashboards Page
	Examples:
	| Invalid Dashboard Name |
	| "A"                    |
	| "AB"                   |
	| " "                    |
