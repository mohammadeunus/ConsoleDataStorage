using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
step1: dotnet ef migrations add CreateUserFiles --project ConsoleDataStorage --context ApplicationDbContext
step2: dotnet ef database update --project ConsoleDataStorage --context ApplicationDbContext
*/

namespace ConsoleDataStorage.DataBaseModelEntity
{
    internal class UserFiles
    {
        public int id { get; set; }
        public string MyData { get; set; }
    }
}
