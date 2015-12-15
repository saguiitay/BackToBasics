using System;

namespace BracketsValidation
{
    internal class Program
    {
        private static void Main()
        {
            var inputs = new[]
                {
                    "(1+2)",
                    "(1+[2*3])",
                    "(1+[2)]",
                    "{(1+1)*2}/[3-1)]"
                };

            foreach (var input in inputs)
            {
                var isValid = Validator.IsValid(input);

                Console.WriteLine("{0}: {1} input", input, isValid ? "valid" : "invalid");
            }
        }
    }
}
