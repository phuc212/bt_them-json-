using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace bt2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\module2\week3\bt_json\bt2\bt2";
            string input = "data.json";
            string output = "Outcome.json";
            string data;
            using (StreamReader sr = File.OpenText($@"{path}\{input}"))
            {
                data = sr.ReadToEnd();
            }
            StudentList result = JsonConvert.DeserializeObject<StudentList>(data);
            List<ResStudent> resStudents = new List<ResStudent>();
            foreach (Student std in result.students)
            {
                var item = new ResStudent()
                {
                    MaHS = std.MaHS,
                    HoTen = std.HoTen,
                    GioiTinh = std.GioiTinh,
                    Lop = std.Lop,
                    LisMonHoc = std.LisMonHoc
                };
                resStudents.Add(item);
            }
            resStudents.Sort(new SortAverage());
            using (StreamWriter sw = File.CreateText($@"{path}\{output}"))
            {
                sw.Write(JsonConvert.SerializeObject(resStudents));
            }

        }
    }
    class StudentList
    {
        public List<Student> students { get; set; }
    }
    class Student
    {
        public int MaHS { get; set; }
        public String HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string Lop { get; set; }
        public List<MonHocs> LisMonHoc { get; set; }

    }
    class MonHocs
    {
        public string scorename { get; set; }
        public double score { get; set; }
    }
    class ResStudent : Student
    {
        public double Averagescorce => CalculatorAveScore();
        public string Xeploai => XepLoai();
        private double CalculatorAveScore()
        {
            double sum = 0.0;
            foreach (var item in LisMonHoc)
            {
                if (item.scorename.Equals("Toan"))
                {
                    sum += item.score * 2;
                }
                else
                {
                    sum += item.score;
                }
            }
            return sum / 4;
        }
        public string XepLoai()
        {
            double DTB = CalculatorAveScore();

            if (DTB > 9)
            {
                return "xuat sac";
            }
            else if (DTB >= 8)
            {
                return "Gioi";
            }
            else if (DTB >= 7)
            {
                return "kha";
            }
            else if (DTB >= 6.5)
            {
                return "TBK";
            }
            else if (DTB >= 5)
            {
                return "TB";
            }
            else
            {
                return "yeu";
            }
        }
    }
    class SortAverage : IComparer<ResStudent>
    {
        public int Compare( ResStudent x, ResStudent y)
        {
            if (x == null || y == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                if (x.Averagescorce > y.Averagescorce)
                {
                    return -1;
                }
                if (x.Averagescorce == y.Averagescorce)
                {
                    return 0;
                }
                else
                    return 1;
            }
        }
    }
}
