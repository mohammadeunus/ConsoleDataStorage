using System;
using ConsoleDataStorage.DataBaseModelEntity;
using DataBaseModelEntity; 

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


        if (StorageChoice == 1)// DataBase as data storage
        {
            taskChoice = CreateTask();
            UserFiles UserFilesObject = new UserFiles();// object of UserFiles entity created

            using ApplicationDbContext context = new ApplicationDbContext();
            

            if (taskChoice == 1)//create file
            {
                Console.Write("Insert the data in database: ");
                string input = Console.ReadLine();
                UserFilesObject.MyData = input; // a row is added to the table UserFiles 

                //Add() method is used to add a new object to the database, and SaveChanges() is used to persist any changes made to the database
                context.UserFilesDbSet.Add(UserFilesObject);
                context.SaveChanges();
                
                //to show the changes in the database
                viewTable();

            }
            else if (taskChoice == 2)//edit file
            {

            }
            else if (taskChoice == 3)//delete file
            {

            }
            else// exit
            {
                return;
            }
            void viewTable()
            {
                List<UserFiles> ListrUserFiles = context.UserFilesDbSet.ToList();
                Console.WriteLine("data in the rows are: ");
                foreach (var item in ListrUserFiles)
                {
                    Console.WriteLine($"Id: {item.id} and my data: {item.MyData}");
                }
            }

        }
        else if (StorageChoice == 2)//File as data storage
        {
            taskChoice = CreateTask();

        }
        else
        {
            return;
        }

    }

}