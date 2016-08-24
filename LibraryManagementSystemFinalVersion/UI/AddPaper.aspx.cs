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
    public partial class AddPaper : System.Web.UI.Page
    {
        PaperManager paperManager = new PaperManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            paperCodeTextBox.Text = LoadNextPaperCode();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Paper paper= new Paper(paperCodeTextBox.Text,paperNameTextBox.Text);
            if (paperCodeTextBox.Text == "" || paperNameTextBox.Text == "")
            {
                message.InnerText = "All Fields are Required!!";

            }
            else
            {
                message.InnerText = paperManager.Save(paper);
            }
        }

        private void CancelTextBoxes()
        {
            paperCodeTextBox.Text = "";
            paperNameTextBox.Text = "";
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            CancelTextBoxes();
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        private string LoadNextPaperCode()
        {
            Paper p = paperManager.GetNextPaperCode();
            string pCode = p.PaperCode;
            int c;
            if (pCode == null)
            {
                c = 1;
            }
            else
            {
                c = (pCode[1] - '0')*10 + (pCode[2] - '0') + 1;
            }
            string nextCode = "P" + c.ToString("00");
            return nextCode;
        }

        protected void reportButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowReport/Emp_Party_BankReport.aspx");
        }
    }
}