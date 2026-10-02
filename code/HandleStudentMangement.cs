using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace ConsoleApp4
{
    public class HandleStudentMangement
    {
        public static string allstudentstxtsfilepath = "studentstxts.txt";
        
        public static void HandleStudentMangementMenu()
        {
            if (!File.Exists(allstudentstxtsfilepath))
            {
                using (StreamWriter sw = new StreamWriter(allstudentstxtsfilepath))
                {
                    sw.WriteLine("");
                }
            }
            Console.Clear();
            Console.WriteLine("1. Create Student");
            Console.WriteLine("2. Remove Student");
            Console.WriteLine("3. View all student filepaths");
            Console.WriteLine("4. Back to Main Menu");
            string input = Console.ReadLine();
            if (input == "1")
            {
                HandleCreateStudent();
            }
            else if (input == "2")
            {
                HandleRemoveStudent();
            }
            else if (input == "3")
            {
                string[] lines = File.ReadAllLines(allstudentstxtsfilepath);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
                Console.ReadLine();
                HandleStudentMangementMenu();
            }
            else if (input == "4")
            {
                Program.Main();
            }
            else
            {
                HandleStudentMangementMenu();
            }
        }
        public static void HandleCreateStudent()
        {
            Console.Clear();
            Console.WriteLine("Student fullname");
            string studentfullname = Console.ReadLine();
            if (File.Exists($"{studentfullname}.txt")) 
            {
                Console.WriteLine("Student already exists");
                Console.ReadLine(); 
                HandleStudentMangementMenu(); 
                return; }
            if (!File.Exists($"{studentfullname}.txt"))
            {
                using (StreamWriter sw = new StreamWriter($"{studentfullname}.txt"))
                {
                    sw.WriteLine($"Student full name, {studentfullname}");
                    sw.WriteLine("-");
                }
                using (StreamWriter sw = new StreamWriter(allstudentstxtsfilepath, true))
                {
                    sw.WriteLine($"{studentfullname}.txt");
                }
            }
            
            Console.WriteLine("How many lessons does your student have?");
            string studentlessonamount = Console.ReadLine();
            if (int.TryParse(studentlessonamount, out int Istudentlesamount)) ;
            
            List<string> grades = new();
            for (int i = 0; i < Istudentlesamount; i++)
            {
                Console.WriteLine("Subject name");
                string subject = Console.ReadLine();

                Console.WriteLine("Subjct grade");
                string grade = Console.ReadLine();
                grades.Add(grade);

                using (StreamWriter sw = new StreamWriter($"{studentfullname}.txt", true))
                {
                    sw.WriteLine($"Subject: {subject}, Grade: {grade}");
                    sw.WriteLine("-");
                }
            }
            float amountofgrades = 0f;
            float allgradeamount = 0f;
            foreach (string Sgrade in grades)
            {
                amountofgrades++;
                if (int.TryParse(Sgrade, out int Igrade)) ;
                allgradeamount = allgradeamount + Igrade;

            }
            float avggrade = allgradeamount / amountofgrades;
            using (StreamWriter sw = new StreamWriter($"{studentfullname}.txt", true))
            {
                sw.WriteLine($"Student overall average grade: {avggrade}");
                sw.WriteLine("-");
            }
            HandleStudentMangementMenu();
            return;
        }
        public static void HandleRemoveStudent()
        {
            Console.Clear();
            Console.WriteLine("type `return` to return");
            Console.WriteLine("Enter student name full you wish to remove from the system");
            Console.WriteLine("needs to be the exact same way you wrote it open creation");
            string studentname = Console.ReadLine();

            if (studentname == "return") { HandleStudentMangementMenu(); return; }
            else if (studentname != null && File.Exists($"{studentname}.txt"))
            {
                File.Delete($"{studentname}.txt");
                List<string> lines = File.ReadAllLines(allstudentstxtsfilepath).ToList();

                lines.Remove($"{studentname}.txt");

                File.WriteAllLines(allstudentstxtsfilepath, lines);
                
                Console.WriteLine("student removed");
                Console.ReadLine();
                HandleStudentMangementMenu();
            }
            else if (!File.Exists($"{studentname}.txt"))
            {
                Console.WriteLine("couldnt find student file make sure you wrote student name exact same way you created it");
                Console.ReadLine();
                HandleStudentMangementMenu();
            }
            else
            {
                Console.WriteLine("invalid responce");
                Console.ReadLine();
                HandleStudentMangementMenu();
            }
        }
    }
}
