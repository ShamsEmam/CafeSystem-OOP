

namespace CafeSystem
{
    public class Drink
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }
        public int Calories { get; set; }
        public int PreparationTime { get; set; }

        public Drink(string name, string size, double price, int calories, int preparationTime)
        {
            Name = name;
            Price = price;
            Size = size;
            Calories = calories;
            PreparationTime = preparationTime;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($" Name : {Name} \n Size: {Size} \n Price: {Price} LE \n Calories: {Calories}  \n ");
        }

    }
}

