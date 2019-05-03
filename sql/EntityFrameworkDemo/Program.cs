using DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static List<Customer> GetCustomers()
        {
            using (var db = new AdventureWorksEntities())
            {
                return db.Customers.ToList();
            }
        }

        public static List<string> GetCustomerNames()
        {
            using (var db = new AdventureWorksEntities())
            {
                return db.Customers.Select(x => x.FirstName
                + " "
                + x.MiddleName
                + " "
                + x.LastName).ToList();
            }
        }

        public static List<Customer> GetTopNCustomersSortedByLastName(int n)
        {
            using (var db = new AdventureWorksEntities())
            {
                return db.Customers
                    .OrderBy(x => x.LastName)
                    .ThenBy(x => x.FirstName)
                    .Take(n)
                    .ToList();
            }
        }

        public static string GetProductCategoryName(int productId)
        {
            using (var db = new AdventureWorksEntities())
            {
                // look for a matching product
                var matchingProduct = db.Products
                    .SingleOrDefault(x => x.ProductID == productId);

                // if there is no match, this is an error
                if (matchingProduct == null)
                    throw new Exception("No matching product with id = " + productId);

                // return the product category name
                return matchingProduct.ProductCategory.Name;
            }
        }

        public static List<Product> GetProducts()
        {
            using (var db = new AdventureWorksEntities())
            {
                return db.Products
                    .Include(x => x.ProductCategory)
                    .Include(x => x.ProductModel)
                    .Include(x => x.SalesOrderDetails)
                    .ToList();
            }
        }

        public static int AddCustomer()
        {
            using (var db = new AdventureWorksEntities())
            {
                var customer = new Customer();
                customer.NameStyle = false;
                customer.FirstName = "Bill";
                customer.LastName = "Gates";
                customer.PasswordHash = string.Empty;
                customer.PasswordSalt = string.Empty;
                customer.rowguid = Guid.NewGuid();
                customer.ModifiedDate = DateTime.Now;

                db.Customers.Add(customer);
                db.SaveChanges();

                return customer.CustomerID;
            }
        }

        public static List<Customer> GetCustomerById(int id)
        {
            using (var db = new AdventureWorksEntities())
            {
                return db.cuspCustomerSelect(id).ToList();
            }
        }
    }
}
