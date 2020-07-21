using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public enum ItemTypes
    {
        Normal,
        Aged,
        Legendary,
        BackstagePass,
        Conjured
    }
    public static class ItemTypeManager
    {
        static Dictionary<string, ItemTypes> itemTypesByName = new Dictionary<string, ItemTypes>
        {
            { "+5 Dexterity Vest", ItemTypes.Normal },
            { "Elixir of the Mongoose", ItemTypes.Normal },
            { "Aged Brie", ItemTypes.Aged },
            { "Sulfuras, Hand of Ragnaros", ItemTypes.Legendary },
            { "Backstage passes to a TAFKAL80ETC concert", ItemTypes.BackstagePass },
            { "Conjured Mana Cake", ItemTypes.Conjured }
        };

        public static ItemTypes GetItemTypeByName(string itemName)
        {
            ItemTypes itemType = itemTypesByName[itemName];

            return itemType;
        }
    }

    
}
