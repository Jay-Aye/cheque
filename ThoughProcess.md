# Thought Process

## The Task

We require a small C# REST API that can automatically write cheques for us. It may be built with ASP.NET MVC or .NET Core. The service must accept a decimal number via an HTTP endpoint and return the English word equivalent. 

## Approach

- I will take a TDD approach as it will be the quickest way of developing and testing this type of problem.  The task doesn't specifically request unit testing, but as a dev I feel it's important to unit test everything as it makes the dev cycle easier for maintainability.
- I will treat the main branch as production.  Therefore I will create a feature branch and not merge to master until it is ready for production.
- I won't be deploying this application to the cloud therefore I won't be setting up any CICD pipelines.
- There appears to be multiple custom error use cases so validation will be required.
- The task specifically asks for git history so I'll show the stages of my process as I go through that.

## Tasks
- [x] Create repo
- [x] Create feature branch
- [x] Setup cheque api project
- [x] Setup unit test project
- [x] Create NumberConverter Service (maybe think of a better name).  Just the shell at this stage so I can setup the unit tests
- [x] Create unit tests with use cases - Push to branch to show TDD
- [x] Identify unit test cases
- [x] Create the logic for the NumberConverter Service - Push to branch
- [x] Create controller and endpoint for consumption - Push to branch
- [x] Create error handling for use cases - Push to branch
- [ ] Update readme with instructions on use and other relevant information

## Error Handling
Unsure exactly which way is best to handle this at first glance.  I will hold off making any decisions until the NumberConverter Service is complete and I have more information.

## Unit Test Cases
- When there is only one cent or one dollar, return CENT or DOLLAR instead of CENTS or DOLLARS
- When rounding cents, make sure they are rounded down to the closest cent
- When handling large numbers, make sure they process correctly (Millions, Billions, Trillions)

## Solution
The end result of ONE **BILLION** TWO ***HUNDRED*** THIRTY-FOUR **MILLION** FIVE ***HUNDRED*** SIXTY-SEVEN **THOUSAND** EIGHT ***HUNDRED*** NINETY-ONE DOLLARS (1234567891) has a recursive structure to it.
- 1,234,567,891

3 digits will always be a type of hundred so I can use that to build the amount of thousands (million, billion, trillion)
The numbers 1 - 19 are unique and I can use an array and array position for handling conversions.
The multiples of 10 are unique and i can use a seperate array for handling converstions.
