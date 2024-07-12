Feature: Edit Dashboards

User should be able to change name and description of the existing dashboard. 

@Smoke
Scenario: It is possible to change dashboard name
	Given [context]
	When [action]
	Then [outcome]

@Smoke
Scenario: It is possible to change dashboard description
	Given [context]
	When [action]
	Then [outcome]

@Extended
Scenario: It is NOT possible to change dashboard name to already existing one
	Given [context]
	When [action]
	Then [outcome]

@Extended
Scenario Outline: It is NOT possible to change dashboard name to new one having less than three symbols
	Given [context]
	When [action]
	Then [outcome]
Examples: 
| New Name | Expected Message |
| A | Message 1 |
| AB | Message 2 |
