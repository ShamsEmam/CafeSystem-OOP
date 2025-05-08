
namespace CafeSystem
{
    public class HotDrink : Drink
    {
        public string MilkType { get; set; }
        public bool HasFoam { get; set; }

        public HotDrink(string name, string size, double price,int preparationTime, int calories, string milkType, bool hasFoam): base(name, size, price, calories, preparationTime) 
        {
            MilkType = milkType;
            HasFoam = hasFoam;
        }

        public void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"\nMilk Type: {MilkType}\nHas Foam: {(HasFoam ? "Yes" : "No")}");
        }

    }
}
