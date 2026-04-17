using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using OFODBGUI.Models;

namespace OFODBGUI.Orders_and_orderItem;

public partial class OrdersListUI : Form
{
    private NeondbContext _context;

    public OrdersListUI()
    {
        InitializeComponent();
    }

    private void OrdersListUI_Load(object sender, EventArgs e)
    {
        _context = new NeondbContext();
        LoadOrders();
    }

    private void LoadOrders()
    {
        var ordersList = _context.Orders
            .Include(o => o.Customers)
            .Include(o => o.Branch)
            .Include(o => o.Deliveryguys)
            .Include(o => o.OrderItems).ThenInclude(oi => oi.Item)
            .ToList() // fetch locally first to evaluate string.Join without translation errors
            .Select(o => new {
                OrderID = o.Orderid,
                Date = o.Datetime,
                Status = string.IsNullOrWhiteSpace(o.Status) ? "Pending" : o.Status,
                Customer = o.Customers != null ? (o.Customers.Customeremail ?? o.Customers.Phonenumber) : "Unknown",
                Branch = o.Branch != null ? $"{o.Branch.City} - {o.Branch.District}" : "Unknown",
                DeliveryGuy = o.Deliveryguys != null ? o.Deliveryguys.Deliveryguyname : "None",
                Items = string.Join(", ", o.OrderItems.Select(oi => $"{oi.Quantity}x {oi.Item?.Itemname}"))
            }).ToList();

        dgvOrders.DataSource = ordersList;

        // Auto-sizing columns to fit the detailed items payload
        dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvOrders.Columns["Items"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        UpdateActionButtonText();
    }

    private void btnDeleteOrder_Click(object sender, EventArgs e)
    {
        if (dgvOrders.CurrentRow != null)
        {
            int orderId = (int)dgvOrders.CurrentRow.Cells["OrderID"].Value;

            var dialogResult = MessageBox.Show(
                $"Are you sure you want to delete Order #{orderId}?", 
                "Confirm Delete", 
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                var order = _context.Orders
                    .Include(o => o.OrderItems)
                    .FirstOrDefault(o => o.Orderid == orderId);

                if (order != null)
                {
                    _context.OrderItems.RemoveRange(order.OrderItems); // remove dependents first
                    _context.Orders.Remove(order);
                    _context.SaveChanges();

                    MessageBox.Show("Order deleted successfully.");
                    LoadOrders(); // Refresh grid
                }
            }
        }
        else
        {
            MessageBox.Show("Please select an order to delete.");
        }
    }

    private void btnMarkComplete_Click(object sender, EventArgs e)
    {
        if (dgvOrders.CurrentRow == null)
        {
            MessageBox.Show("Please select an order to update.");
            return;
        }

        int orderId = (int)dgvOrders.CurrentRow.Cells["OrderID"].Value;
        var order = _context.Orders.FirstOrDefault(o => o.Orderid == orderId);
        var currentStatus = dgvOrders.CurrentRow.Cells["Status"].Value?.ToString();

        if (order == null)
        {
            MessageBox.Show("Selected order could not be found.");
            return;
        }

        if (string.Equals(currentStatus, "Completed", System.StringComparison.OrdinalIgnoreCase))
        {
            order.Status = "Delivered";
            MessageBox.Show($"Order #{orderId} marked as delivered.");
        }
        else if (string.Equals(currentStatus, "Delivered", System.StringComparison.OrdinalIgnoreCase))
        {
            MessageBox.Show($"Order #{orderId} is already delivered.");
            return;
        }
        else
        {
            order.Status = "Completed";
            MessageBox.Show($"Order #{orderId} marked as complete.");
        }

        _context.SaveChanges();
        LoadOrders();
    }

    private void dgvOrders_SelectionChanged(object sender, EventArgs e)
    {
        UpdateActionButtonText();
    }

    private void UpdateActionButtonText()
    {
        if (btnMarkComplete == null)
        {
            return;
        }

        var currentStatus = dgvOrders.CurrentRow?.Cells["Status"]?.Value?.ToString();

        if (string.Equals(currentStatus, "Completed", System.StringComparison.OrdinalIgnoreCase))
        {
            btnMarkComplete.Text = "Mark as Delivered";
            btnMarkComplete.Enabled = true;
        }
        else if (string.Equals(currentStatus, "Delivered", System.StringComparison.OrdinalIgnoreCase))
        {
            btnMarkComplete.Text = "Delivered";
            btnMarkComplete.Enabled = false;
        }
        else
        {
            btnMarkComplete.Text = "Mark as Complete";
            btnMarkComplete.Enabled = true;
        }
    }

    protected override void OnClosed(EventArgs e)
    {
        _context?.Dispose();
        base.OnClosed(e);
    }
}