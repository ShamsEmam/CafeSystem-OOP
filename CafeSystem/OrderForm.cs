using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CafeSystem
{
    public partial class OrderForm : Form
    {
        private Menu cafeMenu;
        private Customer customer;
        public Order Order { get; private set; }

        private ComboBox drinkTypeComboBox;
        private ComboBox drinkNameComboBox;
        private NumericUpDown quantityNumeric;
        private Button addButton;
        private Button completeButton;
        private Button cancelButton;
        private ListBox orderListBox;
        private Label totalLabel;

        private Dictionary<string, int> drinkList = new Dictionary<string, int>();
        private List<KeyValuePair<Drink, int>> priceList = new List<KeyValuePair<Drink, int>>();
        private double totalAmount = 0;

        public OrderForm(Menu menu, Customer customer)
        {
            InitializeComponent();
            this.cafeMenu = menu;
            this.customer = customer;
            SetupForm();
        }

        private void SetupForm()
        {
            // Form properties
            Text = "Create Order";
            Size = new Size(600, 500);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;

            // Create labels
            Label customerLabel = new Label { Text = $"Customer: {customer.Name}", Location = new Point(30, 20), Size = new Size(300, 20), Font = new Font("Arial", 10, FontStyle.Bold) };
            Label drinkTypeLabel = new Label { Text = "Drink Type:", Location = new Point(30, 60), Size = new Size(80, 20) };
            Label drinkNameLabel = new Label { Text = "Drink Name:", Location = new Point(30, 100), Size = new Size(80, 20) };
            Label quantityLabel = new Label { Text = "Quantity:", Location = new Point(30, 140), Size = new Size(80, 20) };
            Label orderLabel = new Label { Text = "Order Items:", Location = new Point(30, 190), Size = new Size(100, 20), Font = new Font("Arial", 10, FontStyle.Bold) };
            totalLabel = new Label { Text = "Total: $0.00", Location = new Point(30, 400), Size = new Size(150, 20), Font = new Font("Arial", 10, FontStyle.Bold) };

            // Create controls
            drinkTypeComboBox = new ComboBox { 
                Location = new Point(120, 60), 
                Size = new Size(150, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            drinkTypeComboBox.Items.Add("Hot");
            drinkTypeComboBox.Items.Add("Cold");
            drinkTypeComboBox.SelectedIndex = 0;

            drinkNameComboBox = new ComboBox { 
                Location = new Point(120, 100), 
                Size = new Size(200, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            quantityNumeric = new NumericUpDown { 
                Location = new Point(120, 140), 
                Size = new Size(80, 20),
                Minimum = 1,
                Maximum = 20,
                Value = 1
            };

            addButton = new Button { Text = "Add to Order", Location = new Point(210, 140), Size = new Size(100, 25) };
            orderListBox = new ListBox { Location = new Point(30, 210), Size = new Size(520, 180) };
            
            completeButton = new Button { Text = "Complete Order", Location = new Point(360, 400), Size = new Size(120, 35) };
            cancelButton = new Button { Text = "Cancel", Location = new Point(490, 400), Size = new Size(80, 35) };

            // Add controls to form
            Controls.Add(customerLabel);
            Controls.Add(drinkTypeLabel);
            Controls.Add(drinkNameLabel);
            Controls.Add(quantityLabel);
            Controls.Add(orderLabel);
            Controls.Add(totalLabel);
            Controls.Add(drinkTypeComboBox);
            Controls.Add(drinkNameComboBox);
            Controls.Add(quantityNumeric);
            Controls.Add(addButton);
            Controls.Add(orderListBox);
            Controls.Add(completeButton);
            Controls.Add(cancelButton);

            // Add event handlers
            drinkTypeComboBox.SelectedIndexChanged += DrinkTypeComboBox_SelectedIndexChanged;
            addButton.Click += AddButton_Click;
            completeButton.Click += CompleteButton_Click;
            cancelButton.Click += (s, e) => DialogResult = DialogResult.Cancel;

            // Load initial drink names
            DrinkTypeComboBox_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private void DrinkTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            drinkNameComboBox.Items.Clear();
            List<Drink> drinks;

            if (drinkTypeComboBox.SelectedIndex == 0) // Hot drinks
            {
                for (int i = 0; i < 10; i++) // Hot drinks are the first 10 in the list
                {
                    drinkNameComboBox.Items.Add(cafeMenu.GetDrinkByName(cafeMenu.allDrinks[i].Name).Name);
                }
            }
            else // Cold drinks
            {
                for (int i = 10; i < cafeMenu.allDrinks.Count; i++) // Cold drinks are the rest
                {
                    drinkNameComboBox.Items.Add(cafeMenu.GetDrinkByName(cafeMenu.allDrinks[i].Name).Name);
                }
            }

            if (drinkNameComboBox.Items.Count > 0)
                drinkNameComboBox.SelectedIndex = 0;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string drinkName = drinkNameComboBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(drinkName))
                return;

            int quantity = (int)quantityNumeric.Value;
            Drink drink = cafeMenu.GetDrinkByName(drinkName);

            if (drink != null)
            {
                // Add to order
                if (drinkList.ContainsKey(drinkName))
                {
                    drinkList[drinkName] += quantity;
                    
                    // Update pricelist
                    for (int i = 0; i < priceList.Count; i++)
                    {
                        if (priceList[i].Key.Name == drinkName)
                        {
                            var existingPair = priceList[i];
                            priceList[i] = new KeyValuePair<Drink, int>(existingPair.Key, existingPair.Value + quantity);
                            break;
                        }
                    }
                }
                else
                {
                    drinkList.Add(drinkName, quantity);
                    priceList.Add(new KeyValuePair<Drink, int>(drink, quantity));
                }

                // Update UI
                RefreshOrderList();
            }
        }

        private void RefreshOrderList()
        {
            orderListBox.Items.Clear();
            totalAmount = 0;

            foreach (var item in drinkList)
            {
                string drinkName = item.Key;
                int quantity = item.Value;
                Drink drink = cafeMenu.GetDrinkByName(drinkName);

                if (drink != null)
                {
                    double itemTotal = drink.Price * quantity;
                    totalAmount += itemTotal;
                    orderListBox.Items.Add($"{drinkName} - {quantity} x ${drink.Price:F2} = ${itemTotal:F2}");
                }
            }

            totalLabel.Text = $"Total: ${totalAmount:F2}";
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            if (drinkList.Count == 0)
            {
                MessageBox.Show("Please add at least one item to the order.", "Empty Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create order object
            Order = new Order();
            Order.DrinkList = drinkList;
            Order.Pricelist = priceList;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
} 