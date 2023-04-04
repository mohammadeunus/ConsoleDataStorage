using Database_with_entity_framework_and_file_operation;
using System;

class program
{
    static byte CreateTask()
    {
        Console.WriteLine("Please Select Task:");
        Console.WriteLine("1)Create File");
        Console.WriteLine("2)Edit File");
        Console.WriteLine("3)Delete File");
        Console.WriteLine("4)Exit");
        byte inputTask = byte.Parse(Console.ReadLine());
        
        return inputTask;
    }
    static void Main(string[] args)
    {
        //user input
        Console.WriteLine("Please Select data Storage:");
        Console.WriteLine("1)DataBase");
        Console.WriteLine("2)File");
        Console.WriteLine("3)Exit");
        byte StorageChoice = byte.Parse(Console.ReadLine());
        byte taskChoice;


        if (StorageChoice == 1)
        {
            taskChoice = CreateTask();

            Console.WriteLine();

        }
        else if(StorageChoice == 2)
        {
            taskChoice = CreateTask();

        }
        else
        {

        }

 
    }

}