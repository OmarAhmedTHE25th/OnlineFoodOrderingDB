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

    private System.Windows.Forms.Label lblPayment;
    private System.Windows.Forms.ComboBox cmbPayment;

    private System.Windows.Forms.Label lblDeliveryGuy;
    private System.Windows.Forms.ComboBox cmbDeliveryGuy;

    private System.Windows.Forms.Button btnPlaceOrder;
    private System.Windows.Forms.Button btnViewAllOrders;

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

        this.lblPayment = new System.Windows.Forms.Label();
        this.cmbPayment = new System.Windows.Forms.ComboBox();

        this.lblDeliveryGuy = new System.Windows.Forms.Label();
        this.cmbDeliveryGuy = new System.Windows.Forms.ComboBox();

        this.btnPlaceOrder = new System.Windows.Forms.Button();
        this.btnViewAllOrders = new System.Windows.Forms.Button();

        this.SuspendLayout();

        // Branch
        this.lblBranch.AutoSize = true;
        this.lblBranch.Location = new System.Drawing.Point(20, 20);
        this.lblBranch.Text = "1. Select Branch:";
        this.cmbBranch.Location = new System.Drawing.Point(20, 40);
        this.cmbBranch.Size = new System.Drawing.Size(200, 23);
        this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.cmbBranch_SelectedIndexChanged);

        // Customer
        this.lblCustomerPhone.AutoSize = true;
        this.lblCustomerPhone.Location = new System.Drawing.Point(20, 80);
        this.lblCustomerPhone.Text = "2. Customer Phone:";
        this.txtCustomerPhone.Location = new System.Drawing.Point(20, 100);
        this.txtCustomerPhone.Size = new System.Drawing.Size(200, 23);
        this.txtCustomerPhone.Leave += new System.EventHandler(this.txtCustomerPhone_Leave);

        this.lblCustomerEmail.AutoSize = true;
        this.lblCustomerEmail.Location = new System.Drawing.Point(20, 130);
        this.lblCustomerEmail.Text = "Customer Email:";
        this.txtCustomerEmail.Location = new System.Drawing.Point(20, 150);
        this.txtCustomerEmail.Size = new System.Drawing.Size(200, 23);

        // Menu & Cart
        this.lblMenu.AutoSize = true;
        this.lblMenu.Location = new System.Drawing.Point(250, 20);
        this.lblMenu.Text = "3. Menu Items:";
        this.cmbMenu.Location = new System.Drawing.Point(250, 40);
        this.cmbMenu.Size = new System.Drawing.Size(200, 23);
        this.cmbMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

        this.btnAddToCart.Location = new System.Drawing.Point(460, 40);
        this.btnAddToCart.Size = new System.Drawing.Size(100, 25);
        this.btnAddToCart.Text = "Add to Cart";
        this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);

        this.lstCart.Location = new System.Drawing.Point(250, 80);
        this.lstCart.Size = new System.Drawing.Size(310, 150);

        // Payment
        this.lblPayment.AutoSize = true;
        this.lblPayment.Location = new System.Drawing.Point(20, 190);
        this.lblPayment.Text = "4. Payment Method:";
        this.cmbPayment.Location = new System.Drawing.Point(20, 210);
        this.cmbPayment.Size = new System.Drawing.Size(200, 23);
        this.cmbPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

        // Delivery Guy
        this.lblDeliveryGuy.AutoSize = true;
        this.lblDeliveryGuy.Location = new System.Drawing.Point(20, 250);
        this.lblDeliveryGuy.Text = "5. Delivery Guy:";
        this.cmbDeliveryGuy.Location = new System.Drawing.Point(20, 270);
        this.cmbDeliveryGuy.Size = new System.Drawing.Size(200, 23);
        this.cmbDeliveryGuy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

        // Place Order
        this.btnPlaceOrder.Location = new System.Drawing.Point(250, 250);
        this.btnPlaceOrder.Size = new System.Drawing.Size(310, 45);
        this.btnPlaceOrder.Text = "PLACE ORDER";
        this.btnPlaceOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);

        // View All Orders
        this.btnViewAllOrders.Location = new System.Drawing.Point(20, 305);
        this.btnViewAllOrders.Size = new System.Drawing.Size(540, 30);
        this.btnViewAllOrders.Text = "View All Orders";
        this.btnViewAllOrders.Click += new System.EventHandler(this.btnViewAllOrders_Click);

        // Form
        this.ClientSize = new System.Drawing.Size(600, 350);
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
        this.Controls.Add(this.lblPayment);
        this.Controls.Add(this.cmbPayment);
        this.Controls.Add(this.lblDeliveryGuy);
        this.Controls.Add(this.cmbDeliveryGuy);
        this.Controls.Add(this.btnPlaceOrder);
        this.Controls.Add(this.btnViewAllOrders);
        this.Name = "OrdersUI";
        this.Text = "Start Order Process";

        this.ResumeLayout(false);
        this.PerformLayout();
    }
}