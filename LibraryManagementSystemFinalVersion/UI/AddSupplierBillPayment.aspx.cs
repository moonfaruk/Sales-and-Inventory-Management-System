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
    public partial class AddSupplierBillPayment : System.Web.UI.Page
    {
        SupplierBillPaymentManager supplierBillPaymentManager = new SupplierBillPaymentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Supplier> sullpierList = supplierBillPaymentManager.GetSupplierInfoByDropDownList();

                Supplier supplier = new Supplier();
                supplier.SupplierId = -1;
                supplier.SupplierName = "<-- Select One Option -->";
                sullpierList.Insert(0, supplier);
                supplierNameDropDownList.DataSource = sullpierList;
                supplierNameDropDownList.DataValueField = "SupplierId";
                supplierNameDropDownList.DataTextField = "SupplierName";
                supplierNameDropDownList.DataBind();

                List<BankAccount> bankList = supplierBillPaymentManager.GetBankInfoByDropDownList();

                BankAccount bankAccount =  new BankAccount();
                bankAccount.BankAccountId = -1;
                bankAccount.BankAccountName = "<-- Select One Option -->";
                bankList.Insert(0, bankAccount);
                bankNameDropDownList.DataSource = bankList;
                bankNameDropDownList.DataValueField = "BankAccountId";
                bankNameDropDownList.DataTextField = "BankAccountName";
                bankNameDropDownList.DataBind();

                billNoTextBox.Text = LoadNextBillNo();

                List<SupplierBillPayment> supplierBillPaymentList = supplierBillPaymentManager.GetAllSupplierBillPaymentList();
                Session["supplierBillPayment"] = supplierBillPaymentList;
                Session["active"] = -1;
                
            }
        }

        private string LoadNextBillNo()
        {
            SupplierBillPayment supplierBillPayment = supplierBillPaymentManager.GetNextBillNo();
            string billNo = supplierBillPayment.BillNo;
            int count;
            if (billNo == null)
            {
                count = 1;
            }
            else
            {
                count = (billNo[4] - '0') * 10 + (billNo[5] - '0') + 1;
            }

            string nextBillNo = "Bi-0" + count.ToString("00");
            return nextBillNo;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            SupplierBillPayment supplierBillPayment = new SupplierBillPayment();
            supplierBillPayment.SupplierDate = dateTextBox.Value;
            supplierBillPayment.BillNo = billNoTextBox.Text;
            supplierBillPayment.SupId = int.Parse(supplierNameDropDownList.SelectedValue);
            supplierBillPayment.PaymentMode = paymentModeDropDownList.SelectedValue;
            supplierBillPayment.BankId = int.Parse(bankNameDropDownList.SelectedValue);
            supplierBillPayment.CheckNo = checkNoTextBox.Text;
            supplierBillPayment.CheckDate = checkDateTextBox.Value;
            string amount = amountTextBox.Text;
            if (dateTextBox.Value == "" || billNoTextBox.Text == "" ||
                paymentModeDropDownList.Text == "" || checkNoTextBox.Text == "" || checkDateTextBox.Value == "" ||
                amountTextBox.Text == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                supplierBillPayment.Amount = Convert.ToDouble(amount);
                messageLabel.InnerText = supplierBillPaymentManager.Save(supplierBillPayment);
            }
            ClearTextBoxes();
        }


        protected void cancelButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            dateTextBox.Value = "";
            billNoTextBox.Text = "";
            paymentModeDropDownList.SelectedValue = "";
            checkNoTextBox.Text = "";
            checkDateTextBox.Value = "";
            amountTextBox.Text = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            SupplierBillPayment supplierBillPayment = supplierBillPaymentManager.GetSupplierBillPayment(0);
            GetData(supplierBillPayment);
            Session["active"] = 0;
        }

        private void GetData(SupplierBillPayment supplierBillPayment)
        {
            dateTextBox.Value = supplierBillPayment.SupplierDate;
            billNoTextBox.Text = supplierBillPayment.BillNo;
            supplierNameDropDownList.Text = supplierBillPayment.SupplierName;
            paymentModeDropDownList.Text = supplierBillPayment.PaymentMode;
            bankNameDropDownList.Text = supplierBillPayment.BankAccountName;
            checkNoTextBox.Text = supplierBillPayment.CheckNo;
            checkDateTextBox.Value = supplierBillPayment.CheckDate;
            amountTextBox.Text = supplierBillPayment.Amount.ToString();
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<SupplierBillPayment> supplierBillPaymentList = (List<SupplierBillPayment>)(Session["supplierBillPayment"]);
            if (active >= supplierBillPaymentList.Count)
                active = 0;
            SupplierBillPayment supplierBillPayment = supplierBillPaymentManager.GetSupplierBillPayment(active);
            GetData(supplierBillPayment);
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<SupplierBillPayment> supplierBillPaymentList = (List<SupplierBillPayment>)(Session["supplierBillPayment"]);
            int x = supplierBillPaymentList.Count - 1;
            SupplierBillPayment supplierBillPayment = supplierBillPaymentManager.GetSupplierBillPayment(x);
            GetData(supplierBillPayment);
            Session["active"] = x;
        }

        protected void slipButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowReport/SupplierBillPaymentReport.aspx");
        }
    }
}