using System.Collections.Generic;

namespace NetCore.AutoMapperPrototype.App.Data.Entities
{
    public sealed class InnerFizz
    {
        public string Value { get; set; }

        public IEnumerable<SubInnerBuzz> Buzzes { get; set; } = new List<SubInnerBuzz>();
    }
}
