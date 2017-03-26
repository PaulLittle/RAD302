using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AngularClientWeek82.Models;
using System.Web.Http.Cors;

namespace AngularClientWeek82.Controllers
{
    [RoutePrefix("api/orders")]
    [EnableCors("http://localhost:1915", "*","*")]
    public class OrdersController : ApiController
    {
        private BusinessDBContext db = new BusinessDBContext();

        //GET: api/Orders
        public List<dynamic> Get()
        {
            return db.Orders.Include("Customer").Include("Orderlines").ToList<dynamic>();
        }
               

        [Route("getOrdersWithProducts/ID/{id:int}")]
        public IQueryable<OrderLine> GetOrdersWithProducts(int id)
        {
            var ordersWithProducts = db.OrderLines.Include(l => l.Product)
                .Include(l => l.Order)
                .Include(o => o.Order.Customer)
                .Where(o => o.OrderID == id);
            return ordersWithProducts;
        }

        [Route("GetOrders")]
        public List<dynamic> GetOrders()
        {
            var GetOrders = db.Orders
                .Include(o => o.Orderlines)
                .Select(o => new {
                    id = o.ID,
                    orderDate = o.OrderDate,
                    enteredBy = o.EnteredBy,
                    customerId = o.CustomerID,
                    orderLines = o.Orderlines
                .Select(ol => new { id = ol.ID, orderId = ol.OrderID, productId = ol.ProductID, quantity = ol.Quantity })
                });
            //.Select(c => new { id = c.ID, name = c.Name });
            return GetOrders.ToList<dynamic>();
        }

        [Route("GetOrderLines/ID/{id:int}")]
        public List<dynamic> GetOrderLines(int id)
        {
            var GetOrderLines = db.OrderLines
                .Where(ol => ol.OrderID == id);
            return GetOrderLines.ToList<dynamic>();
        }

        // GET: api/Orders/5
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> GetOrder(int id)
        {
            Order order;

            if (id > 0)
                order = await db.Orders.FindAsync(id);
            else
                order = new Order()
                { OrderDate = DateTime.Now};
            return Ok(order);
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.ID)
            {
                return BadRequest();
            }

            db.Entry(order).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Orders
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Orders.Add(order);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = order.ID }, order);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> DeleteOrder(int id)
        {
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            db.Orders.Remove(order);
            await db.SaveChangesAsync();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(int id)
        {
            return db.Orders.Count(e => e.ID == id) > 0;
        }
    }
}