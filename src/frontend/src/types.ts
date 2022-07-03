export type UpdatedWindow = Window & {
    RenderCalculator: (divId: string, configuration: IApplicationConfiguration) => void
}

export type LogFunction = 'log' | 'error';

export enum LogLevel {
    Info = "Info",
    Error = "Error"
}

export type MathWebApiCalculateResponse = {
    expression: string;
    resultAsString: string;
}

export interface IMathWebApi {
    calculate(expression: string): Promise<MathWebApiCalculateResponse>
}

export interface ILogger {
    Log: (message: string, level?: LogLevel) => void
}

export interface IApplicationConfiguration {
    apiUrl: string
}