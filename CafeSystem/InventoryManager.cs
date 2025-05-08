using System;
using System.Collections.Generic;

namespace CafeSystem
{
    public class InventoryManager
    {
        private Dictionary<string, Inventory> StockItems;
        public Inventory inventory { get; private set; }

        public InventoryManager()
        {
            StockItems = new Dictionary<string, Inventory>();
            inventory = new Inventory("Main Inventory", 10, 0);
        }

        public void AddItem(string name, int quantity, double price)
        {
            // For the WinForms version, we'll simplify by adding items to a single inventory object
            inventory.AddItem(name, quantity, price);
            
            // Also maintain the original functionality
            if (!StockItems.ContainsKey(name))
            {
                StockItems[name] = new Inventory(name, 5, quantity);
            }
            else
            {
                StockItems[name].Quantity += quantity;
            }
        }

        public void UseFromStock(Dictionary<string, int> orderItems)
        {
            foreach (var item in orderItems)
            {
                string productName = item.Key;
                int quantityUsed = item.Value;

                if (StockItems.ContainsKey(productName))
                {
                    StockItems[productName].Quantity -= quantityUsed;

                    if (StockItems[productName].Quantity < StockItems[productName].ReorderLevel)
                    {
                        Console.WriteLine($"⚠️ Low stock alert: {productName} is below reorder level!");
                    }
                }
                else
                {
                    Console.WriteLine($"❌ Product not found in stock: {productName}");
                }
            }
        }

        public void CheckLowStock()
        {
            Console.WriteLine("🔍 Checking stock levels...");
            foreach (var item in StockItems)
            {
                if (item.Value.Quantity < item.Value.ReorderLevel)
                {
                    Console.WriteLine($"⚠️ {item.Key} is below reorder level ({item.Value.Quantity}/{item.Value.ReorderLevel})");
                }
            }
        }

        public void DisplayStock()
        {
            Console.WriteLine("📦 Current Stock:");
            foreach (var item in StockItems)
            {
                Console.WriteLine($"- {item.Key}: {item.Value.Quantity} units");
            }
        }
    }
}
