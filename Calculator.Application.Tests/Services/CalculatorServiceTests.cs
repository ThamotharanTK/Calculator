using Calculator.Application.Exceptions;
using Calculator.Application.Services;
using Calculator.Application.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Application.Tests.Services
{
    public class CalculatorServiceTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Evaluate_WithEmptyString_ThrowsInvalidInputError(string input)
        {
            ICalculatorService _service = new CalculatorService();
            Assert.ThrowsAsync<InvalidInputException>(async () => await _service.Evaluate(input));
        }
        [Theory]
        [InlineData("2+")]
        [InlineData("3+4/")]
        public async Task Evaluate_WithInvalidString_ThrowsInvalidInputErrorAsync(string input)
        {
            ICalculatorService _service = new CalculatorService();
            await Assert.ThrowsAsync<InvalidInputException>(async () => await _service.Evaluate(input));
        }

        [Theory]
        [InlineData("2+5", 7)]
        [InlineData("1/2", 0.5)]
        public async Task Evaluate_WithValidString_ReturnsResult(string input, double result)
        {
            ICalculatorService _service = new CalculatorService();
            var value = await _service.Evaluate(input);
            Assert.Equal(value, result);
        }
    }
}
