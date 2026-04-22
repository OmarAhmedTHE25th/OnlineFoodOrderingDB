namespace OFODBGUI.Models;

public partial class BranchUpdateForm : Form
{
    private Branch _branch;

    public BranchUpdateForm(Branch branch)
    {
        InitializeComponent();
        _branch = branch;
        PopulateFields();
    }

    public Branch UpdatedBranch => _branch;

    private void PopulateFields()
    {
        textBoxId.Text = _branch.Branchid.ToString();
        textBoxCity.Text = _branch.City;
        textBoxDistrict.Text = _branch.District;
        textBoxPhone.Text = _branch.Phonenumber;
        if (_branch.Openingtime.HasValue)
            dateOpening.Value = DateTime.Today.Add(_branch.Openingtime.Value.ToTimeSpan());
        if (_branch.Closingtime.HasValue)
            dateClosing.Value = DateTime.Today.Add(_branch.Closingtime.Value.ToTimeSpan());
    }

    private void buttonUpdate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBoxCity.Text))
        {
            MessageBox.Show("Please enter a City.");
            return;
        }

        try
        {
            using (var context = new NeondbContext())
            {
                var toUpdate = context.Branches.Find(_branch.Branchid);
                if (toUpdate == null)
                {
                    MessageBox.Show("Branch not found in database.");
                    return;
                }

                toUpdate.City = textBoxCity.Text;
                toUpdate.District = textBoxDistrict.Text;
                toUpdate.Phonenumber = textBoxPhone.Text;
                toUpdate.Openingtime = TimeOnly.FromDateTime(dateOpening.Value);
                toUpdate.Closingtime = TimeOnly.FromDateTime(dateClosing.Value);

                context.SaveChanges();
                _branch = toUpdate;
                MessageBox.Show("Branch updated successfully.");
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating branch: {ex.Message}");
        }
    }
}
