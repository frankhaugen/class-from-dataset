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
        public static string testDataPath = @"input.csv";
        public static string outputPath = @"output.txt";
        
        public static List<string> inputData = new List<string>();

        public static Dictionary<string, string> HeadersAndTypes = new Dictionary<string, string>();
        
        public static DataTable dt = new DataTable();

        static void Main(string[] args)
        {
            if (File.Exists(outputPath)) { File.Delete(outputPath); }
            inputData = CollectInputData();


            GenerateDataTable();
            File.WriteAllLines(outputPath, CreateClass());

            Console.ReadKey();
        }

        static void GenerateDataTable()
        {
            dt.TableName = "Stars";
            string[] heads = inputData[0].Replace(" ", "").Split(',');

            foreach (string head in heads)
            {
                dt.Columns.Add(new DataColumn() { ColumnName = head });
            }

            for (int i = 1; i < inputData.Count; i++)
            {
                dt.Rows.Add(inputData[i].Replace(" ", "").Split(','));
            }

            Dictionary<int, string> testDict = new Dictionary<int, string>();

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                List<string> testList = new List<string>();
                for (int j = 0; j < 500; j++)
                {
                    testList.Add(EvaluateVariableType.Evaluate(dt.Rows[j].ItemArray[i].ToString()));
                    
                }
                
                testDict.Add(i, MostOccurences(testList));
            }

            for (int i = 0; i < testDict.Count; i++)
            {
                HeadersAndTypes.Add(heads[i], testDict[i]);

                Console.WriteLine(testDict[i]);
            }
        }

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

        static List<string> CollectInputData()
        {
            List<string> output = new List<string>();

            output = File.ReadLines(testDataPath).ToList();

            return output;
        }


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
                string str = "\tpublic " + item.Value + " " + StringUtilities.UppercaseFirst(StringUtilities.CheckIfLegal(item.Key)) + getset;

                Console.WriteLine(str);
                output.Add(str);
            }

            Console.WriteLine(breacesEnd);
            output.Add(breacesEnd);

            return output;
        }
    }
}
