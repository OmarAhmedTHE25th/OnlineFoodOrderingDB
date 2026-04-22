namespace OFODBGUI.Models;

public partial class DeliveryGuyInsertForm : Form
{
    public DeliveryGuyInsertForm()
    {
        InitializeComponent();
        LoadBranches();
    }

    public DeliveryGuy? NewGuy { get; private set; }

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

    private void buttonInsert_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(textBoxId.Text, out int id))
        {
            MessageBox.Show("Please enter a valid numeric Delivery Guy ID.");
            return;
        }
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
                if (context.DeliveryGuys.Find(id) != null)
                {
                    MessageBox.Show("A delivery guy with this ID already exists.");
                    return;
                }

                if (!string.IsNullOrWhiteSpace(textBoxSsn.Text) &&
                    context.DeliveryGuys.Any(d => d.Deliveryguyssn == textBoxSsn.Text))
                {
                    MessageBox.Show("A delivery guy with this SSN already exists.");
                    return;
                }

                int? branchId = comboBranch.SelectedValue as int? ?? (comboBranch.SelectedValue != null ? (int)comboBranch.SelectedValue : (int?)null);

                NewGuy = new DeliveryGuy
                {
                    Deliveryguysid = id,
                    Deliveryguyname = textBoxName.Text,
                    Deliveryguyssn = string.IsNullOrWhiteSpace(textBoxSsn.Text) ? null : textBoxSsn.Text,
                    Vehicletype = string.IsNullOrWhiteSpace(textBoxVehicle.Text) ? null : textBoxVehicle.Text,
                    Rating = rating,
                    Numberofordersdelivered = orders,
                    Dateofjoining = DateOnly.FromDateTime(dateJoining.Value),
                    Contractexpirationdate = DateOnly.FromDateTime(dateExpiry.Value),
                    Branchid = branchId
                };

                context.DeliveryGuys.Add(NewGuy);
                context.SaveChanges();
            }

            MessageBox.Show("Delivery guy inserted successfully.");
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error inserting delivery guy: {ex.Message}");
        }
    }
}
