namespace OFODBGUI.Models;

public partial class insertForm : Form
{
    public insertForm()
    {
        InitializeComponent();
    }

    public MenuItem? NewItem { get; private set; }

    private void buttonInsert_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBoxId.Text) || !int.TryParse(textBoxId.Text, out int itemId))
        {
            MessageBox.Show("Please enter a valid numeric Item ID.");
            return;
        }

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
                NewItem = new MenuItem
                {
                    Itemid = itemId,
                    Itemname = textBoxName.Text,
                    Itemdescription = textBoxDescription.Text,
                    Category = textBoxCategory.Text,
                    Price = price,
                    Availability = checkBoxAvailability.Checked
                };

                context.MenuItems.Add(NewItem);
                context.SaveChanges();
            }

            MessageBox.Show("Menu item inserted successfully!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error inserting menu item: {ex.Message}");
        }
    }

  
}