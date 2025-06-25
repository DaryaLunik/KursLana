using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace LAN
{
    class Discipline
    {
        private string name;
        private string semester;
        private string specialtyCode;
        private int[] hours; // [0] - лекции, [1] - семинары, [2] - лабораторные
        private string report;

        public Discipline() { }
        public string Name { get => name; set => name = value; }
        public string Semester { get => semester; set => semester = value; }
        public string SpecialtyCode { get => specialtyCode; set => specialtyCode = value; }
        public int[] Hours { get => hours; set => hours = value; }
        public string Report { get => report; set => report = value; }

        public Discipline(string name, string semester, string specialtyCode, int[] hours, string report)
        {
            this.Name = name;
            this.Semester = semester;
            this.SpecialtyCode = specialtyCode;
            this.Hours = hours;
            this.Report = report;
        }

        // Метод для чтения из строки файла
        public static Discipline FromFileString(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return null;

            string[] parts = line.Split(';');
            if (parts.Length != 7)
                return null;

            return new Discipline
            {
                Semester = parts[0],
                Name = parts[1],
                SpecialtyCode = parts[2],
                Hours = new int[]
        {
            int.Parse(parts[3]),
            int.Parse(parts[4]),
            int.Parse(parts[5])
        },
                Report = parts[6]
            };
        }
        public string ToFileString()
        {
            return $"{Semester};{Name};{SpecialtyCode};{Hours[0]};{Hours[1]};{Hours[2]};{Report}";
        }

        internal Discipline FromString(string data, char delimiter)
        {
            var arrayData = data.Split(delimiter);
            return new Discipline()
            {
                Semester = arrayData[0],
                Name = arrayData[1],
                SpecialtyCode = arrayData[2],
                Hours = new int[]
        {
            int.Parse(arrayData[3]),
            int.Parse(arrayData[4]),
            int.Parse(arrayData[5])
        },
                Report = arrayData[6]
            };
        }

    }
}
