using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TestingWebApi.Controllers;
using TestingWebApi.Model;
using TestingWebApi.Service;
using Xunit;

namespace TestingWebApi.Tests
{
    public class PersonsControllerUnitTests
    {
        [Fact]
        public async Task Values_Get_All()
        {
            // Arrange
            var controller = new PersonsController(new PersonService());

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var persons = okResult.Value.Should().BeAssignableTo<IEnumerable<Person>>().Subject;

            persons.Count().Should().Be(50);
        }

        [Fact]
        public async Task Values_Get_Specific()
        {
            // Arrange
            var controller = new PersonsController(new PersonService());

            // Act
            var result = await controller.Get(16);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var person = okResult.Value.Should().BeAssignableTo<Person>().Subject;
            person.Id.Should().Be(16);
        }


        [Fact]
        public async Task Persons_Add()
        {
            // Arrange
            var controller = new PersonsController(new PersonService());
            var newPerson = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 50,
                Title = "FooBar",
                Email = "john.doe@foo.bar"
            };

            // Act
            var result = await controller.Post(newPerson);

            // Assert
            var okResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
            var person = okResult.Value.Should().BeAssignableTo<Person>().Subject;
            person.Id.Should().Be(51);
        }
    }
}
