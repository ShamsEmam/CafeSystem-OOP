using System;
using System.Drawing;
using System.Windows.Forms;

namespace CafeSystem
{
    public partial class ReceiptForm : Form
    {
        private Receipt receipt;

        public ReceiptForm(Receipt receipt)
        {
            InitializeComponent();
            this.receipt = receipt;
            SetupForm();
        }

        private void SetupForm()
        {
            // Form properties
            Text = "Order Receipt";
            Size = new Size(450, 500);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;

            // Create controls
            Label titleLabel = new Label
            {
                Text = "Order Receipt",
                Font = new Font("Arial", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 20),
                Size = new Size(450, 30)
            };

            Panel receiptPanel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(25, 60),
                Size = new Size(400, 350),
                BackColor = Color.White
            };

            Button printButton = new Button
            {
                Text = "Print Receipt",
                Location = new Point(225, 420),
                Size = new Size(100, 30)
            };

            Button closeButton = new Button
            {
                Text = "Close",
                Location = new Point(335, 420),
                Size = new Size(80, 30)
            };

            // Create receipt content
            Panel contentPanel = new Panel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill
            };

            int yPos = 10;
            
            // Add receipt header
            contentPanel.Controls.Add(new Label
            {
                Text = "Cafe Management System",
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(10, yPos),
                Size = new Size(380, 20)
            });
            yPos += 25;

            contentPanel.Controls.Add(new Label
            {
                Text = $"Receipt ID: {receipt.ReceiptId}",
                Font = new Font("Arial", 10),
                Location = new Point(10, yPos),
                Size = new Size(380, 20)
            });
            yPos += 20;

            contentPanel.Controls.Add(new Label
            {
                Text = $"Date: {receipt.ReceiptDate}",
                Font = new Font("Arial", 10),
                Location = new Point(10, yPos),
                Size = new Size(380, 20)
            });
            yPos += 20;

            contentPanel.Controls.Add(new Label
            {
                Text = $"Customer: {receipt.Customer.Name}",
                Font = new Font("Arial", 10),
                Location = new Point(10, yPos),
                Size = new Size(380, 20)
            });
            yPos += 20;

            contentPanel.Controls.Add(new Label
            {
                Text = $"Phone: {receipt.Customer.PhoneNum}",
                Font = new Font("Arial", 10),
                Location = new Point(10, yPos),
                Size = new Size(380, 20)
            });
            yPos += 20;

            contentPanel.Controls.Add(new Label
            {
                Text = "--------------------------------------------",
                Font = new Font("Arial", 10),
                Location = new Point(10, yPos),
                Size = new Size(380, 20)
            });
            yPos += 25;

            contentPanel.Controls.Add(new Label
            {
                Text = "Item                  Qty    Price    Total",
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(10, yPos),
                Size = new Size(380, 20)
            });
            yPos += 20;

            // Add order items
            foreach (var item in receipt.Order.DrinkList)
            {
                string drinkName = item.Key;
                int quantity = item.Value;
                var drinkPrice = receipt.Order.Pricelist.FirstOrDefault(p => p.Key.Name == drinkName).Key?.Price;

                if (drinkPrice.HasValue)
                {
                    double total = drinkPrice.Value * quantity;
                    contentPanel.Controls.Add(new Label
                    {
                        Text = $"{drinkName.PadRight(20)}{quantity.ToString().PadLeft(5)}    {drinkPrice:F2}    {total:F2}",
                        Font = new Font("Courier New", 9),
                        Location = new Point(10, yPos),
                        Size = new Size(380, 20)
                    });
                    yPos += 20;
                }
            }

            contentPanel.Controls.Add(new Label
            {
                Text = "--------------------------------------------",
                Font = new Font("Arial", 10),
                Location = new Point(10, yPos),
                Size = new Size(380, 20)
            });
            yPos += 25;

            contentPanel.Controls.Add(new Label
            {
                Text = $"Total Amount: ${receipt.TotalAmount:F2}",
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(10, yPos),
                Size = new Size(380, 20)
            });
            yPos += 25;

            contentPanel.Controls.Add(new Label
            {
                Text = $"Payment Method: {receipt.PaymentMethod}",
                Font = new Font("Arial", 10),
                Location = new Point(10, yPos),
                Size = new Size(380, 20)
            });
            yPos += 40;

            contentPanel.Controls.Add(new Label
            {
                Text = "Thank you for your order!",
                Font = new Font("Arial", 10, FontStyle.Italic),
                Location = new Point(10, yPos),
                Size = new Size(380, 20)
            });
            yPos += 20;

            receiptPanel.Controls.Add(contentPanel);

            // Add controls to form
            Controls.Add(titleLabel);
            Controls.Add(receiptPanel);
            Controls.Add(printButton);
            Controls.Add(closeButton);

            // Add event handlers
            printButton.Click += (s, e) => MessageBox.Show("Printing functionality would be implemented here.", "Print Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            closeButton.Click += (s, e) => Close();
        }
    }
} 