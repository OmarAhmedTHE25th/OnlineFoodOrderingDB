using Microsoft.EntityFrameworkCore;

namespace OFODBGUI.Models;

public partial class BranchUI : Form
{
    public BranchUI()
    {
        InitializeComponent();
    }

    private void LogAction(string message)
    {
        outputbox.AppendText($"{message}{Environment.NewLine}");
        outputbox.ScrollToCaret();
    }

    private void BranchUI_Load(object sender, EventArgs e)
    {
        load_Table(sender, e);
    }

    private void load_Table(object sender, EventArgs e)
    {
        using (var context = new NeondbContext())
        {
            var data = context.Branches
                .Select(b => new
                {
                    b.Branchid,
                    b.City,
                    b.District,
                    b.Phonenumber,
                    b.Openingtime,
                    b.Closingtime
                })
                .ToList();

            dataview.DataSource = data;
        }
    }

    private void insert_Click(object sender, EventArgs e)
    {
        using (var form = new BranchInsertForm())
        {
            if (form.ShowDialog() == DialogResult.OK)
            {
                load_Table(sender, e);
                if (form.NewBranch != null)
                    LogAction($"inserted branch {form.NewBranch.Branchid} ({form.NewBranch.City})");
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

        var selectedId = (int)dataview.CurrentRow.Cells["Branchid"].Value;
        using (var context = new NeondbContext())
        {
            var selected = context.Branches.Find(selectedId);
            if (selected != null)
            {
                using (var form = new BranchUpdateForm(selected))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        load_Table(sender, e);
                        LogAction($"updated branch {form.UpdatedBranch.Branchid}");
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

        var selectedId = (int)dataview.CurrentRow.Cells["Branchid"].Value;
        var city = (string?)dataview.CurrentRow.Cells["City"].Value ?? "Unknown";

        var confirm = MessageBox.Show($"Delete branch {selectedId} ({city})?",
                                      "Confirm Delete", MessageBoxButtons.YesNo);
        if (confirm != DialogResult.Yes) return;

        try
        {
            using (var context = new NeondbContext())
            {
                var toDelete = context.Branches.Find(selectedId);
                if (toDelete != null)
                {
                    context.Branches.Remove(toDelete);
                    context.SaveChanges();
                    MessageBox.Show("Branch deleted.");
                    LogAction($"deleted branch {selectedId}");
                    load_Table(sender, e);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting branch: {ex.Message}\n\n(Tip: a branch cannot be deleted while it still has delivery guys or orders linked to it.)");
        }
    }

    private void BackBtn_Click(object sender, EventArgs e) => Close();
}
