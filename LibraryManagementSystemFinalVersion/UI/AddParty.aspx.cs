using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using LibraryManagementSystemFinalVersion.BLL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.UI
{
    public partial class AddParty : System.Web.UI.Page
    {
        PartyManager partyManager = new PartyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                

                List<District> districtList = partyManager.GetAllDistrictByDropDownList();
                districtNameDropDownList.DataSource = districtList;
                districtNameDropDownList.DataValueField = "DivisionId";
                districtNameDropDownList.DataTextField = "DistrictName";
                districtNameDropDownList.DataBind();

                partyCodeTextBox.Text = LoadNextPartyCode();

                List<Party> partyList = partyManager.GetAllPartyInfo();
                Session["parties"] = partyList;
                Session["active"] = -1;

            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Party party = new Party();
            party.DistrictName = districtNameDropDownList.SelectedValue;
            party.PartyCode = partyCodeTextBox.Text;
            party.PartyName = partyNameTextBox.Text;
            party.PartyPropiter = propitorTextBox.Text;
            party.PartyAddress = partyAddressTextArea.InnerText;
            party.PartyPhone = phoneTextBox.Text;
            party.PartyEmail = emailTextBox.Text;
            party.PartyWeb = webTextBox.Text;
            string pOneningBalance = openingBalanceTextBox.Text;
            party.PartyDate = Request.Form["partyDateTextBox"];

            if ( districtNameDropDownList.Text == "" ||
                partyCodeTextBox.Text == "" || partyNameTextBox.Text == "" || propitorTextBox.Text == "" ||
                partyAddressTextArea.InnerText == "" || phoneTextBox.Text == "" || emailTextBox.Text == "" ||
                webTextBox.Text == "" || openingBalanceTextBox.Text == "")
            {
                message.InnerText = "All Fields are Required!!";
            }
            else
            {
                party.PartyOpeningBalance = Convert.ToDouble(pOneningBalance);
                messageLabel.InnerText = partyManager.Insert(party);
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            partyCodeTextBox.Text = "";
            partyNameTextBox.Text = "";
            propitorTextBox.Text = "";
            partyAddressTextArea.InnerText = "";
            phoneTextBox.Text = "";
            emailTextBox.Text = "";
            webTextBox.Text = "";
            openingBalanceTextBox.Text = "";
            
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        private string LoadNextPartyCode()
        {
            Party party = partyManager.GetNextPartyCode();
            string pId = party.PartyCode;
            int c;
            if (pId == null)
            {
                c = 1;
            }
            else
            {
                c = (pId[2] - '0')*10 + (pId[3] - '0') + 1;
            }
            string nextCode = "Pa" + c.ToString("00");
            return nextCode;
        }

        private void GetAllPartyProperty(Party party)
        {
            District dis = partyManager.GetDistrict(party.DistrictId);
            //Division div = partyManager.GetDivision(dis.DivisionId);
            divisionNameTextBox.Text = dis.DivisionName;
            districtNameDropDownList.SelectedValue = party.DistrictName;
            partyCodeTextBox.Text = party.PartyCode;
            partyNameTextBox.Text = party.PartyName;
            propitorTextBox.Text = party.PartyPropiter;
            partyAddressTextArea.InnerText = party.PartyAddress;
            phoneTextBox.Text = party.PartyPhone;
            emailTextBox.Text = party.PartyEmail;
            webTextBox.Text = party.PartyWeb;
            openingBalanceTextBox.Text = party.PartyOpeningBalance.ToString();
            partyDateTextBox.Value = party.PartyDate;

        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            Party party = partyManager.GetParties(0);
            GetAllPartyProperty(party);
            Session["active"] = 0;
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<Party> partyList = (List<Party>)(Session["parties"]);
            if (active >= partyList.Count)
                active = 0;
            Party party = partyManager.GetParties(active);
            GetAllPartyProperty(party);
            
            Session["active"] = active;
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active--;
            List<Party> partyList = (List<Party>)(Session["parties"]);
            if (active <= -1)
                active = partyList.Count -1;
            Party party = partyManager.GetParties(active);
            GetAllPartyProperty(party);
            
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<Party> partyList = (List<Party>) Session["parties"];
            int x = partyList.Count - 1;
            Party party = partyManager.GetParties(x);
            GetAllPartyProperty(party);
            Session["active"] = x;
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            var p = pTextBox.Value;
            Party party = partyManager.GetSearchInfo(p);
            if (party.PartyCode == null)
            {
                message.InnerText = "Invalid Party Code!!";

            }
            else
            {
                GetAllPartyProperty(party);
                message.InnerText = "";
            }

        }

        protected void districtNameDropDownList_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int id = int.Parse(districtNameDropDownList.SelectedValue);
            Division division = partyManager.GetDivision(id);
            divisionNameTextBox.Text = division.DivisionName;

            //District district = partyManager.GetDistrict(id);
            //divisionNameTextBox.Text = district.DivisionName;
        }
    }
}