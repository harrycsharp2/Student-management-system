using System;
using System.IO;
using ConsoleApp4;
public class Program
{
    //Student Grade Manager — Students, subjects, grades, averages.

    //creating storeing student information
    //create a Handlestudent - Create a student each student has its own .txt file with its information.
    //a txt files containg all the filenames of the students .txt files.
    //when creating student they select subjects and grades and the program calculates the average of the student.
    //all the infomation is stored in the student .txt file and the filename is stored in the main .txt file.

    //searchign for student
    //creates a class for each student and gets the information from the student .txt file and displays it to the user.
    //user searchs by name and all information comes up

    //deleting student
    //deletes the student .txt file and removes the filename from the main .txt file.
    public static void Main()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Student Grade Manager!");
        Console.WriteLine("1. Student Manager/create/remove");
        Console.WriteLine("2. Search for Student");
        Console.WriteLine("3. Exit");
        string input = Console.ReadLine();

        if (input == "1")
        {
            HandleStudentMangement.HandleStudentMangementMenu();
        }
        else if (input == "2")
        {
            HandleSearch.HandleStudentSearch();
               
        }
        else if (input == "3")
        {
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Invalid input.1/2/3. Please try again.");
            Main();
        }
    }
}
        