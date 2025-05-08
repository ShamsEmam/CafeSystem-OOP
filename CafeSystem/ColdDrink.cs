
namespace CafeSystem
{
    public class ColdDrink : Drink
    {
        public string IceLevel { get; set; }
        public string Flavor { get; set; }

        public ColdDrink(string name, string size, double price, int calories, int preparationTime, string iceLevel, string flavor)
        : base(name, size, price, calories ,preparationTime)
        {
            IceLevel = iceLevel;
            Flavor = flavor;

        }

        public void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Ice Level: {IceLevel} \nFlavor: {Flavor}");
        }

    }
}
