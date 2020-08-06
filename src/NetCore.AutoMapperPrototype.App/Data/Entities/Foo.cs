using System.Collections.Generic;

namespace NetCore.AutoMapperPrototype.App.Data.Entities
{
    public sealed class Foo
    {
        public string StringValue { get; set; }
        public int IntValue { get; set; }
        public double DoubleValue { get; set; }
        public bool BooleanValue { get; set; }

        public InnerBar Bar { get; set; }
        public IEnumerable<InnerFizz> Fizzes { get; set; } = new List<InnerFizz>();
    }
}
