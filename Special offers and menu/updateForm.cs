namespace OFODBGUI.Models;

public partial class updateForm : Form
{
    private MenuItem _item;

    public updateForm(MenuItem item)
    {
        InitializeComponent();
        _item = item;
        PopulateFields();
    }

    private void PopulateFields()
    {
        textBoxId.Text = _item.Itemid.ToString();
        textBoxName.Text = _item.Itemname;
        textBoxPrice.Text = _item.Price.ToString();
        textBoxDescription.Text = _item.Itemdescription;
        textBoxCategory.Text = _item.Category;
        checkBoxAvailability.Checked = _item.Availability ?? false;
    }

    public MenuItem UpdatedItem => _item;

    private void buttonUpdate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBoxName.Text))
        {
            MessageBox.Show("Please enter an Item Name.");
            return;
        }

        if (string.IsNullOrWhiteSpace(textBoxPrice.Text) || !int.TryParse(textBoxPrice.Text, out int price))
        {
            MessageBox.Show("Please enter a valid numeric Price.");
            return;
        }

        try
        {
            using (var context = new NeondbContext())
            {
                var itemToUpdate = context.MenuItems.Find(_item.Itemid);
                if (itemToUpdate != null)
                {
                    itemToUpdate.Itemname = textBoxName.Text;
                    itemToUpdate.Price = price;
                    itemToUpdate.Itemdescription = textBoxDescription.Text;
                    itemToUpdate.Category = textBoxCategory.Text;
                    itemToUpdate.Availability = checkBoxAvailability.Checked;

                    context.SaveChanges();
                    MessageBox.Show("Menu item updated successfully!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Item not found in database.");
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating menu item: {ex.Message}");
        }
    }
}
