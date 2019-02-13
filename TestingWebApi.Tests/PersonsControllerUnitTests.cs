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
    }
}
