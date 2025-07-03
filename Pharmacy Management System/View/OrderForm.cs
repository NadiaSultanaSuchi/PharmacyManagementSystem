using Pharmacy_Management_System.Controller;
using Pharmacy_Management_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_Management_System.View
{
    public partial class OrderForm : Form
    {
        Login login;
        MedicineController medicineController;

        DataTable odt;
        Medicine medi;

        float grandTotalOrderAmount = 0.00f;

        PrintDocument printDocument;
        PrintPreviewDialog printPreviewDialog;
        public OrderForm(Login login)
        {
            InitializeComponent();
            this.login = login;
            medicineController = new MedicineController();

            numericUpDown1.Enabled = false;
            button2.Enabled = false;
            numericUpDown1.Minimum = 1;
            numericUpDown1.Value = 1;

            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;


            SetupOrderDataGridView();

            LoadAllMedicinesIntoDataGridView();

            UpdateGrandTotalDisplay();

            UpdateChangeDisplay(0.00f);
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            MedicineController mc = new MedicineController();
            dataGridView2.DataSource = mc.GetAllMedicine();
        }
        private void SetupOrderDataGridView()
        {

            odt = new DataTable();
            odt.Columns.Add("MedicineId", typeof(string));
            odt.Columns.Add("Name", typeof(string));
            odt.Columns.Add("ExpiryDate", typeof(string));
            odt.Columns.Add("Price", typeof(float));
            odt.Columns.Add("Quantity", typeof(int));
            odt.Columns.Add("Total Amount", typeof(float));

            dataGridView1.DataSource = odt;

            if (dataGridView1.Columns.Contains("MedicineId"))
            {
                dataGridView1.Columns["MedicineId"].Visible = false;
            }
        }

        private void LoadAllMedicinesIntoDataGridView()
        {
            try
            {
                List<Medicine> allMedicines = medicineController.GetAllMedicine();
                dataGridView2.DataSource = allMedicines;

                if (dataGridView2.Columns.Contains("MedicineId"))
                {
                    dataGridView2.Columns["MedicineId"].Visible = false;
                }
                
                ResetSelectionAndControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading all medicines: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetSelectionAndControls()
        {
            medi = null;
            if (dataGridView2.DataSource != null)
            {
                dataGridView2.ClearSelection();
            }


            if (dataGridView1.DataSource != null && dataGridView1.Rows.Count > 0)
            {
                dataGridView1.ClearSelection();
            }

            numericUpDown1.Value = 1;
            numericUpDown1.Enabled = false;
            button2.Enabled = false;
        }
        private void UpdateGrandTotalDisplay()
        {
            label1.Text = $"Grand Total: {grandTotalOrderAmount:C}";
        }

        private void UpdateChangeDisplay(float change)
        {
            label2.Text = $"Change: {change:C}";
        }

        private void ClearOrderAndResetForm()
        {
            odt.Rows.Clear();

            grandTotalOrderAmount = 0.00f;
            UpdateGrandTotalDisplay();

            textBox1.Text = string.Empty;

            UpdateChangeDisplay(0.00f);

            textBox2.Text = string.Empty;
            LoadAllMedicinesIntoDataGridView();
            ResetSelectionAndControls();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string searchName = textBox1.Text.Trim();

                if (string.IsNullOrEmpty(searchName))
                {
                    MessageBox.Show("Please enter a medicine name to search or leave blank to show all.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllMedicinesIntoDataGridView();
                    return;
                }

                Medicine foundMedicine = medicineController.SearchMedicineByName(searchName);

                if (foundMedicine != null)
                {
                    List<Medicine> searchResults = new List<Medicine> { foundMedicine };
                }
                else
                {
                    dataGridView2.DataSource = null;
                    MessageBox.Show($"Medicine with name '{searchName}' not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ResetSelectionAndControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (medi == null)
            {
                MessageBox.Show("Please select a medicine from the search results first.", "Add Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int quantityToOrder = (int)numericUpDown1.Value;

                if (quantityToOrder <= 0)
                {
                    MessageBox.Show("Quantity must be at least 1.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (quantityToOrder > medi.Quantity)
                {
                    MessageBox.Show($"Cannot order {quantityToOrder} units. Only {medi.Quantity} in stock.", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                float lineItemTotalAmount = medi.Price * quantityToOrder;

                grandTotalOrderAmount += lineItemTotalAmount;

                odt.Rows.Add(
                    medi.MedicineId,
                    medi.Name,
                    medi.ExpiryDate,
                    medi.Price,
                    quantityToOrder,
                    lineItemTotalAmount
                );

                UpdateGrandTotalDisplay();


                MessageBox.Show($"{medi.Name} added to order list!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetSelectionAndControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding medicine to list: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (grandTotalOrderAmount <= 0)
            {
                MessageBox.Show("Please add items to the order first.", "Checkout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter the amount paid.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            try
            {

                float amountPaid = Convert.ToSingle(textBox2.Text);

                if (amountPaid < grandTotalOrderAmount)
                {
                    MessageBox.Show($"Amount paid ({amountPaid:C}) is less than the Grand Total ({grandTotalOrderAmount:C}). Please collect more money.", "Payment Insufficient", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    UpdateChangeDisplay(0.00f);
                    return;
                }


                float change = amountPaid - grandTotalOrderAmount;

                Order newOrder = new Order
                {
                    TotalAmount = grandTotalOrderAmount,
                    PaidAmount = amountPaid,
                    ChangeAmount = change
                };


                UpdateChangeDisplay(change);
                MessageBox.Show($"Transaction successful! Change: {change:C}\nOrder Recorded with details.", "Payment Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearOrderAndResetForm();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid amount entered. Please enter a numeric value for the amount paid.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during checkout: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (grandTotalOrderAmount <= 0 || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please complete an order and enter payment amount before printing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                float amountPaid = Convert.ToSingle(textBox2.Text);
                float change = amountPaid - grandTotalOrderAmount;

                OrderController orderController = new OrderController();
                Order newOrder = new Order
                {
                    TotalAmount = grandTotalOrderAmount,
                    PaidAmount = amountPaid,
                    ChangeAmount = change
                };
                int orderId = orderController.AddOrder(newOrder);

                foreach (DataRow row in odt.Rows)
                {
                    string medicineId = row["MedicineId"].ToString();
                    int quantityOrdered = Convert.ToInt32(row["Quantity"]);

                    medicineController.ReduceQuantity(medicineId, quantityOrdered);
                }

                if (amountPaid < grandTotalOrderAmount)
                {
                    MessageBox.Show("Insufficient payment. Please enter the full amount.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                UpdateChangeDisplay(change);
                MessageBox.Show($"Transaction successful! Change: {change:C}", "Payment Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult printConfirmation = MessageBox.Show("Do you want to print a receipt?", "Print Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (printConfirmation == DialogResult.Yes)
                {
                    printPreviewDialog.ShowDialog();
                }

                ClearOrderAndResetForm();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid numeric amount paid.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerHomeFrame customerHomeFrame = new CustomerHomeFrame(login);
            customerHomeFrame.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                try
                {
                    string medicineId = row.Cells["MedicineId"].Value.ToString();

                    string name = row.Cells["Name"].Value.ToString();
                    string expirydate = row.Cells["ExpiryDate"].Value.ToString();


                    float price = float.Parse(row.Cells["Price"].Value.ToString());
                    int quantity = int.Parse(row.Cells["Quantity"].Value.ToString());

                    medi = new Medicine(medicineId, name, quantity, price, expirydate, "");

                    numericUpDown1.Enabled = true;
                    numericUpDown1.Maximum = medi.Quantity;
                    numericUpDown1.Value = 1;
                    button2.Enabled = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error reading medicine details.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetSelectionAndControls();
                }
            }
            else
            {
                ResetSelectionAndControls();
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 10);
            float y = 20;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;

            e.Graphics.DrawString("Pharmacy Receipt", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, leftMargin, y);
            y += 30;

            e.Graphics.DrawString("Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), font, Brushes.Black, leftMargin, y);
            y += 25;


            y += 20;

            e.Graphics.DrawString("Name", font, Brushes.Black, leftMargin, y);
            e.Graphics.DrawString("Qty", font, Brushes.Black, leftMargin + 200, y);
            e.Graphics.DrawString("Price", font, Brushes.Black, leftMargin + 250, y);
            e.Graphics.DrawString("Total", font, Brushes.Black, leftMargin + 320, y);
            y += 20;


            y += 20;

            foreach (DataRow row in odt.Rows)
            {
                string name = row["Name"].ToString();
                string quantity = row["Quantity"].ToString();
                string price = string.Format("{0:C}", row["Price"]);
                string total = string.Format("{0:C}", row["Total Amount"]);

                e.Graphics.DrawString(name, font, Brushes.Black, leftMargin, y);
                e.Graphics.DrawString(quantity, font, Brushes.Black, leftMargin + 200, y);
                e.Graphics.DrawString(price, font, Brushes.Black, leftMargin + 250, y);
                e.Graphics.DrawString(total, font, Brushes.Black, leftMargin + 320, y);
                y += 20;
            }

            y += 10;

            y += 20;

            e.Graphics.DrawString("Grand Total: " + grandTotalOrderAmount.ToString("C"), font, Brushes.Black, leftMargin, y);
            y += 20;

            float paidAmount;
            float.TryParse(textBox2.Text, out paidAmount);
            float change = paidAmount - grandTotalOrderAmount;

            e.Graphics.DrawString("Paid: " + paidAmount.ToString("C"), font, Brushes.Black, leftMargin, y);
            y += 20;
            e.Graphics.DrawString("Change: " + change.ToString("C"), font, Brushes.Black, leftMargin, y);
            y += 30;

            e.Graphics.DrawString("Thank you for your purchase!", font, Brushes.Black, leftMargin, y);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
