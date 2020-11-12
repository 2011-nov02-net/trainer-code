using System;

namespace EfDbFirstDemo.ConsoleApp
{
    // Entity Framework Core
    // database-first approach steps...
    /*
     * 1. have a data access library project separate from the startup application project.
     *    (with a project reference from the latter to the former).
     *    the library needs to target at least .NET Standard 2.1 or .NET Core 3.1.
     * 2. install Microsoft.EntityFrameworkCore.Design and Microsoft.EntityFrameworkCore.SqlServer
     *    to both projects.
     * 3. using Git Bash / terminal, from the data access project folder run (split into several lines for clarity):
     *    dotnet ef dbcontext scaffold <connection-string-in-quotes>
     *      Microsoft.EntityFrameworkCore.SqlServer
     *      --startup-project <path-to-startup-project-folder>
     *      --force
     *      --output-dir Entities
     *    https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet#dotnet-ef-dbcontext-scaffold
     *    (if you don't have dotnet ef installed, run: "dotnet tool install --global dotnet-ef")
     *    (this will fail if your projects do not compile)
     * 4. delete the DbContext.OnConfiguring method from the scaffolded code.
     *    (so that the connection string is not put on the public internet)
     * 5. any time you change the structure of the tables (DDL), go to step 3.
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
