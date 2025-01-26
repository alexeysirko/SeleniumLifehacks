Feature: SpecFlowKP

Scenario: Calculate date in the future
Given today is 2024-06-25
When I add in 3 days
Then the date should be 2024-06-28


Scenario: Vertical table example
When I entered the following hero information:
    | Field           | Value     |
    | Name            | Pudge     |
    | Birthdate       | 2/2/2003  |
    | Occupation      | Butcher   |
    | Favorite Weapon | Meat Hook |
    | Health          | 670       |

Then Hero information is equal to:
| Name  | Birthdate | Occupation | Favorite Weapon | Health |
| Pudge | 2/2/2003  | Butcher    | Rot             | 9999   |