using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_from_dataset
{
    static class EvaluateVariableType
    {
        public static string Evaluate(string input)
        {
            string output = "string";
            
            if (DateTime.TryParse(input, out var result1)) { output = "DateTime"; }
            if (decimal.TryParse(input, out var result)) { output = "decimal"; }
            if (int.TryParse(input, out var result2)) { output = "int"; }

            if (input == "") { output = "string"; }

            return output;
        }


    }
}
