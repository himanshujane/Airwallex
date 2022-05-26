import { DataFixture as testData } from '../../../Fixtures/DataFixtures/DataFixture';
import { test, expect } from '../../Fixtures/ApplicationFixtures/BaseFixture';

test.describe('Test Describe', () => {

  let url;

  test.beforeEach(async ({  }) => {
   payload = testData.getPayload();
    let response = await abcHelper.callEndpoint(payload);
    url = response.data;
  });

  test('Test', async ({ page }) => {

    //Steps
    await page.goto(url);
   
  });

});