using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class Range
    {
        public int SellInUpperBoundary { get; set; }
        public int QualityChange { get; set; }

        public Range(int sellInUpperBoundary, int qualityChange)
        {
            this.SellInUpperBoundary = sellInUpperBoundary;
            this.QualityChange = qualityChange;
        }
    }
}
