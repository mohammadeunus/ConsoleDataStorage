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
            context.UserFilesDbSet.Add(UserFilesObject);
            context.SaveChanges();

            if (taskChoice == 1)//create file
            {
                UserFilesObject.MyData = Console.ReadLine(); // a row is added to the table UserFiles 
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
                Console.Write("data in the rows are: ");
                foreach (var item in ListrUserFiles)
                {
                    Console.Write(item);
                    Console.Write(", ");
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