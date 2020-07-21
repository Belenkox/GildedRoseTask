using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class RangesContainer
    {
        private List<Range> Ranges = new List<Range>();

        public RangesContainer(List<Range> initialList)
        {
            foreach(Range item in initialList)
            {
                Ranges.Add(new Range(item.SellInUpperBoundary, item.QualityChange));
            }
            Ranges = Ranges.OrderBy(x => x.SellInUpperBoundary).ToList();
        }

        public List<Range> GetList()
        {
            return Ranges;
        }
    }
}