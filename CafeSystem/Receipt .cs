namespace CafeSystem
{
    public class Receipt
    {
        public string ReceiptId { get; set; }
        public string PaymentMethod { get; set; }
        public Customer Customer { get; set; } 
        public DateTime ReceiptDate { get; set; } 
        public Order Order { get; set; } 
        public double TotalAmount { get; set; }
        public bool IsPaid { get; set; } 

        public Receipt(string receiptId, string paymentMethod, Customer customer, DateTime receiptDate, Order order)
        {
            ReceiptId = receiptId;
            PaymentMethod = paymentMethod;
            Customer = customer;
            ReceiptDate = receiptDate;
            Order = order;
            TotalAmount = GenerateTotal();  
            IsPaid = false; 
        }

        public void DisplayInvoice()
        {
            Console.WriteLine($"ReceiptId: {ReceiptId}");
            Console.WriteLine($"Payment Method: {PaymentMethod}");
            Console.WriteLine($"Customer: {Customer.Name}, {Customer.PhoneNum}, {Customer.Mail}");
            Console.WriteLine($"Date: {ReceiptDate}");
            Console.WriteLine("Order Details:");

            foreach (var item in Order.DrinkList)
            {
                Console.WriteLine($"Drink: {item.Key}, Quantity: {item.Value}");
            }
            Console.WriteLine($"Total Amount: {TotalAmount} LE");
            Console.WriteLine($"Paid: {IsPaid}");
        }

        public void MarkAsPaid()
        {
            IsPaid = true;
            Console.WriteLine($"Receipt {ReceiptId} has been marked as paid.");
        }

        public double GenerateTotal()
        {
            return Order.CalculateTotal(Order.DrinkList, Order.Pricelist); 
        }
    }
}
