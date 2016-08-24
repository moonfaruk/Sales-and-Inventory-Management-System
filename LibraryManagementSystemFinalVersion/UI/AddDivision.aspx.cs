using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryManagementSystemFinalVersion.BLL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.UI
{
    public partial class AddDivision : System.Web.UI.Page
    {
        DivisionManager divisionManager = new DivisionManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Division> divisionList = divisionManager.GelAllDivisions();
                Session["division"] = divisionList;
                Session["active"] = -1;


                divisionCodeTextBox.Text = LoadNextDivisionCode();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Division division = new Division(divisionCodeTextBox.Text,divisionNameTextBox.Text);
            if (divisionCodeTextBox.Text == "" || divisionNameTextBox.Text == "")
            {
                message.InnerText = "All Fields are Required!!";
            }
            else
            {
                messageLabel.InnerText = divisionManager.Save(division);
            }
        }

        private void CancelTextBoxes()
        {
            divisionCodeTextBox.Text = "";
            divisionNameTextBox.Text = "";
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            CancelTextBoxes();
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void firstButton_Click1(object sender, EventArgs e)
        {
            Division division = divisionManager.GetDivision(0);
            divisionCodeTextBox.Text = division.DivisionCode;
            divisionNameTextBox.Text = division.DivisionName;
            Session["active"] = 0;
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int) Session["active"];
            active++;
            List<Division> divisions = (List<Division>) (Session["division"]);
            if (active >= divisions.Count)
                active = 0;
            Division division = divisionManager.GetDivision(active);
            divisionCodeTextBox.Text = division.DivisionCode;
            divisionNameTextBox.Text = division.DivisionName;
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<Division> divisions = (List<Division>) (Session["division"]);
            int a = divisions.Count - 1;
            Division division = divisionManager.GetDivision(a);
            divisionCodeTextBox.Text = division.DivisionCode;
            divisionNameTextBox.Text = division.DivisionName;
            Session["active"] = a;
        }

        private string LoadNextDivisionCode()
        {
            Division division = divisionManager.GetNextDivisionCode();
            string code = division.DivisionCode;
            int count;
            if (code == null)
            {
                count = 1;
            }
            else
            {
                count = (code[3] - '0') * 10 + (code[4] - '0') + 1;
            }
             
            string nextCode = "Div" + count.ToString("00");
            return nextCode; 

        }


    }
}