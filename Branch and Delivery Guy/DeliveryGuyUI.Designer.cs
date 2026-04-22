using System.ComponentModel;

namespace OFODBGUI.Models;

partial class DeliveryGuyUI
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
        dataview = new System.Windows.Forms.DataGridView();
        insert = new System.Windows.Forms.Button();
        update = new System.Windows.Forms.Button();
        delete = new System.Windows.Forms.Button();
        BackBtn = new System.Windows.Forms.Button();
        outputbox = new System.Windows.Forms.TextBox();
        titleLabel = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)dataview).BeginInit();
        SuspendLayout();

        titleLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
        titleLabel.Location = new System.Drawing.Point(12, 10);
        titleLabel.Size = new System.Drawing.Size(1100, 40);
        titleLabel.Text = "Delivery Guys";
        titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        dataview.Location = new System.Drawing.Point(12, 55);
        dataview.Size = new System.Drawing.Size(1100, 320);
        dataview.Name = "dataview";
        dataview.ReadOnly = true;
        dataview.AllowUserToAddRows = false;
        dataview.AllowUserToDeleteRows = false;
        dataview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dataview.MultiSelect = false;
        dataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

        insert.Location = new System.Drawing.Point(12, 390);
        insert.Size = new System.Drawing.Size(130, 40);
        insert.Name = "insert";
        insert.Text = "Insert";
        insert.UseVisualStyleBackColor = true;
        insert.Click += insert_Click;

        update.Location = new System.Drawing.Point(150, 390);
        update.Size = new System.Drawing.Size(130, 40);
        update.Name = "update";
        update.Text = "Update";
        update.UseVisualStyleBackColor = true;
        update.Click += update_Click;

        delete.Location = new System.Drawing.Point(288, 390);
        delete.Size = new System.Drawing.Size(130, 40);
        delete.Name = "delete";
        delete.Text = "Delete";
        delete.UseVisualStyleBackColor = true;
        delete.Click += delete_Click;

        BackBtn.Location = new System.Drawing.Point(982, 390);
        BackBtn.Size = new System.Drawing.Size(130, 40);
        BackBtn.Name = "BackBtn";
        BackBtn.Text = "Back";
        BackBtn.UseVisualStyleBackColor = true;
        BackBtn.Click += BackBtn_Click;

        outputbox.Location = new System.Drawing.Point(12, 440);
        outputbox.Size = new System.Drawing.Size(1100, 110);
        outputbox.Name = "outputbox";
        outputbox.Multiline = true;
        outputbox.ReadOnly = true;
        outputbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1124, 565);
        Controls.Add(titleLabel);
        Controls.Add(dataview);
        Controls.Add(insert);
        Controls.Add(update);
        Controls.Add(delete);
        Controls.Add(BackBtn);
        Controls.Add(outputbox);
        Text = "Delivery Guys";
        Load += DeliveryGuyUI_Load;
        ((System.ComponentModel.ISupportInitialize)dataview).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label titleLabel;
    private System.Windows.Forms.DataGridView dataview;
    private System.Windows.Forms.Button insert;
    private System.Windows.Forms.Button update;
    private System.Windows.Forms.Button delete;
    private System.Windows.Forms.Button BackBtn;
    private System.Windows.Forms.TextBox outputbox;
}
