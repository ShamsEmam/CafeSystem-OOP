
namespace CafeSystem
{
    public class Employee
    {
        public string Name { get; set; }
        public DateTime DateJoined { get; set; }
        public string Role { get; set; }
        public int OrdersHandled { get; set; }
        public int OrdersHour { get; set; }
        public bool IsActive { get; set; }
        private string SNN { get; set; }
        private int Salary { get; set; }
        private string Mail { get; set; }
        private string Id { get; set; }

        public Employee(string name, string role, string sNN, int salary, string mail, string id, DateTime dateJoined, int ordersHandled, bool isActive, int ordersHour)
        {
            Name = name;
            Role = role;
            SNN = sNN;
            Salary = salary;
            Mail = mail;
            Id = id;
            DateJoined = dateJoined;
            OrdersHandled = ordersHandled;
            IsActive = isActive;
            OrdersHour = ordersHour;
        }

        public void DisplayEmployeeInfo()
        {
            Console.WriteLine($"Employee Name: {Name}");
            Console.WriteLine($"Role: {Role}");
            Console.WriteLine($"Salary: {Salary} LE");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Orders Handled: {OrdersHandled}");
            Console.WriteLine($"Joined on: {DateJoined}");
        }

        public int CalculateSalaryBonus(int hours, int ordersNumber)
        {
            int noOrderPerHour = ordersNumber / hours;
            int bonus = 0;

            if (noOrderPerHour > 5)
            {
                bonus += (noOrderPerHour - 5) * 20;
            }

            return noOrderPerHour * 20 + bonus;
        }

        public void AddHandledOrder(int count = 1)
        {
            OrdersHandled += count;
            Console.WriteLine($"{Name} handled {count} more order(s). Total handled: {OrdersHandled}");
        }
    }
}
