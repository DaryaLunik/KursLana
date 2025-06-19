using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace LAN
{
    class Metodist
    {
        static List<Specialty> specialties = new List<Specialty>();
        static List<Department> departments = new List<Department>();
        static List<Discipline> disciplines = new List<Discipline>();

        static string specialtyFile = "specialties.txt";
        static string departmentFile = "departments.txt";
        static string disciplineFile = "disciplines.txt";
        public void AddSpecialty()
        {
            Specialty s = new Specialty();
            Console.Write("Введите код (ключ) специальности: ");
            s.Code = Console.ReadLine();
            Console.Write("Введите название: ");
            s.Name = Console.ReadLine();
            Console.Write("Введите специальность: ");
            s.SpecName = Console.ReadLine();
            Console.Write("Введите форму обучения: ");
            s.Form = Console.ReadLine();
            specialties.Add(s);
            Console.WriteLine("Специальность добавлена.");
        }

        public void DeleteSpecialty()
        {
            Console.Write("Введите код специальности для удаления: ");
            string code = Console.ReadLine();
            for (int i = 0; i < specialties.Count; i++)
            {
                if (specialties[i].Code == code)
                {
                    specialties.RemoveAt(i);
                    Console.WriteLine("Специальность удалена.");
                    return;
                }
            }
            Console.WriteLine("Специальность не найдена.");
        }

        public void AddDepartment()
        {
            Department d = new Department();
            Console.Write("Введите название кафедры: ");
            d.Name = Console.ReadLine();
            Console.Write("Введите факультет: ");
            d.Faculty = Console.ReadLine();
            Console.Write("Введите телефон: ");
            d.Phone = Console.ReadLine();
            Console.Write("Введите код специальности: ");
            d.Specialty = Console.ReadLine();
            departments.Add(d);
            Console.WriteLine("Кафедра добавлена.");
        }

        public void AddDiscipline()
        {
            Discipline d = new Discipline();
            Console.Write("Введите название дисциплины: ");
            d.Name = Console.ReadLine();
            Console.Write("Введите семестр: ");
            d.Semester = Console.ReadLine();
            Console.Write("Введите код специальности: ");
            d.SpecialtyCode = Console.ReadLine();

            d.Hours = new int[3];
            Console.Write("Введите часы лекций: ");
            d.Hours[0] = int.Parse(Console.ReadLine());
            Console.Write("Введите часы семинаров: ");
            d.Hours[1] = int.Parse(Console.ReadLine());
            Console.Write("Введите часы лабораторных: ");
            d.Hours[2] = int.Parse(Console.ReadLine());

            Console.Write("Введите форму отчетности (зачет/экзамен/курсовая): ");
            d.Report = Console.ReadLine();

            disciplines.Add(d);
            Console.WriteLine("Дисциплина добавлена.");
        }

        public void GetDisciplinesBySpecialty()
        {
            Console.Write("Введите код специальности: ");
            string code = Console.ReadLine();
            for (int i = 0; i < disciplines.Count; i++)
            {
                if (disciplines[i].SpecialtyCode == code)
                {
                    Console.WriteLine("Дисциплина: " + disciplines[i].Name);
                }
            }
        }

        public void GetLabHoursBySpecialty()
        {
            Console.Write("Введите код специальности: ");
            string code = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < disciplines.Count; i++)
            {
                if (disciplines[i].SpecialtyCode == code)
                {
                    sum = sum + disciplines[i].Hours[2];
                }
            }
            Console.WriteLine("Сумма лабораторных часов: " + sum);
        }

        public void SemNagr()
        {
            Console.Write("Введите код специальности: ");
            string code = Console.ReadLine();
            bool found = false;
            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].Specialty == code)
                {
                    int sum = 0;
                    for (int j = 0; j < disciplines.Count; j++)
                    {
                        if (disciplines[j].SpecialtyCode == code)
                        {
                            sum = sum + disciplines[j].Hours[0] + disciplines[j].Hours[1] + disciplines[j].Hours[2];
                        }
                    }
                    Console.WriteLine("Кафедра: " + departments[i].Name);
                    Console.WriteLine("Факультет: " + departments[i].Faculty);
                    Console.WriteLine("Семестровая нагрузка: " + sum + " часов");
                    found = true;
                }
            }
            if (!found) Console.WriteLine("Кафедра не найдена.");
        }

        public void GetDisciplinesByDepartment()
        {
            Console.Write("Введите название кафедры: ");
            string name = Console.ReadLine().Trim().ToLower();

            string spec = "";
            bool found = false;

            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].Name.Trim().ToLower() == name)
                {
                    spec = departments[i].Specialty;
                    found = true;
                    break; // кафедра найдена, можно выйти из цикла
                }
            }

            if (!found)
            {
                Console.WriteLine("Кафедра с таким названием не найдена.");
                return;
            }

            bool hasDisciplines = false;
            for (int i = 0; i < disciplines.Count; i++)
            {
                if (disciplines[i].SpecialtyCode == spec)
                {
                    Console.WriteLine("Дисциплина: " + disciplines[i].Name);
                    hasDisciplines = true;
                }
            }

            if (!hasDisciplines)
            {
                Console.WriteLine("Для данной кафедры дисциплины не найдены.");
            }
        }


        public void GetMinMaxDisciplineHours()
        {
            if (disciplines.Count == 0) return;
            int min = disciplines[0].Hours[0] + disciplines[0].Hours[1] + disciplines[0].Hours[2];
            int max = min;
            string minName = disciplines[0].Name;
            string maxName = disciplines[0].Name;

            for (int i = 1; i < disciplines.Count; i++)
            {
                int total = disciplines[i].Hours[0] + disciplines[i].Hours[1] + disciplines[i].Hours[2];
                if (total < min)
                {
                    min = total;
                    minName = disciplines[i].Name;
                }
                if (total > max)
                {
                    max = total;
                    maxName = disciplines[i].Name;
                }
            }
            Console.WriteLine("Мин: " + minName + " (" + min + ")");
            Console.WriteLine("Макс: " + maxName + " (" + max + ")");
        }

        public void GetTotalExamsAndTestsByDepartment()
        {
            int total = 0;
            for (int i = 0; i < disciplines.Count; i++)
            {
                if (disciplines[i].Report == "зачет" || disciplines[i].Report == "экзамен" || disciplines[i].Report == "курсовая")
                {
                    total++;
                }
            }
            Console.WriteLine("Всего экзаменов и зачетов (включая курсовые): " + total);
        }
        public void PrintSpecialties()
        {
            if (specialties.Count == 0)
            {
                Console.WriteLine("Список специальностей пуст.");
                return;
            }
            Console.WriteLine("\nСведения о специальностях:");
            for (int i = 0; i < specialties.Count; i++)
            {
                Console.WriteLine($"Код: {specialties[i].Code}, Название: {specialties[i].Name}, Специальность: {specialties[i].SpecName}, Форма обучения: {specialties[i].Form}");
            }
        }

        public void PrintDepartments()
        {
            if (departments.Count == 0)
            {
                Console.WriteLine("Список кафедр пуст.");
                return;
            }
            Console.WriteLine("\nСведения о кафедрах:");
            for (int i = 0; i < departments.Count; i++)
            {
                Console.WriteLine($"Название: {departments[i].Name}, Факультет: {departments[i].Faculty}, Телефон: {departments[i].Phone}, Код специальности: {departments[i].Specialty}");
            }
        }

        public void PrintDisciplines()
        {
            if (disciplines.Count == 0)
            {
                Console.WriteLine("Список дисциплин пуст.");
                return;
            }
            Console.WriteLine("\nСведения о дисциплинах:");
            for (int i = 0; i < disciplines.Count; i++)
            {
                Console.WriteLine($"Название: {disciplines[i].Name}, Семестр: {disciplines[i].Semester}, Код специальности: {disciplines[i].SpecialtyCode}, Часы (л, с, лб): {disciplines[i].Hours[0]}, {disciplines[i].Hours[1]}, {disciplines[i].Hours[2]}, Отчетность: {disciplines[i].Report}");
            }
        }
        public void PokazatChasyPoDiscipline()
        {
            Console.Write("Введите название дисциплины: ");
            string name = Console.ReadLine();
            foreach (Discipline d in disciplines)
            {
                if (d.Name == name)
                {
                    Console.WriteLine("Лекции: " + d.Hours[0]);
                    Console.WriteLine("Семинары: " + d.Hours[1]);
                    Console.WriteLine("Лабораторные: " + d.Hours[2]);
                }
            }
        }
        // Existing code remains unchanged
        public void LoadData()
        {
            if (File.Exists(Program.speciality))
            {
                string[] lines = File.ReadAllLines(specialtyFile);
                for (int i = 0; i < lines.Length; i++)
                {
                    Specialty s = new Specialty().FromString(lines[i],';');
                    if (s != null)
                        specialties.Add(s);
                }
            }

            if (File.Exists(departmentFile))
            {
                string[] lines = File.ReadAllLines(departmentFile);
                for (int i = 0; i < lines.Length; i++)
                {
                    Department d = new Department().FromString(lines[i], ';');
                    if (d != null)
                        departments.Add(d);
                }
            }

            if (File.Exists(disciplineFile))
            {
                string[] lines = File.ReadAllLines(disciplineFile);
                for (int i = 0; i < lines.Length; i++)
                {
                    Discipline d = new Discipline().FromString(lines[i],';');
                    if (d != null)
                        disciplines.Add(d);
                }
            }
        }
        public void SaveData()
        {
            try
            {
                List<string> sLines = new List<string>();
                for (int i = 0; i < specialties.Count; i++)
                {
                    sLines.Add(specialties[i].ToFileString());
                }
                File.WriteAllLines(Program.speciality, sLines);


                List<string> dLines = new List<string>();
                for (int i = 0; i < departments.Count; i++)
                {
                    dLines.Add(departments[i].ToFileString());
                }
                File.WriteAllLines(Program.departmentFile, dLines);


                List<string> discLines = new List<string>();
                for (int i = 0; i < disciplines.Count; i++)
                {
                    discLines.Add(disciplines[i].ToFileString());
                }
                File.WriteAllLines(Program.disciplineFile, discLines);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


        }
    }
}
