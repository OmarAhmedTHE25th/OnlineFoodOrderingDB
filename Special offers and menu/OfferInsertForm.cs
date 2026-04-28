namespace OFODBGUI.Models;

public partial class OfferInsertForm : Form
{
    public OfferInsertForm()
    {
        InitializeComponent();
    }
    [System.ComponentModel.Browsable(false)]
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public SpecialOffer? NewOffer { get; private set; }

    private void buttonInsert_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBoxId.Text) || !int.TryParse(textBoxId.Text, out int offerId))
        {
            MessageBox.Show("Please enter a valid numeric Offer ID.");
            return;
        }

        if (string.IsNullOrWhiteSpace(textBoxName.Text))
        {
            MessageBox.Show("Please enter an Offer Name.");
            return;
        }

        if (!TryGetDate(textBoxStartDate.Text, out DateOnly? startDate, "Start Date"))
        {
            return;
        }

        if (!TryGetDate(textBoxEndDate.Text, out DateOnly? endDate, "End Date"))
        {
            return;
        }

        if (!TryGetInt(textBoxMinPoints.Text, out int? minPoints, "Minimum Points"))
        {
            return;
        }

        try
        {
            using (var context = new NeondbContext())
            {
                NewOffer = new SpecialOffer
                {
                    Offerid = offerId,
                    Offername = textBoxName.Text,
                    Startdate = startDate,
                    Enddate = endDate,
                    Minpoints = minPoints,
                    Dayoftheweek = textBoxDayOfWeek.Text
                };

                context.SpecialOffers.Add(NewOffer);
                context.SaveChanges();
            }

            MessageBox.Show("Special offer inserted successfully!");
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error inserting special offer: {ex.Message}");
        }
    }

    private bool TryGetDate(string input, out DateOnly? value, string fieldName)
    {
        value = null;

        if (string.IsNullOrWhiteSpace(input))
        {
            return true;
        }

        if (DateOnly.TryParse(input, out var parsedDate))
        {
            value = parsedDate;
            return true;
        }

        MessageBox.Show($"Please enter a valid {fieldName} (for example 2026-04-14).");
        return false;
    }

    private bool TryGetInt(string input, out int? value, string fieldName)
    {
        value = null;

        if (string.IsNullOrWhiteSpace(input))
        {
            return true;
        }

        if (int.TryParse(input, out var parsedInt))
        {
            value = parsedInt;
            return true;
        }

        MessageBox.Show($"Please enter a valid numeric value for {fieldName}.");
        return false;
    }
}

