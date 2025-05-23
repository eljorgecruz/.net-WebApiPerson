using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using WebApiPerson.Context;
using WebApiPerson.Controllers;
using WebApiPerson.Models;
using Xunit;

namespace WebApiPerson.Tests
{
    public class PersonControllerTests
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            var context = new AppDbContext(options);
            context.Database.EnsureDeleted(); // limpiar base de datos antes de cada prueba
            context.Database.EnsureCreated();

            return context;
        }

        [Fact]
        public async Task GetPersons_ReturnsAllPersons()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            context.Persons.AddRange(new List<Person>
            {
                new Person { Id = 1, Name = "Juan", Age = 30 },
                new Person { Id = 2, Name = "Ana", Age = 25 }
            });

            await context.SaveChangesAsync();

            var controller = new PersonController(context);

            // Act
            var result = await controller.GetPersons();

            // Assert
            var okResult = Assert.IsType<ActionResult<IEnumerable<Person>>>(result);
            var persons = Assert.IsType<List<Person>>(okResult.Value);
            Assert.Equal(2, persons.Count);
        }
    }
}
