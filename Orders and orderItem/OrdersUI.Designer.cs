namespace OFODBGUI.Orders_and_orderItem;

partial class OrdersUI
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label lblBranch;
    private System.Windows.Forms.ComboBox cmbBranch;

    private System.Windows.Forms.Label lblCustomerPhone;
    private System.Windows.Forms.TextBox txtCustomerPhone;

    private System.Windows.Forms.Label lblCustomerEmail;
    private System.Windows.Forms.TextBox txtCustomerEmail;

    private System.Windows.Forms.Label lblMenu;
    private System.Windows.Forms.ComboBox cmbMenu;
    private System.Windows.Forms.Button btnAddToCart;
    private System.Windows.Forms.ListBox lstCart;
    private System.Windows.Forms.Label lblTotal;
    private System.Windows.Forms.Button btnRemoveFromCart;

    private System.Windows.Forms.Label lblPayment;
    private System.Windows.Forms.ComboBox cmbPayment;

    private System.Windows.Forms.Label lblDeliveryGuy;
    private System.Windows.Forms.ComboBox cmbDeliveryGuy;

    private System.Windows.Forms.Label lblSpecialOffer;
    private System.Windows.Forms.ComboBox cmbSpecialOffer;

    private System.Windows.Forms.Button btnPlaceOrder;
    private System.Windows.Forms.Button btnViewAllOrders;
    private System.Windows.Forms.Button btnBack;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.lblBranch = new System.Windows.Forms.Label();
        this.cmbBranch = new System.Windows.Forms.ComboBox();

        this.lblCustomerPhone = new System.Windows.Forms.Label();
        this.txtCustomerPhone = new System.Windows.Forms.TextBox();

        this.lblCustomerEmail = new System.Windows.Forms.Label();
        this.txtCustomerEmail = new System.Windows.Forms.TextBox();

         this.lblMenu = new System.Windows.Forms.Label();
         this.cmbMenu = new System.Windows.Forms.ComboBox();
         this.btnAddToCart = new System.Windows.Forms.Button();
         this.lstCart = new System.Windows.Forms.ListBox();
         this.lblTotal = new System.Windows.Forms.Label();
         this.btnRemoveFromCart = new System.Windows.Forms.Button();

        this.lblPayment = new System.Windows.Forms.Label();
        this.cmbPayment = new System.Windows.Forms.ComboBox();

         this.lblDeliveryGuy = new System.Windows.Forms.Label();
         this.cmbDeliveryGuy = new System.Windows.Forms.ComboBox();

         this.lblSpecialOffer = new System.Windows.Forms.Label();
         this.cmbSpecialOffer = new System.Windows.Forms.ComboBox();

         this.btnPlaceOrder = new System.Windows.Forms.Button();
         this.btnViewAllOrders = new System.Windows.Forms.Button();
         this.btnBack = new System.Windows.Forms.Button();

        this.SuspendLayout();

        // Branch
        this.lblBranch.AutoSize = true;
        this.lblBranch.Location = new System.Drawing.Point(30, 20);
        this.lblBranch.Text = "1. Select Branch:";
        this.cmbBranch.Location = new System.Drawing.Point(30, 45);
        this.cmbBranch.Size = new System.Drawing.Size(250, 30);
        this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.cmbBranch_SelectedIndexChanged);

        // Customer
         this.lblCustomerPhone.AutoSize = true;
         this.lblCustomerPhone.Location = new System.Drawing.Point(30, 95);
         this.lblCustomerPhone.Text = "2. Customer Phone:";
         this.txtCustomerPhone.Location = new System.Drawing.Point(30, 120);
         this.txtCustomerPhone.Size = new System.Drawing.Size(250, 30);

         this.lblCustomerEmail.AutoSize = true;
         this.lblCustomerEmail.Location = new System.Drawing.Point(30, 165);
         this.lblCustomerEmail.Text = "Customer Email:";
         this.txtCustomerEmail.Location = new System.Drawing.Point(30, 190);
         this.txtCustomerEmail.Size = new System.Drawing.Size(250, 30);
         this.txtCustomerEmail.Leave += new System.EventHandler(this.txtCustomerEmail_Leave);

        // Payment
        this.lblPayment.AutoSize = true;
        this.lblPayment.Location = new System.Drawing.Point(30, 235);
        this.lblPayment.Text = "4. Payment Method:";
        this.cmbPayment.Location = new System.Drawing.Point(30, 260);
        this.cmbPayment.Size = new System.Drawing.Size(250, 30);
        this.cmbPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

         // Delivery Guy
         this.lblDeliveryGuy.AutoSize = true;
         this.lblDeliveryGuy.Location = new System.Drawing.Point(30, 305);
         this.lblDeliveryGuy.Text = "5. Delivery Guy:";
         this.cmbDeliveryGuy.Location = new System.Drawing.Point(30, 330);
         this.cmbDeliveryGuy.Size = new System.Drawing.Size(250, 30);
         this.cmbDeliveryGuy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

         // Special Offer
         this.lblSpecialOffer.AutoSize = true;
         this.lblSpecialOffer.Location = new System.Drawing.Point(30, 375);
         this.lblSpecialOffer.Text = "6. Special Offer (Optional):";
         this.cmbSpecialOffer.Location = new System.Drawing.Point(30, 400);
         this.cmbSpecialOffer.Size = new System.Drawing.Size(250, 30);
         this.cmbSpecialOffer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbSpecialOffer.SelectedIndexChanged += new System.EventHandler(this.cmbSpecialOffer_SelectedIndexChanged);

        // Menu & Cart
        this.lblMenu.AutoSize = true;
        this.lblMenu.Location = new System.Drawing.Point(320, 20);
        this.lblMenu.Text = "3. Menu Items:";
        this.cmbMenu.Location = new System.Drawing.Point(320, 45);
        this.cmbMenu.Size = new System.Drawing.Size(300, 30);
        this.cmbMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

         this.btnAddToCart.Location = new System.Drawing.Point(635, 43);
         this.btnAddToCart.Size = new System.Drawing.Size(120, 35);
         this.btnAddToCart.Text = "Add to Cart";
         this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);

         this.lstCart.Location = new System.Drawing.Point(320, 95);
         this.lstCart.Size = new System.Drawing.Size(300, 230);

         this.btnRemoveFromCart.Location = new System.Drawing.Point(635, 95);
         this.btnRemoveFromCart.Size = new System.Drawing.Size(120, 45);
         this.btnRemoveFromCart.Text = "Remove";
         this.btnRemoveFromCart.Click += new System.EventHandler(this.btnRemoveFromCart_Click);

        // lblTotal
        this.lblTotal.AutoSize = true;
        this.lblTotal.Location = new System.Drawing.Point(320, 335);
        this.lblTotal.Text = "Total Order: $0.00";
        this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

         // Place Order
         this.btnPlaceOrder.Location = new System.Drawing.Point(320, 380);
         this.btnPlaceOrder.Size = new System.Drawing.Size(435, 55);
         this.btnPlaceOrder.Text = "PLACE ORDER";
         this.btnPlaceOrder.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
         this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);

         // View All Orders
         this.btnViewAllOrders.Location = new System.Drawing.Point(30, 450);
         this.btnViewAllOrders.Size = new System.Drawing.Size(250, 40);
         this.btnViewAllOrders.Text = "View All Orders";
         this.btnViewAllOrders.Click += new System.EventHandler(this.btnViewAllOrders_Click);

         // Back Button
         this.btnBack.Location = new System.Drawing.Point(290, 450);
         this.btnBack.Size = new System.Drawing.Size(250, 40);
         this.btnBack.Text = "Back to Main Portal";
         this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

         // Form
         this.ClientSize = new System.Drawing.Size(800, 510);
        this.Controls.Add(this.lblBranch);
        this.Controls.Add(this.cmbBranch);
        this.Controls.Add(this.lblCustomerPhone);
        this.Controls.Add(this.txtCustomerPhone);
        this.Controls.Add(this.lblCustomerEmail);
        this.Controls.Add(this.txtCustomerEmail);
        this.Controls.Add(this.lblMenu);
         this.Controls.Add(this.cmbMenu);
         this.Controls.Add(this.btnAddToCart);
         this.Controls.Add(this.lstCart);
         this.Controls.Add(this.btnRemoveFromCart);
         this.Controls.Add(this.lblTotal);
         this.Controls.Add(this.lblPayment);
         this.Controls.Add(this.cmbPayment);
         this.Controls.Add(this.lblDeliveryGuy);
         this.Controls.Add(this.cmbDeliveryGuy);
         this.Controls.Add(this.lblSpecialOffer);
         this.Controls.Add(this.cmbSpecialOffer);
         this.Controls.Add(this.btnPlaceOrder);
         this.Controls.Add(this.btnViewAllOrders);
         this.Controls.Add(this.btnBack);
        this.Name = "OrdersUI";
        this.Text = "Start Order Process";

        this.ResumeLayout(false);
        this.PerformLayout();
    }
}