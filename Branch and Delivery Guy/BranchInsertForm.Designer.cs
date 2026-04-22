using System.ComponentModel;

namespace OFODBGUI.Models;

partial class BranchInsertForm
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
        labelCity = new System.Windows.Forms.Label();
        textBoxCity = new System.Windows.Forms.TextBox();
        labelDistrict = new System.Windows.Forms.Label();
        textBoxDistrict = new System.Windows.Forms.TextBox();
        labelPhone = new System.Windows.Forms.Label();
        textBoxPhone = new System.Windows.Forms.TextBox();
        labelOpening = new System.Windows.Forms.Label();
        dateOpening = new System.Windows.Forms.DateTimePicker();
        labelClosing = new System.Windows.Forms.Label();
        dateClosing = new System.Windows.Forms.DateTimePicker();
        buttonInsert = new System.Windows.Forms.Button();
        SuspendLayout();

        // titleLabel
        titleLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
        titleLabel.Location = new System.Drawing.Point(20, 10);
        titleLabel.Size = new System.Drawing.Size(540, 40);
        titleLabel.Text = "Insert Branch";
        titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        int y = 70, h = 35, gap = 45;
        int labelX = 30, inputX = 220, labelW = 170, inputW = 320;

        labelId.Location = new System.Drawing.Point(labelX, y);
        labelId.Size = new System.Drawing.Size(labelW, h);
        labelId.Text = "Branch ID:";
        labelId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        textBoxId.Location = new System.Drawing.Point(inputX, y);
        textBoxId.Size = new System.Drawing.Size(inputW, h);
        textBoxId.Name = "textBoxId";

        y += gap;
        labelCity.Location = new System.Drawing.Point(labelX, y);
        labelCity.Size = new System.Drawing.Size(labelW, h);
        labelCity.Text = "City:";
        labelCity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        textBoxCity.Location = new System.Drawing.Point(inputX, y);
        textBoxCity.Size = new System.Drawing.Size(inputW, h);
        textBoxCity.Name = "textBoxCity";

        y += gap;
        labelDistrict.Location = new System.Drawing.Point(labelX, y);
        labelDistrict.Size = new System.Drawing.Size(labelW, h);
        labelDistrict.Text = "District:";
        labelDistrict.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        textBoxDistrict.Location = new System.Drawing.Point(inputX, y);
        textBoxDistrict.Size = new System.Drawing.Size(inputW, h);
        textBoxDistrict.Name = "textBoxDistrict";

        y += gap;
        labelPhone.Location = new System.Drawing.Point(labelX, y);
        labelPhone.Size = new System.Drawing.Size(labelW, h);
        labelPhone.Text = "Phone Number:";
        labelPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        textBoxPhone.Location = new System.Drawing.Point(inputX, y);
        textBoxPhone.Size = new System.Drawing.Size(inputW, h);
        textBoxPhone.Name = "textBoxPhone";

        y += gap;
        labelOpening.Location = new System.Drawing.Point(labelX, y);
        labelOpening.Size = new System.Drawing.Size(labelW, h);
        labelOpening.Text = "Opening Time:";
        labelOpening.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        dateOpening.Location = new System.Drawing.Point(inputX, y);
        dateOpening.Size = new System.Drawing.Size(inputW, h);
        dateOpening.Name = "dateOpening";
        dateOpening.Format = System.Windows.Forms.DateTimePickerFormat.Time;
        dateOpening.ShowUpDown = true;

        y += gap;
        labelClosing.Location = new System.Drawing.Point(labelX, y);
        labelClosing.Size = new System.Drawing.Size(labelW, h);
        labelClosing.Text = "Closing Time:";
        labelClosing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        dateClosing.Location = new System.Drawing.Point(inputX, y);
        dateClosing.Size = new System.Drawing.Size(inputW, h);
        dateClosing.Name = "dateClosing";
        dateClosing.Format = System.Windows.Forms.DateTimePickerFormat.Time;
        dateClosing.ShowUpDown = true;

        y += gap + 20;
        buttonInsert.Location = new System.Drawing.Point(220, y);
        buttonInsert.Size = new System.Drawing.Size(150, 45);
        buttonInsert.Name = "buttonInsert";
        buttonInsert.Text = "Insert";
        buttonInsert.UseVisualStyleBackColor = true;
        buttonInsert.Click += buttonInsert_Click;

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(580, 470);
        Controls.Add(titleLabel);
        Controls.Add(labelId); Controls.Add(textBoxId);
        Controls.Add(labelCity); Controls.Add(textBoxCity);
        Controls.Add(labelDistrict); Controls.Add(textBoxDistrict);
        Controls.Add(labelPhone); Controls.Add(textBoxPhone);
        Controls.Add(labelOpening); Controls.Add(dateOpening);
        Controls.Add(labelClosing); Controls.Add(dateClosing);
        Controls.Add(buttonInsert);
        Text = "Insert Branch";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label titleLabel;
    private System.Windows.Forms.Label labelId;
    private System.Windows.Forms.TextBox textBoxId;
    private System.Windows.Forms.Label labelCity;
    private System.Windows.Forms.TextBox textBoxCity;
    private System.Windows.Forms.Label labelDistrict;
    private System.Windows.Forms.TextBox textBoxDistrict;
    private System.Windows.Forms.Label labelPhone;
    private System.Windows.Forms.TextBox textBoxPhone;
    private System.Windows.Forms.Label labelOpening;
    private System.Windows.Forms.DateTimePicker dateOpening;
    private System.Windows.Forms.Label labelClosing;
    private System.Windows.Forms.DateTimePicker dateClosing;
    private System.Windows.Forms.Button buttonInsert;
}
