using AutoMapper;
using FluentAssertions;
using NetCore.AutoMapperPrototype.App.Data.Dtos;
using NetCore.AutoMapperPrototype.App.Data.Entities;
using NetCore.AutoMapperPrototype.App.Data.Mapping;
using System.Collections.Generic;
using Xunit;

namespace NetCore.AutoMapperPrototype.App.Test.Integration.Data.Mapping
{
    public sealed class AutoMapperProfileTest
    {
        private readonly IMapper mapper;

        public AutoMapperProfileTest()
        {
            var mapperConfiguration = new MapperConfiguration(
                options =>
                {
                    options.AddProfile<AutoMapperProfile>();
                });

            mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        internal void GivenMapFromFooDtoToFooWhenSourceIsNotNullThenMapsData()
        {
            // Arrange
            var fooDto = new FooDto
            {
                StringValue = "foo",
                IntValue = 1,
                DoubleValue = 1.0D,
                BooleanValue = true,
                Bar = null,
                Fizzes = new List<FizzDto>()
            };

            // Act
            var foo = mapper.Map<Foo>(fooDto);

            // Assert
            foo.Should().NotBeNull().And.BeOfType<Foo>();
            foo.StringValue.Should().Be(fooDto.StringValue);
            foo.IntValue.Should().Be(fooDto.IntValue);
            foo.DoubleValue.Should().Be(fooDto.DoubleValue);
            foo.BooleanValue.Should().Be(fooDto.BooleanValue);
            foo.Bar.Should().BeNull();
            foo.Fizzes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        internal void GivenMapFromFooDtoToFooWhenSourceIsNullThenMapsNoData()
        {
            // Arrange
            var fooDto = (FooDto)null;

            // Act
            var foo = mapper.Map<Foo>(fooDto);

            // Assert
            foo.Should().BeNull();
        }

        [Fact]
        internal void GivenCollectionMapFromFooDtoToFooWhenSourceIsNotEmptyThenMapsData()
        {
            // Arrange
            var fooDtos = new List<FooDto>
            {
                new FooDto
                {
                    StringValue = "foo",
                    IntValue = 1,
                    DoubleValue = 1.0D,
                    BooleanValue = true,
                    Bar = null,
                    Fizzes = new List<FizzDto>()
                },
                new FooDto
                {
                    StringValue = "fooo",
                    IntValue = 2,
                    DoubleValue = 2.0D,
                    BooleanValue = false,
                    Bar = null,
                    Fizzes = new List<FizzDto>()
                },
                new FooDto
                {
                    StringValue = "foooo",
                    IntValue = 3,
                    DoubleValue = 3.0D,
                    BooleanValue = true,
                    Bar = null,
                    Fizzes = new List<FizzDto>()
                }
            };

            // Act
            var foos = mapper.Map<IEnumerable<Foo>>(fooDtos);

            // Assert
            foos.Should().NotBeNull().And.BeAssignableTo<IEnumerable<Foo>>();
            foos.Should().NotBeEmpty().And.HaveCount(3);
            (foos as IList<Foo>)[0].StringValue.Should().Be(fooDtos[0].StringValue);
            (foos as IList<Foo>)[0].IntValue.Should().Be(fooDtos[0].IntValue);
            (foos as IList<Foo>)[0].DoubleValue.Should().Be(fooDtos[0].DoubleValue);
            (foos as IList<Foo>)[0].BooleanValue.Should().Be(fooDtos[0].BooleanValue);
            (foos as IList<Foo>)[0].Bar.Should().BeNull();
            (foos as IList<Foo>)[0].Fizzes.Should().NotBeNull().And.BeEmpty();
            (foos as IList<Foo>)[1].StringValue.Should().Be(fooDtos[1].StringValue);
            (foos as IList<Foo>)[1].IntValue.Should().Be(fooDtos[1].IntValue);
            (foos as IList<Foo>)[1].DoubleValue.Should().Be(fooDtos[1].DoubleValue);
            (foos as IList<Foo>)[1].BooleanValue.Should().Be(fooDtos[1].BooleanValue);
            (foos as IList<Foo>)[1].Bar.Should().BeNull();
            (foos as IList<Foo>)[1].Fizzes.Should().NotBeNull().And.BeEmpty();
            (foos as IList<Foo>)[2].StringValue.Should().Be(fooDtos[2].StringValue);
            (foos as IList<Foo>)[2].IntValue.Should().Be(fooDtos[2].IntValue);
            (foos as IList<Foo>)[2].DoubleValue.Should().Be(fooDtos[2].DoubleValue);
            (foos as IList<Foo>)[2].BooleanValue.Should().Be(fooDtos[2].BooleanValue);
            (foos as IList<Foo>)[2].Bar.Should().BeNull();
            (foos as IList<Foo>)[2].Fizzes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        internal void GivenCollectionMapFromFooDtoToFooWhenSourceIsEmptyThenMapsNoData()
        {
            // Arrange
            var fooDtos = new List<FooDto>();

            // Act
            var foos = mapper.Map<IEnumerable<Foo>>(fooDtos);

            // Assert
            foos.Should().NotBeNull().And.BeAssignableTo<IEnumerable<Foo>>().And.BeEmpty();
        }

        [Fact]
        internal void GivenMapFromBarDtoToBarWhenSourceIsNotNullThenMapsData()
        {
            // Arrange
            var barDto = new BarDto
            {
                Value = "bar"
            };

            // Act
            var bar = mapper.Map<Bar>(barDto);

            // Assert
            bar.Should().NotBeNull().And.BeOfType<Bar>();
            bar.Value.Should().Be(barDto.Value);
        }

        [Fact]
        internal void GivenMapFromBarDtoToBarWhenSourceIsNullThenMapsNoData()
        {
            // Arrange
            var barDto = (BarDto)null;

            // Act
            var bar = mapper.Map<Bar>(barDto);

            // Assert
            bar.Should().BeNull();
        }

        [Fact]
        internal void GivenCollectionMapFromBarDtoToBarWhenSourceIsNotEmptyThenMapsData()
        {
            // Arrange
            var barDtos = new List<BarDto>
            {
                new BarDto
                {
                    Value = "bar"
                },
                new BarDto
                {
                    Value = "barr"
                },
                new BarDto
                {
                    Value = "barrr"
                }
            };

            // Act
            var bars = mapper.Map<IEnumerable<Bar>>(barDtos);

            // Assert
            bars.Should().NotBeNull().And.BeAssignableTo<IEnumerable<Bar>>();
            bars.Should().NotBeEmpty().And.HaveCount(3);
            (bars as IList<Bar>)[0].Value.Should().Be(barDtos[0].Value);
            (bars as IList<Bar>)[1].Value.Should().Be(barDtos[1].Value);
            (bars as IList<Bar>)[2].Value.Should().Be(barDtos[2].Value);
        }

        [Fact]
        internal void GivenCollectionMapFromBarDtoToBarWhenSourceIsEmptyThenMapsNoData()
        {
            // Arrange
            var barDtos = new List<BarDto>();

            // Act
            var bars = mapper.Map<IEnumerable<Bar>>(barDtos);

            // Assert
            bars.Should().NotBeNull().And.BeAssignableTo<IEnumerable<Bar>>().And.BeEmpty();
        }

        [Fact]
        internal void GivenMapFromFizzDtoToFizzWhenSourceIsNotNullThenMapsData()
        {
            // Arrange
            var fizzDto = new FizzDto
            {
                Value = "fizz",
                Buzzes = new List<BuzzDto>()
            };

            // Act
            var fizz = mapper.Map<Fizz>(fizzDto);

            // Assert
            fizz.Should().NotBeNull().And.BeOfType<Fizz>();
            fizz.Value.Should().Be(fizzDto.Value);
            fizz.Buzzes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        internal void GivenMapFromFizzDtoToFizzWhenSourceIsNullThenMapsNoData()
        {
            // Arrange
            var fizzDto = (FizzDto)null;

            // Act
            var fizz = mapper.Map<Fizz>(fizzDto);

            // Assert
            fizz.Should().BeNull();
        }

        [Fact]
        internal void GivenCollectionMapFromFizzDtoToFizzWhenSourceIsNotEmptyThenMapsData()
        {
            // Arrange
            var fizzDtos = new List<FizzDto>
            {
                new FizzDto
                {
                    Value = "fizz",
                    Buzzes = new List<BuzzDto>()
                },
                new FizzDto
                {
                    Value = "fizzz",
                    Buzzes = new List<BuzzDto>()
                },
                new FizzDto
                {
                    Value = "fizzzz",
                    Buzzes = new List<BuzzDto>()
                }
            };

            // Act
            var fizzes = mapper.Map<IEnumerable<Fizz>>(fizzDtos);

            // Assert
            fizzes.Should().NotBeNull().And.BeAssignableTo<IEnumerable<Fizz>>();
            fizzes.Should().NotBeEmpty().And.HaveCount(3);
            (fizzes as IList<Fizz>)[0].Value.Should().Be(fizzDtos[0].Value);
            (fizzes as IList<Fizz>)[0].Buzzes.Should().NotBeNull().And.BeEmpty();
            (fizzes as IList<Fizz>)[1].Value.Should().Be(fizzDtos[1].Value);
            (fizzes as IList<Fizz>)[1].Buzzes.Should().NotBeNull().And.BeEmpty();
            (fizzes as IList<Fizz>)[2].Value.Should().Be(fizzDtos[2].Value);
            (fizzes as IList<Fizz>)[2].Buzzes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        internal void GivenCollectionMapFromFizzDtoToFizzWhenSourceIsEmptyThenMapsNoData()
        {
            // Arrange
            var fizzDtos = new List<FizzDto>();

            // Act
            var fizzes = mapper.Map<IEnumerable<Fizz>>(fizzDtos);

            // Assert
            fizzes.Should().NotBeNull().And.BeAssignableTo<IEnumerable<Fizz>>().And.BeEmpty();
        }

        [Fact]
        internal void GivenMapFromBuzzDtoToBuzzWhenSourceIsNotNullThenMapsData()
        {
            // Arrange
            var buzzDto = new BuzzDto
            {
                Value = "buzz"
            };

            // Act
            var buzz = mapper.Map<Buzz>(buzzDto);

            // Assert
            buzz.Should().NotBeNull().And.BeOfType<Buzz>();
            buzz.Value.Should().Be(buzzDto.Value);
        }

        [Fact]
        internal void GivenMapFromBuzzDtoToBuzzWhenSourceIsNullThenMapsNoData()
        {
            // Arrange
            var buzzDto = (BuzzDto)null;

            // Act
            var buzz = mapper.Map<Buzz>(buzzDto);

            // Assert
            buzz.Should().BeNull();
        }

        [Fact]
        internal void GivenCollectionMapFromBuzzDtoToBuzzWhenSourceIsNotEmptyThenMapsData()
        {
            // Arrange
            var buzzDtos = new List<BuzzDto>
            {
                new BuzzDto
                {
                    Value = "buzz"
                },
                new BuzzDto
                {
                    Value = "buzzz"
                },
                new BuzzDto
                {
                    Value = "buzzzz"
                }
            };

            // Act
            var buzzes = mapper.Map<IEnumerable<Buzz>>(buzzDtos);

            // Assert
            buzzes.Should().NotBeNull().And.BeAssignableTo<IEnumerable<Buzz>>();
            buzzes.Should().NotBeEmpty().And.HaveCount(3);
            (buzzes as IList<Buzz>)[0].Value.Should().Be(buzzDtos[0].Value);
            (buzzes as IList<Buzz>)[1].Value.Should().Be(buzzDtos[1].Value);
            (buzzes as IList<Buzz>)[2].Value.Should().Be(buzzDtos[2].Value);
        }

        [Fact]
        internal void GivenCollectionMapFromBuzzDtoToBuzzWhenSourceIsEmptyThenMapsNoData()
        {
            // Arrange
            var buzzDtos = new List<BuzzDto>();

            // Act
            var buzzes = mapper.Map<IEnumerable<Buzz>>(buzzDtos);

            // Assert
            buzzes.Should().NotBeNull().And.BeAssignableTo<IEnumerable<Buzz>>().And.BeEmpty();
        }
    }
}
