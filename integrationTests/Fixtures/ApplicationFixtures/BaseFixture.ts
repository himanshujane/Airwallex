import { test as base } from '@playwright/test';
import { Page } from '../../PageFactory/Page';
import { DatabaseFixture } from './DatabaseFixture';

// Declare the types of your fixtures.
type Fixtures = {
    xyzPage: XYZPage;
    databaseFixture: DatabaseFixture;
};

// This new "test" can be used in multiple test files, and each of them will get the fixtures.
export const test = base.extend<Fixtures>({

   xyzPage: async ({ page }, use) => {
        // Set up the fixture.
        await use(new XYZPage(page));
    },


    databaseFixture: async ({},use) => {
        // Set up the fixture.
        await use(new DatabaseFixture());
    },

});
export { expect } from '@playwright/test';