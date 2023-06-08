Feature: Google Search
	 Scenario Outline: Search for <term> in Google Search
		Given I have Google Search home page open in my browser
		When I search for <term>
		Then I am at the results page.
		Examples:
		| term              |
		| panda             |
		# | piña colada       |
		# | rumba samba mambo |
		# | gorilla           |
		# | dinosaur          |
