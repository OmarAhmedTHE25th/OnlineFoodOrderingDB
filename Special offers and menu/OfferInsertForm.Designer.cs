using System.ComponentModel;

namespace OFODBGUI.Models;

partial class OfferInsertForm
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
        labelStartDate = new System.Windows.Forms.Label();
        textBoxStartDate = new System.Windows.Forms.TextBox();
        labelEndDate = new System.Windows.Forms.Label();
        textBoxEndDate = new System.Windows.Forms.TextBox();
        labelMinPoints = new System.Windows.Forms.Label();
        textBoxMinPoints = new System.Windows.Forms.TextBox();
        labelDayOfWeek = new System.Windows.Forms.Label();
        textBoxDayOfWeek = new System.Windows.Forms.TextBox();
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
        insertLabel.Text = "Insert Offer";
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
        tableLayoutPanel1.Controls.Add(labelStartDate, 0, 2);
        tableLayoutPanel1.Controls.Add(textBoxStartDate, 1, 2);
        tableLayoutPanel1.Controls.Add(labelEndDate, 0, 3);
        tableLayoutPanel1.Controls.Add(textBoxEndDate, 1, 3);
        tableLayoutPanel1.Controls.Add(labelMinPoints, 0, 4);
        tableLayoutPanel1.Controls.Add(textBoxMinPoints, 1, 4);
        tableLayoutPanel1.Controls.Add(labelDayOfWeek, 0, 5);
        tableLayoutPanel1.Controls.Add(textBoxDayOfWeek, 1, 5);
        tableLayoutPanel1.Location = new System.Drawing.Point(50, 60);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 6;
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
        tableLayoutPanel1.Size = new System.Drawing.Size(700, 240);
        tableLayoutPanel1.TabIndex = 1;
        // 
        // labelId
        // 
        labelId.Dock = System.Windows.Forms.DockStyle.Fill;
        labelId.Location = new System.Drawing.Point(3, 0);
        labelId.Name = "labelId";
        labelId.Size = new System.Drawing.Size(274, 40);
        labelId.TabIndex = 0;
        labelId.Text = "Offer ID:";
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
        labelName.Text = "Offer Name:";
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
        // labelStartDate
        // 
        labelStartDate.Dock = System.Windows.Forms.DockStyle.Fill;
        labelStartDate.Location = new System.Drawing.Point(3, 80);
        labelStartDate.Name = "labelStartDate";
        labelStartDate.Size = new System.Drawing.Size(274, 40);
        labelStartDate.TabIndex = 4;
        labelStartDate.Text = "Start Date:";
        labelStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBoxStartDate
        // 
        textBoxStartDate.Dock = System.Windows.Forms.DockStyle.Fill;
        textBoxStartDate.Location = new System.Drawing.Point(283, 83);
        textBoxStartDate.Name = "textBoxStartDate";
        textBoxStartDate.PlaceholderText = "yyyy-MM-dd";
        textBoxStartDate.Size = new System.Drawing.Size(414, 31);
        textBoxStartDate.TabIndex = 5;
        // 
        // labelEndDate
        // 
        labelEndDate.Dock = System.Windows.Forms.DockStyle.Fill;
        labelEndDate.Location = new System.Drawing.Point(3, 120);
        labelEndDate.Name = "labelEndDate";
        labelEndDate.Size = new System.Drawing.Size(274, 40);
        labelEndDate.TabIndex = 6;
        labelEndDate.Text = "End Date:";
        labelEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBoxEndDate
        // 
        textBoxEndDate.Dock = System.Windows.Forms.DockStyle.Fill;
        textBoxEndDate.Location = new System.Drawing.Point(283, 123);
        textBoxEndDate.Name = "textBoxEndDate";
        textBoxEndDate.PlaceholderText = "yyyy-MM-dd";
        textBoxEndDate.Size = new System.Drawing.Size(414, 31);
        textBoxEndDate.TabIndex = 7;
        // 
        // labelMinPoints
        // 
        labelMinPoints.Dock = System.Windows.Forms.DockStyle.Fill;
        labelMinPoints.Location = new System.Drawing.Point(3, 160);
        labelMinPoints.Name = "labelMinPoints";
        labelMinPoints.Size = new System.Drawing.Size(274, 40);
        labelMinPoints.TabIndex = 8;
        labelMinPoints.Text = "Minimum Points:";
        labelMinPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBoxMinPoints
        // 
        textBoxMinPoints.Dock = System.Windows.Forms.DockStyle.Fill;
        textBoxMinPoints.Location = new System.Drawing.Point(283, 163);
        textBoxMinPoints.Name = "textBoxMinPoints";
        textBoxMinPoints.Size = new System.Drawing.Size(414, 31);
        textBoxMinPoints.TabIndex = 9;
        // 
        // labelDayOfWeek
        // 
        labelDayOfWeek.Dock = System.Windows.Forms.DockStyle.Fill;
        labelDayOfWeek.Location = new System.Drawing.Point(3, 200);
        labelDayOfWeek.Name = "labelDayOfWeek";
        labelDayOfWeek.Size = new System.Drawing.Size(274, 40);
        labelDayOfWeek.TabIndex = 10;
        labelDayOfWeek.Text = "Day of the Week:";
        labelDayOfWeek.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // textBoxDayOfWeek
        // 
        textBoxDayOfWeek.Dock = System.Windows.Forms.DockStyle.Fill;
        textBoxDayOfWeek.Location = new System.Drawing.Point(283, 203);
        textBoxDayOfWeek.Name = "textBoxDayOfWeek";
        textBoxDayOfWeek.Size = new System.Drawing.Size(414, 31);
        textBoxDayOfWeek.TabIndex = 11;
        // 
        // buttonInsert
        // 
        buttonInsert.Location = new System.Drawing.Point(325, 320);
        buttonInsert.Name = "buttonInsert";
        buttonInsert.Size = new System.Drawing.Size(150, 50);
        buttonInsert.TabIndex = 2;
        buttonInsert.Text = "Insert";
        buttonInsert.UseVisualStyleBackColor = true;
        buttonInsert.Click += buttonInsert_Click;
        // 
        // OfferInsertForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 400);
        Controls.Add(buttonInsert);
        Controls.Add(tableLayoutPanel1);
        Controls.Add(insertLabel);
        Text = "Insert Special Offer";
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label labelId;
    private System.Windows.Forms.TextBox textBoxId;
    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.TextBox textBoxName;
    private System.Windows.Forms.Label labelStartDate;
    private System.Windows.Forms.TextBox textBoxStartDate;
    private System.Windows.Forms.Label labelEndDate;
    private System.Windows.Forms.TextBox textBoxEndDate;
    private System.Windows.Forms.Label labelMinPoints;
    private System.Windows.Forms.TextBox textBoxMinPoints;
    private System.Windows.Forms.Label labelDayOfWeek;
    private System.Windows.Forms.TextBox textBoxDayOfWeek;
    private System.Windows.Forms.Button buttonInsert;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    private System.Windows.Forms.Label insertLabel;

    #endregion
}

