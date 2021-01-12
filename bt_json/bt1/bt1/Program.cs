using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace bt1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\module2\week3\bt_json\bt1\bt1";
            string inputFile = "input.json";
            string outputFile = "output.json";
            string output = "output1.json";
            string data;
            using (StreamReader sr = File.OpenText($@"{path}\{inputFile}"))
            {
                data = sr.ReadToEnd();
            }
            SerialNumber result = JsonConvert.DeserializeObject<SerialNumber>(data);
            List<ResSum> resNumber = new List<ResSum>();

            foreach (IntegerNumb std in result.input)
            {
                var item = new ResSum()
                {
                    a = std.a,
                    b = std.b,
                    c = std.c
                };
                resNumber.Add(item);
            };
            using (StreamWriter sw = File.CreateText($@"{path}\{outputFile}"))
            {
                sw.Write(JsonConvert.SerializeObject(resNumber));
            }
            for (int i = 0; i < result.input.Count; i++)
            {
                result.input[i].a *= 2;
                result.input[i].b *= 2;
                result.input[i].c *= 2;
            }
            using (StreamWriter sw = File.CreateText($@"{path}\{output}"))
            {
                sw.Write(JsonConvert.SerializeObject(result.input));
            }

        }
    }
    class SerialNumber
    {
        public List<IntegerNumb> input = new List<IntegerNumb>();
    }
    class IntegerNumb
    {
       
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }
    }
    class ResSum : IntegerNumb
    {
        public double tong => average();
        private double average()
        {
            return (a + b + c);
        }
    }
}
