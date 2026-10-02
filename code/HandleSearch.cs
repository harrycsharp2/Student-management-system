using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    public class HandleSearch
    {
        public static string allstudentstxtsfilepath = "studentstxts.txt";

        public static void HandleStudentSearch()
        {
            Console.Clear();
            Console.WriteLine("type `return` to return to main menu");
            Console.WriteLine("Enter student full name - exact same way as upon creation");
            string input = Console.ReadLine();
            
            if (input == "return")
            {
                Program.Main();
                return;
            }
            
            string studentsearchfilepath = $"{input}.txt";

            string[] lines = File.ReadAllLines(studentsearchfilepath);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.ReadLine();
            HandleStudentSearch();

        }
    }
}
