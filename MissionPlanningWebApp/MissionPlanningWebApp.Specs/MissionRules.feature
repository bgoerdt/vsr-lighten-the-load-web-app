Feature: Mission rules

Scenario: View all mission rules
	Given you are on the home page
	And these mission rules exist
	  | ID | ParamIndex | RuleCond | RuleData | EquipIndex | ConstrCond | ConstrRHS |
	  | 0  | 0          | >        | 10       | 0          | =          | 5         |
	  | 1  | 0          | >        | 20       | 0          | =          | 10        |
	  | 2  | 0          | >        | 30       | 0          | =          | 15        |
	When you click "Mission Rules"
	Then the mission rules should be displayed