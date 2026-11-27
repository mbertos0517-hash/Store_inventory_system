#nullable disable
namespace Store_inventory_system.WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            gridProducts = new System.Windows.Forms.DataGridView();
            colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colReorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            panelSide = new System.Windows.Forms.Panel();
            grpDetails = new System.Windows.Forms.GroupBox();
            lblName = new System.Windows.Forms.Label();
            txtName = new System.Windows.Forms.TextBox();
            lblPrice = new System.Windows.Forms.Label();
            numPrice = new System.Windows.Forms.NumericUpDown();
            lblStock = new System.Windows.Forms.Label();
            numStock = new System.Windows.Forms.NumericUpDown();
            lblReorder = new System.Windows.Forms.Label();
            numReorder = new System.Windows.Forms.NumericUpDown();
            btnAdd = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();
            grpStock = new System.Windows.Forms.GroupBox();
            lblQuantity = new System.Windows.Forms.Label();
            numQuantity = new System.Windows.Forms.NumericUpDown();
            btnStockIn = new System.Windows.Forms.Button();
            btnStockOut = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            chkLowOnly = new System.Windows.Forms.CheckBox();
            btnRefresh = new System.Windows.Forms.Button();
            statusStrip = new System.Windows.Forms.StatusStrip();
            lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)gridProducts).BeginInit();
            panelSide.SuspendLayout();
            grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numReorder).BeginInit();
            grpStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // gridProducts
            // 
            gridProducts.AllowUserToAddRows = false;
            gridProducts.AllowUserToDeleteRows = false;
            gridProducts.AllowUserToResizeRows = false;
            gridProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            gridProducts.BackgroundColor = System.Drawing.SystemColors.Window;
            gridProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colId, colName, colPrice, colStock, colReorder });
            gridProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            gridProducts.Location = new System.Drawing.Point(0, 0);
            gridProducts.MultiSelect = false;
            gridProducts.Name = "gridProducts";
            gridProducts.ReadOnly = true;
            gridProducts.RowHeadersVisible = false;
            gridProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            gridProducts.Size = new System.Drawing.Size(660, 538);
            gridProducts.TabIndex = 0;
            gridProducts.DataBindingComplete += gridProducts_DataBindingComplete;
            gridProducts.SelectionChanged += gridProducts_SelectionChanged;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.FillWeight = 10F;
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colName
            // 
            colName.DataPropertyName = "Name";
            colName.FillWeight = 40F;
            colName.HeaderText = "Product";
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colPrice
            // 
            colPrice.DataPropertyName = "Price";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            colPrice.DefaultCellStyle = dataGridViewCellStyle1;
            colPrice.FillWeight = 20F;
            colPrice.HeaderText = "Price";
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            // 
            // colStock
            // 
            colStock.DataPropertyName = "StockQuantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            colStock.DefaultCellStyle = dataGridViewCellStyle2;
            colStock.FillWeight = 15F;
            colStock.HeaderText = "Stock";
            colStock.Name = "colStock";
            colStock.ReadOnly = true;
            // 
            // colReorder
            // 
            colReorder.DataPropertyName = "ReorderLevel";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            colReorder.DefaultCellStyle = dataGridViewCellStyle3;
            colReorder.FillWeight = 15F;
            colReorder.HeaderText = "Reorder level";
            colReorder.Name = "colReorder";
            colReorder.ReadOnly = true;
            // 
            // panelSide
            // 
            panelSide.Controls.Add(grpDetails);
            panelSide.Controls.Add(grpStock);
            panelSide.Controls.Add(btnDelete);
            panelSide.Controls.Add(chkLowOnly);
            panelSide.Controls.Add(btnRefresh);
            panelSide.Dock = System.Windows.Forms.DockStyle.Right;
            panelSide.Location = new System.Drawing.Point(660, 0);
            panelSide.Name = "panelSide";
            panelSide.Padding = new System.Windows.Forms.Padding(10);
            panelSide.Size = new System.Drawing.Size(300, 538);
            panelSide.TabIndex = 1;
            // 
            // grpDetails
            // 
            grpDetails.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpDetails.Controls.Add(lblName);
            grpDetails.Controls.Add(txtName);
            grpDetails.Controls.Add(lblPrice);
            grpDetails.Controls.Add(numPrice);
            grpDetails.Controls.Add(lblStock);
            grpDetails.Controls.Add(numStock);
            grpDetails.Controls.Add(lblReorder);
            grpDetails.Controls.Add(numReorder);
            grpDetails.Controls.Add(btnAdd);
            grpDetails.Controls.Add(btnUpdate);
            grpDetails.Controls.Add(btnClear);
            grpDetails.Location = new System.Drawing.Point(10, 10);
            grpDetails.Name = "grpDetails";
            grpDetails.Size = new System.Drawing.Size(280, 222);
            grpDetails.TabIndex = 0;
            grpDetails.TabStop = false;
            grpDetails.Text = "Product details";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new System.Drawing.Point(12, 32);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(39, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // txtName
            // 
            txtName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtName.Location = new System.Drawing.Point(122, 28);
            txtName.MaxLength = 100;
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(146, 23);
            txtName.TabIndex = 1;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new System.Drawing.Point(12, 66);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new System.Drawing.Size(33, 15);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "Price";
            // 
            // numPrice
            // 
            numPrice.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new System.Drawing.Point(122, 62);
            numPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new System.Drawing.Size(146, 23);
            numPrice.TabIndex = 3;
            numPrice.ThousandsSeparator = true;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new System.Drawing.Point(12, 100);
            lblStock.Name = "lblStock";
            lblStock.Size = new System.Drawing.Size(70, 15);
            lblStock.TabIndex = 4;
            lblStock.Text = "Initial stock";
            // 
            // numStock
            // 
            numStock.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            numStock.Location = new System.Drawing.Point(122, 96);
            numStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new System.Drawing.Size(146, 23);
            numStock.TabIndex = 5;
            numStock.ThousandsSeparator = true;
            // 
            // lblReorder
            // 
            lblReorder.AutoSize = true;
            lblReorder.Location = new System.Drawing.Point(12, 134);
            lblReorder.Name = "lblReorder";
            lblReorder.Size = new System.Drawing.Size(78, 15);
            lblReorder.TabIndex = 6;
            lblReorder.Text = "Reorder level";
            // 
            // numReorder
            // 
            numReorder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            numReorder.Location = new System.Drawing.Point(122, 130);
            numReorder.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numReorder.Name = "numReorder";
            numReorder.Size = new System.Drawing.Size(146, 23);
            numReorder.TabIndex = 7;
            numReorder.ThousandsSeparator = true;
            numReorder.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(12, 176);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(88, 30);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add as new";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new System.Drawing.Point(104, 176);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(104, 30);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update selected";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new System.Drawing.Point(212, 176);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(56, 30);
            btnClear.TabIndex = 10;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // grpStock
            // 
            grpStock.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpStock.Controls.Add(lblQuantity);
            grpStock.Controls.Add(numQuantity);
            grpStock.Controls.Add(btnStockIn);
            grpStock.Controls.Add(btnStockOut);
            grpStock.Location = new System.Drawing.Point(10, 242);
            grpStock.Name = "grpStock";
            grpStock.Size = new System.Drawing.Size(280, 112);
            grpStock.TabIndex = 1;
            grpStock.TabStop = false;
            grpStock.Text = "Stock in / Stock out (selected product)";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new System.Drawing.Point(12, 34);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new System.Drawing.Size(53, 15);
            lblQuantity.TabIndex = 0;
            lblQuantity.Text = "Quantity";
            // 
            // numQuantity
            // 
            numQuantity.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            numQuantity.Location = new System.Drawing.Point(122, 30);
            numQuantity.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new System.Drawing.Size(146, 23);
            numQuantity.TabIndex = 1;
            numQuantity.ThousandsSeparator = true;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnStockIn
            // 
            btnStockIn.Location = new System.Drawing.Point(12, 66);
            btnStockIn.Name = "btnStockIn";
            btnStockIn.Size = new System.Drawing.Size(120, 30);
            btnStockIn.TabIndex = 2;
            btnStockIn.Text = "Stock in (+)";
            btnStockIn.UseVisualStyleBackColor = true;
            btnStockIn.Click += btnStockIn_Click;
            // 
            // btnStockOut
            // 
            btnStockOut.Location = new System.Drawing.Point(140, 66);
            btnStockOut.Name = "btnStockOut";
            btnStockOut.Size = new System.Drawing.Size(128, 30);
            btnStockOut.TabIndex = 3;
            btnStockOut.Text = "Stock out (-)";
            btnStockOut.UseVisualStyleBackColor = true;
            btnStockOut.Click += btnStockOut_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnDelete.Location = new System.Drawing.Point(10, 364);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(280, 32);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete selected product";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // chkLowOnly
            // 
            chkLowOnly.AutoSize = true;
            chkLowOnly.Location = new System.Drawing.Point(14, 406);
            chkLowOnly.Name = "chkLowOnly";
            chkLowOnly.Size = new System.Drawing.Size(188, 19);
            chkLowOnly.TabIndex = 3;
            chkLowOnly.Text = "Show low stock products only";
            chkLowOnly.UseVisualStyleBackColor = true;
            chkLowOnly.CheckedChanged += chkLowOnly_CheckedChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnRefresh.Location = new System.Drawing.Point(10, 436);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(280, 32);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { lblStatus });
            statusStrip.Location = new System.Drawing.Point(0, 538);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new System.Drawing.Size(960, 22);
            statusStrip.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(945, 17);
            lblStatus.Spring = true;
            lblStatus.Text = "Ready";
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(960, 560);
            Controls.Add(gridProducts);
            Controls.Add(panelSide);
            Controls.Add(statusStrip);
            MinimumSize = new System.Drawing.Size(820, 480);
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Store Inventory System";
            FormClosing += MainForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)gridProducts).EndInit();
            panelSide.ResumeLayout(false);
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numReorder).EndInit();
            grpStock.ResumeLayout(false);
            grpStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView gridProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReorder;
        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.Label lblReorder;
        private System.Windows.Forms.NumericUpDown numReorder;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpStock;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnStockIn;
        private System.Windows.Forms.Button btnStockOut;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox chkLowOnly;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}
