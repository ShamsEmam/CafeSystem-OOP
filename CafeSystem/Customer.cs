namespace CafeSystem
{
   public class Customer
    {
        public int CustomerId { get; set; }
        public string PhoneNum { get; set; }
        public string SNN { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

        public Customer(int customerId, string phoneNum, string sNN, string name, string mail)
        {
            CustomerId = customerId;
            PhoneNum = phoneNum;
            SNN = sNN;
            Name = name;
            Mail = mail;
        }

        public void DisplayCustomerInfo()
        {
            Console.WriteLine($"Name: {Name}, Phone: {PhoneNum}, Email: {Mail}");
            Console.WriteLine($"Total Orders: {Orders.Count}");
        }
        public void AddOrder(Order newOrder)
        {
            if (newOrder != null)
                Orders.Add(newOrder);
        }
        public void DisplayOrders()
        {
            if (Orders.Count == 0)
            {
                Console.WriteLine("No orders found for this customer.");
                return;
            }

            foreach (var order in Orders)
            {
                order.DisplayOrder();
            }
        }
        public double GetTotalSpent()
        {
            double total = 0;
            foreach (var order in Orders)
            {
                total += Order.CalculateTotal(order.DrinkList, order.Pricelist);
            }
            return total;
        }

    }

}
