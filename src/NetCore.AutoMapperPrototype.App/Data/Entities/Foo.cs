using System.Collections.Generic;

namespace NetCore.AutoMapperPrototype.App.Data.Entities
{
    public sealed class Foo
    {
        public string StringValue { get; set; }
        public int IntValue { get; set; }
        public double DoubleValue { get; set; }
        public bool BooleanValue { get; set; }

        public Bar Bar { get; set; }
        public IEnumerable<Fizz> Fizzes { get; set; } = new List<Fizz>();
    }
}
