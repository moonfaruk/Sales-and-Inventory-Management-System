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
    public partial class AddBankAccount : System.Web.UI.Page
    {
        BankManager manager = new BankManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllBankInfo();
                bankCodeTextBox.Text = LoadNextBankCode();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (saveButton.Text == "Update")
            {
                BankAccount bankAccount = new BankAccount();
                bankAccount.BankAccountCode = bankCodeTextBox.Text;
                bankAccount.BankAccountName = bankNameTextBox.Text;
                bankAccount.AccountNo = accountNoTextBox.Text;
                bankAccount.BankAccountOpeningBalance = Convert.ToDouble(bankOpeningBalanceTextBox.Text);

                bankAccount.BankAccountId = int.Parse(formWithBankAccountIdHiddenField.Value);
                if (manager.UpdateBankAccount(bankAccount))
                {
                    messageLabel.InnerText = "Updated Successfully!!";
                    saveButton.Text = "Save";
                    ClearTextBoxes();
                }
                else
                {
                    message.InnerText = "No data has been Updated!!";
                }
            }
            else
            {
                InsertBankAccount();
            }
            LoadAllBankInfo();
        }

        private void InsertBankAccount()
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.BankAccountCode = bankCodeTextBox.Text;
            bankAccount.BankAccountName = bankNameTextBox.Text;
            bankAccount.AccountNo = accountNoTextBox.Text;
            string bank = bankOpeningBalanceTextBox.Text;
            if (bankCodeTextBox.Text == "" || bankNameTextBox.Text == "" || accountNoTextBox.Text == "" || bankOpeningBalanceTextBox.Text == "")
            {
                message.InnerText = "All Fields are Required!!";
            }
            else
            {
                bankAccount.BankAccountOpeningBalance = Convert.ToDouble(bank);
                messageLabel.InnerText = manager.Save(bankAccount);
                LoadAllBankInfo();
            }
        }

        protected void clearButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            bankCodeTextBox.Text = "";
            bankNameTextBox.Text = "";
            accountNoTextBox.Text = "";
            bankOpeningBalanceTextBox.Text = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        private string LoadNextBankCode()
        {
            BankAccount bankAccount = manager.GetNextBankCode();
            string bCode = bankAccount.BankAccountCode;
            int c;
            if (bCode == null)
            {
                c = 1;
            }
            else
            {
                c = (bCode[4] - '0')*10 + (bCode[5] - '0') + 1;
            }
            string nextCode = "Bank" + c.ToString("00");
            return nextCode;
        }

        private void LoadAllBankInfo()
        {
            List<BankAccount> bankList = manager.GetAllBankInfo();
            showShopInfoGridView.DataSource = bankList;
            showShopInfoGridView.DataBind();
        }

        protected void updateButton_OnClick(object sender, EventArgs e)
        {
            GridViewRow clickedRow = (GridViewRow) ((LinkButton) sender).Parent.Parent;
            HiddenField bankIdHiddenField = (HiddenField) clickedRow.FindControl("bankAccountIdHiddenField");
            int bankAccountId = int.Parse(bankIdHiddenField.Value);
            BankAccount bankAccount = manager.GetBankAccountById(bankAccountId);
            if (LoadFormWithBankId(bankAccount))
            {
                saveButton.Text = "Update";
            }
        }

        private bool LoadFormWithBankId(BankAccount bankAccount)
        {
            if (bankAccount != null)
            {
                bankCodeTextBox.Text = bankAccount.BankAccountCode;
                bankNameTextBox.Text = bankAccount.BankAccountName;
                accountNoTextBox.Text = bankAccount.AccountNo;
                bankOpeningBalanceTextBox.Text = bankAccount.BankAccountOpeningBalance.ToString();
                formWithBankAccountIdHiddenField.Value = bankAccount.BankAccountId.ToString();
                return true;
            }
            return false;
        }

        protected void deleteButton_OnClick(object sender, EventArgs e)
        {
            GridViewRow deleteRow = (GridViewRow) ((LinkButton) sender).Parent.Parent;
            HiddenField deleteBankId = (HiddenField) deleteRow.FindControl("bankAccountIdHiddenField");
            int dId = int.Parse(deleteBankId.Value);
            if (manager.DeleteBankAccount(dId))
            {
                messageLabel.InnerText = "Deleted Successfully!!";
                ClearTextBoxes();
            }
            else
            {
                message.InnerText = "No data has been Deleted!!";
            }
            LoadAllBankInfo();
        }
    }
}