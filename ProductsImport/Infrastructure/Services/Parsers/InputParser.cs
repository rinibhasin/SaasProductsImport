using ProductsImport.Infrastructure.Models;
using System;
using System.Linq;

namespace ProductsImport.Infrastructure.Services.Parsers
{
    public class InputParser : IInputParser
    {
        public InputModel Parse(string input)
        {
            try
            {
                return new InputModel()
                {
                    CompanyName = input.Split(' ').ToArray().Skip(1).Take(1).First()
                };
            }
            catch (Exception)
            {
                throw new Exception("Input format not correct");
            }
        }
    }
}
