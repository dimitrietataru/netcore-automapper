namespace NetCore.AutoMapperPrototype.App.Test.Unit.Controllers;

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
        (result as OkObjectResult)!.StatusCode.Should().Be((int)HttpStatusCode.OK);
        (result as OkObjectResult)!.Value.Should().Be(It.IsAny<Foo>());
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
        (result as OkObjectResult)!.StatusCode.Should().Be((int)HttpStatusCode.OK);
        (result as OkObjectResult)!.Value.Should().Be(It.IsAny<IEnumerable<Foo>>());
    }

    [Fact]
    internal void GivenTestBarMappingCalledWhenInputIsValidThenReturnsMappedData()
    {
        // Arrange
        mockMapper
            .Setup(_ => _.Map<Bar>(It.IsAny<BarDto>()))
            .Returns(It.IsAny<Bar>())
            .Verifiable();

        // Act
        var result = mapController.TestBarMapping(It.IsAny<BarDto>());

        // Assert
        mockMapper.Verify();
        result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
        (result as OkObjectResult)!.StatusCode.Should().Be((int)HttpStatusCode.OK);
        (result as OkObjectResult)!.Value.Should().Be(It.IsAny<Bar>());
    }

    [Fact]
    internal void GivenTestBarsMappingCalledWhenInputIsValidThenReturnsMappedData()
    {
        // Arrange
        mockMapper
            .Setup(_ => _.Map<IEnumerable<Bar>>(It.IsAny<ICollection<BarDto>>()))
            .Returns(It.IsAny<IEnumerable<Bar>>())
            .Verifiable();

        // Act
        var result = mapController.TestBarsMapping(It.IsAny<ICollection<BarDto>>());

        // Assert
        mockMapper.Verify();
        result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
        (result as OkObjectResult)!.StatusCode.Should().Be((int)HttpStatusCode.OK);
        (result as OkObjectResult)!.Value.Should().Be(It.IsAny<IEnumerable<Bar>>());
    }

    [Fact]
    internal void GivenTestFizzMappingCalledWhenInputIsValidThenReturnsMappedData()
    {
        // Arrange
        mockMapper
            .Setup(_ => _.Map<Fizz>(It.IsAny<FizzDto>()))
            .Returns(It.IsAny<Fizz>())
            .Verifiable();

        // Act
        var result = mapController.TestFizzMapping(It.IsAny<FizzDto>());

        // Assert
        mockMapper.Verify();
        result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
        (result as OkObjectResult)!.StatusCode.Should().Be((int)HttpStatusCode.OK);
        (result as OkObjectResult)!.Value.Should().Be(It.IsAny<Fizz>());
    }

    [Fact]
    internal void GivenTestFizzesMappingCalledWhenInputIsValidThenReturnsMappedData()
    {
        // Arrange
        mockMapper
            .Setup(_ => _.Map<IEnumerable<Fizz>>(It.IsAny<ICollection<FizzDto>>()))
            .Returns(It.IsAny<IEnumerable<Fizz>>())
            .Verifiable();

        // Act
        var result = mapController.TestFizzesMapping(It.IsAny<ICollection<FizzDto>>());

        // Assert
        mockMapper.Verify();
        result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
        (result as OkObjectResult)!.StatusCode.Should().Be((int)HttpStatusCode.OK);
        (result as OkObjectResult)!.Value.Should().Be(It.IsAny<IEnumerable<Fizz>>());
    }

    [Fact]
    internal void GivenTestBuzzMappingCalledWhenInputIsValidThenReturnsMappedData()
    {
        // Arrange
        mockMapper
            .Setup(_ => _.Map<Buzz>(It.IsAny<BuzzDto>()))
            .Returns(It.IsAny<Buzz>())
            .Verifiable();

        // Act
        var result = mapController.TestBuzzMapping(It.IsAny<BuzzDto>());

        // Assert
        mockMapper.Verify();
        result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
        (result as OkObjectResult)!.StatusCode.Should().Be((int)HttpStatusCode.OK);
        (result as OkObjectResult)!.Value.Should().Be(It.IsAny<Buzz>());
    }

    [Fact]
    internal void GivenTestBuzzesMappingCalledWhenInputIsValidThenReturnsMappedData()
    {
        // Arrange
        mockMapper
            .Setup(_ => _.Map<IEnumerable<Buzz>>(It.IsAny<ICollection<BuzzDto>>()))
            .Returns(It.IsAny<IEnumerable<Buzz>>())
            .Verifiable();

        // Act
        var result = mapController.TestBuzzesMapping(It.IsAny<ICollection<BuzzDto>>());

        // Assert
        mockMapper.Verify();
        result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
        (result as OkObjectResult)!.StatusCode.Should().Be((int)HttpStatusCode.OK);
        (result as OkObjectResult)!.Value.Should().Be(It.IsAny<IEnumerable<Buzz>>());
    }
}
