namespace NetCore.AutoMapperPrototype.App.Controllers;

[ApiController]
[Produces("application/json")]
public sealed class MapController : ControllerBase
{
    private readonly IMapper mapper;

    public MapController(IMapper mapper) => this.mapper = mapper;

    [HttpPost]
    [Route("api/v1/map/test-foo")]
    public IActionResult TestFooMapping([FromBody] FooDto dto)
    {
        var foo = mapper.Map<Foo>(dto);

        return Ok(foo);
    }

    [HttpPost]
    [Route("api/v1/map/test-foos")]
    public IActionResult TestFoosMapping([FromBody] ICollection<FooDto> dtos)
    {
        var foos = mapper.Map<IEnumerable<Foo>>(dtos);

        return Ok(foos);
    }

    [HttpPost]
    [Route("api/v1/map/test-bar")]
    public IActionResult TestBarMapping([FromBody] BarDto dto)
    {
        var bar = mapper.Map<Bar>(dto);

        return Ok(bar);
    }

    [HttpPost]
    [Route("api/v1/map/test-bars")]
    public IActionResult TestBarsMapping([FromBody] ICollection<BarDto> dtos)
    {
        var bars = mapper.Map<IEnumerable<Bar>>(dtos);

        return Ok(bars);
    }

    [HttpPost]
    [Route("api/v1/map/test-fizz")]
    public IActionResult TestFizzMapping([FromBody] FizzDto dto)
    {
        var fizz = mapper.Map<Fizz>(dto);

        return Ok(fizz);
    }

    [HttpPost]
    [Route("api/v1/map/test-fizzes")]
    public IActionResult TestFizzesMapping([FromBody] ICollection<FizzDto> dtos)
    {
        var fizzes = mapper.Map<IEnumerable<Fizz>>(dtos);

        return Ok(fizzes);
    }

    [HttpPost]
    [Route("api/v1/map/test-buzz")]
    public IActionResult TestBuzzMapping([FromBody] BuzzDto dto)
    {
        var buzz = mapper.Map<Buzz>(dto);

        return Ok(buzz);
    }

    [HttpPost]
    [Route("api/v1/map/test-buzzes")]
    public IActionResult TestBuzzesMapping([FromBody] ICollection<BuzzDto> dtos)
    {
        var buzzes = mapper.Map<IEnumerable<Buzz>>(dtos);

        return Ok(buzzes);
    }
}
