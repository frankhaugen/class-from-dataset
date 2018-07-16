using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Data;

namespace class_from_dataset
{
    class Program
    {
        public static string DataPath = @"input.csv";
        public static string outputPath = @"output.txt";
        
        public static List<string> inputData = File.ReadLines(DataPath).ToList();
        public static List<string> illigalWords = File.ReadLines(@"ForbiddenWords.txt").ToList();


        public static Dictionary<string, string> HeadersAndTypes = new Dictionary<string, string>();
        
        public static DataTable dt = new DataTable();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (File.Exists(outputPath)) { File.Delete(outputPath); }
            
            GenerateDataTable();
            File.WriteAllLines(outputPath, CreateClass());

            Console.ReadKey();
        }
        
        /// <summary>
        /// This construct a datatable based on the inputted data
        /// </summary>
        static void GenerateDataTable()
        {
            dt.TableName = "TableName"; // Table name required

            // The headers on the columns must be collected
            string[] heads = inputData[0].Replace(" ", "").Split(',');

            // Go through the headers and create datacolumns for the Datatable
            foreach (string head in heads)
            {
                dt.Columns.Add(new DataColumn() { ColumnName = head });
            }

            // Add the remaining data from the inputted data
            for (int i = 1; i < inputData.Count; i++)
            {
                dt.Rows.Add(inputData[i].Replace(" ", "").Split(','));
            }

            // TODO: Rename
            Dictionary<int, string> testDict = new Dictionary<int, string>();
            
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                List<string> testList = new List<string>();
                for (int j = 0; j < 5; j++)
                {
                    testList.Add(Evaluate(dt.Rows[j].ItemArray[i].ToString()));
                }
                
                testDict.Add(i, MostOccurences(testList));
            }

            for (int i = 0; i < testDict.Count; i++)
            {
                HeadersAndTypes.Add(heads[i], testDict[i]);
            }
        }

        // Return the string value most common in a list
        static string MostOccurences(List<string> input)
        {
            string output;

            try
            {
                var groupsWithCounts = from s in input
                                       group s by s into g
                                       select new
                                       {
                                           Item = g.Key,
                                           Count = g.Count()
                                       };

                var groupsSorted = groupsWithCounts.OrderByDescending(g => g.Count);
                string mostFrequest = groupsSorted.First().Item;

                output = mostFrequest;
            }
            catch (Exception e)
            {
                output = e.Message;
            }

            return output;
        }
        

        // Creates the lines of text that represents the class, to be written to file
        static List<string> CreateClass()
        {
            List<string> output = new List<string>();

            string classline = "class ";
            string bracesStart = "{";
            string getset = " { get; set; }";
            string breacesEnd = "}";

            Console.WriteLine(classline);
            output.Add(classline);
            Console.WriteLine(bracesStart);
            output.Add(bracesStart);

            foreach (KeyValuePair<string, string> item in HeadersAndTypes)
            {
                string str = "\tpublic " + item.Value + " " + UppercaseFirst(CheckIfLegal(item.Key)) + getset;

                Console.WriteLine(str);
                output.Add(str);
            }

            Console.WriteLine(breacesEnd);
            output.Add(breacesEnd);

            return output;
        }


        // Evaluate a string and return it's datatype, (default is "string")
        public static string Evaluate(string input)
        {
            string output = "string";

            if (DateTime.TryParse(input, out var result1)) { output = "DateTime"; }
            if (decimal.TryParse(input, out var result)) { output = "decimal"; }
            if (int.TryParse(input, out var result2)) { output = "int"; }

            if (input == "") { output = "string"; }

            return output;
        }


        public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static string CheckIfLegal(string s)
        {
            string output;
            bool legal = true;

            foreach (var item in illigalWords)
            {
                if (s == item)
                {
                    legal = false;
                }
            }

            if (legal) { output = s; }
            else { output = s + "_"; }

            return output;
        }
    }
}
