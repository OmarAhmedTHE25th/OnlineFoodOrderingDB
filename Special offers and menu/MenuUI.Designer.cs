using System.ComponentModel;

namespace OFODBGUI.Models;

partial class MenuUI
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
        dataGridView1 = new System.Windows.Forms.DataGridView();
        MenuLabel = new System.Windows.Forms.Label();
        insert = new System.Windows.Forms.Button();
        update = new System.Windows.Forms.Button();
        textBox1 = new System.Windows.Forms.TextBox();
        tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        delete = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // dataGridView1
        // 
        dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Location = new System.Drawing.Point(2, 38);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowHeadersWidth = 62;
        dataGridView1.Size = new System.Drawing.Size(1242, 267);
        dataGridView1.TabIndex = 0;
        dataGridView1.Text = "dataGridView1";
        // 
        // MenuLabel
        // 
        MenuLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        MenuLabel.Location = new System.Drawing.Point(460, -3);
        MenuLabel.Name = "MenuLabel";
        MenuLabel.Size = new System.Drawing.Size(146, 38);
        MenuLabel.TabIndex = 1;
        MenuLabel.Text = "Menu";
        MenuLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        MenuLabel.Click += label1_Click;
        // 
        // insert
        // 
        insert.Location = new System.Drawing.Point(3, 3);
        insert.Name = "insert";
        insert.Size = new System.Drawing.Size(157, 73);
        insert.TabIndex = 2;
        insert.Text = "Insert";
        insert.UseVisualStyleBackColor = true;
        insert.Click += insert_Click;
        // 
        // update
        // 
        update.Location = new System.Drawing.Point(455, 3);
        update.Name = "update";
        update.Size = new System.Drawing.Size(130, 73);
        update.TabIndex = 3;
        update.Text = "Update";
        update.UseVisualStyleBackColor = true;
        update.Click += update_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(12, 458);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(1232, 229);
        textBox1.TabIndex = 5;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
        tableLayoutPanel1.ColumnCount = 3;
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.986843F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.013157F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 354F));
        tableLayoutPanel1.Controls.Add(delete, 2, 0);
        tableLayoutPanel1.Controls.Add(update, 1, 0);
        tableLayoutPanel1.Controls.Add(insert, 0, 0);
        tableLayoutPanel1.Location = new System.Drawing.Point(2, 311);
        tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 1;
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.Size = new System.Drawing.Size(1242, 79);
        tableLayoutPanel1.TabIndex = 6;
        // 
        // delete
        // 
        delete.Location = new System.Drawing.Point(890, 3);
        delete.Name = "delete";
        delete.Size = new System.Drawing.Size(130, 73);
        delete.TabIndex = 4;
        delete.Text = "Delete";
        delete.UseVisualStyleBackColor = true;
        delete.Click += delete_Click;
        // 
        // MenuUI
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1256, 691);
        Controls.Add(tableLayoutPanel1);
        Controls.Add(textBox1);
        Controls.Add(MenuLabel);
        Controls.Add(dataGridView1);
        Text = "MenuUI";
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        tableLayoutPanel1.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.Button delete;

    private System.Windows.Forms.Button insert;
    private System.Windows.Forms.Button update;

    private System.Windows.Forms.Label MenuLabel;

    private System.Windows.Forms.DataGridView dataGridView1;

    #endregion
}