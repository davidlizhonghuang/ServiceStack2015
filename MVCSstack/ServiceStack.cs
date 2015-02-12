using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCSstack
{
    [Route("/hello")]
    [Route("/hello/{Name}")]
    public class ServiceStack
    {
        public string Name { get; set; }
    }
    public class HelloResponse
    {
        public string Result { get; set; }
    }
    public class HelloService : Service
    {
        public object Any(ServiceStack request)
        {
            return new HelloResponse { Result = "Hello, " + request.Name };
        }
    }

    [Route("/product")]
    public class ProductEF
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; } 
    } 
    public class ProductReponse
    {
        public List<ProductEF> products { get; set; }
    }

    public class ProductService : IService
    {
        apiinjectEntities db = new apiinjectEntities();
        public object Any(ProductEF request)
        {
            var allProducts = db.Products;

            var allProductList = new List<ProductEF>();

            allProductList.Clear();

            foreach (var item in allProducts)
            {
                request = new ProductEF();
                request.Desc = item.Desc;
                request.Id = item.Id;
                request.Name = item.Name;
                request.UnitPrice = item.UnitPrice;
                allProductList.Add(request);
            };

            return new ProductReponse
            {
                products = allProductList
            };
        }

    }




    //public class ProductService : IService
    //{
    //    apiinjectEntities et = new apiinjectEntities();
    //    public object Any(ProductEF request)
    //    {
    //       var  pdt= et.Products;

    //        var pef = new List<ProductEF>();

    //        pef.Clear();
    //        foreach (var ppp in pdt)
    //        {
    //            var pef1 = new ProductEF();
    //            pef1.Desc = ppp.Desc;
    //            pef1.Id = ppp.Id;
    //            pef1.Name = ppp.Name;
    //            pef1.UnitPrice = ppp.UnitPrice;
    //            pef.Add(pef1);
    //        };

    //        return new ProductReponse
    //        {
    //            products = pef
    //        };
    //    }

    //}


    public class ProductListing : List<Product>
    {
        public IEnumerable<Product> GetAllFoods()
        {
            return this.AsEnumerable();
        }


    }
}
