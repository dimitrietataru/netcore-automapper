using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NetCore.AutoMapperPrototype.App.Controllers;
using NetCore.AutoMapperPrototype.App.Data.Dtos;
using NetCore.AutoMapperPrototype.App.Data.Entities;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace NetCore.AutoMapperPrototype.App.Test.Unit.Controllers
{
    public sealed class MapControllerTest
    {
        private readonly MapController mapController;
        private readonly Mock<IMapper> mockMapper;

        public MapControllerTest()
        {
            mockMapper = new Mock<IMapper>();
            mapController = new MapController(mockMapper.Object);
        }

        [Fact]
        internal void GivenTestFooMappingCalledWhenInputIsValidThenReturnsMappedData()
        {
            // Arrange
            mockMapper
                .Setup(_ => _.Map<Foo>(It.IsAny<FooDto>()))
                .Returns(It.IsAny<Foo>())
                .Verifiable();

            // Act
            var result = mapController.TestFooMapping(It.IsAny<FooDto>());

            // Assert
            mockMapper.Verify();
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
            (result as OkObjectResult).Value.Should().Be(It.IsAny<Foo>());
        }

        [Fact]
        internal void GivenTestFoosMappingCalledWhenInputIsValidThenReturnsMappedData()
        {
            // Arrange
            mockMapper
                .Setup(_ => _.Map<IEnumerable<Foo>>(It.IsAny<ICollection<FooDto>>()))
                .Returns(It.IsAny<IEnumerable<Foo>>())
                .Verifiable();

            // Act
            var result = mapController.TestFoosMapping(It.IsAny<ICollection<FooDto>>());

            // Assert
            mockMapper.Verify();
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
            (result as OkObjectResult).Value.Should().Be(It.IsAny<IEnumerable<Foo>>());
        }

        [Fact]
        internal void GivenTestBarMappingCalledWhenInputIsValidThenReturnsMappedData()
        {
            // Arrange
            mockMapper
                .Setup(_ => _.Map<InnerBar>(It.IsAny<InnerBarDto>()))
                .Returns(It.IsAny<InnerBar>())
                .Verifiable();

            // Act
            var result = mapController.TestBarMapping(It.IsAny<InnerBarDto>());

            // Assert
            mockMapper.Verify();
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
            (result as OkObjectResult).Value.Should().Be(It.IsAny<InnerBar>());
        }

        [Fact]
        internal void GivenTestBarsMappingCalledWhenInputIsValidThenReturnsMappedData()
        {
            // Arrange
            mockMapper
                .Setup(_ => _.Map<IEnumerable<InnerBar>>(It.IsAny<ICollection<InnerBarDto>>()))
                .Returns(It.IsAny<IEnumerable<InnerBar>>())
                .Verifiable();

            // Act
            var result = mapController.TestBarsMapping(It.IsAny<ICollection<InnerBarDto>>());

            // Assert
            mockMapper.Verify();
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
            (result as OkObjectResult).Value.Should().Be(It.IsAny<IEnumerable<InnerBar>>());
        }

        [Fact]
        internal void GivenTestFizzMappingCalledWhenInputIsValidThenReturnsMappedData()
        {
            // Arrange
            mockMapper
                .Setup(_ => _.Map<InnerFizz>(It.IsAny<InnerFizzDto>()))
                .Returns(It.IsAny<InnerFizz>())
                .Verifiable();

            // Act
            var result = mapController.TestFizzMapping(It.IsAny<InnerFizzDto>());

            // Assert
            mockMapper.Verify();
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
            (result as OkObjectResult).Value.Should().Be(It.IsAny<InnerFizz>());
        }

        [Fact]
        internal void GivenTestFizzesMappingCalledWhenInputIsValidThenReturnsMappedData()
        {
            // Arrange
            mockMapper
                .Setup(_ => _.Map<IEnumerable<InnerFizz>>(It.IsAny<ICollection<InnerFizzDto>>()))
                .Returns(It.IsAny<IEnumerable<InnerFizz>>())
                .Verifiable();

            // Act
            var result = mapController.TestFizzesMapping(It.IsAny<ICollection<InnerFizzDto>>());

            // Assert
            mockMapper.Verify();
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
            (result as OkObjectResult).Value.Should().Be(It.IsAny<IEnumerable<InnerFizz>>());
        }

        [Fact]
        internal void GivenTestBuzzMappingCalledWhenInputIsValidThenReturnsMappedData()
        {
            // Arrange
            mockMapper
                .Setup(_ => _.Map<SubInnerBuzz>(It.IsAny<SubInnerBuzzDto>()))
                .Returns(It.IsAny<SubInnerBuzz>())
                .Verifiable();

            // Act
            var result = mapController.TestBuzzMapping(It.IsAny<SubInnerBuzzDto>());

            // Assert
            mockMapper.Verify();
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
            (result as OkObjectResult).Value.Should().Be(It.IsAny<SubInnerBuzz>());
        }

        [Fact]
        internal void GivenTestBuzzesMappingCalledWhenInputIsValidThenReturnsMappedData()
        {
            // Arrange
            mockMapper
                .Setup(_ => _.Map<IEnumerable<SubInnerBuzz>>(It.IsAny<ICollection<SubInnerBuzzDto>>()))
                .Returns(It.IsAny<IEnumerable<SubInnerBuzz>>())
                .Verifiable();

            // Act
            var result = mapController.TestBuzzesMapping(It.IsAny<ICollection<SubInnerBuzzDto>>());

            // Assert
            mockMapper.Verify();
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            (result as OkObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
            (result as OkObjectResult).Value.Should().Be(It.IsAny<IEnumerable<SubInnerBuzz>>());
        }
    }
}
