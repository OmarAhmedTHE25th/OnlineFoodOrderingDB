namespace OFODBGUI.Orders_and_orderItem;

partial class OrdersListUI
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.DataGridView dgvOrders;
    private System.Windows.Forms.Button btnDeleteOrder;
    private System.Windows.Forms.Button btnMarkComplete;
    private System.Windows.Forms.TextBox outputbox;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;

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
        this.outputbox = new System.Windows.Forms.TextBox();
        this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
        this.tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();

        ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
        this.tableLayoutPanelMain.SuspendLayout();
        this.tableLayoutPanelButtons.SuspendLayout();
        this.SuspendLayout();

        // tableLayoutPanelMain — 3 rows: dgv (stretch), buttons (fixed), outputbox (fixed)
        this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutPanelMain.ColumnCount = 1;
        this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutPanelMain.RowCount = 3;
        this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));  // dgv stretches
        this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));  // buttons fixed
        this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F)); // outputbox fixed
        this.tableLayoutPanelMain.Padding = new System.Windows.Forms.Padding(8);
        this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";

        // dgvOrders
        this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvOrders.Name = "dgvOrders";
        this.dgvOrders.TabIndex = 0;
        this.dgvOrders.ReadOnly = true;
        this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvOrders.MultiSelect = false;
        this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);

        // tableLayoutPanelButtons
        this.tableLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutPanelButtons.ColumnCount = 2;
        this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.tableLayoutPanelButtons.RowCount = 1;
        this.tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutPanelButtons.Controls.Add(this.btnDeleteOrder, 0, 0);
        this.tableLayoutPanelButtons.Controls.Add(this.btnMarkComplete, 1, 0);
        this.tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
        this.tableLayoutPanelButtons.TabIndex = 1;

        // btnDeleteOrder
        this.btnDeleteOrder.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnDeleteOrder.Name = "btnDeleteOrder";
        this.btnDeleteOrder.TabIndex = 0;
        this.btnDeleteOrder.Text = "Delete Selected Order";
        this.btnDeleteOrder.UseVisualStyleBackColor = true;
        this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);

        // btnMarkComplete
        this.btnMarkComplete.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnMarkComplete.Name = "btnMarkComplete";
        this.btnMarkComplete.TabIndex = 1;
        this.btnMarkComplete.Text = "Mark as Complete";
        this.btnMarkComplete.UseVisualStyleBackColor = true;
        this.btnMarkComplete.Click += new System.EventHandler(this.btnMarkComplete_Click);

        // outputbox
        this.outputbox.Dock = System.Windows.Forms.DockStyle.Fill;
        this.outputbox.Multiline = true;
        this.outputbox.Name = "outputbox";
        this.outputbox.ReadOnly = true;
        this.outputbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.outputbox.TabIndex = 2;

        // Assemble main layout
        this.tableLayoutPanelMain.Controls.Add(this.dgvOrders, 0, 0);
        this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelButtons, 0, 1);
        this.tableLayoutPanelMain.Controls.Add(this.outputbox, 0, 2);

        // OrdersListUI
        this.ClientSize = new System.Drawing.Size(984, 500);
        this.Controls.Add(this.tableLayoutPanelMain);
        this.Name = "OrdersListUI";
        this.Text = "All Orders View";
        this.Load += new System.EventHandler(this.OrdersListUI_Load);

        ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
        this.tableLayoutPanelMain.ResumeLayout(false);
        this.tableLayoutPanelButtons.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}