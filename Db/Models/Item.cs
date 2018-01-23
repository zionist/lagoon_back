using System;
using System.Collections.Generic;

namespace lagoon_back
{
    public partial class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specification { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }

        public ItemCategory Category { get; set; }
    }
}
