using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18File_IO_Deserialization
{
    public class InventoryItem
    {
        public InventoryItem(string productId, string productName, string description, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            Description = description;
            Price = price;
        }

        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


        // ToString() will be called:
        // 1. If you explicitly call it, myInstance.ToString()
        // 2. If you pass the instance into a method that expecting a string. For example, Console.WriteLine(myInstance)
        public override string ToString()
        {
            return $"{ProductId}||{ProductName}||{Description}||{Price}";
        }
    }
}
