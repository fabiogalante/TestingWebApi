using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TestingWebApi.Controllers;
using TestingWebApi.Model;
using TestingWebApi.Service;
using Xunit;

namespace TestingWebApi.Tests
{
    public class PersonsControllerUnitTestsMoq
    {
        [Fact]
        public async Task Persons_Get_From_Moq()
        {
            // Arrange // Os dados não estão vindo do banco e sim são falto, mockdos
            var serviceMock = new Mock<IPersonService>();
            serviceMock.Setup(x => x.GetAll()).Returns(() => new List<Person>
            {
                new Person{Id=1, FirstName="Foo", LastName="Bar"},
                new Person{Id=2, FirstName="John", LastName="Doe"},
                new Person{Id=3, FirstName="Juergen", LastName="Gutsch"},
            });
            var controller = new PersonsController(serviceMock.Object);



            // Act
            var result = await controller.Get();

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var persons = okResult.Value.Should().BeAssignableTo<IEnumerable<Person>>().Subject;

            persons.Count().Should().Be(3);
        }
    }
}
