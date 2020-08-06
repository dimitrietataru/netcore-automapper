using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetCore.AutoMapperPrototype.App.Data.Dtos
{
    public sealed class InnerFizzDto
    {
        [Required]
        [MaxLength(100)]
        public string Value { get; set; }

        [Required]
        public IEnumerable<SubInnerBuzzDto> Buzzes { get; set; } = new List<SubInnerBuzzDto>();
    }
}
