using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebServer.Models;

namespace WebServer.Controllers {

    [Route("api/[controller]")]
    public class ProductsController : Controller {
        [HttpGet]
        public ActionResult Get() {
            if (null == FakeData.Products) {
                return NotFound();
            }
            return Ok(FakeData.Products.Values.ToArray());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id) {
            if (FakeData.Products.ContainsKey(id))
                return Ok(FakeData.Products[id]);
            else
                return NotFound();
        }

        [HttpGet("price/{from}/{to}")]
        public ActionResult Get(int from, int to) {
            var res = FakeData.Products.Values.Where(p =>
                p.Price >= from
                && p.Price <= to
            ).ToArray();
            if (0 == res.Length) {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            if (FakeData.Products.ContainsKey(id)) {
                FakeData.Products.Remove(id);
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Product newP) {
            newP.ID = FakeData.Products.Keys.Max() + 1;
            FakeData.Products.Add(newP.ID, newP);
            return Created($"api/products/{newP.ID}", newP);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product p) {
            if (FakeData.Products.ContainsKey(id)) {
                var t = FakeData.Products[id];
                t.Name = p.Name;
                t.Price = p.Price;
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("raise/{rval}")]
        public ActionResult Raise(double rval) {
            foreach (var p in FakeData.Products.Values) {
                p.Price = System.Math.Round(p.Price + rval, 2);
            }
            return Ok();
        }
    }
}