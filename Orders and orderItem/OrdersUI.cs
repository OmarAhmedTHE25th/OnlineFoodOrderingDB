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
    private List<CartEntry> _cart = new();

    public class CartEntry
    {
        public MenuItem? Item { get; set; }
        public SpecialOffer? Offer { get; set; }
        public bool IsOffer => Offer != null;
        public string Name => IsOffer ? Offer!.Offername ?? "Unnamed Offer" : Item!.Itemname ?? "Unnamed Item";
        public decimal Price => IsOffer ? (decimal)(Offer!.Items.Sum(i => i.Price ?? 0)) : (decimal)(Item!.Price ?? 0);
        public int Points => IsOffer ? (Offer!.Minpoints ?? 0) : (int)Math.Floor((double)(Item!.Price ?? 0) / 2.0);
    }
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

            if (specialOffer != null)
            {
                _cart.Add(new CartEntry { Offer = specialOffer });
                UpdateCartList();
                MessageBox.Show($"Added offer '{specialOffer.Offername}' to your cart!");
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
            _cart.Add(new CartEntry { Item = item });
            UpdateCartList();
        }
    }

    private void btnRemoveFromCart_Click(object sender, EventArgs e)
    {
        if (lstCart.SelectedIndex == -1)
        {
            MessageBox.Show("Please select an item or offer to remove from the cart.");
            return;
        }

        // The list is grouped by Name and Type (Item/Offer)
        var selectedText = lstCart.SelectedItem.ToString();
        var parts = selectedText.Split("x ", 2);
        if (parts.Length < 2) return;

        var nameAndPrice = parts[1].Split(" - ", 2);
        if (nameAndPrice.Length < 1) return;

        var entryName = nameAndPrice[0].Trim();

        // Find matches in _cart
        var matches = _cart.Where(c => c.Name == entryName).ToList();
        if (!matches.Any()) return;

        int totalCount = matches.Count;
        int removeCount = 1;

        if (totalCount > 1)
        {
            var input = Microsoft.VisualBasic.Interaction.InputBox(
                $"How many '{entryName}' do you want to remove? (You have {totalCount})",
                "Remove Entry",
                "1");

            if (string.IsNullOrEmpty(input)) return;

            if (!int.TryParse(input, out removeCount) || removeCount < 1 || removeCount > totalCount)
            {
                MessageBox.Show($"Invalid quantity.");
                return;
            }
        }

        for (int i = 0; i < removeCount; i++)
        {
            var toRemove = _cart.FirstOrDefault(c => c.Name == entryName);
            if (toRemove != null) _cart.Remove(toRemove);
        }

        UpdateCartList();
        MessageBox.Show($"Removed {removeCount} '{entryName}' from cart.");
    }

    private void UpdateCartList()
    {
        lstCart.Items.Clear();
        decimal total = 0;
        foreach (var group in _cart.GroupBy(c => new { c.Name, c.IsOffer }))
        {
            var count = group.Count();
            var first = group.First();
            lstCart.Items.Add($"{count}x {first.Name} - ${first.Price * count}");
            total += first.Price * count;
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

        var flatItems = new List<OrderItem>();
        int totalPointsToAdd = 0;

        foreach (var entry in _cart)
        {
            totalPointsToAdd += entry.Points;
            
            if (entry.IsOffer)
            {
                foreach (var item in entry.Offer!.Items)
                {
                    flatItems.Add(new OrderItem
                    {
                        Orderid = newOrder.Orderid,
                        Itemid = item.Itemid,
                        Quantity = 1,
                        Price = (decimal)(item.Price ?? 0)
                    });
                }
            }
            else
            {
                flatItems.Add(new OrderItem
                {
                    Orderid = newOrder.Orderid,
                    Itemid = entry.Item!.Itemid,
                    Quantity = 1,
                    Price = (decimal)(entry.Item!.Price ?? 0)
                });
            }
        }

        foreach (var itemGroup in flatItems.GroupBy(i => i.Itemid))
        {
            var orderItem = new OrderItem
            {
                Orderid = newOrder.Orderid,
                Itemid = itemGroup.Key,
                Quantity = itemGroup.Sum(i => i.Quantity),
                Price = itemGroup.First().Price
            };
            _context.OrderItems.Add(orderItem);
        }
        _context.SaveChanges();

        // Update customer points
        customer.Totalpoints = (customer.Totalpoints ?? 0) + totalPointsToAdd;
        _context.Customers.Update(customer);
        _context.SaveChanges();

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

    
