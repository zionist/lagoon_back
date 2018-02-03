using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lagoon_back.Controllers
{
    // /admin/api/item_categories
    [Route("admin/api/[controller]")]
    [Authorize]
    public class Item_categoriesController : Controller
    {

        //   private readonly ILoggerFactory loggerFactory;
        //  private readonly ILogger logger;
        private AppDbContext lagoonContext;

        public Item_categoriesController(AppDbContext lagoonContext)
        {
            this.lagoonContext = lagoonContext;
        }


        // GET all admin/api/item_Categories
        [HttpGet]
        public List<ItemCategory> Get()
        {
            using (var db = this.lagoonContext)
            {
                var itemCategories = db.ItemCategory
                    //.Where(b => b.Rating > 3)
                    //.OrderBy(c => c.Name)
                    .ToList();
                return itemCategories;

            }

        }

        // get one
        [HttpGet("{id}")]
        public ItemCategory Get(int id)
        {
            using (var db = this.lagoonContext)
            {
                var itemCategory = db.ItemCategory
                .Where(c => c.Id == id).First();
                return itemCategory;

            }
        }

        // create
        [HttpPost]
        public ItemCategory Post([FromBody]ItemCategory value)
        {
            value.ImagePath = Guid.NewGuid().ToString();
            using (var db = this.lagoonContext)
            {
                db.Add(value);
                db.SaveChanges();
            }
            return value;

        }

        // update
        [HttpPut]
        public ItemCategory Put([FromBody]ItemCategory value)
        {

            using (var db = this.lagoonContext)
            {
                //var record = db.ItemCategory.Single(c => c.Id == id );
                db.Update(value);
                db.SaveChanges();
            }
            return value;
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var db = this.lagoonContext)
            {
                var record = db.ItemCategory.Single(c => c.Id == id);
                db.ItemCategory.Remove(record);
                db.SaveChanges();
            }
        }
    }
}
