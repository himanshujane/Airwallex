import { BaseHelper } from "../../Helpers/BaseHelper";
import {Dto } from "../../Models/Dto";


export class DataFixture {

    static getdata() {

        var card: Dto =
        {
            CardNumber: "<>",
            Name: "Test Automation",
            ExpiryDate: "<>",
            Cvv: ""
        };
        return card;
    }
}