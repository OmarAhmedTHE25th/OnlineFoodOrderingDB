using Microsoft.EntityFrameworkCore;

namespace OFODBGUI.Models;

public partial class MenuUI : Form
{
    public MenuUI()
    {
        InitializeComponent();
    }


    private void LogAction(string message)
    {
        outputbox.AppendText($"{message}{Environment.NewLine}");
        outputbox.ScrollToCaret();
    }

    private void insert_Click(object sender, EventArgs e)
    {
        using (var form = new insertForm())
        {
            if (form.ShowDialog() == DialogResult.OK)
            {
                load_Table(sender, e);
                if (form.NewItem != null)
                {
                    LogAction($"inserted {form.NewItem.Itemname}");
                }
            }
        }
    }

    private void update_Click(object sender, EventArgs e)
    {
        if (dataview.CurrentRow != null)
        {
            var selectedId = (int)dataview.CurrentRow.Cells["Itemid"].Value;
            using (var context = new NeondbContext())
            {
                var selectedItem = context.MenuItems.Find(selectedId);
                if (selectedItem != null)
                {
                    using (var form = new updateForm(selectedItem))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            load_Table(sender, e);
                            LogAction($"updated {form.UpdatedItem.Itemname}");
                        }
                    }
                }
            }
        }
        else
        {
            MessageBox.Show("Please select a row to update.");
        }
    }

    private void delete_Click(object sender, EventArgs e)
    {
        if (dataview.CurrentRow != null)
        {
            var selectedId = (int)dataview.CurrentRow.Cells["Itemid"].Value;
            var itemName = (string?)dataview.CurrentRow.Cells["Itemname"].Value ?? "Unknown Item";

            var confirmResult = MessageBox.Show($"Are you sure you want to delete {itemName}?",
                                     "Confirm Delete",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (var context = new NeondbContext())
                    {
                        var itemToDelete = context.MenuItems.Find(selectedId);
                        if (itemToDelete != null)
                        {
                            context.MenuItems.Remove(itemToDelete);
                            context.SaveChanges();
                            MessageBox.Show("Menu item deleted successfully!");
                            LogAction($"deleted {itemName}");
                            load_Table(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting menu item: {ex.Message}");
                }
            }
        }
        else
        {
            MessageBox.Show("Please select a row to delete.");
        }
    }

    private void MenuUI_Load(object sender, EventArgs e)
    {
        load_Table(sender, e);
    }

    private void load_Table(object sender, EventArgs e)
    {
        using (var context = new NeondbContext())
        {
            var data = context.MenuItems
                .Include(m => m.Offers)
                .Select(m => new
                {
                    m.Itemid,
                    m.Itemname,
                    m.Price,
                    m.Itemdescription,
                    m.Category,
                    m.Availability,
                    Offers = string.Join(", ", m.Offers.Select(o => o.Offername).ToList())
                })
                .ToList();

            dataview.DataSource = data;
        }
    }

    private void BackBtn_Click(object sender, EventArgs e)
    {
        Close();
        
    }
}