using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeSystem
{
    public class Order : Drink
    {
        public int NoDrink { get; set; }
        public Dictionary<string, int> DrinkList { get; set; } = new Dictionary<string, int>();
        public List<KeyValuePair<Drink, int>> Pricelist { get; set; }

        public Order() : base("", "", 0, 0, 0)
        {
            NoDrink = 0;
            Pricelist = new List<KeyValuePair<Drink, int>>();
        }

        public Order(string name, string size, double price, int preparationTime, int calories, int noDrink, Dictionary<string, int> drinklist)
            : base(name, size, price, calories, preparationTime)
        {
            NoDrink = noDrink;
            DrinkList = drinklist;
            Pricelist = new List<KeyValuePair<Drink, int>>();
        }

        public static int CalculateTotal(Dictionary<string, int> drinklist, List<KeyValuePair<Drink, int>> pricelist)
        {
            int totalCost = 0;

            foreach (var item in drinklist)
            {
                string name = item.Key;
                int quantity = item.Value;

                var drinkPrice = pricelist.FirstOrDefault(p => p.Key.Name == name).Key?.Price;

                if (drinkPrice != null)
                {
                    totalCost += (int)(drinkPrice.Value * quantity);
                }
            }

            return totalCost;
        }

        public void DisplayOrder()
        {
            Console.WriteLine("\n===== Order Summary =====\n");
            foreach (var i in DrinkList)
            {
                string name = i.Key;
                int quantity = i.Value;
                Console.WriteLine($"Drink: {name} \t Quantity: {quantity}");
            }

            int cost = CalculateTotal(DrinkList, Pricelist);
            Console.WriteLine($"\nTotal Cost: {cost} LE\n");
        }

        public void AddDrink(string name, int quantity, Drink drinkObj)
        {
            if (DrinkList.ContainsKey(name))
            {
                DrinkList[name] += quantity;
            }
            else
            {
                DrinkList.Add(name, quantity);
            }

            var existingDrink = Pricelist.FirstOrDefault(pair => pair.Key.Name == drinkObj.Name);
            if (existingDrink.Key != null)
            {
                var index = Pricelist.IndexOf(existingDrink);
                Pricelist[index] = new KeyValuePair<Drink, int>(existingDrink.Key, existingDrink.Value + quantity);
            }
            else
            {
                Pricelist.Add(new KeyValuePair<Drink, int>(drinkObj, quantity));
            }
        }
    }
}
