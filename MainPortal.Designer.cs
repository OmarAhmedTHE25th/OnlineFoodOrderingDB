namespace OFODBGUI;

partial class MainPortal
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        CustomerBtn = new System.Windows.Forms.Button();
        BranchBtn = new System.Windows.Forms.Button();
        DeliveryGuyBtn = new System.Windows.Forms.Button();
        button4 = new System.Windows.Forms.Button();
        OrdersBtn = new System.Windows.Forms.Button();
        MenuBtn = new System.Windows.Forms.Button();
        OffersBtn = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // CustomerBtn
        // 
        CustomerBtn.Location = new System.Drawing.Point(233, 12);
        CustomerBtn.Name = "CustomerBtn";
        CustomerBtn.Size = new System.Drawing.Size(226, 94);
        CustomerBtn.TabIndex = 0;
        CustomerBtn.Text = "Customer Form";
        CustomerBtn.UseVisualStyleBackColor = true;
        // 
        // BranchBtn
        // 
        BranchBtn.Location = new System.Drawing.Point(468, 12);
        BranchBtn.Name = "BranchBtn";
        BranchBtn.Size = new System.Drawing.Size(226, 94);
        BranchBtn.TabIndex = 1;
        BranchBtn.Text = "Branch Form";
        BranchBtn.UseVisualStyleBackColor = true;
        // 
        // DeliveryGuyBtn
        // 
        DeliveryGuyBtn.Location = new System.Drawing.Point(725, 12);
        DeliveryGuyBtn.Name = "DeliveryGuyBtn";
        DeliveryGuyBtn.Size = new System.Drawing.Size(226, 94);
        DeliveryGuyBtn.TabIndex = 2;
        DeliveryGuyBtn.Text = "Delivery Guy From";
        DeliveryGuyBtn.UseVisualStyleBackColor = true;
        // 
        // button4
        // 
        button4.Location = new System.Drawing.Point(468, 116);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(226, 94);
        button4.TabIndex = 3;
        button4.Text = "button4";
        button4.UseVisualStyleBackColor = true;
        // 
        // OrdersBtn
        // 
        OrdersBtn.Location = new System.Drawing.Point(233, 116);
        OrdersBtn.Name = "OrdersBtn";
        OrdersBtn.Size = new System.Drawing.Size(226, 94);
        OrdersBtn.TabIndex = 4;
        OrdersBtn.Text = "Orders Form";
        OrdersBtn.UseVisualStyleBackColor = true;
        OrdersBtn.Click += OrdersBtn_Click;
        // 
        // MenuBtn
        // 
        MenuBtn.Location = new System.Drawing.Point(725, 116);
        MenuBtn.Name = "MenuBtn";
        MenuBtn.Size = new System.Drawing.Size(226, 94);
        MenuBtn.TabIndex = 5;
        MenuBtn.Text = "Menu Form";
        MenuBtn.UseVisualStyleBackColor = true;
        MenuBtn.Click += MenuBtn_Click;
        // 
        // OffersBtn
        // 
        OffersBtn.Location = new System.Drawing.Point(468, 238);
        OffersBtn.Name = "OffersBtn";
        OffersBtn.Size = new System.Drawing.Size(226, 94);
        OffersBtn.TabIndex = 6;
        OffersBtn.Text = "Special Offers Form";
        OffersBtn.UseVisualStyleBackColor = true;
        OffersBtn.Click += OffersBtn_Click;
        // 
        // MainPortal
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1280, 663);
        Controls.Add(OffersBtn);
        Controls.Add(MenuBtn);
        Controls.Add(OrdersBtn);
        Controls.Add(button4);
        Controls.Add(DeliveryGuyBtn);
        Controls.Add(BranchBtn);
        Controls.Add(CustomerBtn);
        Text = "Main Portal";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button CustomerBtn;
    private System.Windows.Forms.Button BranchBtn;
    private System.Windows.Forms.Button DeliveryGuyBtn;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button OrdersBtn;
    private System.Windows.Forms.Button MenuBtn;
    private System.Windows.Forms.Button OffersBtn;

    #endregion
}