using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace TodoApi.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TodoContext(
                serviceProvider.GetRequiredService<DbContextOptions<TodoContext>>()))
            {
                // Look for any TODO.
                if (context.TodoItems.Any())
                {
                    return;   // DB has been seeded
                }

                context.TodoItems.AddRange(
                     new TodoItem
                     {
                         Name = "Ir para a academia",
                         IsComplete = true
                     },

                     new TodoItem
                     {
                         Name = "Desenvolver um Rest Client",
                         IsComplete = false
                     },

                     new TodoItem
                     {
                         Name = "Aprender um novo idioma",
                         IsComplete = true
                     },

                   new TodoItem
                     {
                         Name = "Viajar para outro país",
                         IsComplete = false
                     }
                );
                context.SaveChanges();
            }
        }
    }
}