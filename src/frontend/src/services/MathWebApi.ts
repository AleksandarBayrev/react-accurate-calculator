import { ILogger, IMathWebApi, MathWebApiCalculateResponse } from "../types";
import fetch from 'node-fetch';
export class MathWebApi implements IMathWebApi {
    private readonly apiUrl: string;
    private readonly logger: ILogger;
    constructor(apiUrl: string, logger: ILogger) {
        this.apiUrl = apiUrl;
        this.logger = logger;
        this.calculate = this.calculate.bind(this);
    }
    public async calculate(expression: string): Promise<MathWebApiCalculateResponse> {
        try {
            this.logger.Log(`Trying to evaulate ${expression} ...`);
            return await fetch(`${this.apiUrl}/calculate`, {
                method: 'POST',
                body: JSON.stringify({
                    equation: expression
                }),
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(async (x) => {
                const result = await x.json();
                this.logger.Log(`${expression} evaluated: ${JSON.stringify(result)}`);
                return result as MathWebApiCalculateResponse;
            });
        } catch(err) {
            throw err;
        }
    }    
}