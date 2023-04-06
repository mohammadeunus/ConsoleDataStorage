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
            using ApplicationDbContext context = new ApplicationDbContext();

            if (taskChoice == 1)//create file
            {
                Console.Write("Insert the data in database: ");
                string input = Console.ReadLine();

                UserFiles UserFilesObject = new UserFiles();// object of UserFiles entity created
                UserFilesObject.MyData = input; // a row is added to the table UserFiles  

                /*it is used only when creating a file, because you want to create a new file and add it to the database.
                When editing a file, you do not need to add a new object to the database, you only need to modify the existing one. 
                Therefore, you only call context.SaveChanges();*/
                context.UserFilesDbSet.Add(UserFilesObject);
                context.SaveChanges();

                viewTable();
            }
            else if (taskChoice == 2)//edit file
            {
                Console.Write("the data you want to edit: ");
                string input = Console.ReadLine();
                UserFiles userFilesObject = context.UserFilesDbSet.Where(x => x.MyData == input).FirstOrDefault();
                if (userFilesObject != null)
                {
                    Console.Write("replacing data: ");
                    string replacingData = Console.ReadLine();
                    userFilesObject.MyData = replacingData;

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"{input} data is not available in database");
                }

            }
            else if (taskChoice == 3)//delete file
            {
                Console.Write("the data you want to delete: ");
                string? inputDelete = Console.ReadLine();
                UserFiles userFilesObject = context.UserFilesDbSet.Where(x => x.MyData == inputDelete).FirstOrDefault();
                if (userFilesObject != null)
                {
                    context.UserFilesDbSet.Remove(userFilesObject);

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"{inputDelete} data is not available in database");
                }
                viewTable();
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