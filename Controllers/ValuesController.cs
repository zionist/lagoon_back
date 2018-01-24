using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lagoon_back.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

    //   private readonly ILoggerFactory loggerFactory;
     //  private readonly ILogger logger;
       private lagoonContext lagoonContext;

        public ValuesController(lagoonContext lagoonContext) {
            this.lagoonContext = lagoonContext;
        }


        // GET api/values
        [HttpGet]
         [Authorize]
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

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
       
        public List<ItemCategory> Post([FromBody]string value)
        {
            using (var db = this.lagoonContext)
            {
                var blogs = db.ItemCategory
                    //.Where(b => b.Rating > 3)
                    //.OrderBy(c => c.Name)
                    .ToList();
                return blogs;
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
