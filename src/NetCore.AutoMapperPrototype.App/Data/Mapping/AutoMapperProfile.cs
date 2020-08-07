using AutoMapper;
using NetCore.AutoMapperPrototype.App.Data.Dtos;
using NetCore.AutoMapperPrototype.App.Data.Entities;
using System.Diagnostics;

namespace NetCore.AutoMapperPrototype.App.Data.Mapping
{
    [DebuggerStepThrough]
    public sealed class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<FooDto, Foo>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ForMember(
                    destination => destination.StringValue,
                    options => options.MapFrom(source => source.StringValue))
                .ForMember(
                    destination => destination.IntValue,
                    options => options.MapFrom(source => source.IntValue))
                .ForMember(
                    destination => destination.DoubleValue,
                    options => options.MapFrom(source => source.DoubleValue))
                .ForMember(
                    destination => destination.BooleanValue,
                    options => options.MapFrom(source => source.BooleanValue))
                .ForMember(
                    destination => destination.Bar,
                    options => options.MapFrom(source => source.Bar))
                .ForMember(
                    destination => destination.Fizzes,
                    options => options.MapFrom(source => source.Fizzes))
                .ForAllOtherMembers(options => options.Ignore());

            CreateMap<BarDto, Bar>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ForMember(
                    destination => destination.Value,
                    options => options.MapFrom(source => source.Value))
                .ForAllOtherMembers(options => options.Ignore());

            CreateMap<FizzDto, Fizz>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ForMember(
                    destination => destination.Value,
                    options => options.MapFrom(source => source.Value))
                .ForMember(
                    destination => destination.Buzzes,
                    options => options.MapFrom(source => source.Buzzes))
                .ForAllOtherMembers(options => options.Ignore());

            CreateMap<BuzzDto, Buzz>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ForMember(
                    destination => destination.Value,
                    options => options.MapFrom(source => source.Value))
                .ForAllOtherMembers(options => options.Ignore());
        }
    }
}
