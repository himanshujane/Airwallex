import { FrameLocator, Locator, Page } from '@playwright/test';
import { BasePage } from './BasePage';

export class HomePage extends BasePage {

    readonly page: Page;

    constructor(page: Page) {
        super(page);
        this.page = page;
    }

    //example
    txtHeaderAmount = (amount: string) => this.page.locator(`<xpath>${amount}`);

    
    async fillInformationAndClickSubmit(card: Dto) {
       <action>
    }

}