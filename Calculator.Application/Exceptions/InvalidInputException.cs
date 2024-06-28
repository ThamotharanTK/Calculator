using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Application.Exceptions
{
    public class InvalidInputException : Exception
    {   
        public InvalidInputException(string message) : base(message)
        {
            
        }
    }
}
