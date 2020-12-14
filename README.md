# .NET - AutoMapper

## Install
``` powershell
PM> Install-Package AutoMapper -Version 10.1.1
PM> Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection -Version 8.1.0
```

## Configure Profiles
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

## Configure Dependency Injection
``` csharp
using AutoMapper;

public void ConfigureServices(IServiceCollection services)
{
    // ..

    services.AddAutoMapper(typeof(Startup));
    
    // ..
}
```
