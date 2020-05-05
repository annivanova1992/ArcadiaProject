Feature: Navigation
In order to interact with website
As User
I would like to use nav menu

@nav
Scenario Outline: Check navigation menu
Given I am on the <pageName> page
When I click <pageLink> from menu
Then <Page> should be open

Examples:
| pageName | pageLink	| Page |
| About	   | Home		| Home |
| Home	   | About		| About |
| Home	   | Messages	| Messages |
