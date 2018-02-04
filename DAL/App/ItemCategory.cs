using System;
using System.Collections.Generic;

namespace lagoon_back.DAL.App
{
    public partial class ItemCategory
    {
        public ItemCategory()
        {
            Item = new HashSet<Item>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public ICollection<Item> Item { get; set; }
    }
}
