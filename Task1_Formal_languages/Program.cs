using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task1_Formal_languages
{
    class Program
    {
        static public string Input(string fileName)
        {
            StringBuilder result = new StringBuilder();

            using (StreamReader file = new StreamReader(fileName))
            {
                result.Append(file.ReadToEnd());
            }

            return result.ToString();
        }
        static void Main(string[] args)
        {
            FiniteStateMachine machine = new FiniteStateMachine("input_json.json");

            string input = Input("inputString.txt");
            int skip = 0;
            while (skip < input.Length)
            {
                KeyValuePair<bool, int> result = machine.MaxString(input, skip);

                if (result.Key == true)
                {
                    string output = input.Substring(skip, result.Value);

                    using (StreamWriter file = new StreamWriter("output.txt", true, Encoding.Default))
                    {
                        file.WriteLine(output);
                    }
                    
                    Console.WriteLine(output);
                    skip += result.Value;
                }
                else
                {
                    skip++;
                }
            }
        }
    }
}
