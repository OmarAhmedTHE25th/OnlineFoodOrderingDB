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
    private List<MenuItem> _cart = new();
    private bool _isInitializing = true;
    private bool _suppressSpecialOfferChange = false;   
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

        // Load special offers
        var specialOffers = _context.SpecialOffers.ToList();
        cmbSpecialOffer.DisplayMember = "Offername";
        cmbSpecialOffer.ValueMember = "Offerid";
        cmbSpecialOffer.DataSource = specialOffers;
        cmbSpecialOffer.SelectedIndex = -1; // No selection by default

        cmbPayment.Items.AddRange(new string[] { "Cash", "Credit Card" });
        cmbPayment.SelectedIndex = 0;

        _isInitializing = false; // Allow events after initialization
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

    private void cmbSpecialOffer_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Don't process events during form initialization or programmatic reset
        if (_isInitializing || _suppressSpecialOfferChange)
            return;

        if (cmbSpecialOffer.SelectedIndex == -1 || cmbSpecialOffer.SelectedValue == null)
            return;

        if (int.TryParse(cmbSpecialOffer.SelectedValue.ToString(), out var offerId))
        {
            var specialOffer = _context.SpecialOffers
                .Include(o => o.Items)
                .FirstOrDefault(o => o.Offerid == offerId);

            if (specialOffer != null && specialOffer.Items.Any())
            {
                foreach (var item in specialOffer.Items)
                {
                    _cart.Add(item);
                }

                UpdateCartList();
                MessageBox.Show($"Added {specialOffer.Items.Count} items from '{specialOffer.Offername}' to your cart!");
            }
        }
    }

    private void txtCustomerEmail_Leave(object sender, EventArgs e)
    {
        var email = txtCustomerEmail.Text.Trim();
        if (string.IsNullOrEmpty(email)) return;

        var customer = _context.Customers.FirstOrDefault(c => c.Customeremail == email);
        if (customer != null)
        {
            txtCustomerPhone.Text = customer.Phonenumber ?? "";
        }
        else
        {
            MessageBox.Show("Customer with this email does not exist.");
            txtCustomerPhone.Text = "";
        }
    }

    private void btnAddToCart_Click(object sender, EventArgs e)
    {
        if (cmbMenu.SelectedItem is MenuItem item)
        {
            _cart.Add(item);
            UpdateCartList();
        }
    }

    private void btnRemoveFromCart_Click(object sender, EventArgs e)
    {
        if (lstCart.SelectedIndex == -1)
        {
            MessageBox.Show("Please select an item to remove from the cart.");
            return;
        }

        // Parse the selected item from display text
        var selectedText = lstCart.SelectedItem.ToString();
        // Format: "2x Burger - $20.00" -> extract item name
        var parts = selectedText.Split(" - ");
        if (parts.Length < 1)
        {
            MessageBox.Show("Error parsing cart item.");
            return;
        }

        var itemInfo = parts[0]; // "2x Burger"
        var itemNameParts = itemInfo.Split("x ");
        if (itemNameParts.Length < 2)
        {
            MessageBox.Show("Error parsing item name.");
            return;
        }

        var itemName = itemNameParts[1].Trim();
        var itemsInCart = _cart.Where(c => c.Itemname == itemName).ToList();
        var totalCount = itemsInCart.Count;

        if (totalCount == 0)
        {
            MessageBox.Show("Item not found in cart.");
            return;
        }

        int removeCount = totalCount;

        if (totalCount > 1)
        {
            // Ask how many to remove
            var input = Microsoft.VisualBasic.Interaction.InputBox(
                $"How many '{itemName}' do you want to remove? (You have {totalCount})",
                "Remove Items",
                "1");

            if (string.IsNullOrEmpty(input))
            {
                return; // User canceled
            }

            if (!int.TryParse(input, out removeCount) || removeCount < 1 || removeCount > totalCount)
            {
                if (removeCount < 1)
                    MessageBox.Show($"Invalid input. Please enter a number greater than 0.");
                else
                    MessageBox.Show($"Invalid input. You only have {totalCount} of this item.");
                return;
            }
        }

        // Remove the items
        for (int i = 0; i < removeCount; i++)
        {
            var itemToRemove = _cart.FirstOrDefault(c => c.Itemname == itemName);
            if (itemToRemove != null)
            {
                _cart.Remove(itemToRemove);
            }
        }

        UpdateCartList();
        MessageBox.Show($"Removed {removeCount} '{itemName}' from cart.");
    }

    private void UpdateCartList()
    {
        lstCart.Items.Clear();
        decimal total = 0;
        foreach (var item in _cart.GroupBy(i => i.Itemid))
        {
            var count = item.Count();
            var first = item.First();
            lstCart.Items.Add($"{count}x {first.Itemname} - ${first.Price * count}");
            total += (first.Price ?? 0) * count;
        }
        lblTotal.Text = $"Total Order: ${total:F2}";
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

        if (string.IsNullOrEmpty(email))
        {
            MessageBox.Show("Please enter a customer email.");
            return;
        }

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

        // Check if email exists
        var customer = _context.Customers.FirstOrDefault(c => c.Customeremail == email);
        if (customer == null)
        {
            MessageBox.Show("Customer with this email does not exist. Please register first.");
            return;
        }

        // Check if phone number matches
        if (customer.Phonenumber != phone)
        {
            MessageBox.Show("Phone number does not match the email on file. Please enter the correct phone number.");
            return;
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
                Price = itemGroup.Key.Price
            };
            _context.OrderItems.Add(orderItem);
        }
        _context.SaveChanges();

        // If special offer is selected, add MinPoints to customer
        if (cmbSpecialOffer.SelectedValue != null && int.TryParse(cmbSpecialOffer.SelectedValue.ToString(), out var offerId))
        {
            var specialOffer = _context.SpecialOffers.FirstOrDefault(o => o.Offerid == offerId);
            if (specialOffer != null && specialOffer.Minpoints.HasValue)
            {
                customer.Totalpoints = (customer.Totalpoints ?? 0) + specialOffer.Minpoints.Value;
                _context.Customers.Update(customer);
                _context.SaveChanges();
            }
        }

        MessageBox.Show($"Order placed successfully! Order ID: {newOrder.Orderid}");

        // Reset form
        _suppressSpecialOfferChange = true;

        _cart.Clear();
        UpdateCartList();
        txtCustomerPhone.Text = "";
        txtCustomerEmail.Text = "";
        cmbSpecialOffer.SelectedIndex = -1;

        _suppressSpecialOfferChange = false;
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

    private void btnBack_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    protected override void OnClosed(EventArgs e)
    {
        _context?.Dispose();
        base.OnClosed(e);
    }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

    
