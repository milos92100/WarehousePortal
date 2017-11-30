using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehousePortal.Entity
{
    class Article
    {
        public int Id { get; set; }
        public int ArtNo { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
        public int Quant { get; set; }



    }
}
