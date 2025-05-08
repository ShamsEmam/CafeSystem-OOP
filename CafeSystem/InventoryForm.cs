using System;
using System.Drawing;
using System.Windows.Forms;

namespace CafeSystem
{
    public partial class InventoryForm : Form
    {
        private InventoryManager inventoryManager;

        public InventoryForm(InventoryManager inventory)
        {
            InitializeComponent();
            this.inventoryManager = inventory;
            SetupForm();
        }

        private void SetupForm()
        {
            // Form properties
            Text = "Inventory Management";
            Size = new Size(600, 500);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;

            // Create controls
            Label titleLabel = new Label
            {
                Text = "Inventory Management",
                Font = new Font("Arial", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 20),
                Size = new Size(600, 30)
            };

            ListView inventoryListView = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Location = new Point(30, 60),
                Size = new Size(540, 300)
            };

            // Add columns
            inventoryListView.Columns.Add("Item Name", 150);
            inventoryListView.Columns.Add("Quantity", 100);
            inventoryListView.Columns.Add("Price per Unit", 120);
            inventoryListView.Columns.Add("Total Value", 120);

            // Add items panel
            Panel addItemPanel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(30, 370),
                Size = new Size(540, 80)
            };

            Label itemNameLabel = new Label
            {
                Text = "Item Name:",
                Location = new Point(10, 15),
                Size = new Size(80, 20)
            };

            TextBox itemNameTextBox = new TextBox
            {
                Location = new Point(90, 15),
                Size = new Size(150, 20)
            };

            Label quantityLabel = new Label
            {
                Text = "Quantity:",
                Location = new Point(10, 45),
                Size = new Size(80, 20)
            };

            NumericUpDown quantityNumeric = new NumericUpDown
            {
                Location = new Point(90, 45),
                Size = new Size(80, 20),
                Minimum = 1,
                Maximum = 1000,
                Value = 1
            };

            Label priceLabel = new Label
            {
                Text = "Price:",
                Location = new Point(250, 15),
                Size = new Size(50, 20)
            };

            NumericUpDown priceNumeric = new NumericUpDown
            {
                Location = new Point(300, 15),
                Size = new Size(80, 20),
                Minimum = 1,
                Maximum = 1000,
                DecimalPlaces = 2,
                Value = 10
            };

            Button addButton = new Button
            {
                Text = "Add / Update Item",
                Location = new Point(400, 30),
                Size = new Size(120, 30)
            };

            // Add controls to panel
            addItemPanel.Controls.Add(itemNameLabel);
            addItemPanel.Controls.Add(itemNameTextBox);
            addItemPanel.Controls.Add(quantityLabel);
            addItemPanel.Controls.Add(quantityNumeric);
            addItemPanel.Controls.Add(priceLabel);
            addItemPanel.Controls.Add(priceNumeric);
            addItemPanel.Controls.Add(addButton);

            // Add controls to form
            Controls.Add(titleLabel);
            Controls.Add(inventoryListView);
            Controls.Add(addItemPanel);

            // Load inventory data
            LoadInventoryData(inventoryListView);

            // Add event handlers
            addButton.Click += (s, e) =>
            {
                string itemName = itemNameTextBox.Text.Trim();
                int quantity = (int)quantityNumeric.Value;
                decimal price = priceNumeric.Value;

                if (string.IsNullOrEmpty(itemName))
                {
                    MessageBox.Show("Please enter an item name.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                inventoryManager.AddItem(itemName, quantity, (double)price);
                LoadInventoryData(inventoryListView);
                itemNameTextBox.Clear();
            };
        }

        private void LoadInventoryData(ListView listView)
        {
            listView.Items.Clear();

            foreach (var item in inventoryManager.inventory.Items)
            {
                ListViewItem listItem = new ListViewItem(item.Name);
                listItem.SubItems.Add(item.Quantity.ToString());
                listItem.SubItems.Add(item.Price.ToString("F2"));
                listItem.SubItems.Add((item.Quantity * item.Price).ToString("F2"));
                listView.Items.Add(listItem);
            }
        }
    }
} 