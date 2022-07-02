import { ILogger } from "../types";
import { Logger } from "../utils/Logger";

describe('Logger', () => {
    it('logs correctly for given context', () => {
        const originalToIsoString = Date.prototype.toISOString;
        const originalConsoleLog = console.log;
        Date.prototype.toISOString = () => '2000-01-01T00:00:00.000Z';
        console.log = jest.fn((message) => message);
        const logger: ILogger = new Logger('myContext');
        logger.Log('Hello there');
        expect(console.log).toHaveBeenCalledWith('[2000-01-01T00:00:00.000Z] Logger_myContext: Hello there');
        Date.prototype.toISOString = originalToIsoString;
        console.log = originalConsoleLog;
    });
});