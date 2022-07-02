export type UpdatedWindow = Window & {
    RenderCalculator: (divId: string, configuration: IApplicationConfiguration) => void
}

export interface ILogger {
    Log: (message: string) => void
}

export interface IApplicationConfiguration {
    apiUrl: string
}