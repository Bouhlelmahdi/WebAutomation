Feature: Mention
Automate a test scenario for the web application at web.mention.com

@LenovoThinkPad
Scenario: Fetch for mentions
	Given Im on mention's website
	When I Login a username and a password
	| username            | password     |
	| ci-test@mention.com | nqkNtTxdgKhJ |
	Then I should see an alert named 'Lenovo Thinkpad' in the sidebar
	And I should see a mention with content '1511 Lenovo ThinkPad'
	When I enter the keyword 'VS HP Pavilion 15-eh1103AU Laptop Comparison' in the search field, and submit the search
	Then I Should see a mention with content '20YES00100'