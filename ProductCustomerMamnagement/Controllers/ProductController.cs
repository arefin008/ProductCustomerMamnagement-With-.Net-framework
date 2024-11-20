using ProductCustomerMamnagement.DTOs;
using ProductCustomerMamnagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductCustomerMamnagement.Controllers
{
    public class ProductController : Controller
    {
        ProductCustomerManagementEntities db = new ProductCustomerManagementEntities();

        public static Product Convert(ProductDTO d)
        {
            return new Product
            {
                ProductId =d.ProductId,
                Name = d.Name,
                Description = d.Description,
                Price = d.Price,
                StockQuantity = d.StockQuantity,
                Category = d.Category

            };
        }

        public static ProductDTO Convert(Product d)
        {
            return new ProductDTO
            {
                ProductId = d.ProductId,
                Name = d.Name,
                Description = d.Description,
                Price = d.Price,
                StockQuantity = d.StockQuantity,
                Category = d.Category
            };
        }

        public static List<ProductDTO> Convert(List<Product> data)
        {
            var list = new List<ProductDTO>();
            foreach(var d in data)
            {
                list.Add(Convert(d));
            }
            return list;
        }
        // GET: Product
        public ActionResult List()
        {
            var data = db.Products.ToList();
            return View(Convert(data));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Create(ProductDTO d)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(Convert(d));
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(d);
        }

        public ActionResult Details(int id)
        {
            var exobj = db.Products.Find(id);
            return View(Convert(exobj));
        }
        [HttpGet]
        public ActionResult Edit(int id) 
        { 
            var exobj = db.Products.Find(id);
            return View(Convert(exobj));
        }
        [HttpPost]
        public ActionResult Edit(ProductDTO d)
        {
            var exobj = db.Products.Find(d.ProductId);
            db.Entry(exobj).CurrentValues.SetValues(d);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Delete(int id) 
        {
            var exobj = db.Products.Find(id);
            return View(Convert(exobj));
        }
        [HttpPost]
        public ActionResult Delete(int ProductId,string dcsn)
        {
            if (dcsn.Equals("Yes"))
            {
                var exobj = db.Products.Find(ProductId);
                db.Products.Remove(exobj);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

    }
}