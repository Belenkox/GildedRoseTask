using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public static class ItemsUtils
    {
        //default quality changes in one day
        static int normalItemQualityChange = -1;
        static int agedItemQualityChange = -normalItemQualityChange;
        static int legendaryItemQualityChange = 0;
        static int backstagePassQualityChange = 1;
        static int conjuredItemQualityChange = 2 * normalItemQualityChange;

        //bounds
        static int qualityLowerBound = 0;
        static int qualityUpperBound = 50;

        public static int NormalItemQualityChange
        {
            get { return normalItemQualityChange; }
        }

        public static int AgedItemQualityChange
        {
            get { return agedItemQualityChange; }
        }

        public static int LegendaryItemQualityChange
        {
            get { return legendaryItemQualityChange; }
        }

        public static int BackstagePassQualityChange
        {
            get { return backstagePassQualityChange; }
        }

        public static int ConjuredItemQualityChange
        {
            get { return conjuredItemQualityChange; }
        }

        public static int QualityLowerBound
        {
            get { return qualityLowerBound; }
        }

        public static int QualityUpperBound
        {
            get { return qualityUpperBound; }
        }
    }
}
