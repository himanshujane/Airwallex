import { APIRequestContext, expect } from "@playwright/test";
import { DatabaseFixture } from "../Fixtures/ApplicationFixtures/DatabaseFixture";
import { Dto } from "../Models/Dto";
import CryptoJS from "crypto-js";

export class AbcHelper {

    readonly request: APIRequestContext;
    readonly databaseFixture: DatabaseFixture;

    constructor(request: APIRequestContext) {
        this.request = request;
        this.databaseFixture = new DatabaseFixture();
    }

    async callEndpoint(payload: Dto) {

        const response = await this.request.post(`https://endpoint`, {
            data: payload
        });
        console.log(await response.json());
        expect(response.ok()).toBeTruthy();
        const dResponse: Dto = await response.json();

        return dResponse;
    }

    createBancontactDataUrl(parameters) {

        const hash = CryptoJS.MD5(Object.values(parameters).join('')).toString();
        return `http://localhost${parameters.abc}`;

    }
}