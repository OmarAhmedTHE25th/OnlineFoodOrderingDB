using System.Drawing;
using Microsoft.EntityFrameworkCore;

namespace OFODBGUI.Models;

public partial class OffersUI : Form
{
    public OffersUI()
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
        using (var form = new OfferInsertForm())
        {
            if (form.ShowDialog() == DialogResult.OK)
            {
                load_Table(sender, e);
                if (form.NewOffer != null)
                {
                    LogAction($"inserted {form.NewOffer.Offername}");
                }
            }
        }
    }

    private void update_Click(object sender, EventArgs e)
    {
        if (dataview.CurrentRow != null)
        {
            var selectedId = (int)dataview.CurrentRow.Cells["Offerid"].Value;
            using (var context = new NeondbContext())
            {
                var selectedItem = context.SpecialOffers.Find(selectedId);
                if (selectedItem != null)
                {
                    using (var form = new OfferUpdateForm(selectedItem))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            load_Table(sender, e);
                            LogAction($"updated {form.UpdatedOffer.Offername}");
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
            var selectedId = (int)dataview.CurrentRow.Cells["Offerid"].Value;
            var offerName = (string?)dataview.CurrentRow.Cells["Offername"].Value ?? "Unknown Offer";

            var confirmResult = MessageBox.Show($"Are you sure you want to delete {offerName}?",
                                     "Confirm Delete",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (var context = new NeondbContext())
                    {
                        var itemToDelete = context.SpecialOffers.Find(selectedId);
                        if (itemToDelete != null)
                        {
                            context.SpecialOffers.Remove(itemToDelete);
                            context.SaveChanges();
                            MessageBox.Show("Special offer deleted successfully!");
                            LogAction($"deleted {offerName}");
                            load_Table(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting special offer: {ex.Message}");
                }
            }
        }
        else
        {
            MessageBox.Show("Please select a row to delete.");
        }
    }

    private void manageItems_Click(object sender, EventArgs e)
    {
        if (dataview.CurrentRow != null)
        {
            var selectedOfferId = (int)dataview.CurrentRow.Cells["Offerid"].Value;
            using (var form = new ManageOfferItemsForm(selectedOfferId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var context = new NeondbContext())
                        {
                            var offer = context.SpecialOffers
                                .Include(o => o.Items)
                                .FirstOrDefault(o => o.Offerid == selectedOfferId);

                            if (offer != null)
                            {
                                // Remove items not in SelectedItemIds
                                var itemsToRemove = offer.Items
                                    .Where(i => !form.SelectedItemIds.Contains(i.Itemid))
                                    .ToList();
                                foreach (var item in itemsToRemove)
                                {
                                    offer.Items.Remove(item);
                                }

                                // Add new items
                                var currentItemIds = offer.Items.Select(i => i.Itemid).ToHashSet();
                                var itemIdsToAdd = form.SelectedItemIds
                                    .Where(id => !currentItemIds.Contains(id))
                                    .ToList();

                                foreach (var itemId in itemIdsToAdd)
                                {
                                    var item = context.MenuItems.Find(itemId);
                                    if (item != null)
                                    {
                                        offer.Items.Add(item);
                                    }
                                }

                                context.SaveChanges();
                                string offerName = offer.Offername ?? "Unknown Offer";
                                LogAction($"Updated items for offer: {offerName}");
                                MessageBox.Show("Offer items updated successfully!");
                                load_Table(sender, e);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating offer items: {ex.Message}");
                    }
                }
            }
        }
        else
        {
            MessageBox.Show("Please select an offer to manage its items.");
        }
    }

    private void OffersUI_Load(object sender, EventArgs e)
    {
        load_Table(sender, e);
    }

    private void load_Table(object sender, EventArgs e)
    {
        using (var context = new NeondbContext())
        {
            var data = context.SpecialOffers
                .Include(o => o.Items)
                .Select(o => new
                {
                    o.Offerid,
                    o.Offername,
                    o.Startdate,
                    o.Enddate,
                    o.Minpoints,
                    o.Dayoftheweek,
                    Items = string.Join(", ", o.Items.Select(i => i.Itemname).ToList())
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