namespace OFODBGUI.Orders_and_orderItem;

partial class OrdersListUI
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.DataGridView dgvOrders;
    private System.Windows.Forms.Button btnDeleteOrder;
    private System.Windows.Forms.Button btnMarkComplete;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.dgvOrders = new System.Windows.Forms.DataGridView();
        this.btnDeleteOrder = new System.Windows.Forms.Button();
        this.btnMarkComplete = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
        this.SuspendLayout();

        // dgvOrders
        this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvOrders.Location = new System.Drawing.Point(12, 12);
        this.dgvOrders.Name = "dgvOrders";
        this.dgvOrders.Size = new System.Drawing.Size(960, 400);
        this.dgvOrders.TabIndex = 0;
        this.dgvOrders.ReadOnly = true;
        this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvOrders.MultiSelect = false;
        this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);

        // btnDeleteOrder
        this.btnDeleteOrder.Location = new System.Drawing.Point(12, 420);
        this.btnDeleteOrder.Name = "btnDeleteOrder";
        this.btnDeleteOrder.Size = new System.Drawing.Size(150, 40);
        this.btnDeleteOrder.TabIndex = 1;
        this.btnDeleteOrder.Text = "Delete Selected Order";
        this.btnDeleteOrder.UseVisualStyleBackColor = true;
        this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);

        // btnMarkComplete
        this.btnMarkComplete.Location = new System.Drawing.Point(168, 420);
        this.btnMarkComplete.Name = "btnMarkComplete";
        this.btnMarkComplete.Size = new System.Drawing.Size(150, 40);
        this.btnMarkComplete.TabIndex = 2;
        this.btnMarkComplete.Text = "Mark as Complete";
        this.btnMarkComplete.UseVisualStyleBackColor = true;
        this.btnMarkComplete.Click += new System.EventHandler(this.btnMarkComplete_Click);

        // OrdersListUI
        this.ClientSize = new System.Drawing.Size(984, 471);
        this.Controls.Add(this.btnMarkComplete);
        this.Controls.Add(this.btnDeleteOrder);
        this.Controls.Add(this.dgvOrders);
        this.Name = "OrdersListUI";
        this.Text = "All Orders View";
        this.Load += new System.EventHandler(this.OrdersListUI_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
        this.ResumeLayout(false);
    }
}