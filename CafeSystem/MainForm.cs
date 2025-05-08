using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeSystem
{
    public partial class MainForm : Form
    {
        private Customer currentCustomer;
        private Order currentOrder;
        private Menu cafeMenu;
        private InventoryManager inventory;

        public MainForm()
        {
            InitializeComponent();
            cafeMenu = new Menu();
            inventory = new InventoryManager();
            currentOrder = new Order();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = "Cafe Management System";
            Size = new Size(800, 600);
            CenterToScreen();
            
            // Create main menu
            MenuStrip mainMenu = new MenuStrip();
            Controls.Add(mainMenu);
            MainMenuStrip = mainMenu;

            // Create menu items
            ToolStripMenuItem newOrderMenuItem = new ToolStripMenuItem("New Order");
            ToolStripMenuItem viewMenuMenuItem = new ToolStripMenuItem("View Menu");
            ToolStripMenuItem inventoryMenuItem = new ToolStripMenuItem("Inventory");
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit");

            // Add menu items to menu
            mainMenu.Items.Add(newOrderMenuItem);
            mainMenu.Items.Add(viewMenuMenuItem);
            mainMenu.Items.Add(inventoryMenuItem);
            mainMenu.Items.Add(exitMenuItem);

            // Create buttons
            Button newOrderButton = new Button
            {
                Text = "New Order",
                Size = new Size(150, 50),
                Location = new Point(325, 150),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };

            Button viewMenuButton = new Button
            {
                Text = "View Menu",
                Size = new Size(150, 50),
                Location = new Point(325, 220),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };

            Button inventoryButton = new Button
            {
                Text = "Manage Inventory",
                Size = new Size(150, 50),
                Location = new Point(325, 290),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };

            Button exitButton = new Button
            {
                Text = "Exit",
                Size = new Size(150, 50),
                Location = new Point(325, 360),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };

            // Add buttons to form
            Controls.Add(newOrderButton);
            Controls.Add(viewMenuButton);
            Controls.Add(inventoryButton);
            Controls.Add(exitButton);

            // Add welcome label
            Label welcomeLabel = new Label
            {
                Text = "Welcome to Cafe Management System",
                Font = new Font("Arial", 20, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(175, 70)
            };
            Controls.Add(welcomeLabel);

            // Add event handlers
            newOrderButton.Click += (s, ev) => ShowCustomerForm();
            viewMenuButton.Click += (s, ev) => ShowMenuForm();
            inventoryButton.Click += (s, ev) => ShowInventoryForm();
            exitButton.Click += (s, ev) => Application.Exit();

            newOrderMenuItem.Click += (s, ev) => ShowCustomerForm();
            viewMenuMenuItem.Click += (s, ev) => ShowMenuForm();
            inventoryMenuItem.Click += (s, ev) => ShowInventoryForm();
            exitMenuItem.Click += (s, ev) => Application.Exit();
        }

        private void ShowCustomerForm()
        {
            CustomerForm customerForm = new CustomerForm();
            if (customerForm.ShowDialog() == DialogResult.OK)
            {
                currentCustomer = customerForm.Customer;
                ShowOrderForm();
            }
        }

        private void ShowOrderForm()
        {
            OrderForm orderForm = new OrderForm(cafeMenu, currentCustomer);
            if (orderForm.ShowDialog() == DialogResult.OK)
            {
                currentOrder = orderForm.Order;
                ShowReceiptForm();
            }
        }

        private void ShowReceiptForm()
        {
            Receipt receipt = new Receipt("R" + DateTime.Now.ToString("yyyyMMddHHmmss"), "Cash", currentCustomer, DateTime.Now, currentOrder);
            ReceiptForm receiptForm = new ReceiptForm(receipt);
            receiptForm.ShowDialog();
        }

        private void ShowMenuForm()
        {
            MenuViewForm menuForm = new MenuViewForm(cafeMenu);
            menuForm.ShowDialog();
        }

        private void ShowInventoryForm()
        {
            InventoryForm inventoryForm = new InventoryForm(inventory);
            inventoryForm.ShowDialog();
        }
    }
} 