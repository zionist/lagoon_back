using System;
using System.Collections.Generic;

namespace lagoon_back.DAL.App
{
    public partial class Item
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Specification { get; set; }
        public int Price { get; set; }
        public long CategoryId { get; set; }
        public string ImagePath { get; set; }

        public ItemCategory Category { get; set; }
    }
}
