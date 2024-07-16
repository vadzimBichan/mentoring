Feature: Edit Dashboards

User should be able to change name and description of the existing dashboard. 

 Background: 
	Given Test User is logged in
 	And New dashboard is created and opened

@Smoke
Scenario: It is possible to change dashboard name
	Given User edits dashboard name to new unique value and clicks save changes
	Then  Edit dialog is closed on the Dashboard Page
	And   Dashboard name is updated on the Dashboard Page
	When  User navigates to All Dashboards Page
	Then  Dashboard name is updated on All Dashboards Page

@Smoke
Scenario: It is possible to change dashboard description
	Given User edits dashboard description to new unique value and clicks save changes
	Then  Edit dialog is closed on the Dashboard Page
	When  User navigates to All Dashboards Page
	Then  Dashboard description is updated on All Dashboards Page

@Extended
Scenario: It is NOT possible to change dashboard name to already existing one
	Given Second dashboard is created and opened
	And   User edits dashboard name to already existing value and clicks save changes
	Then  Edit dialog is NOT closed on the Dashboard Page
	And   Dashboard name is NOT updated on the Dashboard Page
	When  User closes Edit Dashboard dialog on the Dashboard Page
	And   User navigates to All Dashboards Page
	Then  Two original dashboards are displayed on All Dashboards Page

@Extended
Scenario Outline: It is NOT possible to change dashboard name to new one having less than three symbols
	Given User edits dashboard name to invalid <NewName> and clicks save changes
	Then  Edit dialog is NOT closed on the Dashboard Page
	And   Dashboard name is NOT updated on the Dashboard Page
	When  User closes Edit Dashboard dialog on the Dashboard Page
	And   User navigates to All Dashboards Page
	Then  Dashboard name is NOT updated on All Dashboards Page
	Examples:
	| NewName |
	| "A"     | 
	| "AB"    | 
	| " "     | 
