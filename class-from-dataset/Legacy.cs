using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace class_from_dataset
{
    class Legacy
    {
        /*
        static void GenerateDictionary()
        {


            string[] headersArray = headers.Split(',');
            string[] valuesArray = values.Split(',');

            for (int i = 0; i < headersArray.Length; i++)
            {
                keyValuePairs.Add(headersArray[i], EvaluateVariableType.Evaluate(valuesArray[i]));
            }
        }

        static void GetDataSamples()
        {
            dataSamples = inputData.GetRange(1, 5);
        }

        static List<string> GetHeaders(string input)
        {
            List<string> output = input.Replace(" ", "").Split(',').ToList<string>();

            return output;
        }


        public static void TestXXX(string[] input)
        {
            // Dict< key(row), Dict< key(cell), Value)> >

            List<Dictionary<int, string>> rows = new List<Dictionary<int, string>>();

            for (int i = 1; i < input.Length; i++)
            {
                Dictionary<int, string> cells = new Dictionary<int, string>();

                string[] cellArray = input[i].Split(',');

                for (int j = 0; j < cellArray.Length; j++)
                {
                    cells.Add(j, cellArray[j]);
                }

                rows.Add(cells);
            }

            Console.WriteLine(rows.ToString());

            Dictionary<int, string> types = new Dictionary<int, string>();

            foreach (Dictionary<int, string> row in rows)
            {
                for (int i = 0; i < row.Count; i++)
                {
                    row[i] = Evaluate(row[i]);
                }
            }

        }
        */
    }
}
