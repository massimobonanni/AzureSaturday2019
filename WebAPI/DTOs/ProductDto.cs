using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public int StoreQuantity { get; set; }

        public string ShortDescription { get; set; }

        public string Title { get; set; }

    }
}
