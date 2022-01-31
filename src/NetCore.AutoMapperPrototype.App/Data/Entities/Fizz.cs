namespace NetCore.AutoMapperPrototype.App.Data.Entities;

public sealed class Fizz
{
    public string? Value { get; set; }

    public IEnumerable<Buzz> Buzzes { get; set; } = new List<Buzz>();
}
