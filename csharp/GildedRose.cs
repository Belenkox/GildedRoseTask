using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                UpdateItemQuality(i);
                UpdateItemSellIn(i);
            }
        }

        private void UpdateItemSellIn(int index)
        {
            switch(ItemTypeManager.GetItemTypeByName(Items[index].Name))
            {
                case ItemTypes.Legendary:
                    break;
                default:
                    Items[index].SellIn--;
                    break;
            }
        }

        private void UpdateItemQuality(int index)
        {
            Items[index] = QualityManager.CalculateNewQuality(Items[index]);
        }
    }
}
