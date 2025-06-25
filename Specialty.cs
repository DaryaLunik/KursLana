using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace LAN
{
    class Specialty
    {
        private string code;
        private string name;
        private string specName;
        private string form;

        public Specialty() { }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string SpecName { get => specName; set => specName = value; }
        public string Form { get => form; set => form = value; }

        public Specialty(string code, string name, string specName, string form)
        {
            this.Code = code;
            this.Name = name;
            this.SpecName = specName;
            this.Form = form;
        }

        public string ToFileString()
        {
            return $"{Code};{Name};{SpecName};{Form}";
        }


        public static Specialty FromFileString(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return null;

            string[] parts = line.Split(';');
            if (parts.Length != 4)
                return null;

            return new Specialty
            {
                Code = parts[0],
                Name = parts[1],
                SpecName = parts[2],
                Form = parts[3]
            };
        }

        internal Specialty FromString(string data, char delimiter)
        {
            var arrayData = data.Split(delimiter);
            return new Specialty()
            {
                Code = arrayData[0],
                Name = arrayData[1],
                SpecName = arrayData[2],
                Form = arrayData[3]
            };
        }
    }
}
