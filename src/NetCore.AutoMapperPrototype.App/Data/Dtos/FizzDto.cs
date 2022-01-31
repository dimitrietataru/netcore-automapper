namespace NetCore.AutoMapperPrototype.App.Data.Dtos;

public sealed class FizzDto
{
    [Required]
    [MaxLength(100)]
    public string? Value { get; set; }

    [Required]
    public IEnumerable<BuzzDto> Buzzes { get; set; } = new List<BuzzDto>();
}
