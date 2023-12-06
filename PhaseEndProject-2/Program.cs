using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhaseEndProject_2
{
    internal class Program
    {
        static readonly string textFile = @"G:\SimpliLearn\Assignments\PhaseEndProject-2\TeacherDetails.txt";
        static void Main(string[] args)
        {
            string choice = "";
            do
            {
                Console.WriteLine("Choose\n1.Add Teacher Details\n2.Update Teacher Details\n3.Display all Teacher Details");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        {
                            AddTeacher();
                        }
                        break;
                    case 2:
                        {
                            UpdateTeacher();
                        }
                        break;
                    case 3:
                        {
                            Display();
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Invalid choice");
                        }
                        break;
                }
                Console.WriteLine("Enter M if you want to go back to Main Menu");
                choice = Console.ReadLine();
            } while (choice.ToLower() == "m");
                Console.ReadKey();
        }
        static void AddTeacher()
        {
            Console.WriteLine("Enter the Teacher ID");
            int Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Teacher Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Class and Section");
            string classSec = Console.ReadLine();
            StreamWriter sw = File.AppendText(textFile);
            sw.WriteLine("ID: "+Id+"\tName: "+name+"\tClass Sec: "+classSec);
            sw.Dispose();
            sw.Close();
            Console.WriteLine("Teacher Details Added");
        }

        static void UpdateTeacher()
        {
            Console.WriteLine("Enter the teacher ID to be updated");
            string id = Console.ReadLine();
            string oldDetails = "";
            using (StreamReader file = new StreamReader(textFile))
            {
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    if (ln.StartsWith("ID: "+id))
                    {
                        oldDetails = ln;
                    }
                }
                file.Close();
            }
            Console.WriteLine("Enter the new Teacher ID");
            string newID = Console.ReadLine();
            Console.WriteLine("Enter the new Teacher Name");
            string newName = Console.ReadLine();
            Console.WriteLine("Enter the new Teacher Class Sec");
            string newClassSec = Console.ReadLine();
            string replacement = "ID: " + newID + "\tName: " + newName + "\tClass Sec: " + newClassSec;

            StreamReader reader = new StreamReader(textFile);
            string input = reader.ReadToEnd();
            reader.Close();

            using (StreamWriter writer = new StreamWriter(textFile, false))
            {
                {
                    string output = input.Replace(oldDetails, replacement);
                    writer.Write(output);
                }
                writer.Close();
            }
        }

        static void Display()
        {
            if (File.Exists(textFile))
            {
                Console.WriteLine("Here are the Teacher Details");
                using (StreamReader file = new StreamReader(textFile))
                {
                    string ln;

                    while ((ln = file.ReadLine()) != null)
                    {
                        Console.WriteLine(ln);
                    }
                    file.Close();
                }
            }
        }
    }
}
