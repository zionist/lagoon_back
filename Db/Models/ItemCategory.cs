using System;
using System.Collections.Generic;

namespace lagoon_back
{
    public partial class ItemCategory
    {
        public ItemCategory()
        {
            Item = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public ICollection<Item> Item { get; set; }
    }
}
