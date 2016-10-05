using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework15 {
    static class DatabaseController {
        public enum Tables { Product, Sale }

        #region methods of creating entries
        static public void CreateEntry(Product product) {
            using (var db = new hm15Model()) {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }

        static public void CreateEntry(Sale sale) {
            using (var db = new hm15Model()) {
                db.Sales.Add(sale);
                db.SaveChanges();
            }
        }

        static public void CreateEntries(Product[] products) {
            using (var db = new hm15Model()) {
                foreach(Product prod in products)
                    db.Products.Add(prod);
                db.SaveChanges();
            }
        }

        static public void CreateEntries(Sale[] sales) {
            using (var db = new hm15Model()) {
                foreach(Sale sale in sales)
                    db.Sales.Add(sale);
                db.SaveChanges();
            }
        }
        #endregion

        static public bool RemoveEntryById(Tables table, Int32 id) {
            using (var db = new hm15Model()) {
                switch (table) {
                    case Tables.Product:
                        Product targetProd = db.Products.Where(p => p.ProductId == id).FirstOrDefault();
                        if (targetProd == default(Product))
                            return false;

                        db.Products.Remove(targetProd);
                        break;
                    case Tables.Sale:
                        Sale targetSale = db.Sales.Where(s => s.SaleId == id).FirstOrDefault();
                        if (targetSale == default(Sale))
                            return false;

                        db.Sales.Remove(targetSale);
                        break;
                }
                                
                db.SaveChanges();
                return true;
            }
        }

        #region methods edit entries
        static public bool ChangeProductNameById(Int32 id, String name) {
            using (var db = new hm15Model()) {
                Product target = db.Products.Where(p => p.ProductId == id).FirstOrDefault();
                if (target == default(Product))
                    return false;

                target.Name = name;
                db.SaveChanges();
                return true;
            }
        }

        static public bool ChangeProductPriceById(Int32 id, Decimal price) {
            using (var db = new hm15Model()) {
                Product target = db.Products.Where(p => p.ProductId == id).FirstOrDefault();
                if (target == default(Product))
                    return false;

                target.Price = price;
                db.SaveChanges();
                return true;
            }
        }

        static public bool ChangeSaleSumById(Int32 id, Decimal sum) {
            using (var db = new hm15Model()) {
                Sale target = db.Sales.Where(s => s.SaleId == id).FirstOrDefault();
                if (target == default(Sale))
                    return false;

                target.Sum = sum;
                db.SaveChanges();
                return true;
            }
        }
        #endregion

        static public void CleanTable(Tables table) {
            using (var db = new hm15Model()) {
                switch (table) {
                    case Tables.Product:
                        var itemsForAffectP = db.Products.Select(p => p);
                        foreach (var item in itemsForAffectP)
                            db.Products.Remove(item);
                        break;
                    case Tables.Sale:
                        var itemsForAffectS = db.Sales.Select(s => s);
                        foreach (var item in itemsForAffectS)
                            db.Sales.Remove(item);
                        break;
                }

                db.SaveChanges();
            }
        }


        #region getters of entry collections by id
        static public List<Product> GetProductsList() {
            using (var db = new hm15Model()) {
                return db.Products.ToList();
            }
        }

        static public List<Sale> GetSalesList() {
            using (var db = new hm15Model()) {
                return db.Sales.ToList();
            }
        }
        #endregion

        #region getters of entries by id
        static public Product GetProductById(Int32 id) {
            using (var db = new hm15Model()) {
                Product targetProd = db.Products.Where(p => p.ProductId == id).FirstOrDefault();

                return targetProd == default(Product) ? default(Product) : targetProd;
            }
        }

        static public Sale GetSaleById(int id) {
            using (var db = new hm15Model()) {
                Sale targetSale = db.Sales.Where(s => s.SaleId == id).FirstOrDefault();

                return targetSale == default(Sale) ? default(Sale) : targetSale;
            }
        }
        #endregion

        static public DataEntry GetDataEntryById(Int32 id) {
            using (var db = new hm15Model()) {
                DataEntry result = (from p in db.Products
                                    join s in db.Sales
                                        on p.ProductId equals s.SaleId
                                    select new {
                                        Id = p.ProductId,
                                        Name = p.Name,
                                        Price = p.Price,
                                        Sum = s.Sum
                                    })
                                    .Where(i => i.Id == id)
                                    .Select(i => new DataEntry() {
                                        Name = i.Name,
                                        Price = i.Price,
                                        Sum = i.Sum
                                    }).FirstOrDefault();

                return result == default(DataEntry) ? default(DataEntry) : result;
            }
        }

        static public bool Sale(Int32 id, Int32 amount) {
            using (var db = new hm15Model()) {
                Sale targetSale = db.Sales.Where(s => s.SaleId == id).FirstOrDefault();
                if (targetSale == default(Sale)) {
                    Product targetProd = db.Products.Where(p => p.ProductId == id).FirstOrDefault();
                    if (targetProd == default(Product))
                        return false;

                    targetSale = new Sale() {
                        Product = targetProd,
                        SaleId = targetProd.ProductId,
                        Sum = targetProd.Price * amount
                    };

                    db.Sales.Add(targetSale);
                    db.SaveChanges();
                } else {
                        targetSale.Sum += targetSale.Product.Price * amount;
                        db.SaveChanges();
                }

                return true;
            }
        }
    }
}
