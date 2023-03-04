# cheque-service

## How to use the service
Using Visual Studio, build and run the service.

The application has a Swagger UI which can be accessed via https://localhost:7278/swagger/index.html or alternatively you can use a url https://localhost:7278/Converter?number=1234 where 1234 is the decimal parameter.

## Unit Tests
The application has a unit test project which has been used to validate the use cases and test.
The test suite can be run through Visual Studio.

## Limitations
At this stage the service will only calculate up to Trillions of Dollars.
There is currently no authorization or authentication built into the service which would pose a security concern in a production environment depending on how it was intended to be used.  Further information would be required around how and where this service was going to be used to better understand the security requirements and implentation.

## Thought process
Please find the ThoughtProcess.md which is a bit of a brain dump and live document as I was planning and working though the solution

This solution took me roughly 5 hours to build including planning and thinking through the solution.