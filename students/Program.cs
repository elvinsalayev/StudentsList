using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
namespace Generics.First
{
    internal class Program
    {
        static string fileName = @"students.dat";

        [Obsolete]
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine(@"








");
            string logo = (@"
                                  _____ _             _            _           _ _     _   
                                 /  ___| |           | |          | |         | (_)   | |  
                                 \ `--.| |_ _   _  __| | ___ _ __ | |_ ___    | |_ ___| |_ 
                                  `--. \ __| | | |/ _` |/ _ \ '_ \| __/ __|   | | / __| __|
                                 /\__/ / |_| |_| | (_| |  __/ | | | |_\__ \   | | \__ \ |_ 
                                 \____/ \__|\__,_|\__,_|\___|_| |_|\__|___/   |_|_|___/\__|
                                                                                                                
");
            Console.WriteLine(logo);
            Thread.Sleep(1500);
            bool hasCancel = false;

            GenericStore<Student> studentsList = LoadFromFile(fileName);

            while (hasCancel != true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.WriteLine(logo);

                Console.ForegroundColor = ConsoleColor.DarkYellow;

                PrintMenu();

                int selectedMenu = ReadInteger(@"    

                                                 Please select operation from menu: 

                                                                 ");



                switch (selectedMenu)
                {


                    case 1:
                        {
                            Console.Clear();
                            Student student = new Student();

                            Console.Write("Name of student: ");
                            student.Name = Console.ReadLine();

                            Console.Write("Surname of student: ");
                            student.Surname = Console.ReadLine();

                            student.Age = ReadInteger("Age of student: ");

                            Console.Write("Sex of student: ");
                            student.Sex = Console.ReadLine();

                            student.School = ReadInteger("School: ");

                            Console.Write("Class: ");
                            student.Class = Console.ReadLine();

                            studentsList.Add(student);
                            break;
                        }
                    case 2:
                        {

                            Console.Clear();
                            Console.WriteLine("[List of students]");
                            for (int i = 0; i < studentsList.Length; i++)
                            {
                                Student s = studentsList[i];

                                Console.WriteLine($"{i}.{s}");
                            }
                            int index = ReadInteger("Which student would you like to remove from list?: ");
                            studentsList.RemoveAt(index);
                            goto case 3;
                        }
                    case 3:
                        Console.Clear();
                        Console.WriteLine("List of Students");
                        foreach (var item in studentsList)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("Press any key to return menu");
                        Console.ReadKey();
                        break;
                    case 4:
                        SaveToFile(studentsList, fileName);
                        break;
                    case 5:
                        SaveToFile(studentsList, fileName);
                        hasCancel = true;
                        break;
                    case 6:
                        hasCancel = true;
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }
        static void PrintMenu()
        {
            Console.WriteLine(@"

                                                 
                                      [1]          A D D   N E W   S T U D E N T
                                             
                                      [2]           R E M O V E   S T U D E N T
                                             
                                      [3]    L O A D   L I S T   O F   S T U D E N T S
                                             
                                      [4]                    S A V E 
                                             
                                      [5]           S A V E   A N D   E X I T
                                             
                                      [6]                    E X I T


");
        }

        static int ReadInteger(string caption)
        {
        l1:
            Console.Write(caption);

            if (int.TryParse(Console.ReadLine(), out int value))
            {
                return value;
            }

            goto l1;
        }
        static double ReadDouble(string caption)
        {
        l1:
            Console.Write(caption);

            if (double.TryParse(Console.ReadLine(), out double value))
            {
                return value;
            }

            goto l1;
        }


        [Obsolete]
        static void SaveToFile(GenericStore<Student> store, string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs, store);
            }
        }

        [Obsolete]
        static GenericStore<Student> LoadFromFile(string filePath)
        {
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    object fileBulk = bf.Deserialize(fs);

                    GenericStore<Student> store = (GenericStore<Student>)fileBulk;
                    return store;
                }
            }
            catch (Exception)
            {
                return new GenericStore<Student>();
            }
        }
    }
}
