using Microsoft.EntityFrameworkCore;

namespace OFODBGUI.Models;

public partial class ManageOfferItemsForm : Form
{
    private readonly int _offerId;
    [System.ComponentModel.Browsable(false)]
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public List<int> SelectedItemIds { get; private set; } = new();

    public ManageOfferItemsForm(int offerId)
    {
        _offerId = offerId;
        InitializeComponent();
        LoadMenuItems();
    }

    private void LoadMenuItems()
    {
        using (var context = new NeondbContext())
        {
            var allItems = context.MenuItems.ToList();
            var currentOffer = context.SpecialOffers
                .Include(o => o.Items)
                .FirstOrDefault(o => o.Offerid == _offerId);

            var currentItemIds = currentOffer?.Items.Select(i => i.Itemid).ToHashSet() ?? new HashSet<int>();

            checkedListBoxItems.DisplayMember = "Itemname";
            checkedListBoxItems.ValueMember = "Itemid";

            foreach (var item in allItems)
            {
                bool isChecked = currentItemIds.Contains(item.Itemid);
                checkedListBoxItems.Items.Add(item, isChecked);
            }
        }
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
        SelectedItemIds = checkedListBoxItems.CheckedItems
            .Cast<MenuItem>()
            .Select(i => i.Itemid)
            .ToList();
        
        DialogResult = DialogResult.OK;
        Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
