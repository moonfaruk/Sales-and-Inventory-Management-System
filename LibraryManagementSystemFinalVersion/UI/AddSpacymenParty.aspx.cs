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
    public partial class AddSpacymenParty : System.Web.UI.Page
    {
        SpacymenPartyManager spacymenPartyManager = new SpacymenPartyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<District> districtList = spacymenPartyManager.GetAllDistrictByDropDownList();
                districtNameDropDownList.DataSource = districtList;
                districtNameDropDownList.DataValueField = "DistrictId";
                districtNameDropDownList.DataTextField = "DistrictName";
                districtNameDropDownList.DataBind();

                partyCodeTextBox.Text = LoadNextPartyCode();

                List<SpacymenParty> spacymenPartyList = spacymenPartyManager.GetAllSpacymenPartyList();
                Session["spacymenParty"] = spacymenPartyList;
                Session["active"] = -1;
            }
        }

        //protected void saveButton_Click(object sender, EventArgs e)
        //{
        //    SpacymenParty spacymenParty = new SpacymenParty();
        //    spacymenParty.DistrictName = districtNameDropDownList.SelectedValue;
        //    spacymenParty.PartyCode = partyCodeTextBox.Text;
        //    spacymenParty.PartyName = partyNameTextBox.Text;
        //    spacymenParty.PartyAddress = partyAddressTextArea.InnerText;
        //    spacymenParty.SchoolName = schoolNameTextBox.Text;
        //    if (districtNameDropDownList.Text == "" || partyCodeTextBox.Text == "" || partyNameTextBox.Text == "" ||
        //        partyAddressTextArea.InnerText == "" || schoolNameTextBox.Text == "")
        //    {
        //        message.InnerText = "All Fields are Required!!";
        //    }
        //    else
        //    {
        //        messageLabel.InnerText = spacymenPartyManager.Save(spacymenParty);
        //    }
        //}

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
           
            partyCodeTextBox.Text = "";
            partyNameTextBox.Text = "";
            partyAddressTextArea.InnerText = "";
            schoolNameTextBox.Text = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            SpacymenParty spacymenParty = new SpacymenParty();
            spacymenParty.DistrictName = districtNameDropDownList.SelectedValue;
            spacymenParty.SpacymenPartyCode = partyCodeTextBox.Text;
            spacymenParty.SpacymenPartyName = partyNameTextBox.Text;
            spacymenParty.SpacymenPartyAddress = partyAddressTextArea.InnerText;
            spacymenParty.SchoolName = schoolNameTextBox.Text;
            if (districtNameDropDownList.Text == "" || partyCodeTextBox.Text == "" || partyNameTextBox.Text == "" ||
                partyAddressTextArea.InnerText == "" || schoolNameTextBox.Text == "")
            {
                message.InnerText = "All Fields are Required!!";
            }
            else
            {
                messageLabel.InnerText = spacymenPartyManager.Save(spacymenParty);
            }
        }

        //protected void districtNameDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int id = int.Parse(districtNameDropDownList.SelectedValue);
        //    Party spacymenParty = spacymenPartyManager.GetSpacymenParty(id);
        //    partyCodeTextBox.Text = spacymenParty.PartyCode;
        //    partyNameTextBox.Text = spacymenParty.PartyName;
        //    partyAddressTextArea.InnerText = spacymenParty.PartyAddress;
        //}

        private string LoadNextPartyCode()
        {
            SpacymenParty spacymenParty = spacymenPartyManager.GetNextPartyCode();
            string spCode = spacymenParty.SpacymenPartyCode;
            int c;
            if (spCode == null)
            {
                c = 1;
            }
            else
            {
                c = (spCode[3] - '0')*10 + (spCode[4] - '4') + 1;
            }
            string nextCode = "Spc" + c.ToString("00");
            return nextCode;

        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            SpacymenParty spacymenParty = spacymenPartyManager.GetAllSpacymenParties(0);
            GetValueFromDatabase(spacymenParty);
            Session["active"] = 0;
        }

        private void GetValueFromDatabase(SpacymenParty spacymenParty)
        {
            districtNameDropDownList.Text = spacymenParty.DistrictName;
            partyCodeTextBox.Text = spacymenParty.SpacymenPartyCode;
            partyNameTextBox.Text = spacymenParty.SpacymenPartyName;
            partyAddressTextArea.InnerText = spacymenParty.SpacymenPartyAddress;
            schoolNameTextBox.Text = spacymenParty.SchoolName;
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<SpacymenParty> spacymenPartyList = (List<SpacymenParty>)(Session["spacymenParty"]);
            if (active >= spacymenPartyList.Count)
                active = 0;
            SpacymenParty spacymenParty = spacymenPartyManager.GetAllSpacymenParties(active);
            GetValueFromDatabase(spacymenParty);
            Session["active"] = active;
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active--;
            List<SpacymenParty> spacymenPartyList = (List<SpacymenParty>)(Session["spacymenParty"]);
            if (active <= -1)
                active = spacymenPartyList.Count - 1;
            SpacymenParty spacymenParty = spacymenPartyManager.GetAllSpacymenParties(active);
            GetValueFromDatabase(spacymenParty);
            Session["active"] = active; 
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<SpacymenParty> spacymenPartyList = (List<SpacymenParty>)(Session["spacymenParty"]);
            int x = spacymenPartyList.Count - 1;
            SpacymenParty spacymenParty = spacymenPartyManager.GetAllSpacymenParties(x);
            GetValueFromDatabase(spacymenParty);
            Session["active"] = x;
        }
    }
}