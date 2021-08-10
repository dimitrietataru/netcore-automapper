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
            RegisterFooMappingProfiles();
            RegisterBarMappingProfiles();
            RegisterFizzMappingProfiles();
            RegisterBuzzMappingProfiles();
        }

        private void RegisterFooMappingProfiles()
        {
            CreateMap<FooDto, Foo>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ForMember(
                    destination => destination.StringValue,
                    options => options.MapFrom(source => source.StringValue))
                .ForMember(
                    destination => destination.IntValue,
                    options => options.Ignore())
                .ForMember(
                    destination => destination.DoubleValue,
                    options => options.MapFrom(source => source.DoubleValue))
                .ForMember(
                    destination => destination.BooleanValue,
                    options => options.Ignore())
                .ForMember(
                    destination => destination.Bar,
                    options => options.MapFrom(source => source.Bar))
                .ForMember(
                    destination => destination.Fizzes,
                    options => options.MapFrom(source => source.Fizzes))
                .AfterMap(
                    (source, destination) =>
                    {
                        destination.IntValue = source.IntValue * 10;
                        destination.BooleanValue = !source.BooleanValue;
                    })
                .ForAllOtherMembers(options => options.Ignore());
        }

        private void RegisterBarMappingProfiles()
        {
            CreateMap<BarDto, Bar>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ForMember(
                    destination => destination.Value,
                    options => options.MapFrom(source => source.Value))
                .ForAllOtherMembers(options => options.Ignore());
        }

        private void RegisterFizzMappingProfiles()
        {
            CreateMap<FizzDto, Fizz>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ForMember(
                    destination => destination.Value,
                    options => options.MapFrom(source => source.Value))
                .ForMember(
                    destination => destination.Buzzes,
                    options => options.MapFrom(source => source.Buzzes))
                .ForAllOtherMembers(options => options.Ignore());
        }

        private void RegisterBuzzMappingProfiles()
        {
            CreateMap<BuzzDto, Buzz>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ForMember(
                    destination => destination.Value,
                    options => options.MapFrom(source => source.Value))
                .AfterMap(
                    (source, destination) =>
                    {
                        destination.Value = $"Value: { destination.Value }";
                    })
                .ForAllOtherMembers(options => options.Ignore());
        }
    }
}
