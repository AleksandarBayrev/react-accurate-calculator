import { ILogger } from "../types";

export class Logger implements ILogger {
    private loggingContext: string;
    constructor(loggingContext: string) {
        this.loggingContext = loggingContext;
        this.Log = this.Log.bind(this);
    }

    public Log(message: string) {
        console.log(`[${new Date().toISOString()}] Logger_${this.loggingContext}: ${message}`);
    }
}