using System.ComponentModel;

namespace OFODBGUI.Models;

partial class DeliveryGuyInsertForm
{
    private IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        titleLabel = new System.Windows.Forms.Label();
        labelId = new System.Windows.Forms.Label();
        textBoxId = new System.Windows.Forms.TextBox();
        labelName = new System.Windows.Forms.Label();
        textBoxName = new System.Windows.Forms.TextBox();
        labelSsn = new System.Windows.Forms.Label();
        textBoxSsn = new System.Windows.Forms.TextBox();
        labelVehicle = new System.Windows.Forms.Label();
        textBoxVehicle = new System.Windows.Forms.TextBox();
        labelRating = new System.Windows.Forms.Label();
        textBoxRating = new System.Windows.Forms.TextBox();
        labelOrders = new System.Windows.Forms.Label();
        textBoxOrders = new System.Windows.Forms.TextBox();
        labelJoining = new System.Windows.Forms.Label();
        dateJoining = new System.Windows.Forms.DateTimePicker();
        labelExpiry = new System.Windows.Forms.Label();
        dateExpiry = new System.Windows.Forms.DateTimePicker();
        labelBranch = new System.Windows.Forms.Label();
        comboBranch = new System.Windows.Forms.ComboBox();
        buttonInsert = new System.Windows.Forms.Button();
        SuspendLayout();

        titleLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
        titleLabel.Location = new System.Drawing.Point(20, 10);
        titleLabel.Size = new System.Drawing.Size(540, 40);
        titleLabel.Text = "Insert Delivery Guy";
        titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        int y = 60, h = 32, gap = 40;
        int labelX = 20, inputX = 210, labelW = 180, inputW = 330;

        labelId.Location = new System.Drawing.Point(labelX, y);
        labelId.Size = new System.Drawing.Size(labelW, h);
        labelId.Text = "Delivery Guy ID:";
        labelId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        textBoxId.Location = new System.Drawing.Point(inputX, y);
        textBoxId.Size = new System.Drawing.Size(inputW, h);
        textBoxId.Name = "textBoxId";

        y += gap;
        labelName.Location = new System.Drawing.Point(labelX, y);
        labelName.Size = new System.Drawing.Size(labelW, h);
        labelName.Text = "Name:";
        labelName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        textBoxName.Location = new System.Drawing.Point(inputX, y);
        textBoxName.Size = new System.Drawing.Size(inputW, h);
        textBoxName.Name = "textBoxName";

        y += gap;
        labelSsn.Location = new System.Drawing.Point(labelX, y);
        labelSsn.Size = new System.Drawing.Size(labelW, h);
        labelSsn.Text = "SSN:";
        labelSsn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        textBoxSsn.Location = new System.Drawing.Point(inputX, y);
        textBoxSsn.Size = new System.Drawing.Size(inputW, h);
        textBoxSsn.Name = "textBoxSsn";

        y += gap;
        labelVehicle.Location = new System.Drawing.Point(labelX, y);
        labelVehicle.Size = new System.Drawing.Size(labelW, h);
        labelVehicle.Text = "Vehicle Type:";
        labelVehicle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        textBoxVehicle.Location = new System.Drawing.Point(inputX, y);
        textBoxVehicle.Size = new System.Drawing.Size(inputW, h);
        textBoxVehicle.Name = "textBoxVehicle";

        y += gap;
        labelRating.Location = new System.Drawing.Point(labelX, y);
        labelRating.Size = new System.Drawing.Size(labelW, h);
        labelRating.Text = "Rating (0-5):";
        labelRating.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        textBoxRating.Location = new System.Drawing.Point(inputX, y);
        textBoxRating.Size = new System.Drawing.Size(inputW, h);
        textBoxRating.Name = "textBoxRating";

        y += gap;
        labelOrders.Location = new System.Drawing.Point(labelX, y);
        labelOrders.Size = new System.Drawing.Size(labelW, h);
        labelOrders.Text = "Orders Delivered:";
        labelOrders.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        textBoxOrders.Location = new System.Drawing.Point(inputX, y);
        textBoxOrders.Size = new System.Drawing.Size(inputW, h);
        textBoxOrders.Name = "textBoxOrders";

        y += gap;
        labelJoining.Location = new System.Drawing.Point(labelX, y);
        labelJoining.Size = new System.Drawing.Size(labelW, h);
        labelJoining.Text = "Date of Joining:";
        labelJoining.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        dateJoining.Location = new System.Drawing.Point(inputX, y);
        dateJoining.Size = new System.Drawing.Size(inputW, h);
        dateJoining.Name = "dateJoining";
        dateJoining.Format = System.Windows.Forms.DateTimePickerFormat.Short;

        y += gap;
        labelExpiry.Location = new System.Drawing.Point(labelX, y);
        labelExpiry.Size = new System.Drawing.Size(labelW, h);
        labelExpiry.Text = "Contract Expiry:";
        labelExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        dateExpiry.Location = new System.Drawing.Point(inputX, y);
        dateExpiry.Size = new System.Drawing.Size(inputW, h);
        dateExpiry.Name = "dateExpiry";
        dateExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;

        y += gap;
        labelBranch.Location = new System.Drawing.Point(labelX, y);
        labelBranch.Size = new System.Drawing.Size(labelW, h);
        labelBranch.Text = "Branch:";
        labelBranch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        comboBranch.Location = new System.Drawing.Point(inputX, y);
        comboBranch.Size = new System.Drawing.Size(inputW, h);
        comboBranch.Name = "comboBranch";
        comboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

        y += gap + 15;
        buttonInsert.Location = new System.Drawing.Point(210, y);
        buttonInsert.Size = new System.Drawing.Size(150, 45);
        buttonInsert.Name = "buttonInsert";
        buttonInsert.Text = "Insert";
        buttonInsert.UseVisualStyleBackColor = true;
        buttonInsert.Click += buttonInsert_Click;

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(580, y + 70);
        Controls.Add(titleLabel);
        Controls.Add(labelId); Controls.Add(textBoxId);
        Controls.Add(labelName); Controls.Add(textBoxName);
        Controls.Add(labelSsn); Controls.Add(textBoxSsn);
        Controls.Add(labelVehicle); Controls.Add(textBoxVehicle);
        Controls.Add(labelRating); Controls.Add(textBoxRating);
        Controls.Add(labelOrders); Controls.Add(textBoxOrders);
        Controls.Add(labelJoining); Controls.Add(dateJoining);
        Controls.Add(labelExpiry); Controls.Add(dateExpiry);
        Controls.Add(labelBranch); Controls.Add(comboBranch);
        Controls.Add(buttonInsert);
        Text = "Insert Delivery Guy";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label titleLabel;
    private System.Windows.Forms.Label labelId;
    private System.Windows.Forms.TextBox textBoxId;
    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.TextBox textBoxName;
    private System.Windows.Forms.Label labelSsn;
    private System.Windows.Forms.TextBox textBoxSsn;
    private System.Windows.Forms.Label labelVehicle;
    private System.Windows.Forms.TextBox textBoxVehicle;
    private System.Windows.Forms.Label labelRating;
    private System.Windows.Forms.TextBox textBoxRating;
    private System.Windows.Forms.Label labelOrders;
    private System.Windows.Forms.TextBox textBoxOrders;
    private System.Windows.Forms.Label labelJoining;
    private System.Windows.Forms.DateTimePicker dateJoining;
    private System.Windows.Forms.Label labelExpiry;
    private System.Windows.Forms.DateTimePicker dateExpiry;
    private System.Windows.Forms.Label labelBranch;
    private System.Windows.Forms.ComboBox comboBranch;
    private System.Windows.Forms.Button buttonInsert;
}
