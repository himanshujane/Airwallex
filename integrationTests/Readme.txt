Commands to run testsuite

Make sure you are in the correct directory
>cd /payment-view/test/integrationTests

Make sure to install all the dependencies
> npm install

To run in headed mode with number of parallel tests=4 [Default is 4 set in playwright.config.ts]
> npx playwright test --headed --workers 4

To run in headless mode with number of parallel tests=4
> npx playwright test

To run specific test - pass the testname
> npx playwright test --headed -g <testname or any string matching the testname>

To view report
> npx playwright show-report

Notes:
Visual Test will only run successful in headless mode.