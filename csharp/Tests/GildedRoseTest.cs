using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void NormalItems()
        {
            IList<Item> Items = new List<Item> { 
                new Item { Name = "+5 Dexterity Vest", SellIn = 1, Quality = 2 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 10 },
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0 }};
            GildedRose app = new GildedRose(Items);
            var tmpQuality1 = Items[0].Quality;
            var tmpQuality2 = Items[1].Quality;
            app.UpdateQuality();

            // Normal item quality degrades by 1 when SellIn > 0
            Assert.AreEqual(tmpQuality1 + ItemsUtils.NormalItemQualityChange, Items[0].Quality);
            // Normal item quality degrades by 2 when SellIn <= 0
            Assert.AreEqual(tmpQuality2 + ItemsUtils.NormalItemQualityChange * 2, Items[1].Quality);
            // Normal item quality can't be lower than 0
            Assert.AreEqual(ItemsUtils.QualityLowerBound, Items[2].Quality);
        }

        [Test]
        public void AgedItems()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = 1, Quality = 2 },
                new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 },
                new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 }};
            GildedRose app = new GildedRose(Items);
            var tmpQuality1 = Items[0].Quality;
            var tmpQuality2 = Items[1].Quality;
            app.UpdateQuality();

            // Aged item quality increases by 1 when SellIn > 0
            Assert.AreEqual(tmpQuality1 + ItemsUtils.AgedItemQualityChange, Items[0].Quality);
            // Aged item quality increases by 2 when SellIn <= 0
            Assert.AreEqual(tmpQuality2 + 2 * ItemsUtils.AgedItemQualityChange, Items[1].Quality);
            // Aged item quality can't be higher than 50
            Assert.AreEqual(ItemsUtils.QualityUpperBound, Items[2].Quality);
        }

        [Test]
        public void LegendaryItems()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 100 }};
            GildedRose app = new GildedRose(Items);
            var tmpSellIn = Items[0].SellIn;
            var tmpQuality = Items[0].Quality;
            app.UpdateQuality();

            // Legendary item SellIn value does not change
            Assert.AreEqual(tmpSellIn, Items[0].SellIn);
            // Legendary item quality value does not change
            Assert.AreEqual(tmpQuality + ItemsUtils.LegendaryItemQualityChange, Items[0].Quality);
        }

        [Test]
        public void BackstagePass()
        {
            IList<Item> Items = new List<Item> 
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 16 },
                new Item  { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 },
                new Item  { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 16 },
                new Item  { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 48 },
                new Item  { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 46 }
                
            };
            GildedRose app = new GildedRose(Items);
            var tmpQuality1 = Items[0].Quality;
            var tmpQuality2 = Items[1].Quality;
            var tmpQuality3 = Items[2].Quality;
            app.UpdateQuality();

            // Backstage pass quality increases by 1 when SellIn > 10
            Assert.AreEqual(tmpQuality1 + ItemsUtils.BackstagePassQualityChange, Items[0].Quality);
            // Backstage pass quality increases by 2 when 5 < SellIn <= 10
            Assert.AreEqual(tmpQuality2 + 2 * ItemsUtils.BackstagePassQualityChange, Items[1].Quality);
            // Backstage pass quality increases by 3 when SellIn <= 5
            Assert.AreEqual(tmpQuality3 + 3 * ItemsUtils.BackstagePassQualityChange, Items[2].Quality);
            // Backstage pass quality value can't be higher than 50
            Assert.AreEqual(ItemsUtils.QualityUpperBound, Items[3].Quality);
            // Backstage pass quality value is equal to 0 if SellIn < 0
            Assert.AreEqual(0, Items[4].Quality);
        }

        [Test]
        public void ConjuredItem()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Conjured Mana Cake", SellIn = 2, Quality = 10 },
                new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 5 },
                new Item { Name = "Conjured Mana Cake", SellIn = -2, Quality = 3 }
            };
            GildedRose app = new GildedRose(Items);
            var tmpQuality1 = Items[0].Quality;
            var tmpQuality2 = Items[1].Quality;
            app.UpdateQuality();

            // Conjured item quality decreases twice as fast than normal item when SellIn > 0
            Assert.AreEqual(tmpQuality1 + ItemsUtils.ConjuredItemQualityChange, Items[0].Quality);
            // Conjured item quality decreases 2 more times faster when SellIn <= 0
            Assert.AreEqual(tmpQuality2 + 2 * ItemsUtils.ConjuredItemQualityChange, Items[1].Quality);
            // Conjured item quality can't be lower than 0
            Assert.AreEqual(ItemsUtils.QualityLowerBound, Items[2].Quality);
        }
    }
}
