using System;
using System.Collections.Generic;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            QualityManager.Initialize();

            IList<Item> Items = ItemsGenerator.GenerateData();
            var app = new GildedRose(Items);

            OutputGenerator.GenerateOutput(Items, app);
        }
    }
}
