using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using EfDbFirstDemo.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
     *      --no-onconfiguring
     *    https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet#dotnet-ef-dbcontext-scaffold
     *    (if you don't have dotnet ef installed, run: "dotnet tool install --global dotnet-ef")
     *    (this will fail if your projects do not compile)
     * 4. any time you change the structure of the tables (DDL), go to step 3.
     */

    class Program
    {
        static DbContextOptions<ChinookContext> s_dbContextOptions;

        static void Main(string[] args)
        {
            //LinqStuff();

            using var logStream = new StreamWriter("ef-logs.txt");
            // DbContextOptions is how we give the context its connection string (to log in to the sql server),
            // tell it to use SQL Server (and not MySQL etc), and any other EF-side options.
            var optionsBuilder = new DbContextOptionsBuilder<ChinookContext>();
            optionsBuilder.UseSqlServer(GetConnectionString());
            optionsBuilder.UseLazyLoadingProxies(); // switch on lazy loading
            optionsBuilder.LogTo(logStream.WriteLine, LogLevel.Information);
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            s_dbContextOptions = optionsBuilder.Options;

            Display5Tracks();
            Console.WriteLine();

            // implement these 3 methods, changing what they're doing if you want
            // bonus: user input instead of hardcoded stuff...
            // bonus: involve multiple tables besides just track.

            EditOneOfThoseTracks();

            Display5Tracks();
            Console.WriteLine();

            InsertANewTrack();

            Display5Tracks();
            Console.WriteLine();

            DeleteThatTrack();

            Display5Tracks();
            Console.WriteLine();
        }

        static string GetConnectionString()
        {
            string path = "../../../../../../../chinook-connection-string.json";
            string json;
            try
            {
                json = File.ReadAllText(path);
            }
            catch (IOException)
            {
                Console.WriteLine($"required file {path} not found. should just be the connection string in quotes.");
                throw;
            }
            string connectionString = JsonSerializer.Deserialize<string>(json);
            return connectionString;
        }

        static void Display5Tracks()
        {
            using var context = new ChinookContext(s_dbContextOptions);

            IQueryable<Track> tracks = context.Tracks
                // .Include(t => t.Genre)
                .OrderBy(t => t.Name)
                .Take(5);

            // at this point, the query has not yet even been sent, let alone the results downloaded.
            // (because LINQ uses deferred execution)

            foreach (var track in tracks.ToList())
            {
                Console.WriteLine($"{track.TrackId} - {track.Name} ({track?.Genre?.Name})");
            }

            // EF by default only loads the data from one table at a time.
            //    therefore, the navigation properties will be null or empty.
            // if you need those properties to be filled in, you have to tell EF somehow.

            // there are three ways to tell EF to fill them in:
            //  1. eager loading (do this one): call Include (and maybe ThenInclude) methods
            //        (telling EF in the query itself to join with other tables)
            //  2. lazy loading (avoid this one): can be enabled in the dbcontext options...
            //       it will load each navigation property in the moment you access it.
            //       for very simple cases, minimal convenience
            //       for anything more complicated, the performance impact is too much
            //          (N+1 problem)
            //  3. explicit loading (rarely needed): given an actual object taken from the context
            //        we can tell EF to fill in individual properties

            // good practice with entity framework:
            // 1. pay attention to when the query is actually sent to the DB (e.g. ToList())
            // 2. try to get all the data you need at a given moment in one query rather than several.
            // 3. use eager loading (Include) rather than lazy or explicit.
            // 4. avoid using foreign key values when the navigation properties work instead.



            //List<string> info = context.Tracks
            //    .Include(t => t.Genre)
            //    .OrderBy(t => t.Name)
            //    .Where(track => SomeComplexMethod(track)) // this can't become sql, so, EF will fetch every row and then discard them
            //    .Take(5)
            //    .ToList();
        }

        static void EditOneOfThoseTracks()
        {

            using var context = new ChinookContext(s_dbContextOptions);

            Track track = context.Tracks.OrderBy(x => x.Name).First();

            // context.Tracks.Find(45) // get the track with primary key 45.

            // every object that you pull from the context is "tracked" by the context
            // when you call SaveChanges, the context will send all changes that have been
            // noticed automatically on the tracked entities

            track.Name += ".";

            // at this point, no SQL has run, the changes are pending inside the context object.

            //context.Tracks.Update(track); // Update method will make the context track the object you pass
            // (if it isn't already)

            context.SaveChanges(); // or, SaveChangesAsync
            // all the changes are applied as a transaction by default
            // if anything goes wrong - network problems, SQL errors - it's thrown as an exception

            // we could do more changes here and then call SaveChanges again
        }

        static void InsertANewTrack()
        {
            // for adding, you don't need to worry about foreign key values.
            // you can add/change relationships between objects via the navigation properties.

            using var context = new ChinookContext(s_dbContextOptions);

            Track firstTrack = context.Tracks.OrderBy(x => x.Name).First();
            string nameOfFirstTrack = firstTrack.Name;

            var audio = context.MediaTypes.First(x => x.Name.Contains("AUDIO"));

            var random = new Random();
            var track = new Track
            {
                TrackId = random.Next(8000, 80000),
                Name = $"!{nameOfFirstTrack}",
                UnitPrice = 3.99M,
                Milliseconds = 5000,
                MediaType = audio,
                Genre = new Genre { GenreId = random.Next(10000, 100000), Name = "abc" }
            };

            var rock = context.Genres
                .Include(g => g.Tracks)
                .First(g => g.Name.Contains("rock"));

            rock.Tracks.Add(track);

            // EF frees us from having to worry about foreign key values

            context.Tracks.Add(track);

            // this not only will see the Genre and insert it as well, with the right foreign key value on the Track...
            context.SaveChanges();
            // ... but also, once SaveChanges returns, all three places where the relationship is represented in .NET
            //    will be fixed up to be consistent.
        }

        static void DeleteThatTrack()
        {
            // there's actually no way to delete in EF without first fetching the object.
            // first, get the thing, then, remove it from its DbSet, then SaveChanges
        }

        static void LinqStuff()
        {
            // the best/most useful application of lambda expression / delegate types etc
            // is a part of the base class library called LINQ - stands for Language Integrated Query
            // - there's two ways to write it, one is weird and looks like SQL, called "query syntax"
            // - the other is called method syntax

            int[] scores = new int[] { 97, 92, 81, 60 };

            // query syntax
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            // method syntax
            IEnumerable<int> scoreQuery2 = scores.Where(s => s > 80).ToList();
            //                                        ^                 ^
            //                    wouldn't run "yet" except...       this part makes it run right now.

            scores[0] = 50;
            // scoreQuery if we look at it now, would not have the 97.
            // but scoreQuery2 would, because we called ToList to run the query then.

            // calculate the average length of the strings in a list
            var list = new List<string> { "abc", "abcdefg" };
            double average = list.Average(s => s.Length); // 5

            // LINQ is just a big pile of overloaded extension methods defined for the IEnumerable<T> interface

            // three types of LINQ methods
            // 1. the ones that return a new IEnumerable collection (they never modify the original collection)
            //    they don't execute "yet" - they use deferred execution.
            // 2. the ones that return any concrete value - like Average, First- do not use deferred execution
            // 3. things like ToArray, ToList. these return collections that need to be "all there"
            //     so they also don't use deferred execution.
            //    "ToList" lets you effectively force execution of type-1 methods whenever you want.

            // - Select: maps each element to something new
            var firstCharacters = list.Select(x => x[0]); // ['a', 'a']
            // - Where: filters the collection according to some condition

            // - Distinct: filters out duplicates
            var distinctFirstCharacters = firstCharacters.Distinct(); // ['a']
            // - Skip: skips n elements
            // - Take: skips AFTER n elements

            // - Count: counts how many items (match a condition)
            int howManyDistinctFirstChars = distinctFirstCharacters.Count(); // 1
            // - First: returns the first item (matching a condition)
            string firstStringLongerThanFive = list.First(x => x.Length > 5); // "abcdefg"
            // there's also FirstOrDefault, which returns null (or whatever struct default, e.g. 0)
            //    if there are no matches, unlike First, which throws an exception.

            // there's two versions of every LINQ extension method.
            // IEnumerable, and IQueryable.
            // IEnumerable runs in the CLR, with .NET objects.
            //     "LINQ to Objects"
            // IQueryable can be converted to some very different way to get the data, like SQL query.
            //     "LINQ to SQL", "LINQ to XML"
        }
    }
}
