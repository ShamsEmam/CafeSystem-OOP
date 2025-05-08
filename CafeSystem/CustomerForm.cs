using System;
using System.Windows.Forms;

namespace CafeSystem
{
    public partial class CustomerForm : Form
    {
        public Customer Customer { get; private set; }

        private TextBox nameTextBox;
        private TextBox phoneTextBox;
        private TextBox emailTextBox;
        private TextBox snnTextBox;
        private Button saveButton;
        private Button cancelButton;
        private Label errorLabel;

        public CustomerForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // Form properties
            Text = "Customer Information";
            Size = new Size(400, 300);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;

            // Create labels
            Label nameLabel = new Label { Text = "Name:", Location = new Point(30, 30), Size = new Size(80, 20) };
            Label phoneLabel = new Label { Text = "Phone:", Location = new Point(30, 70), Size = new Size(80, 20) };
            Label emailLabel = new Label { Text = "Email:", Location = new Point(30, 110), Size = new Size(80, 20) };
            Label snnLabel = new Label { Text = "SNN:", Location = new Point(30, 150), Size = new Size(80, 20) };
            errorLabel = new Label { Text = "", ForeColor = Color.Red, Location = new Point(30, 190), Size = new Size(320, 20) };

            // Create text boxes
            nameTextBox = new TextBox { Location = new Point(120, 30), Size = new Size(200, 20) };
            phoneTextBox = new TextBox { Location = new Point(120, 70), Size = new Size(200, 20) };
            emailTextBox = new TextBox { Location = new Point(120, 110), Size = new Size(200, 20) };
            snnTextBox = new TextBox { Location = new Point(120, 150), Size = new Size(200, 20) };

            // Create buttons
            saveButton = new Button { Text = "Save", Location = new Point(120, 220), Size = new Size(80, 30) };
            cancelButton = new Button { Text = "Cancel", Location = new Point(220, 220), Size = new Size(80, 30) };

            // Add controls to form
            Controls.Add(nameLabel);
            Controls.Add(phoneLabel);
            Controls.Add(emailLabel);
            Controls.Add(snnLabel);
            Controls.Add(nameTextBox);
            Controls.Add(phoneTextBox);
            Controls.Add(emailTextBox);
            Controls.Add(snnTextBox);
            Controls.Add(saveButton);
            Controls.Add(cancelButton);
            Controls.Add(errorLabel);

            // Add event handlers
            saveButton.Click += SaveButton_Click;
            cancelButton.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (!ValidateInputs())
                return;

            // Create customer object
            Customer = new Customer(
                1, // Temporary ID
                phoneTextBox.Text,
                snnTextBox.Text,
                nameTextBox.Text,
                emailTextBox.Text
            );

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateInputs()
        {
            if (!InputValidator.ValidateName(nameTextBox.Text))
            {
                errorLabel.Text = "Name must contain only letters.";
                return false;
            }

            if (!InputValidator.ValidatePhoneNumber(phoneTextBox.Text))
            {
                errorLabel.Text = "Phone number must be 11 digits.";
                return false;
            }

            if (!InputValidator.ValidateEmail(emailTextBox.Text))
            {
                errorLabel.Text = "Email must be in a valid format.";
                return false;
            }

            if (!InputValidator.ValidateSNN(snnTextBox.Text))
            {
                errorLabel.Text = "SNN must contain only digits.";
                return false;
            }

            return true;
        }
    }
} 