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
    public partial class AddBankWithdraw : System.Web.UI.Page
    {
        BankWithdrawManager bankWithdrawManager = new BankWithdrawManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<BankAccount> bankAccountList = bankWithdrawManager.GetAllBankInfoByDropDownList();
                BankAccount bankAccount = new BankAccount();
                bankAccount.BankAccountId = -1;
                bankAccount.BankAccountName = "<--Select One Option-->";
                bankAccountList.Insert(0, bankAccount);
                bankNameDropDownList.DataSource = bankAccountList;
                bankNameDropDownList.DataValueField = "BankAccountId";
                bankNameDropDownList.DataTextField = "BankAccountName";
                bankNameDropDownList.DataBind();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            BankWithdraw bankWithdraw = new BankWithdraw();
            bankWithdraw.Date = bankDateTextBox.Value;
            bankWithdraw.BankId = int.Parse(bankNameDropDownList.SelectedValue);
            bankWithdraw.CheckNo = checkNoTextBox.Text;
            bankWithdraw.WithdrawBy = withdrawByTextBox.Text;
            string amount = amountTextBox.Text;
            if (bankDateTextBox.Value == "" || accountNoTextBox.Text == "" || checkNoTextBox.Text == "" ||
                withdrawByTextBox.Text == "" || amountTextBox.Text == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                bankWithdraw.Amount = Convert.ToDouble(amount);
                messageLabel.InnerText = bankWithdrawManager.Save(bankWithdraw);
            }
            ClearTextBoxes();
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            bankDateTextBox.Value = "";
            accountNoTextBox.Text = "";
            checkNoTextBox.Text = "";
            withdrawByTextBox.Text = "";
            amountTextBox.Text = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            BankWithdraw bankWithdraw = bankWithdrawManager.GetLastBankWithdrawInfo();
            bankDateTextBox.Value = bankWithdraw.Date;
            bankNameDropDownList.Text = bankWithdraw.BankName;
            int id = int.Parse(bankWithdraw.AccountNo);
            BankAccount acountNo = bankWithdrawManager.GetAccountNo(id);
            accountNoTextBox.Text = acountNo.AccountNo;
            checkNoTextBox.Text = bankWithdraw.CheckNo;
            withdrawByTextBox.Text = bankWithdraw.WithdrawBy;
            amountTextBox.Text = bankWithdraw.Amount.ToString();
        }

        protected void bankNameDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(bankNameDropDownList.SelectedValue);
            BankAccount bankAccount = bankWithdrawManager.GetBank(id);
            accountNoTextBox.Text = bankAccount.AccountNo;
        }
    }
}