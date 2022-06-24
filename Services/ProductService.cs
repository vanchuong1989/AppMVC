using AppMVC.Models;
using System.Collections.Generic;

namespace AppMVC.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[] {
                new ProductModel(){Id=1, Name="Iphone x", Price=1000},
                new ProductModel(){Id=2, Name="Sansung x", Price=500},
                new ProductModel(){Id=3, Name="Sony x", Price=800},
                new ProductModel(){Id=4, Name="Nokia x", Price=200}
                
            });
        }
    }
}
