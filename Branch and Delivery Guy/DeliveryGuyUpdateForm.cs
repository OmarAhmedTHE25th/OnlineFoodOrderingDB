namespace OFODBGUI.Models;

public partial class DeliveryGuyUpdateForm : Form
{
    private DeliveryGuy _guy;

    public DeliveryGuyUpdateForm(DeliveryGuy guy)
    {
        InitializeComponent();
        _guy = guy;
        LoadBranches();
        PopulateFields();
    }

    public DeliveryGuy UpdatedGuy => _guy;

    private void LoadBranches()
    {
        using (var context = new NeondbContext())
        {
            var branches = context.Branches
                .Select(b => new { b.Branchid, Display = b.Branchid + " - " + b.City })
                .ToList();
            comboBranch.DataSource = branches;
            comboBranch.DisplayMember = "Display";
            comboBranch.ValueMember = "Branchid";
        }
    }

    private void PopulateFields()
    {
        textBoxId.Text = _guy.Deliveryguysid.ToString();
        textBoxName.Text = _guy.Deliveryguyname;
        textBoxSsn.Text = _guy.Deliveryguyssn;
        textBoxVehicle.Text = _guy.Vehicletype;
        textBoxRating.Text = _guy.Rating?.ToString();
        textBoxOrders.Text = _guy.Numberofordersdelivered?.ToString();
        if (_guy.Dateofjoining.HasValue)
            dateJoining.Value = _guy.Dateofjoining.Value.ToDateTime(TimeOnly.MinValue);
        if (_guy.Contractexpirationdate.HasValue)
            dateExpiry.Value = _guy.Contractexpirationdate.Value.ToDateTime(TimeOnly.MinValue);
        if (_guy.Branchid.HasValue)
            comboBranch.SelectedValue = _guy.Branchid.Value;
    }

    private void buttonUpdate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBoxName.Text))
        {
            MessageBox.Show("Please enter a Name.");
            return;
        }

        decimal? rating = null;
        if (!string.IsNullOrWhiteSpace(textBoxRating.Text))
        {
            if (!decimal.TryParse(textBoxRating.Text, out decimal r) || r < 0 || r > 5)
            {
                MessageBox.Show("Rating must be a number between 0 and 5.");
                return;
            }
            rating = r;
        }

        int? orders = null;
        if (!string.IsNullOrWhiteSpace(textBoxOrders.Text))
        {
            if (!int.TryParse(textBoxOrders.Text, out int o) || o < 0)
            {
                MessageBox.Show("Orders delivered must be a non-negative integer.");
                return;
            }
            orders = o;
        }

        try
        {
            using (var context = new NeondbContext())
            {
                var toUpdate = context.DeliveryGuys.Find(_guy.Deliveryguysid);
                if (toUpdate == null)
                {
                    MessageBox.Show("Delivery guy not found.");
                    return;
                }

                if (!string.IsNullOrWhiteSpace(textBoxSsn.Text) &&
                    context.DeliveryGuys.Any(d =>
                        d.Deliveryguyssn == textBoxSsn.Text &&
                        d.Deliveryguysid != _guy.Deliveryguysid))
                {
                    MessageBox.Show("Another delivery guy already has this SSN.");
                    return;
                }

                toUpdate.Deliveryguyname = textBoxName.Text;
                toUpdate.Deliveryguyssn = string.IsNullOrWhiteSpace(textBoxSsn.Text) ? null : textBoxSsn.Text;
                toUpdate.Vehicletype = string.IsNullOrWhiteSpace(textBoxVehicle.Text) ? null : textBoxVehicle.Text;
                toUpdate.Rating = rating;
                toUpdate.Numberofordersdelivered = orders;
                toUpdate.Dateofjoining = DateOnly.FromDateTime(dateJoining.Value);
                toUpdate.Contractexpirationdate = DateOnly.FromDateTime(dateExpiry.Value);
                toUpdate.Branchid = comboBranch.SelectedValue != null ? (int)comboBranch.SelectedValue : (int?)null;

                context.SaveChanges();
                _guy = toUpdate;
                MessageBox.Show("Delivery guy updated successfully.");
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating delivery guy: {ex.Message}");
        }
    }
}
