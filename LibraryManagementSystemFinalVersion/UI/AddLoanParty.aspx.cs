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
    public partial class AddLoanParty : System.Web.UI.Page
    {
        LoanManager loanManager = new LoanManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            loanCodeTextBox.Text = LoadNextLoanCode();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            LoanParty loanParty = new LoanParty();
            loanParty.LoanCode = int.Parse(loanCodeTextBox.Text);
            loanParty.LoanName = loanNameTextBox.Text;
            loanParty.Remarks = remarksTextArea.InnerText;
            if (loanCodeTextBox.Text == "" || loanNameTextBox.Text == "" || remarksTextArea.InnerText == "")
            {
                message.InnerText = "All Fields are Required!!";
            }
            else
            {
                message.InnerText = loanManager.Save(loanParty);
            }
        }

        private void ClearTextBoxes()
        {
            loanCodeTextBox.Text = "";
            loanNameTextBox.Text = "";
            remarksTextArea.InnerText = "";
        }
        protected void clearButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        private string LoadNextLoanCode()
        {
            LoanParty lp = loanManager.GetNextLoanCode();
            string lpCode = lp.LoanCode.ToString();
            int count;
            if (lpCode == null)
            {
                count = 1;
            }
            else
            {
               // count = (lpCode[0] - '0')*10 + (lpCode[5] - '0') + 1;
                count = (lpCode[0] - '0') + 1;
            }
            string nextCode = "" + count.ToString("0");
            return nextCode;
        }
    }
}