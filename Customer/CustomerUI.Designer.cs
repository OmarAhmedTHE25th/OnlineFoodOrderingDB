namespace OFODBGUI.Customer
{
    partial class CustomerUI
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dataview = new DataGridView();
            insert = new Button();
            update = new Button();
            delete = new Button();
            BackBtn = new Button();
            outputbox = new RichTextBox();

            ((System.ComponentModel.ISupportInitialize)dataview).BeginInit();
            SuspendLayout();

            // dataview
            dataview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataview.Location = new Point(20, 75);
            dataview.Name = "dataview";
            dataview.RowHeadersWidth = 62;
            dataview.Size = new Size(1200, 300);
            dataview.TabIndex = 0;

            // insert
            insert.Location = new Point(120, 415);
            insert.Name = "insert";
            insert.Size = new Size(150, 55);
            insert.TabIndex = 1;
            insert.Text = "Insert";
            insert.UseVisualStyleBackColor = true;
            insert.Click += insert_Click;

            // update
            update.Location = new Point(430, 415);
            update.Name = "update";
            update.Size = new Size(150, 55);
            update.TabIndex = 2;
            update.Text = "Update";
            update.UseVisualStyleBackColor = true;
            update.Click += update_Click;

            // delete
            delete.Location = new Point(740, 415);
            delete.Name = "delete";
            delete.Size = new Size(150, 55);
            delete.TabIndex = 3;
            delete.Text = "Delete";
            delete.UseVisualStyleBackColor = true;
            delete.Click += delete_Click;

            // BackBtn
            BackBtn.Location = new Point(1050, 415);
            BackBtn.Name = "BackBtn";
            BackBtn.Size = new Size(150, 55);
            BackBtn.TabIndex = 4;
            BackBtn.Text = "Back";
            BackBtn.UseVisualStyleBackColor = true;
            BackBtn.Click += BackBtn_Click;

            // outputbox
            outputbox.Location = new Point(20, 530);
            outputbox.Name = "outputbox";
            outputbox.ReadOnly = true;
            outputbox.Size = new Size(1200, 110);
            outputbox.TabIndex = 5;
            outputbox.Text = "";

            // CustomerUI
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 700);
            Controls.Add(outputbox);
            Controls.Add(BackBtn);
            Controls.Add(delete);
            Controls.Add(update);
            Controls.Add(insert);
            Controls.Add(dataview);
            Name = "CustomerUI";
            Text = "CustomerUI";
            Load += CustomerUI_Load;

            ((System.ComponentModel.ISupportInitialize)dataview).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataview;
        private Button insert;
        private Button update;
        private Button delete;
        private Button BackBtn;
        private RichTextBox outputbox;
    }
}