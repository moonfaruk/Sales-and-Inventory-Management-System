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
    public partial class AddpressInfo : System.Web.UI.Page
    {
        PressManager pressManager = new PressManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            pressCodeTextBox.Text = LoanNextPressCode();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Press press = new Press();
            press.PressCode = pressCodeTextBox.Text;
            press.PressName = pressNameTextBox.Text;
            press.PressAddress = pressAddressTextArea.InnerText;
            string POpeningBalance = pressOpeningBalanceTextBox.Text;
            if (pressCodeTextBox.Text == "" || pressNameTextBox.Text == "" || pressAddressTextArea.InnerText == "" ||
                pressOpeningBalanceTextBox.Text == "")
            {
                message.InnerText = "All Fields are Required!!";
            }
            else
            {
                press.PressOpeningBalance = Convert.ToDouble(POpeningBalance);
                message.InnerText = pressManager.Save(press);
            }
        }

        private void CancelTextBoxes()
        {
            pressCodeTextBox.Text = "";
            pressNameTextBox.Text = "";
            pressAddressTextArea.InnerText = "";
            pressOpeningBalanceTextBox.Text = "";
        }
        protected void cancelButton_Click(object sender, EventArgs e)
        {
            CancelTextBoxes();
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        private string LoanNextPressCode()
        {
            Press p = pressManager.GetNextPressCode();
            string prCode = p.PressCode;
            int c;
            if (prCode == null)
            {
                c = 1;
            }
            else
            {
                c = (prCode[2] - '0')*10 + (prCode[3] - '0') + 1;
            }
            string nextCode = "Pr" + c.ToString("00");
            return nextCode;
        }
    }
}