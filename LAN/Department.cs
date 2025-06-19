using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace LAN
{
    class Department
    {
        private string name;
        private string faculty;
        private string phone;
        private string specialty;

        public Department() { }
        public string Name { get => name; set => name = value; }
        public string Faculty { get => faculty; set => faculty = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Specialty { get => specialty; set => specialty = value; }

        public Department(string name, string faculty, string phone, string specialty)
        {
            this.Name = name;
            this.Faculty = faculty;
            this.Phone = phone;
            this.Specialty = specialty;
        }
        public static Department FromFileString(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return null;

            string[] parts = line.Split(';');
            if (parts.Length != 3)
                return null;

            return new Department
            {
                Specialty = parts[0],
                Name = parts[1],
                Faculty = parts[2],
                Phone = parts[3]
            };
        }

        public string ToFileString()
        {
            return $"{Phone};{Name};{Faculty};{Specialty}";
        }

        internal Department FromString(string data, char delimiter)
        {
            var arrayData = data.Split(delimiter);
            return new Department()
            {
                Specialty = arrayData[0],
                Name = arrayData[1],
                Faculty = arrayData[2],
                Phone = arrayData[3]
            };
        }
    }
}
