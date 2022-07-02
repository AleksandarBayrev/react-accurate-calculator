import { ILogger, LogFunction, LogLevel } from "../types";

export class Logger implements ILogger {
    private loggingContext: string;
    constructor(loggingContext: string) {
        this.loggingContext = loggingContext;
        this.Log = this.Log.bind(this);
    }

    public Log(message: string, logLevel?: LogLevel) {
        console[this.getLogFunction()](`[${new Date().toISOString()}] Logger_${this.loggingContext}: ${message}`);
    }

    private getLogFunction(logLevel?: LogLevel): LogFunction {
        return logLevel && logLevel === LogLevel.Error ? 'error' : 'log';
    }
}