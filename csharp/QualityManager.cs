using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public static class QualityManager
    {
        static Dictionary<ItemTypes, RangesContainer> AllRanges = new Dictionary<ItemTypes, RangesContainer>();
        
        //Sets items quality dependency by range
        public static void Initialize()
        {
            AllRanges = new Dictionary<ItemTypes, RangesContainer>();
            AllRanges.Add(ItemTypes.Normal, new RangesContainer(new List<Range>
            {
                new Range(0, 2 * ItemsUtils.NormalItemQualityChange),
                new Range(int.MaxValue, ItemsUtils.NormalItemQualityChange)
            }));
            AllRanges.Add(ItemTypes.Aged, new RangesContainer(new List<Range>
            {
                new Range(0, 2 * ItemsUtils.AgedItemQualityChange),
                new Range(int.MaxValue, ItemsUtils.AgedItemQualityChange)
            }));
            AllRanges.Add(ItemTypes.Legendary, new RangesContainer(new List<Range>
            {
                new Range(int.MaxValue, ItemsUtils.LegendaryItemQualityChange)
            }));
            AllRanges.Add(ItemTypes.BackstagePass, new RangesContainer(new List<Range>
            {
                new Range(0, 0),
                new Range(5, 3 * ItemsUtils.BackstagePassQualityChange),
                new Range(10, 2 * ItemsUtils.BackstagePassQualityChange),
                new Range(int.MaxValue, ItemsUtils.BackstagePassQualityChange)
                
            }));
            AllRanges.Add(ItemTypes.Conjured, new RangesContainer(new List<Range>
            {
                new Range(0, 2 * ItemsUtils.ConjuredItemQualityChange),
                new Range(int.MaxValue, ItemsUtils.ConjuredItemQualityChange)
            }));
        }

        //Calculates quality for the next day
        public static Item CalculateNewQuality(Item item)
        {
            ItemTypes itemType = ItemTypeManager.GetItemTypeByName(item.Name);
            Item newItem = item;
            RangesContainer ranges;
            if (AllRanges.TryGetValue(itemType, out ranges) == false)
            {
                throw new Exception("Could not get value by given key");
            }
            
            foreach (Range range in ranges.GetList())
            {
                if (newItem.SellIn <= range.SellInUpperBoundary)
                {
                    UpdateItemQuality(ref newItem, range.QualityChange, itemType);
                    break;
                }
            }
            return newItem;
        }

        //Calculates new quality
        private static void UpdateItemQuality(ref Item item, int qualityChange, ItemTypes type)
        {
            item.Quality += qualityChange;
            AdjustBoundaries(ref item, type);
            NullBackstagePass(ref item, type);
        }

        //Fixes item quality if it is exceeded the bounds
        private static void AdjustBoundaries(ref Item item, ItemTypes type)
        {
            if (type != ItemTypes.Legendary)
            {
                if (item.Quality > ItemsUtils.QualityUpperBound)
                    item.Quality = ItemsUtils.QualityUpperBound;
                else if (item.Quality < ItemsUtils.QualityLowerBound)
                    item.Quality = ItemsUtils.QualityLowerBound;
            }
        }

        //After concert nulls quality for backstage pass
        private static void NullBackstagePass(ref Item item, ItemTypes type)
        {
            if (type == ItemTypes.BackstagePass && item.SellIn <= 0 && item.Quality > 0)
                item.Quality = 0;
        }
    }
}
