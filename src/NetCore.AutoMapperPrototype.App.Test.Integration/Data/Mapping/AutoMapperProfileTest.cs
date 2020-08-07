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
                StringValue = "test",
                IntValue = 1,
                DoubleValue = 1.0D,
                BooleanValue = true,
                Bar = null,
                Fizzes = new List<InnerFizzDto>()
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
                    StringValue = "fo",
                    IntValue = 1,
                    DoubleValue = 1.0D,
                    BooleanValue = true,
                    Bar = null,
                    Fizzes = new List<InnerFizzDto>()
                },
                new FooDto
                {
                    StringValue = "foo",
                    IntValue = 2,
                    DoubleValue = 2.0D,
                    BooleanValue = false,
                    Bar = null,
                    Fizzes = new List<InnerFizzDto>()
                },
                new FooDto
                {
                    StringValue = "fooo",
                    IntValue = 3,
                    DoubleValue = 3.0D,
                    BooleanValue = true,
                    Bar = null,
                    Fizzes = new List<InnerFizzDto>()
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
        internal void GivenMapFromInnerBarDtoToInnerBarWhenSourceIsNotNullThenMapsData()
        {
            // Arrange
            var barDto = new InnerBarDto
            {
                Value = "test"
            };

            // Act
            var bar = mapper.Map<InnerBar>(barDto);

            // Assert
            bar.Should().NotBeNull().And.BeOfType<InnerBar>();
            bar.Value.Should().Be(barDto.Value);
        }

        [Fact]
        internal void GivenMapFromInnerBarDtoToInnerBarWhenSourceIsNullThenMapsNoData()
        {
            // Arrange
            var barDto = (InnerBarDto)null;

            // Act
            var bar = mapper.Map<InnerBar>(barDto);

            // Assert
            bar.Should().BeNull();
        }

        [Fact]
        internal void GivenCollectionMapFromInnerBarDtoToInnerBarWhenSourceIsNotEmptyThenMapsData()
        {
            // Arrange
            var barDtos = new List<InnerBarDto>
            {
                new InnerBarDto
                {
                    Value = "bar"
                },
                new InnerBarDto
                {
                    Value = "barr"
                },
                new InnerBarDto
                {
                    Value = "barrr"
                }
            };

            // Act
            var bars = mapper.Map<IEnumerable<InnerBar>>(barDtos);

            // Assert
            bars.Should().NotBeNull().And.BeAssignableTo<IEnumerable<InnerBar>>();
            bars.Should().NotBeEmpty().And.HaveCount(3);
            (bars as IList<InnerBar>)[0].Value.Should().Be(barDtos[0].Value);
            (bars as IList<InnerBar>)[1].Value.Should().Be(barDtos[1].Value);
            (bars as IList<InnerBar>)[2].Value.Should().Be(barDtos[2].Value);
        }

        [Fact]
        internal void GivenCollectionMapFromInnerBarDtoToInnerBarWhenSourceIsEmptyThenMapsNoData()
        {
            // Arrange
            var barDtos = new List<InnerBarDto>();

            // Act
            var bars = mapper.Map<IEnumerable<InnerBar>>(barDtos);

            // Assert
            bars.Should().NotBeNull().And.BeAssignableTo<IEnumerable<InnerBar>>().And.BeEmpty();
        }

        [Fact]
        internal void GivenMapFromInnerFizzDtoToInnerFizzWhenSourceIsNotNullThenMapsData()
        {
            // Arrange
            var fizzDto = new InnerFizzDto
            {
                Value = "fizz",
                Buzzes = new List<SubInnerBuzzDto>()
            };

            // Act
            var fizz = mapper.Map<InnerFizz>(fizzDto);

            // Assert
            fizz.Should().NotBeNull().And.BeOfType<InnerFizz>();
            fizz.Value.Should().Be(fizzDto.Value);
            fizz.Buzzes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        internal void GivenMapFromInnerFizzDtoToInnerFizzWhenSourceIsNullThenMapsNoData()
        {
            // Arrange
            var fizzDto = (InnerFizzDto)null;

            // Act
            var fizz = mapper.Map<InnerFizz>(fizzDto);

            // Assert
            fizz.Should().BeNull();
        }

        [Fact]
        internal void GivenCollectionMapFromInnerFizzDtoToInnerFizzWhenSourceIsNotEmptyThenMapsData()
        {
            // Arrange
            var fizzDtos = new List<InnerFizzDto>
            {
                new InnerFizzDto
                {
                    Value = "fiz",
                    Buzzes = new List<SubInnerBuzzDto>()
                },
                new InnerFizzDto
                {
                    Value = "fizz",
                    Buzzes = new List<SubInnerBuzzDto>()
                },
                new InnerFizzDto
                {
                    Value = "fizzz",
                    Buzzes = new List<SubInnerBuzzDto>()
                }
            };

            // Act
            var fizzes = mapper.Map<IEnumerable<InnerFizz>>(fizzDtos);

            // Assert
            fizzes.Should().NotBeNull().And.BeAssignableTo<IEnumerable<InnerFizz>>();
            fizzes.Should().NotBeEmpty().And.HaveCount(3);
            (fizzes as IList<InnerFizz>)[0].Value.Should().Be(fizzDtos[0].Value);
            (fizzes as IList<InnerFizz>)[0].Buzzes.Should().NotBeNull().And.BeEmpty();
            (fizzes as IList<InnerFizz>)[1].Value.Should().Be(fizzDtos[1].Value);
            (fizzes as IList<InnerFizz>)[1].Buzzes.Should().NotBeNull().And.BeEmpty();
            (fizzes as IList<InnerFizz>)[2].Value.Should().Be(fizzDtos[2].Value);
            (fizzes as IList<InnerFizz>)[2].Buzzes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        internal void GivenCollectionMapFromInnerFizzDtoToInnerFizzWhenSourceIsEmptyThenMapsNoData()
        {
            // Arrange
            var fizzDtos = new List<InnerFizzDto>();

            // Act
            var fizzes = mapper.Map<IEnumerable<InnerFizz>>(fizzDtos);

            // Assert
            fizzes.Should().NotBeNull().And.BeAssignableTo<IEnumerable<InnerFizz>>().And.BeEmpty();
        }

        [Fact]
        internal void GivenMapFromSubInnerBuzzDtoToSubInnerBuzzWhenSourceIsNotNullThenMapsData()
        {
            // Arrange
            var buzzDto = new SubInnerBuzzDto
            {
                Value = "buzz"
            };

            // Act
            var buzz = mapper.Map<SubInnerBuzz>(buzzDto);

            // Assert
            buzz.Should().NotBeNull().And.BeOfType<SubInnerBuzz>();
            buzz.Value.Should().Be(buzzDto.Value);
        }

        [Fact]
        internal void GivenMapFromSubInnerBuzzDtoToSubInnerBuzzWhenSourceIsNullThenMapsNoData()
        {
            // Arrange
            var buzzDto = (SubInnerBuzzDto)null;

            // Act
            var buzz = mapper.Map<SubInnerBuzz>(buzzDto);

            // Assert
            buzz.Should().BeNull();
        }

        [Fact]
        internal void GivenCollectionMapFromSubInnerBuzzDtoToSubInnerBuzzWhenSourceIsNotEmptyThenMapsData()
        {
            // Arrange
            var buzzDtos = new List<SubInnerBuzzDto>
            {
                new SubInnerBuzzDto
                {
                    Value = "buz"
                },
                new SubInnerBuzzDto
                {
                    Value = "buzz"
                },
                new SubInnerBuzzDto
                {
                    Value = "buzzz"
                }
            };

            // Act
            var buzzes = mapper.Map<IEnumerable<SubInnerBuzz>>(buzzDtos);

            // Assert
            buzzes.Should().NotBeNull().And.BeAssignableTo<IEnumerable<SubInnerBuzz>>();
            buzzes.Should().NotBeEmpty().And.HaveCount(3);
            (buzzes as IList<SubInnerBuzz>)[0].Value.Should().Be(buzzDtos[0].Value);
            (buzzes as IList<SubInnerBuzz>)[1].Value.Should().Be(buzzDtos[1].Value);
            (buzzes as IList<SubInnerBuzz>)[2].Value.Should().Be(buzzDtos[2].Value);
        }

        [Fact]
        internal void GivenCollectionMapFromSubInnerBuzzDtoToSubInnerBuzzWhenSourceIsEmptyThenMapsNoData()
        {
            // Arrange
            var buzzDtos = new List<SubInnerBuzzDto>();

            // Act
            var buzzes = mapper.Map<IEnumerable<SubInnerBuzz>>(buzzDtos);

            // Assert
            buzzes.Should().NotBeNull().And.BeAssignableTo<IEnumerable<SubInnerBuzz>>().And.BeEmpty();
        }
    }
}
