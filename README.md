# .NET Core - AutoMapper

### Install
``` powershell
PM> Install-Package AutoMapper -Version 10.0.0
PM> Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection -Version 8.0.1
```

### Configure Profiles
``` csharp
public class AutoMapperProfile : AutoMapper.Profile
{
    public AutoMapperProfile()
    {
        CreateMap<TSource, TDestionation>();
        CreateMap<TDestionation, TSource>();
        
        CreateMap<Foo, Bar>();
        CreateMap<Bar, Foo>();
        
        CreateMap<Fizz, Buzz>().ReverseMap();
        
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
            .AfterMap(
                (source, destination) =>
                {
                    // ..
                })
            .ForAllOtherMembers(options => options.Ignore());
    }
}
```

### Configure Dependency Injection
``` csharp
// ..
```
