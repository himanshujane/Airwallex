# Airwallex

## Overview of framework

This test framework is designed using a feature-rich xUnit test framework and for API calls .Net inbuilt class HttpClient is used. It is written in c# language. For assertion xUnit inbuilt class Assert is used.

###Required Software and tools

- .Net: Version - 5.0
- xUnit: Version - 2.4.1

## How to install and run the API test suite
###Prerequisite

One should make sure .Net (v5.0) is installed on your operating system. Install from this site - [Click here]()

###Instructions to run the API test suite

- Open the test suite in any code editor
- Open the terminal and hit the following command 

Note: This will internally build the project and run all the tests in parallel
```
dotnet test --logger "console;verbosity=normal"
```
###To view only failed tests during run.
```
dotnet test --logger "console;verbosity=minimal"
```

###To run all the tests on different environment
[Environment details defined in appsettings.Testing.json]

```
TestEnvironment=Staging dotnet test
```