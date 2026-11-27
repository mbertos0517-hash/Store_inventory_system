using Store_inventory_system.BLL.Exceptions;
using Store_inventory_system.BLL.Services;
using Store_inventory_system.DLL.Models;

namespace Store_inventory_system.WinForms
{
    /// <summary>
    /// Main window. Contains no business rules: everything goes through IInventoryService.
    /// The layout lives in MainForm.Designer.cs - open MainForm.cs in the Designer tab
    /// (double-click it in Solution Explorer) to edit it visually.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly IInventoryService _service = null!;

        private bool _loading;

        // Used by the Visual Studio Designer only. The app always uses the constructor below.
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(IInventoryService service) : this()
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));

            // Columns are defined in the Designer; don't let the grid generate extra ones.
            gridProducts.AutoGenerateColumns = false;

            RefreshGrid();
        }

        // ------------------------------------------------------------ event handlers
        // These are wired up in the Designer (select a control > Properties > lightning bolt).

        private void btnAdd_Click(object? sender, EventArgs e) => Run(AddProduct);

        private void btnUpdate_Click(object? sender, EventArgs e) => Run(UpdateProduct);

        private void btnClear_Click(object? sender, EventArgs e) => ClearDetails();

        private void btnDelete_Click(object? sender, EventArgs e) => Run(DeleteProduct);

        private void btnStockIn_Click(object? sender, EventArgs e) => Run(() => ChangeStock(isStockIn: true));

        private void btnStockOut_Click(object? sender, EventArgs e) => Run(() => ChangeStock(isStockIn: false));

        private void btnRefresh_Click(object? sender, EventArgs e) => RefreshGrid();

        private void chkLowOnly_CheckedChanged(object? sender, EventArgs e) => RefreshGrid();

        private void gridProducts_SelectionChanged(object? sender, EventArgs e) => FillDetailsFromSelection();

        private void gridProducts_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e) => HighlightLowStockRows();

        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            try { _service.SaveChanges(); } catch { /* nothing useful to do while closing */ }
        }

        // ------------------------------------------------------------ actions

        private void AddProduct()
        {
            var product = _service.AddProduct(
                txtName.Text, numPrice.Value, (int)numStock.Value, (int)numReorder.Value);

            RefreshGrid(selectId: product.Id);
            SetStatus($"Added '{product.Name}' (id {product.Id}).");
        }

        private void UpdateProduct()
        {
            var selected = GetSelectedProduct("Select a product in the list to update.");
            if (selected is null) return;

            var updated = _service.UpdateProduct(selected.Id, txtName.Text, numPrice.Value);

            RefreshGrid(selectId: updated.Id);
            SetStatus("Product successfully changed.");
        }

        private void DeleteProduct()
        {
            var selected = GetSelectedProduct("Select a product in the list to delete.");
            if (selected is null) return;

            var answer = MessageBox.Show(
                $"Delete '{selected.Name}' (stock: {selected.StockQuantity})?\n\nThis cannot be undone.",
                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (answer != DialogResult.Yes) return;

            var deleted = _service.DeleteProduct(selected.Id);

            ClearDetails();
            RefreshGrid();
            SetStatus($"Deleted '{deleted.Name}'.");
        }

        private void ChangeStock(bool isStockIn)
        {
            var selected = GetSelectedProduct("Select a product in the list first.");
            if (selected is null) return;

            int quantity = (int)numQuantity.Value;
            var updated = isStockIn
                ? _service.StockIn(selected.Id, quantity)
                : _service.StockOut(selected.Id, quantity);

            RefreshGrid(selectId: updated.Id);
            SetStatus($"{(isStockIn ? "Added" : "Removed")} {quantity}. '{updated.Name}' now has {updated.StockQuantity} in stock.");
        }

        // Runs a button action; business-rule errors are shown to the user instead of crashing the form.
        private void Run(Action action)
        {
            try
            {
                action();
            }
            catch (InventoryException ex)
            {
                MessageBox.Show(ex.Message, "Cannot complete action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error:\n\n" + ex.Message, "Store Inventory System",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------------------------------------------------ grid helpers

        private void RefreshGrid(int? selectId = null)
        {
            int? keepId = selectId ?? GetSelectedProduct(null)?.Id;

            _loading = true;
            try
            {
                IReadOnlyList<Product> products = chkLowOnly.Checked
                    ? _service.GetLowStockProducts()
                    : _service.GetAllProducts();

                gridProducts.DataSource = products.ToList();
                gridProducts.ClearSelection();

                if (keepId.HasValue)
                {
                    foreach (DataGridViewRow row in gridProducts.Rows)
                    {
                        if (row.DataBoundItem is Product p && p.Id == keepId.Value)
                        {
                            row.Selected = true;
                            gridProducts.CurrentCell = row.Cells[1];
                            break;
                        }
                    }
                }

                SetStatus(chkLowOnly.Checked
                    ? $"{products.Count} product(s) at or below their reorder level."
                    : $"{products.Count} product(s).");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load products:\n\n" + ex.Message, "Store Inventory System",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _loading = false;
            }

            FillDetailsFromSelection();
        }

        private void HighlightLowStockRows()
        {
            foreach (DataGridViewRow row in gridProducts.Rows)
            {
                bool low = row.DataBoundItem is Product p && p.StockQuantity <= p.ReorderLevel;
                row.DefaultCellStyle.BackColor = low ? Color.MistyRose : SystemColors.Window;
            }
        }

        private Product? GetSelectedProduct(string? messageIfNone)
        {
            if (gridProducts.SelectedRows.Count > 0 && gridProducts.SelectedRows[0].DataBoundItem is Product product)
                return product;

            if (messageIfNone is not null)
                MessageBox.Show(messageIfNone, "Store Inventory System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }

        private void FillDetailsFromSelection()
        {
            if (_loading) return;

            var selected = GetSelectedProduct(null);
            if (selected is null) return;

            txtName.Text = selected.Name;
            numPrice.Value = Math.Min(selected.Price, numPrice.Maximum);
            numStock.Value = Math.Min(selected.StockQuantity, (int)numStock.Maximum);
            numReorder.Value = Math.Min(selected.ReorderLevel, (int)numReorder.Maximum);
        }

        private void ClearDetails()
        {
            gridProducts.ClearSelection();
            txtName.Clear();
            numPrice.Value = 0;
            numStock.Value = 0;
            numReorder.Value = 10;
            txtName.Focus();
        }

        private void SetStatus(string text) => lblStatus.Text = text;
    }
}
