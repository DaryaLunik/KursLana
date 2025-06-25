using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LAN
{
    class Program
    {
        //public static string speciality = @"C:\Users\Kab-35-16\Desktop\LAN\txt\Specialty.txt";
        //public static string departmentFile = @"C:\Users\Kab-35-16\Desktop\LAN\txt\Department.txt";
        //public static string disciplineFile = @"C:\Users\Kab-35-16\Desktop\LAN\txt\Discipline.txt";

        public static string speciality = @"C:\Users\Hitech\OneDrive\Рабочий стол\LAN\txt\Specialty.txt";
        public static string departmentFile = @"C:\Users\Hitech\OneDrive\Рабочий стол\LAN\txt\Department.txt";
        public static string disciplineFile = @"C:\Users\Hitech\OneDrive\Рабочий стол\LAN\txt\Discipline.txt";
        static void Main(string[] args)
        {
            Metodist metodist = new Metodist();
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("============== МЕНЮ ==============");
                Console.WriteLine(" 1. Ввести специальности");
                Console.WriteLine(" 2. Показать специальности");
                Console.WriteLine(" 3. Поиск лабораторных часов");
                Console.WriteLine(" 4. Удалить специальность");
                Console.WriteLine("----------------------------------");
                Console.WriteLine(" 5. Ввести кафедры");
                Console.WriteLine(" 6. Показать кафедры");
                Console.WriteLine(" 7. Семестровая нагрузка по спец.");
                Console.WriteLine("----------------------------------");
                Console.WriteLine(" 8. Ввести дисциплины");
                Console.WriteLine(" 9. Показать дисциплины");
                Console.WriteLine("10. Поиск часов по дисциплине");
                Console.WriteLine("11. Дисциплины по кафедре");
                Console.WriteLine("12. Мин/Макс продолжительность");
                Console.WriteLine("13. Экзамены/Зачёты/Курсовые");
                Console.WriteLine("==================================");
                Console.WriteLine("14. Выход");
                Console.WriteLine("==================================");
                Console.Write("Введите номер действия: ");


                string choice;
                choice = Console.ReadLine();
                metodist.LoadData();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        metodist.AddSpecialty();
                        Console.Read();
                        Console.Clear();
                        break;
                    case "2":
                        metodist.PrintSpecialties();
                        Console.Read();
                        Console.Clear();
                        break;
                    case "3":
                        metodist.GetLabHoursBySpecialty();
                        Console.Read();
                        Console.Clear();
                        break;
                    case "4":
                        metodist.DeleteSpecialty();
                        Console.Read();
                        Console.Clear();
                        break;
                    case "5":
                        metodist.AddDepartment();
                        Console.Read();
                        Console.Clear();
                        break;
                    case "6":
                        metodist.PrintDepartments();
                        Console.Read();
                        Console.Clear();
                        break;
                    case "7":
                        metodist.SemNagr();
                        Console.Read();
                        Console.Clear();
                        break;
                    case "8":
                        metodist.AddDiscipline();
                        Console.Read();
                        Console.Clear();
                        break;
                    case "9":
                        metodist.PrintDisciplines();
                        Console.Read();
                        Console.Clear();
                        break;
                    case "10":
                        metodist.PokazatChasyPoDiscipline();
                        Console.Read();
                        Console.Clear();
                        break;
                    case "11":
                        metodist.GetDisciplinesByDepartment();
                        Console.Read();
                        Console.Clear();
                        break;
                    case "12":
                        metodist.GetMinMaxDisciplineHours();
                        Console.Read();
                        Console.Clear();
                        break;
                    case "13":
                        metodist.GetTotalExamsAndTestsByDepartment();
                        Console.Read();
                        Console.Clear();
                        break;
                    case "14":
                        exit = true;
                        metodist.SaveData();
                        break;
                    case "0":
                        return;
                    default: Console.WriteLine("Неверный выбор."); break;
                }
            }
            Console.ReadLine();
        }
    }
}
