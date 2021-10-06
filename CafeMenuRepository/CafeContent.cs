using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenuRepository
{


    public class CafeContent
    {
        public int OrderNumber { get; set; }
        public string Menu { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }

        public CafeContent() { }


        public CafeContent(int orderNumber, string menu, string description, string ingredients, double price)
        {
            OrderNumber = orderNumber;
            Menu = menu;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }

}
