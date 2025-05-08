using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeSystem
{
    public class Menu
    {
        public List<Drink> allDrinks;
        private List<Drink> hotDrinks;
        private List<Drink> coldDrinks;

        public Menu()
        {
            allDrinks = new List<Drink>
            {
                // Hot Drinks
                new Drink("Espresso", "Small", 25, 5, 3),
                new Drink("Espresso", "Medium", 40, 5, 3),
                new Drink("Espresso", "larg", 50, 5, 3),
                new Drink("Cappuccino", "small", 35, 120, 5),
                new Drink("Cappuccino", "Medium", 45, 120, 5),
                new Drink("Cappuccino", "larg", 55, 120, 5),
                new Drink("Latte", "small", 40, 150, 5),
                new Drink("Latte", "Medium", 50, 150, 5),
                new Drink("Latte", "larg", 60, 150, 5),
                new Drink("Hot Chocolate", "small", 38, 180, 4),
                new Drink("Hot Chocolate", "Medium", 38, 180, 4),
                new Drink("Hot Chocolate", "larg", 38, 180, 4),
                new Drink("Americano", "small", 30, 10, 4),
                new Drink("Americano", "Medium", 30, 10, 4),
                new Drink("Americano", "larg", 30, 10, 4),
                new Drink("Flat White", "small", 36, 130, 4),
                new Drink("Flat White", "Medium", 36, 130, 4),
                new Drink("Flat White", "larg", 36, 130, 4),
                new Drink("Black Tea", "small", 15, 0, 2),
                new Drink("Black Tea", "Medium", 15, 0, 2),
                new Drink("Black Tea", "larg", 15, 0, 2),
                new Drink("Green Tea", "small", 18, 0, 2),
                new Drink("Green Tea", "Medium", 18, 0, 2),
                new Drink("Green Tea", "larg", 18, 0, 2),
                new Drink("Herbal Tea", "small", 20, 0, 3),
                new Drink("Herbal Tea", "Medium", 20, 0, 3),
                new Drink("Herbal Tea", "larg", 20, 0, 3),
                new Drink("Turkish Coffee", "Small", 28, 80, 3),
                new Drink("Turkish Coffee", "Medium", 28, 80, 3),
                new Drink("Turkish Coffee", "larg", 28, 80, 3),

                // Cold Drinks
                new Drink("Iced Latte", "Large", 45, 160, 5),
                new Drink("Iced Americano", "Large", 40, 10, 4),
                new Drink("Cold Brew", "Large", 50, 15, 6),
                new Drink("Frappuccino", "Large", 55, 220, 6),
                new Drink("Iced Mocha", "Large", 52, 200, 5),
                new Drink("Lemon Iced Tea", "Large", 35, 90, 3),
                new Drink("Milkshake - Chocolate", "Large", 48, 250, 4),
                new Drink("Milkshake - Vanilla", "Large", 46, 240, 4),
                new Drink("Milkshake - Oreo", "Large", 50, 260, 5),
                new Drink("Smoothie - Strawberry", "Large", 50, 180, 4),
                new Drink("Smoothie - Mango", "Large", 50, 190, 4),
                new Drink("Smoothie - Banana", "Large", 50, 210, 4),
                new Drink("Mojito - Classic", "Large", 45, 100, 3),
                new Drink("Mojito - Strawberry", "Large", 47, 110, 3),
                new Drink("Mojito - Blueberry", "Large", 47, 115, 3),
                new Drink("Coke", "Can", 20, 140, 1),
                new Drink("Sprite", "Can", 20, 130, 1),
                new Drink("Fanta", "Can", 20, 135, 1),
            };

            // فصلهم حسب النوع
            hotDrinks = allDrinks.Where(d => d.Name.Contains("Espresso") ||
                                             d.Name.Contains("Cappuccino") ||
                                             d.Name.Contains("Latte") && !d.Name.Contains("Iced") ||
                                             d.Name.Contains("Chocolate") ||
                                             d.Name.Contains("Tea") && !d.Name.Contains("Iced") ||
                                             d.Name.Contains("Turkish") ||
                                             d.Name.Contains("Americano") && !d.Name.Contains("Iced")).ToList();

            coldDrinks = allDrinks.Except(hotDrinks).ToList();
        }

        public void DisplayMenu()
        {
            Console.WriteLine("\n===== Drinks Menu =====\n");

            foreach (var drink in allDrinks)
            {
                Console.WriteLine($"- {drink.Name} ({drink.Size}) - {drink.Price} LE");
            }

            Console.WriteLine("\n========================\n");
        }

        public Drink GetDrinkByName(string name)
        {
            return allDrinks.FirstOrDefault(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public Drink GetHotDrink(string name)
        {
            return hotDrinks.FirstOrDefault(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public Drink GetColdDrink(string name)
        {
            return coldDrinks.FirstOrDefault(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void DisplayHotDrinks()
        {
            Console.WriteLine("\n== Hot Drinks ==\n");
            foreach (var drink in hotDrinks)
            {
                Console.WriteLine($"{drink.Name} - {drink.Price} LE");
            }
        }

        public void DisplayColdDrinks()
        {
            Console.WriteLine("\n== Cold Drinks ==\n");
            foreach (var drink in coldDrinks)
            {
                Console.WriteLine($"{drink.Name} - {drink.Price} LE");
            }
        }

        public List<Drink> GetHotDrinks()
        {
            return hotDrinks;
        }

        public List<Drink> GetColdDrinks()
        {
            return coldDrinks;
        }
    }
}
