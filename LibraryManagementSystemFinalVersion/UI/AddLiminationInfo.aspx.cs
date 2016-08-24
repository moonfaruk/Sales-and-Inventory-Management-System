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
    public partial class AddLiminationInfo : System.Web.UI.Page
    {
        PPLiminationManager ppLiminationManager = new PPLiminationManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ppLiminationCodeTextBox.Text = LoadNextppLiminationCode();
                List<PPLimination> ppLiminationList = ppLiminationManager.GetAllPpLiminationInfo();
                Session["liminations"] = ppLiminationList;
                Session["active"] = 0;
            }
           
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            PPLimination ppLimination = new PPLimination();
            ppLimination.PPLiminationCode = ppLiminationCodeTextBox.Text;
            ppLimination.PPLiminationName = ppLiminationNameTextBox.Text;
            ppLimination.PPLiminationAddress = ppLiminationAddressTextArea.InnerText;
            string PPOpeningBalance = ppLiminationOpeningBalanceTextBox.Text;
            if (ppLiminationCodeTextBox.Text == "" || ppLiminationNameTextBox.Text == "" ||
                ppLiminationAddressTextArea.InnerText == "" || ppLiminationOpeningBalanceTextBox.Text == "")
            {
                message.InnerText = "All Fields are Required!!";
            }
            else
            {
                ppLimination.PPLiminationOpeningBalance = Convert.ToDouble(PPOpeningBalance);
                message.InnerText = ppLiminationManager.Save(ppLimination);
            }
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        private void ClearTextBoxes()
        {
            ppLiminationCodeTextBox.Text = "";
            ppLiminationNameTextBox.Text = "";
            ppLiminationAddressTextArea.InnerText = "";
            ppLiminationOpeningBalanceTextBox.Text = "";
        }
        protected void clearButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private string LoadNextppLiminationCode()
        {
            PPLimination ppl = ppLiminationManager.GetNextPPLiminationCode();
            string pplCode = ppl.PPLiminationCode;
            int count;
            if (pplCode == null)
            {
                count = 1;
            }
            else
            {
                count = (pplCode[3] - '0')*10 + (pplCode[4] - '0') + 1;
            }
            string nextCode = "PPL" + count.ToString("00");
            return nextCode;
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            List<PPLimination> ppLiminationList = (List<PPLimination>)(Session["liminations"]);
            if (active == ppLiminationList.Count)
                active = 0;
            PPLimination ppl = ppLiminationManager.GetPpLiminations(active);
            ppLiminationCodeTextBox.Text = ppl.PPLiminationCode;
            ppLiminationNameTextBox.Text = ppl.PPLiminationName;
            ppLiminationAddressTextArea.InnerText = ppl.PPLiminationAddress;
            ppLiminationOpeningBalanceTextBox.Text = ppl.PPLiminationOpeningBalance.ToString();
            active++;
            Session["active"] = active;
        }

    }
}