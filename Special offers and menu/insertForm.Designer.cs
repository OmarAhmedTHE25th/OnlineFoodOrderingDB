using System.ComponentModel;

namespace OFODBGUI.Models;

partial class insertForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        insertLabel = new System.Windows.Forms.Label();
        tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        labelId = new System.Windows.Forms.Label();
        textBoxId = new System.Windows.Forms.TextBox();
        labelName = new System.Windows.Forms.Label();
        textBoxName = new System.Windows.Forms.TextBox();
        labelDescription = new System.Windows.Forms.Label();
        textBoxDescription = new System.Windows.Forms.TextBox();
        labelCategory = new System.Windows.Forms.Label();
        textBoxCategory = new System.Windows.Forms.TextBox();
        labelAvailability = new System.Windows.Forms.Label();
        checkBoxAvailability = new System.Windows.Forms.CheckBox();
        buttonInsert = new System.Windows.Forms.Button();
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // insertLabel
        // 
        insertLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        insertLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
        insertLabel.Location = new System.Drawing.Point(277, -5);
        insertLabel.Name = "insertLabel";
        insertLabel.Size = new System.Drawing.Size(258, 49);
        insertLabel.TabIndex = 0;
        insertLabel.Text = "Insert Menu Item";
        insertLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 2;
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
        tableLayoutPanel1.Controls.Add(labelId, 0, 0);
        tableLayoutPanel1.Controls.Add(textBoxId, 1, 0);
        tableLayoutPanel1.Controls.Add(labelName, 0, 1);
        tableLayoutPanel1.Controls.Add(textBoxName, 1, 1);
        tableLayoutPanel1.Controls.Add(labelPrice, 0, 2);
        tableLayoutPanel1.Controls.Add(textBoxPrice, 1, 2);
        tableLayoutPanel1.Controls.Add(labelDescription, 0, 3);
        tableLayoutPanel1.Controls.Add(textBoxDescription, 1, 3);
        tableLayoutPanel1.Controls.Add(labelCategory, 0, 4);
        tableLayoutPanel1.Controls.Add(textBoxCategory, 1, 4);
        tableLayoutPanel1.Controls.Add(labelAvailability, 0, 5);
        tableLayoutPanel1.Controls.Add(checkBoxAvailability, 1, 5);
        tableLayoutPanel1.Location = new System.Drawing.Point(50, 60);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 6;
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
        tableLayoutPanel1.Size = new System.Drawing.Size(700, 273);
        tableLayoutPanel1.TabIndex = 1;
        // 
        // labelId
        // 
        labelId.Dock = System.Windows.Forms.DockStyle.Fill;
        labelId.Location = new System.Drawing.Point(3, 0);
        labelId.Name = "labelId";
        labelId.Size = new System.Drawing.Size(274, 40);
        labelId.TabIndex = 0;
        labelId.Text = "Item ID:";
        labelId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBoxId
        // 
        textBoxId.Dock = System.Windows.Forms.DockStyle.Fill;
        textBoxId.Location = new System.Drawing.Point(283, 3);
        textBoxId.Name = "textBoxId";
        textBoxId.Size = new System.Drawing.Size(414, 31);
        textBoxId.TabIndex = 1;
        // 
        // labelName
        // 
        labelName.Dock = System.Windows.Forms.DockStyle.Fill;
        labelName.Location = new System.Drawing.Point(3, 40);
        labelName.Name = "labelName";
        labelName.Size = new System.Drawing.Size(274, 40);
        labelName.TabIndex = 2;
        labelName.Text = "Item Name:";
        labelName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBoxName
        // 
        textBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
        textBoxName.Location = new System.Drawing.Point(283, 43);
        textBoxName.Name = "textBoxName";
        textBoxName.Size = new System.Drawing.Size(414, 31);
        textBoxName.TabIndex = 3;
        // 
        // labelPrice
        // 
        labelPrice.Dock = System.Windows.Forms.DockStyle.Fill;
        labelPrice.Location = new System.Drawing.Point(3, 80);
        labelPrice.Name = "labelPrice";
        labelPrice.Size = new System.Drawing.Size(274, 40);
        labelPrice.TabIndex = 4;
        labelPrice.Text = "Price:";
        labelPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBoxPrice
        // 
        textBoxPrice.Dock = System.Windows.Forms.DockStyle.Fill;
        textBoxPrice.Location = new System.Drawing.Point(283, 83);
        textBoxPrice.Name = "textBoxPrice";
        textBoxPrice.Size = new System.Drawing.Size(414, 31);
        textBoxPrice.TabIndex = 5;
        // 
        // labelDescription
        // 
        labelDescription.Dock = System.Windows.Forms.DockStyle.Fill;
        labelDescription.Location = new System.Drawing.Point(3, 120);
        labelDescription.Name = "labelDescription";
        labelDescription.Size = new System.Drawing.Size(274, 80);
        labelDescription.TabIndex = 6;
        labelDescription.Text = "Description:";
        labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBoxDescription
        // 
        textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
        textBoxDescription.Location = new System.Drawing.Point(283, 123);
        textBoxDescription.Multiline = true;
        textBoxDescription.Name = "textBoxDescription";
        textBoxDescription.Size = new System.Drawing.Size(414, 74);
        textBoxDescription.TabIndex = 7;
        // 
        // labelCategory
        // 
        labelCategory.Dock = System.Windows.Forms.DockStyle.Fill;
        labelCategory.Location = new System.Drawing.Point(3, 200);
        labelCategory.Name = "labelCategory";
        labelCategory.Size = new System.Drawing.Size(274, 40);
        labelCategory.TabIndex = 8;
        labelCategory.Text = "Category:";
        labelCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBoxCategory
        // 
        textBoxCategory.Dock = System.Windows.Forms.DockStyle.Fill;
        textBoxCategory.Location = new System.Drawing.Point(283, 203);
        textBoxCategory.Name = "textBoxCategory";
        textBoxCategory.Size = new System.Drawing.Size(414, 31);
        textBoxCategory.TabIndex = 9;
        // 
        // labelAvailability
        // 
        labelAvailability.Dock = System.Windows.Forms.DockStyle.Fill;
        labelAvailability.Location = new System.Drawing.Point(3, 240);
        labelAvailability.Name = "labelAvailability";
        labelAvailability.Size = new System.Drawing.Size(274, 40);
        labelAvailability.TabIndex = 10;
        labelAvailability.Text = "Available:";
        labelAvailability.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // checkBoxAvailability
        // 
        checkBoxAvailability.AutoSize = true;
        checkBoxAvailability.Dock = System.Windows.Forms.DockStyle.Fill;
        checkBoxAvailability.Location = new System.Drawing.Point(283, 243);
        checkBoxAvailability.Name = "checkBoxAvailability";
        checkBoxAvailability.Size = new System.Drawing.Size(414, 34);
        checkBoxAvailability.TabIndex = 11;
        checkBoxAvailability.UseVisualStyleBackColor = true;
        // 
        // buttonInsert
        // 
        buttonInsert.Location = new System.Drawing.Point(324, 398);
        buttonInsert.Name = "buttonInsert";
        buttonInsert.Size = new System.Drawing.Size(150, 50);
        buttonInsert.TabIndex = 2;
        buttonInsert.Text = "Insert";
        buttonInsert.UseVisualStyleBackColor = true;
        buttonInsert.Click += buttonInsert_Click;
        // 
        // insertForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(894, 549);
        Controls.Add(buttonInsert);
        Controls.Add(tableLayoutPanel1);
        Controls.Add(insertLabel);
        Text = "Insert Menu Item";
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label labelId;
    private System.Windows.Forms.TextBox textBoxId;
    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.TextBox textBoxName;
    private System.Windows.Forms.Label labelPrice;
    private System.Windows.Forms.TextBox textBoxPrice;
    private System.Windows.Forms.Label labelDescription;
    private System.Windows.Forms.TextBox textBoxDescription;
    private System.Windows.Forms.Label labelCategory;
    private System.Windows.Forms.TextBox textBoxCategory;
    private System.Windows.Forms.Label labelAvailability;
    private System.Windows.Forms.CheckBox checkBoxAvailability;
    private System.Windows.Forms.Button buttonInsert;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    private System.Windows.Forms.Label insertLabel;

    #endregion
}