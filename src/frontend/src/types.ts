export type UpdatedWindow = Window & {
    RenderCalculator: (divId: string, configuration: IApplicationConfiguration) => void
}

export interface IApplicationConfiguration {
    apiUrl: string
}