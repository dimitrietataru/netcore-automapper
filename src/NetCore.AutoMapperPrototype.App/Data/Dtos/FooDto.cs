namespace NetCore.AutoMapperPrototype.App.Data.Dtos;

public sealed class FooDto
{
    [Required]
    [MaxLength(100)]
    public string? StringValue { get; set; }

    [Required]
    [Range(0, 100)]
    public int IntValue { get; set; }

    [Required]
    [Range(0.0D, 100.0D)]
    public double DoubleValue { get; set; }

    [Required]
    public bool BooleanValue { get; set; }

    [Required]
    public BarDto? Bar { get; set; }

    [Required]
    public IEnumerable<FizzDto> Fizzes { get; set; } = new List<FizzDto>();
}
