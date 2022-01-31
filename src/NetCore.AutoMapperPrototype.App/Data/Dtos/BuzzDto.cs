namespace NetCore.AutoMapperPrototype.App.Data.Dtos;

public sealed class BuzzDto
{
    [Required]
    [MaxLength(100)]
    public string? Value { get; set; }
}
