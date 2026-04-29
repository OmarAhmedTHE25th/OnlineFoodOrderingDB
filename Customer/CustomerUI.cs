using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OFODBGUI.Models;
using ModelCustomer = OFODBGUI.Models.Customer;
using System.ComponentModel;

namespace OFODBGUI.Customer
{
    public partial class CustomerUI : Form
    {
        public CustomerUI()
        {
            InitializeComponent();
            BuildCustomerDesign();
        }

        private void CustomerUI_Load(object sender, EventArgs e)
        {
            load_Table();
        }

        private void BuildCustomerDesign()
        {
            Text = "CustomerUI";
            ClientSize = new Size(1250, 700);
            StartPosition = FormStartPosition.CenterScreen;

            Label title = new Label
            {
                Text = "Customer",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(560, 20)
            };
            Controls.Add(title);

            dataview.Location = new Point(20, 75);
            dataview.Size = new Size(1200, 300);
            dataview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataview.MultiSelect = false;
            dataview.ReadOnly = true;

            insert.Location = new Point(120, 415);
            update.Location = new Point(430, 415);
            delete.Location = new Point(740, 415);
            BackBtn.Location = new Point(1050, 415);

            insert.Size = update.Size = delete.Size = BackBtn.Size = new Size(150, 55);

            outputbox.Location = new Point(20, 530);
            outputbox.Size = new Size(1200, 110);
            outputbox.ReadOnly = true;
        }

        private void LogAction(string message)
        {
            outputbox.AppendText($"{message}{Environment.NewLine}");
            outputbox.ScrollToCaret();
        }

        private void load_Table()
        {
            using (var context = new NeondbContext())
            {
                var data = context.Customers
                    .Select(c => new
                    {
                        c.Customersid,
                        c.Customeremail,
                        c.Customerpassword,
                        c.Phonenumber,
                        c.Country,
                        c.City,
                        c.District,
                        c.Streetname,
                        c.Buildingno,
                        c.Floorno,
                        c.Apartmentno,
                        c.Totalpoints
                    })
                    .ToList();

                dataview.DataSource = data;
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {
            using (var form = new CustomerInputDialog())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    using (var context = new NeondbContext())
                    {
                        context.Customers.Add(form.CustomerData);
                        context.SaveChanges();
                    }

                    MessageBox.Show("Customer inserted successfully!");
                    LogAction($"Inserted customer {form.CustomerData.Customeremail}");
                    load_Table();
                }
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (dataview.CurrentRow == null)
            {
                MessageBox.Show("Please select a customer to update.");
                return;
            }

            int selectedId = Convert.ToInt32(dataview.CurrentRow.Cells["Customersid"].Value);

            using (var context = new NeondbContext())
            {
                var customer = context.Customers.Find(selectedId);

                if (customer == null)
                {
                    MessageBox.Show("Customer not found.");
                    return;
                }

                using (var form = new CustomerInputDialog(customer))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        customer.Customeremail = form.CustomerData.Customeremail;
                        customer.Customerpassword = form.CustomerData.Customerpassword;
                        customer.Phonenumber = form.CustomerData.Phonenumber;
                        customer.Country = form.CustomerData.Country;
                        customer.City = form.CustomerData.City;
                        customer.District = form.CustomerData.District;
                        customer.Streetname = form.CustomerData.Streetname;
                        customer.Buildingno = form.CustomerData.Buildingno;
                        customer.Floorno = form.CustomerData.Floorno;
                        customer.Apartmentno = form.CustomerData.Apartmentno;
                        customer.Totalpoints = form.CustomerData.Totalpoints;

                        context.SaveChanges();

                        MessageBox.Show("Customer updated successfully!");
                        LogAction($"Updated customer {customer.Customeremail}");
                        load_Table();
                    }
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataview.CurrentRow == null)
            {
                MessageBox.Show("Please select a customer to delete.");
                return;
            }

            int selectedId = Convert.ToInt32(dataview.CurrentRow.Cells["Customersid"].Value);
            string email = dataview.CurrentRow.Cells["Customeremail"].Value?.ToString() ?? "Unknown";

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete {email}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo
            );

            if (confirm == DialogResult.Yes)
            {
                using (var context = new NeondbContext())
                {
                    var customer = context.Customers.Find(selectedId);

                    if (customer != null)
                    {
                        context.Customers.Remove(customer);
                        context.SaveChanges();

                        MessageBox.Show("Customer deleted successfully!");
                        LogAction($"Deleted customer {email}");
                        load_Table();
                    }
                }
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public class CustomerInputDialog : Form
    {
        private TextBox txtID = new TextBox();
        private TextBox txtEmail = new TextBox();
        private TextBox txtPassword = new TextBox();
        private TextBox txtPhone = new TextBox();
        private TextBox txtCountry = new TextBox();
        private TextBox txtCity = new TextBox();
        private TextBox txtDistrict = new TextBox();
        private TextBox txtStreet = new TextBox();
        private TextBox txtBuilding = new TextBox();
        private TextBox txtFloor = new TextBox();
        private TextBox txtApartment = new TextBox();
        private TextBox txtPoints = new TextBox();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public global::OFODBGUI.Models.Customer CustomerData { get; private set; } = null!;

        public CustomerInputDialog(global::OFODBGUI.Models.Customer? customer = null)
        {
            Text = customer == null ? "Insert Customer" : "Update Customer";
            ClientSize = new Size(430, 560);
            StartPosition = FormStartPosition.CenterParent;

            AddField("ID", txtID, 20);
            AddField("Email", txtEmail, 60);
            AddField("Password", txtPassword, 100);
            AddField("Phone", txtPhone, 140);
            AddField("Country", txtCountry, 180);
            AddField("City", txtCity, 220);
            AddField("District", txtDistrict, 260);
            AddField("Street", txtStreet, 300);
            AddField("Building", txtBuilding, 340);
            AddField("Floor", txtFloor, 380);
            AddField("Apartment", txtApartment, 420);
            AddField("Points", txtPoints, 460);

            Button saveBtn = new Button
            {
                Text = "Save",
                Location = new Point(90, 505),
                Size = new Size(100, 35)
            };

            Button cancelBtn = new Button
            {
                Text = "Cancel",
                Location = new Point(230, 505),
                Size = new Size(100, 35)
            };

            saveBtn.Click += SaveBtn_Click;
            cancelBtn.Click += (s, e) => DialogResult = DialogResult.Cancel;

            Controls.Add(saveBtn);
            Controls.Add(cancelBtn);

            if (customer != null)
            {
                txtID.Text = customer.Customersid.ToString();
                txtID.ReadOnly = true;
                txtEmail.Text = customer.Customeremail;
                txtPassword.Text = customer.Customerpassword;
                txtPhone.Text = customer.Phonenumber;
                txtCountry.Text = customer.Country;
                txtCity.Text = customer.City;
                txtDistrict.Text = customer.District;
                txtStreet.Text = customer.Streetname;
                txtBuilding.Text = customer.Buildingno;
                txtFloor.Text = customer.Floorno;
                txtApartment.Text = customer.Apartmentno;
                txtPoints.Text = customer.Totalpoints?.ToString() ?? "0";
            }
        }

        private void AddField(string labelText, TextBox textBox, int y)
        {
            Label label = new Label
            {
                Text = labelText,
                Location = new Point(30, y + 5),
                Size = new Size(100, 25)
            };

            textBox.Location = new Point(150, y);
            textBox.Size = new Size(230, 30);

            Controls.Add(label);
            Controls.Add(textBox);
        }

        private void SaveBtn_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtID.Text, out int id))
            {
                MessageBox.Show("Please enter a valid Customer ID.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter customer email.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter customer password.");
                return;
            }

            int points = 0;
            int.TryParse(txtPoints.Text, out points);

            CustomerData = new global::OFODBGUI.Models.Customer
            {
                Customersid = id,
                Customeremail = txtEmail.Text,
                Customerpassword = txtPassword.Text,
                Phonenumber = txtPhone.Text,
                Country = txtCountry.Text,
                City = txtCity.Text,
                District = txtDistrict.Text,
                Streetname = txtStreet.Text,
                Buildingno = txtBuilding.Text,
                Floorno = txtFloor.Text,
                Apartmentno = txtApartment.Text,
                Totalpoints = points
            };

            DialogResult = DialogResult.OK;
        }
    }
}