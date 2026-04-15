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
}