using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class Helper
    {
        public static List<Item> GetAvailableItems()
        {
            List<Item> items = new List<Item>
            {
                new Item("Sword of Truth", 6, 5, 1),
                new Item("Druzelda's Wand", 1, 3, 7),
                new Item("Hand of Midas", 1, 1, 1),
                new Item("Achilles' Shield", 5, 2, 1),
                new Item("Staff of Wisdom", 4, 2, 5),
                new Item("Hermes Boots", 1, 1, 1),
                new Item("Ring of Power", 9, 9, 9)
            };

            return items;
        }
    }
}