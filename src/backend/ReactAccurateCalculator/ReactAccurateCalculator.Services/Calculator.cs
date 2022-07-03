using ReactAccurateCalculator.Interfaces;
using AngouriMath;
using AngouriMath.Extensions;

namespace ReactAccurateCalculator.Services
{
    public class Calculator : ICalculator
    {
        private readonly ILogger logger;

        public Calculator(ILogger logger)
        {
            this.logger = logger;
        }

        public async Task<string> Calculate(string equation)
        {
            await logger.Log(nameof(Calculator), $"Calculating equation {equation}");
            Entity.Number.Complex result = await EvalNumericalAsync(equation);
            var parsedResult = await ParseToDecimalAsync(result);
            var asString = parsedResult.ToString();
            await logger.Log(nameof(Calculator), $"Finished calculating equation {equation}, result = {asString}");
            return asString;
        }

        private Task<Entity.Number.Complex> EvalNumericalAsync(string equation)
        {
            return Task.FromResult(equation.EvalNumerical());
        }

        private Task<decimal> ParseToDecimalAsync(Entity.Number.Complex complexNumber)
        {
            return Task.FromResult(((decimal)complexNumber));
        }
    }
}