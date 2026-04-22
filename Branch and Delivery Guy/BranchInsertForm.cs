namespace OFODBGUI.Models;

public partial class BranchInsertForm : Form
{
    public BranchInsertForm()
    {
        InitializeComponent();
    }

    public Branch? NewBranch { get; private set; }

    private void buttonInsert_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(textBoxId.Text, out int id))
        {
            MessageBox.Show("Please enter a valid numeric Branch ID.");
            return;
        }

        if (string.IsNullOrWhiteSpace(textBoxCity.Text))
        {
            MessageBox.Show("Please enter a City.");
            return;
        }

        try
        {
            using (var context = new NeondbContext())
            {
                if (context.Branches.Find(id) != null)
                {
                    MessageBox.Show("A branch with this ID already exists.");
                    return;
                }

                NewBranch = new Branch
                {
                    Branchid = id,
                    City = textBoxCity.Text,
                    District = textBoxDistrict.Text,
                    Phonenumber = textBoxPhone.Text,
                    Openingtime = TimeOnly.FromDateTime(dateOpening.Value),
                    Closingtime = TimeOnly.FromDateTime(dateClosing.Value)
                };

                context.Branches.Add(NewBranch);
                context.SaveChanges();
            }

            MessageBox.Show("Branch inserted successfully.");
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error inserting branch: {ex.Message}");
        }
    }
}
