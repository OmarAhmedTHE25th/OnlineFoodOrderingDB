using OFODBGUI.Models;

namespace OFODBGUI;

public partial class MainPortal : Form
{
    public MainPortal()
    {
        InitializeComponent();
    }

    private void CustomerBtn_Click(object sender, EventArgs e)
    {
        var customerForm = new OFODBGUI.Customer.CustomerUI();
        customerForm.ShowDialog();
    }

    private void MenuBtn_Click(object sender, EventArgs e)
    {
        var menuForm = new MenuUI();
        menuForm.ShowDialog();
    }

    private void OffersBtn_Click(object sender, EventArgs e)
    {
        // Temporary fix to remove error
        MessageBox.Show("Special Offers form is not ready yet.");
    }

    private void OrdersBtn_Click(object sender, EventArgs e)
    {
        var ordersForm = new OFODBGUI.Orders_and_orderItem.OrdersUI();
        ordersForm.ShowDialog();
    }

}