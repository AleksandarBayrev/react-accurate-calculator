using ReactAccurateCalculator.Interfaces;
using ReactAccurateCalculator.Models;

namespace ReactAccurateCalculator.Services
{
    public class Calculator : ICalculator
    {
        private readonly IList<decimal> numbers;
        private readonly IList<MathOperation> mathOperations;

        public Calculator()
        {
            this.numbers = new List<decimal>();
            this.mathOperations = new List<MathOperation>();
        }

        private async Task ClearCollections()
        {
            await Task.WhenAll(
                Task.Run(() => this.numbers.Clear()),
                Task.Run(() => this.mathOperations.Clear())
            );
        }

        public async Task<decimal> Calculate(string equation)
        {
            decimal result = 0;
            equation.Split().ToList();
            await ClearCollections();
            return result;
        }
    }
}