import { DataFixture as testData } from '../../../Fixtures/DataFixtures/DataFixture';
import { test, expect } from '../../../Fixtures/ApplicationFixtures/BaseFixture';

const data: Dto = testData.getData();

test('User Interface @visual', async ({ testHelper, databaseFixture, page, homePage }) => {

  //Arrange
  let parameters = testData.getParameters();
  await databaseFixture.seed(parameters);
  const url = testHelper.createUrl(parameters);

  //Launch URL
  await page.goto(url);
  await expect(homePage.imgLogo).toBeVisible();

  const shot = await page.screenshot({animations: "disabled", mask: [homePage.txt(parameters.Key)]});
  await expect(shot).toMatchSnapshot();

});