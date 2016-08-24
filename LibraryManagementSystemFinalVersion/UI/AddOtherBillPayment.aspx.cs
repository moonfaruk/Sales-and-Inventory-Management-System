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
    public partial class AddOtherBillPayment : System.Web.UI.Page
    {
        OthersBillPaymentManager othersBillPaymentManager = new OthersBillPaymentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<OthersGroup> othersGroupList = othersBillPaymentManager.GetAllGroupByIdDropDownList();
                OthersGroup othersGroup = new OthersGroup();
                othersGroup.OthersGroupId = -1;
                othersGroup.OtherGroupName = "<--Select One Option-->";
                othersGroupList.Insert(0,othersGroup);
                expHeadDropDownList.DataSource = othersGroupList;
                expHeadDropDownList.DataValueField = "OthersGroupId";
                expHeadDropDownList.DataTextField = "OtherGroupName";
                expHeadDropDownList.DataBind();

                List<BankAccount> bankAccountList = othersBillPaymentManager.GetAllBankInfoByIdDropDownList();
                BankAccount bankAccount = new BankAccount();
                bankAccount.BankAccountId = -1;
                bankAccount.BankAccountName = "<--Select One Option-->";
                bankAccountList.Insert(0,bankAccount);
                bankNameDropDownList.DataSource = bankAccountList;
                bankNameDropDownList.DataValueField = "BankAccountId";
                bankNameDropDownList.DataTextField = "BankAccountName";
                bankNameDropDownList.DataBind();

                List<OthersBillPayment> othersBillPaymentList = othersBillPaymentManager.GetAllOthersBillPaymentList();
                Session["othersBill"] = othersBillPaymentList;
                Session["active"] = -1;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            OthersBillPayment othersBillPayment = new OthersBillPayment();
            othersBillPayment.Date = dateTextBox.Value;
            othersBillPayment.OtherGroupId = int.Parse(expHeadDropDownList.SelectedValue);
            othersBillPayment.PaymentMode = paymentModeDropDownList.SelectedValue;
            othersBillPayment.BankId = int.Parse(bankNameDropDownList.SelectedValue);
            othersBillPayment.CheckNo = checkNoTextBox.Text;
            othersBillPayment.CheckDate = checkDateTextBox.Value;
            string amount = amountTextBox.Text;
            othersBillPayment.Remarks = remarksTextArea.InnerText;
            if (dateTextBox.Value == "" || paymentModeDropDownList.Text == "" || checkNoTextBox.Text == "" ||
                checkDateTextBox.Value == "" || amountTextBox.Text == "" || remarksTextArea.InnerText == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                othersBillPayment.Amount = Convert.ToDouble(amount);
                messageLabel.InnerText = othersBillPaymentManager.Save(othersBillPayment);
               
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
            paymentModeDropDownList.Text = "";
            checkNoTextBox.Text = "";
            checkDateTextBox.Value = "";
            amountTextBox.Text = "";
            remarksTextArea.InnerText = "";

        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void slipButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowReport/OthersPaymentReport.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            OthersBillPayment othersBillPayment = othersBillPaymentManager.GetOthesBills(0);
            GetData(othersBillPayment);
            Session["active"] = 0;
        }

        private void GetData(OthersBillPayment othersBillPayment)
        {
            dateTextBox.Value = othersBillPayment.Date;
            expHeadDropDownList.Text = othersBillPayment.OtherGroupName;
            paymentModeDropDownList.Text = othersBillPayment.PaymentMode;
            bankNameDropDownList.Text = othersBillPayment.BankName;
            checkNoTextBox.Text = othersBillPayment.CheckNo;
            checkDateTextBox.Value = othersBillPayment.CheckDate;
            amountTextBox.Text = othersBillPayment.Amount.ToString();
            remarksTextArea.InnerText = othersBillPayment.Remarks;
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<OthersBillPayment> othersBillPaymentList = (List<OthersBillPayment>)(Session["othersBill"]);
            if (active >= othersBillPaymentList.Count)
                active = 0;
            OthersBillPayment othersBillPayment = othersBillPaymentManager.GetOthesBills(active);
            GetData(othersBillPayment);
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<OthersBillPayment> othersBillPaymentList = (List<OthersBillPayment>)(Session["othersBill"]);
            int x = othersBillPaymentList.Count - 1;
            OthersBillPayment othersBillPayment = othersBillPaymentManager.GetOthesBills(x);
            GetData(othersBillPayment);
            Session["active"] = x;
        }
    }
}