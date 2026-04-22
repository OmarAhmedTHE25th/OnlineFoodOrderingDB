using Microsoft.EntityFrameworkCore;

namespace OFODBGUI.Models;

public partial class DeliveryGuyUI : Form
{
    public DeliveryGuyUI()
    {
        InitializeComponent();
    }

    private void LogAction(string message)
    {
        outputbox.AppendText($"{message}{Environment.NewLine}");
        outputbox.ScrollToCaret();
    }

    private void DeliveryGuyUI_Load(object sender, EventArgs e)
    {
        load_Table(sender, e);
    }

    private void load_Table(object sender, EventArgs e)
    {
        using (var context = new NeondbContext())
        {
            var data = context.DeliveryGuys
                .Include(d => d.Branch)
                .Select(d => new
                {
                    d.Deliveryguysid,
                    d.Deliveryguyname,
                    d.Deliveryguyssn,
                    d.Vehicletype,
                    d.Rating,
                    d.Numberofordersdelivered,
                    d.Dateofjoining,
                    d.Contractexpirationdate,
                    d.Branchid,
                    BranchCity = d.Branch != null ? d.Branch.City : null
                })
                .ToList();

            dataview.DataSource = data;
        }
    }

    private void insert_Click(object sender, EventArgs e)
    {
        using (var form = new DeliveryGuyInsertForm())
        {
            if (form.ShowDialog() == DialogResult.OK)
            {
                load_Table(sender, e);
                if (form.NewGuy != null)
                    LogAction($"inserted delivery guy {form.NewGuy.Deliveryguysid} ({form.NewGuy.Deliveryguyname})");
            }
        }
    }

    private void update_Click(object sender, EventArgs e)
    {
        if (dataview.CurrentRow == null)
        {
            MessageBox.Show("Please select a row to update.");
            return;
        }

        var selectedId = (int)dataview.CurrentRow.Cells["Deliveryguysid"].Value;
        using (var context = new NeondbContext())
        {
            var selected = context.DeliveryGuys.Find(selectedId);
            if (selected != null)
            {
                using (var form = new DeliveryGuyUpdateForm(selected))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        load_Table(sender, e);
                        LogAction($"updated delivery guy {form.UpdatedGuy.Deliveryguysid}");
                    }
                }
            }
        }
    }

    private void delete_Click(object sender, EventArgs e)
    {
        if (dataview.CurrentRow == null)
        {
            MessageBox.Show("Please select a row to delete.");
            return;
        }

        var selectedId = (int)dataview.CurrentRow.Cells["Deliveryguysid"].Value;
        var name = (string?)dataview.CurrentRow.Cells["Deliveryguyname"].Value ?? "Unknown";

        var confirm = MessageBox.Show($"Delete delivery guy {selectedId} ({name})?",
                                      "Confirm Delete", MessageBoxButtons.YesNo);
        if (confirm != DialogResult.Yes) return;

        try
        {
            using (var context = new NeondbContext())
            {
                var toDelete = context.DeliveryGuys.Find(selectedId);
                if (toDelete != null)
                {
                    context.DeliveryGuys.Remove(toDelete);
                    context.SaveChanges();
                    MessageBox.Show("Delivery guy deleted.");
                    LogAction($"deleted delivery guy {selectedId}");
                    load_Table(sender, e);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting delivery guy: {ex.Message}\n\n(Tip: a delivery guy linked to existing orders cannot be deleted.)");
        }
    }

    private void BackBtn_Click(object sender, EventArgs e) => Close();
}
