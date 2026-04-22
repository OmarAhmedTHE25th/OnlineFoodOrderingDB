using OFODBGUI.Models;
using OFODBGUI.Models;

namespace OFODBGUI;

public partial class MainPortal : Form
{
    public MainPortal()
    {
        InitializeComponent();
    }

    private void MenuBtn_Click(object sender, EventArgs e)
    {
        var menuForm = new MenuUI();
        menuForm.ShowDialog();
    }

    private void OffersBtn_Click(object sender, EventArgs e)
    {
        var offersForm = new OffersUI();
        offersForm.ShowDialog();
    }

    private void OrdersBtn_Click(object sender, EventArgs e)
    {
        var ordersForm = new OFODBGUI.Orders_and_orderItem.OrdersUI();
        ordersForm.ShowDialog();
    }

    private void BranchBtn_Click(object sender, EventArgs e)
    {
        var branchForm = new BranchUI();
        branchForm.ShowDialog();
    }

    private void DeliveryGuyBtn_Click(object sender, EventArgs e)
    {
        var deliveryForm = new DeliveryGuyUI();
        deliveryForm.ShowDialog();
    }
}