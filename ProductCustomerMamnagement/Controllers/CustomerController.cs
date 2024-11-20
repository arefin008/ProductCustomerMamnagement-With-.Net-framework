using ProductCustomerMamnagement.DTOs;
using ProductCustomerMamnagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductCustomerMamnagement.Controllers
{
    public class CustomerController : Controller
    {
        ProductCustomerManagementEntities db = new ProductCustomerManagementEntities();

        public static Customer Convert(CustomerDTO d)
        {
            return new Customer
            {
                CustomerId = d.CustomerId,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email,
                Phone = d.Phone,
                Address = d.Address,
                DateJoined = d.DateJoined

            };
        }

        public static CustomerDTO Convert(Customer d)
        {
            return new CustomerDTO
            {
                CustomerId = d.CustomerId,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email,
                Phone = d.Phone,
                Address = d.Address,
                DateJoined = d.DateJoined
            };
        }

        public static List<CustomerDTO> Convert(List<Customer> data)
        {
            var list = new List<CustomerDTO>();
            foreach (var d in data)
            {
                list.Add(Convert(d));
            }
            return list;
        }
        // GET: Product
        public ActionResult List()
        {
            var data = db.Customers.ToList();
            return View(Convert(data));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Customer());
        }

        [HttpPost]
        public ActionResult Create(CustomerDTO d)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(Convert(d));
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(d);
        }

        public ActionResult Details(int id)
        {
            var exobj = db.Customers.Find(id);
            return View(Convert(exobj));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var exobj = db.Customers.Find(id);
            return View(Convert(exobj));
        }
        [HttpPost]
        public ActionResult Edit(CustomerDTO d)
        {
            var exobj = db.Customers.Find(d.CustomerId);
            db.Entry(exobj).CurrentValues.SetValues(d);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var exobj = db.Customers.Find(id);
            return View(Convert(exobj));
        }
        [HttpPost]
        public ActionResult Delete(int CustomerId, string dcsn)
        {
            if (dcsn.Equals("Yes"))
            {
                var exobj = db.Customers.Find(CustomerId);
                db.Customers.Remove(exobj);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

    }
}