using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCore.AutoMapperPrototype.App.Data.Dtos;
using NetCore.AutoMapperPrototype.App.Data.Entities;
using System.Collections.Generic;

namespace NetCore.AutoMapperPrototype.App.Controllers
{
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
        public IActionResult TestBarMapping([FromBody] InnerBarDto dto)
        {
            var bar = mapper.Map<InnerBar>(dto);

            return Ok(bar);
        }

        [HttpPost]
        [Route("api/v1/map/test-bars")]
        public IActionResult TestBarsMapping([FromBody] ICollection<InnerBarDto> dtos)
        {
            var bars = mapper.Map<IEnumerable<InnerBar>>(dtos);

            return Ok(bars);
        }

        [HttpPost]
        [Route("api/v1/map/test-fizz")]
        public IActionResult TestFizzMapping([FromBody] InnerFizzDto dto)
        {
            var fizz = mapper.Map<InnerFizz>(dto);

            return Ok(fizz);
        }

        [HttpPost]
        [Route("api/v1/map/test-fizzes")]
        public IActionResult TestFizzesMapping([FromBody] ICollection<InnerFizzDto> dtos)
        {
            var fizzes = mapper.Map<IEnumerable<InnerFizz>>(dtos);

            return Ok(fizzes);
        }

        [HttpPost]
        [Route("api/v1/map/test-buzz")]
        public IActionResult TestBuzzMapping([FromBody] SubInnerBuzzDto dto)
        {
            var buzz = mapper.Map<SubInnerBuzz>(dto);

            return Ok(buzz);
        }

        [HttpPost]
        [Route("api/v1/map/test-buzzes")]
        public IActionResult TestBuzzesMapping([FromBody] ICollection<SubInnerBuzzDto> dtos)
        {
            var buzzes = mapper.Map<IEnumerable<SubInnerBuzz>>(dtos);

            return Ok(buzzes);
        }
    }
}
