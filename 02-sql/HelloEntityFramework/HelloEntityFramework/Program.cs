﻿using HelloEntityFramework.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Linq;

namespace HelloEntityFramework
{
    class Program
    {
        // EF database-first approach steps:
        //
        // 1. have startup project, and data access library project.
        // 2. reference data access from startup project.
        // 3. add NuGet packages to the startup project:
        //     - Microsoft.EntityFrameworkCore.Tools
        //     - Microsoft.EntityFrameworkCore.SqlServer
        //    and to the data access project:
        //     - Microsoft.EntityFrameworkCore.SqlServer
        // 4. open Package Manager Console in VS
        //     ( View -> Other Windows -> Package Manager Console
        // 5. run command (your solution needs to be able to compile) (one-line):
        //      Scaffold-DbContext "<your-connection-string>"
        //             Microsoft.EntityFrameworkCore.SqlServer
        //             -Project <name-of-data-project> -Force
        //     (you can get connection string from Azure, but, make sure to delete
        //     the braces {} when you fill in the username and password.
        // (alternate 4/5. run in git bash/terminal:
        //      dotnet ef dbcontext scaffold "<your-connection-string>"
        //               Microsoft.EntityFrameworkCore.SqlServer
        //               --project <name-of-data-project> -Force
        // 6. delete the OnConfiguring override in the DbContext, to prevent
        //       committing your connection string to git.

        // (7. any time we change the database (add a new column, etc.), go to step 4.)


        // by default, the scaffolding will configure the models in OnModelCreating
        //     with the fluent API. this is the right way to do it - strongest separation
        //     of concerns, more flexibility.
        //   if we scaffold with option "-DataAnnotations" we'll put the configuration
        //   on the Movie and Genre classes themselves with attributes.
        //   third "way to configure" is convention-based
        public static readonly LoggerFactory AppLoggerFactory =
#pragma warning disable CS0618 // Type or member is obsolete
            new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });
#pragma warning restore CS0618 // Type or member is obsolete

        static void Main(string[] args)
        {


            var optionsBuilder = new DbContextOptionsBuilder<MoviesContext>();
            optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);
            optionsBuilder.UseLoggerFactory(AppLoggerFactory);
            var options = optionsBuilder.Options;

            using (var dbContext = new MoviesContext(options))
            {
                // lots of complex setup... here is where the payoff begins
                PrintMovies(dbContext);
                Console.WriteLine();

                AddMovie(dbContext);

                PrintMovies(dbContext);
                Console.WriteLine();

                UpdateMovies(dbContext);

                PrintMovies(dbContext);
                Console.WriteLine();

                DeleteAMovie(dbContext);

                PrintMovies(dbContext);
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        static void DeleteAMovie(MoviesContext dbContext)
        {
            var movieToDelete = dbContext.Movie
                .OrderByDescending(x => x.ReleaseDate)
                .First();

            dbContext.Movie.Remove(movieToDelete);
            dbContext.SaveChanges();
        }

        static void UpdateMovies(MoviesContext dbContext)
        {
            foreach (var movie in dbContext.Movie)
            {
                movie.ReleaseDate = movie.ReleaseDate.AddYears(1);
            }
            // that loop only runs in memory - changes are written to the DB
            // with savechanges

            // the objects that we get out of the DbSets are "tracked" by the DbContext.
            // basically the DbContext knows about any changes we make to those objects.

            dbContext.SaveChanges();
        }

        static void AddMovie(MoviesContext dbContext)
        {
            // read from db
            // DbSet implements IQueryable, which has LINQ methods just like IEnumerable
            //   IQueryable supports translating those lambdas into actual SQL commands
            //   IEnumerable does all the processing in-memory
            // so... this doesn't fetch all records into objects and then run a lambda on them
            // it translates the lambda/LINQ into a SQL query.
            Genre actionGenre = dbContext.Genre
                .Include(g => g.Movie)
                .First(g => g.Name.Contains("Action"));

            var newMovie = new Movie
            {
                Title = "LOTR: The Two Towers",
                ReleaseDate = DateTime.Now,
                Genre = actionGenre
            };

            // tell the dbcontext we have a new movie to insert.
            dbContext.Movie.Add(newMovie);
            // won't do anything until we call "SaveChanges"

            // another equivalent way to add a new movie
            newMovie = new Movie
            {
                Title = "LOTR: The Two Towers",
                ReleaseDate = DateTime.Now
            };
            actionGenre.Movie.Add(newMovie);
            // that will also insert it into the DB, with the right FK,
            // etc.

            // this one actually accesses the SQL server and runs INSERT.
            dbContext.SaveChanges();
        }

        static void PrintMovies(MoviesContext dbContext)
        {
            // code didn't work with this line, null exception on Genre.
            // because we needed to load that relationship / navigation property
            //foreach (var movie in dbContext.Movie)
            // but with .Include, it will fetch that data we ask for.
            foreach (var movie in dbContext.Movie.Include(m => m.Genre))
                {
                Console.WriteLine($"{movie.Genre.Name} Movie #{movie.MovieId}: {movie.Title}" +
                    $" ({movie.ReleaseDate.Year})");
            }
        }
    }
}
