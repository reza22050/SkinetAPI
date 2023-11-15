using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.OrderAggregate
{
    public class ProductItemOrdered
    {
        public ProductItemOrdered(int productItemId, string productName, string productUrl)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            PictureUrl = productUrl;
        }

        public ProductItemOrdered()
        {
                
        }

        public int ProductItemId { get; set; }
        public string ProductName { get; set; } 
        public string PictureUrl { get; set; }
    }
}
