using System;
using System.Drawing;
using System.Windows.Forms;

namespace CafeSystem
{
    public partial class MenuViewForm : Form
    {
        private Menu cafeMenu;

        public MenuViewForm(Menu menu)
        {
            InitializeComponent();
            this.cafeMenu = menu;
            SetupForm();
        }

        private void SetupForm()
        {
            // Form properties
            Text = "Cafe Menu";
            Size = new Size(500, 600);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;

            // Create controls
            Label titleLabel = new Label
            {
                Text = "Cafe Menu",
                Font = new Font("Arial", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 20),
                Size = new Size(500, 30)
            };

            TabControl menuTabs = new TabControl
            {
                Location = new Point(25, 60),
                Size = new Size(450, 450)
            };

            Button closeButton = new Button
            {
                Text = "Close",
                Location = new Point(375, 520),
                Size = new Size(100, 30)
            };

            // Create tabs
            TabPage hotDrinksTab = new TabPage("Hot Drinks");
            TabPage coldDrinksTab = new TabPage("Cold Drinks");

            // Create list views
            ListView hotDrinksListView = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Dock = DockStyle.Fill
            };

            ListView coldDrinksListView = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Dock = DockStyle.Fill
            };

            // Add columns
            hotDrinksListView.Columns.Add("Name", 150);
            hotDrinksListView.Columns.Add("Size", 80);
            hotDrinksListView.Columns.Add("Price (LE)", 80);
            hotDrinksListView.Columns.Add("Calories", 80);

            coldDrinksListView.Columns.Add("Name", 150);
            coldDrinksListView.Columns.Add("Size", 80);
            coldDrinksListView.Columns.Add("Price (LE)", 80);
            coldDrinksListView.Columns.Add("Calories", 80);

            // Populate list views
            var hotDrinks = cafeMenu.GetHotDrinks();
            foreach (var drink in hotDrinks)
            {
                ListViewItem item = new ListViewItem(drink.Name);
                item.SubItems.Add(drink.Size);
                item.SubItems.Add(drink.Price.ToString("F2"));
                item.SubItems.Add(drink.Calories.ToString());
                hotDrinksListView.Items.Add(item);
            }

            var coldDrinks = cafeMenu.GetColdDrinks();
            foreach (var drink in coldDrinks)
            {
                ListViewItem item = new ListViewItem(drink.Name);
                item.SubItems.Add(drink.Size);
                item.SubItems.Add(drink.Price.ToString("F2"));
                item.SubItems.Add(drink.Calories.ToString());
                coldDrinksListView.Items.Add(item);
            }

            // Add list views to tabs
            hotDrinksTab.Controls.Add(hotDrinksListView);
            coldDrinksTab.Controls.Add(coldDrinksListView);

            // Add tabs to tab control
            menuTabs.TabPages.Add(hotDrinksTab);
            menuTabs.TabPages.Add(coldDrinksTab);

            // Add controls to form
            Controls.Add(titleLabel);
            Controls.Add(menuTabs);
            Controls.Add(closeButton);

            // Add event handlers
            closeButton.Click += (s, e) => Close();
        }
    }
} 