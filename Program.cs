using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Api.Database;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace aspnetcoreapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using(var db = new StoreContext()) 
            {
                var authorDbEntry = db.Authors.Add(
                    new Author
                    {
                        Name = "Stephen King",
                    }
                );

                db.SaveChanges();

                db.Books.AddRange(
                new Book
                {
                    Name = "IT",
                    Published = true,
                    AuthorId = authorDbEntry.Entity.Id,
                    Genre = "Mystery"
                },
                new Book
                {
                    Name = "The Langoleers",
                    Published = true,
                    AuthorId = authorDbEntry.Entity.Id,
                    Genre = "Mystery"
                }
                );

                db.SaveChanges();
            }
            
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
