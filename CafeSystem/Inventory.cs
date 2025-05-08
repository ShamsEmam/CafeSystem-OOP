using System;
using System.Collections.Generic;

namespace CafeSystem
{
    public class Inventory
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
        
        // Add support for items collection and price
        public List<InventoryItem> Items { get; set; } = new List<InventoryItem>();

        public Inventory(string productName, int reorderLevel, int quantity)
        {
            ProductName = productName;
            Quantity = quantity;
            ReorderLevel = reorderLevel;
            Items = new List<InventoryItem>();
        }

        public void AddItem(string name, int quantity, double price)
        {
            var existingItem = Items.Find(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                existingItem.Price = price; // Update price
            }
            else
            {
                Items.Add(new InventoryItem { Name = name, Quantity = quantity, Price = price });
            }
        }

        public void ReduceQuantity(int usedQuantity)
        {
            if (usedQuantity <= Quantity)
                Quantity -= usedQuantity;
            else
                Console.WriteLine($"Not enough {ProductName} in stock!");
        }

        public bool IsLow()
        {
            return Quantity <= ReorderLevel;
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"Product: {ProductName}, Quantity: {Quantity}, Reorder Level: {ReorderLevel}");
            if (IsLow())
            {
                Console.WriteLine($"Reorder needed for {ProductName}!");
            }
        }
    }

    public class InventoryItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
