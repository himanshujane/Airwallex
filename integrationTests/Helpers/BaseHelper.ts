import CryptoJS from "crypto-js";

export class BaseHelper {

    /**
     * @returns {string} Random 5 char String
     */
    static randomString(): string {
        return Math.random().toString(36).substr(2, 12).toLowerCase();
    }

    static randomNumber(): number {
        return Math.floor(Math.random() * (99999999999999 - 10000 + 1)) + 10000;
    }

    /**
     * 
     * @param {string} content 
     * @returns {string} MD5 Hash
     */
    static getHash(content: string): string{
        return CryptoJS.MD5(content).toString();
    }

}