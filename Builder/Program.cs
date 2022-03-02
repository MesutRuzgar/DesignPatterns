using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            var builder = new NewCustomerProductBuilder();
            productDirector.GenerateProduct(builder);
            var model=builder.GetModel();

            Console.WriteLine("Ürün Kodu : {0}", model.Id);
            Console.WriteLine("Kategori  : {0}", model.CategoryName);
            Console.WriteLine("Ürün İsmi : {0}", model.ProductName);
            Console.WriteLine(" Fiyatı : {0}", model.UnitPrice);
            Console.WriteLine("İndirimli Fiyat : {0}",model.DiscountedPrice);
            Console.WriteLine("İndirim Ugulandı mı? : {0}", model.DiscountApplied);
            Console.ReadLine();
        }
    }
   public class ProductViewModel

    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool  DiscountApplied { get; set; }

    }
    public abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }
   public class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * (decimal)0.90;
            model.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;


        }
    }
   public  class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice ;
            model.DiscountApplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }
    }
    public class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            //arka arkaya çalıştıracağımız işleri sıraladık.
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
