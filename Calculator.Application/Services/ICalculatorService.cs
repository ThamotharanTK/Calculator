using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Application.Services
{
    public interface ICalculatorService
    {
        Task<double> Evaluate(string input);
    }
}
