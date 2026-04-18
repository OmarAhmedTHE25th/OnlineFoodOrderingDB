using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using OFODBGUI.Models;

namespace OFODBGUI.Orders_and_orderItem;

public partial class OrdersUI : Form
{
    private NeondbContext _context;
    private List<OFODBGUI.Models.MenuItem> _cart = new();

    public OrdersUI()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        _context = new NeondbContext();

        // Load combobox data
        var branches = _context.Branches.Select(b => new { b.Branchid, Name = b.City + " - " + b.District }).ToList();
        cmbBranch.DisplayMember = "Name";
        cmbBranch.ValueMember = "Branchid";
        cmbBranch.DataSource = branches;

        var menu = _context.MenuItems.ToList();
        cmbMenu.DisplayMember = "Itemname";
        cmbMenu.ValueMember = "Itemid";
        cmbMenu.DataSource = menu;

        cmbPayment.Items.AddRange(new string[] { "Cash", "Credit Card" });
        cmbPayment.SelectedIndex = 0;
    }

    private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbBranch.SelectedValue is int branchId)
        {
            var deliveryGuys = _context.DeliveryGuys.Where(d => d.Branchid == branchId).ToList();
            cmbDeliveryGuy.DisplayMember = "Deliveryguyname";
            cmbDeliveryGuy.ValueMember = "Deliveryguysid";
            cmbDeliveryGuy.DataSource = deliveryGuys;
        }
    }

    private void txtCustomerPhone_Leave(object sender, EventArgs e)
    {
        var phone = txtCustomerPhone.Text.Trim();
        if (string.IsNullOrEmpty(phone)) return;

        var customer = _context.Customers.FirstOrDefault(c => c.Phonenumber == phone);
        if (customer != null)
        {
            txtCustomerEmail.Text = customer.Customeremail;
        }
    }

    private void btnAddToCart_Click(object sender, EventArgs e)
    {
        if (cmbMenu.SelectedItem is OFODBGUI.Models.MenuItem item)
        {
            _cart.Add(item);
            UpdateCartList();
        }
    }

    private void UpdateCartList()
    {
        lstCart.Items.Clear();
        foreach (var item in _cart.GroupBy(i => i.Itemid))
        {
            var count = item.Count();
            var first = item.First();
            lstCart.Items.Add($"{count}x {first.Itemname}");
        }
    }

    private void btnPlaceOrder_Click(object sender, EventArgs e)
    {
        if (!_cart.Any())
        {
            MessageBox.Show("Cart is empty!");
            return;
        }

        var phone = txtCustomerPhone.Text.Trim();
        var email = txtCustomerEmail.Text.Trim();

        if (string.IsNullOrEmpty(phone))
        {
            MessageBox.Show("Please enter a customer phone number.");
            return;
        }

        if (cmbBranch.SelectedValue == null || !int.TryParse(cmbBranch.SelectedValue.ToString(), out var branchId))
        {
            MessageBox.Show("Please select a branch.");
            return;
        }

        var customer = _context.Customers.FirstOrDefault(c => c.Phonenumber == phone);
        if (customer == null)
        {
            customer = new Customer
            {
                Customersid = GetNextCustomerId(),
                Phonenumber = phone,
                Customeremail = email,
                Customerpassword = string.IsNullOrWhiteSpace(email) ? "DefaultPassword123" : email
            };
            _context.Customers.Add(customer);
            _context.SaveChanges(); 
        }
        else if (string.IsNullOrWhiteSpace(customer.Customeremail) && !string.IsNullOrWhiteSpace(email))
        {
            customer.Customeremail = email;
        }

        var newOrder = new Order
        {
            Orderid = GetNextOrderId(),
            Datetime = DateTime.Now,
            Status = "Pending",
            Paymentmethod = cmbPayment.SelectedItem?.ToString() ?? "Cash",
            Customersid = customer.Customersid,
            Branchid = branchId,
            Deliveryguysid = cmbDeliveryGuy.SelectedValue != null && int.TryParse(cmbDeliveryGuy.SelectedValue.ToString(), out var deliveryGuyId)
                ? deliveryGuyId
                : null
        };
        _context.Orders.Add(newOrder);
        _context.SaveChanges(); 

        foreach (var itemGroup in _cart.GroupBy(i => i))
        {
            var orderItem = new OrderItem
            {
                Orderid = newOrder.Orderid,
                Itemid = itemGroup.Key.Itemid,
                Quantity = itemGroup.Count(),
                // Note: assuming MenuItem has no price property since it was not generated. 
                // We're leaving Price to null or calculating it later
                Price = 0
            };
            _context.OrderItems.Add(orderItem);
        }
        _context.SaveChanges();

        MessageBox.Show($"Order placed successfully! Order ID: {newOrder.Orderid}");

        // Reset form
        _cart.Clear();
        UpdateCartList();
        txtCustomerPhone.Text = "";
        txtCustomerEmail.Text = "";
    }

    private int GetNextCustomerId()
    {
        return _context.Customers.Any() ? _context.Customers.Max(c => c.Customersid) + 1 : 1;
    }

    private int GetNextOrderId()
    {
        return _context.Orders.Any() ? _context.Orders.Max(o => o.Orderid) + 1 : 1;
    }

    private void btnViewAllOrders_Click(object sender, EventArgs e)
    {
        var viewOrders = new OrdersListUI();
        viewOrders.ShowDialog();
    }

    protected override void OnClosed(EventArgs e)
    {
        _context?.Dispose();
        base.OnClosed(e);
    }
}
