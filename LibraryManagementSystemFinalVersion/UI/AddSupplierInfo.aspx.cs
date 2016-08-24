using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryManagementSystemFinalVersion.BLL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.UI
{
    public partial class AddSupplierInfo : System.Web.UI.Page
    {
        SupplierManager supplierManager = new SupplierManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            supplierCodeTextBox.Text = LoadNextSupplierCode();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            supplier.SupplierCode = supplierCodeTextBox.Text;
            supplier.SupplierName = supplierNameTextBox.Text;
            supplier.SupplierAddress = supplierAddressTextArea.InnerText;
            string supOpeningBalance = supplierOpeningBalanceTextBox.Text;

            if (supplierCodeTextBox.Text == "" || supplierNameTextBox.Text == "" ||
                supplierAddressTextArea.InnerText == "" || supplierOpeningBalanceTextBox.Text =="")
            {
                message.InnerText = "All Fields are Required!!";
            }
            else
            {
                supplier.SupplierOpeningBalance = Convert.ToDouble(supOpeningBalance);
                message.InnerText = supplierManager.Save(supplier);
            }

        }


        private void CancelTextBoxes()
        {
            supplierCodeTextBox.Text = "";
            supplierNameTextBox.Text = "";
            supplierAddressTextArea.InnerText = "";
            supplierOpeningBalanceTextBox.Text = "";
        }
        protected void cancelButton_Click(object sender, EventArgs e)
        {
            CancelTextBoxes();
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        private string LoadNextSupplierCode()
        {
            Supplier sp = supplierManager.GetNextSupplierCode();
            string sCode = sp.SupplierCode;
            int c;
            if (sCode == null)
            {
                c = 1;
            }
            else
            {
                c = (sCode[4] - '0')*10 + (sCode[5] - '0') + 1;
            }
            string nextCode = "Supp" + c.ToString("00");
            return nextCode;
        }
    }
}