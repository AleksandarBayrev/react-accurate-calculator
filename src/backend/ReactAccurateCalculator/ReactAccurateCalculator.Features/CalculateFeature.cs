using MediatR;
using ReactAccurateCalculator.Interfaces;
using ReactAccurateCalculator.Models;

namespace ReactAccurateCalculator.Features
{
    public class CalculateFeature
    {
        public class CalculateQuery : IRequest<CalculateResponse>
        {
            public string Equation { get; init; }
        }

        public class CalculateQueryHandler : IRequestHandler<CalculateQuery, CalculateResponse>
        {
            private readonly ICalculator calculator;

            public CalculateQueryHandler(ICalculator calculator)
            {
                this.calculator = calculator;
            }

            public async Task<CalculateResponse> Handle(CalculateQuery request, CancellationToken cancellationToken)
            {
                var calculatedEquation = await calculator.Calculate(request.Equation);
                return new CalculateResponse
                {
                    Equation = request.Equation,
                    ResultAsString = calculatedEquation
                };
            }
        }

    }
}