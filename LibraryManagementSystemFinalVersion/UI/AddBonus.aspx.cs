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
    public partial class AddBonus : System.Web.UI.Page
    {
        BonusManager bonusManager = new BonusManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<District> districtList = bonusManager.GetAllDistrictByDropDownList();
                District district = new District();
                district.DistrictId = -1;
                district.DistrictName = "<--Select One Option-->";
                districtList.Insert(0,district);
                districtNameDropDownList.DataSource = districtList;
                districtNameDropDownList.DataValueField = "DistrictId";
                districtNameDropDownList.DataTextField = "DistrictName";
                districtNameDropDownList.DataBind();

                List<Party> partyList = bonusManager.GetAllPartiesByIdDropDownList();
                Party party = new Party();
                party.PartyId = -1;
                party.PartyCode = "<-- Select One Option -->";
                partyList.Insert(0, party);
                partyCodeDropDownList.DataSource = partyList;
                partyCodeDropDownList.DataValueField = "PartyId";
                partyCodeDropDownList.DataTextField = "PartyCode";
                partyCodeDropDownList.DataBind();

                List<Bonus> bonusList = bonusManager.GetAllBonus();
                Session["bonus"] = bonusList;
                Session["active"] = -1;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Bonus bonus = new Bonus();
            bonus.Date = dateTextBox.Value;
            bonus.DistrictId = int.Parse(districtNameDropDownList.SelectedValue);
            bonus.PartyId = int.Parse(partyCodeDropDownList.SelectedValue);
            string amount = amountTextBox.Text;
            if (dateTextBox.Value == "" || amountTextBox.Text == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                bonus.Amount = Convert.ToDouble(amount);
                messageLabel.InnerText = bonusManager.Save(bonus);
            }
            ClearTextBoxes();
        }

        protected void partyCodeDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(partyCodeDropDownList.SelectedValue);
            Party party = bonusManager.GetPartyName(id);
            partyNameTextBox.Text = party.PartyName;
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            dateTextBox.Value = "";
            partyNameTextBox.Text = "";
            amountTextBox.Text = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            Bonus bonus = bonusManager.GetBonus(0);
            GetData(bonus);
            Session["active"] = 0;
        }

        private void GetData(Bonus bonus)
        {
            dateTextBox.Value = bonus.Date;
            districtNameDropDownList.Text = bonus.DistrictName;
            partyCodeDropDownList.SelectedValue = bonus.PartyId.ToString();
            partyNameTextBox.Text = bonus.PartyName;
            amountTextBox.Text = bonus.Amount.ToString();
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<Bonus> bonusList = (List<Bonus>)(Session["bonus"]);
            if (active >= bonusList.Count)
                active = 0;
            Bonus bonus = bonusManager.GetBonus(active);
            GetData(bonus);
            Session["active"] = active;
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active--;
            List<Bonus> bonusList = (List<Bonus>)(Session["bonus"]);
            if (active <= -1)
                active = bonusList.Count - 1;
            Bonus bonus = bonusManager.GetBonus(active);
            GetData(bonus);
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<Bonus> bonusList = (List<Bonus>)(Session["bonus"]);
            int x = bonusList.Count - 1;
            Bonus bonus = bonusManager.GetBonus(x);
            GetData(bonus);
            Session["active"] = x;
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            var d = dTextBox.Value;
            Bonus bonus = bonusManager.GetSearchInfo(d);
            if (bonus.Date == null)
            {
                message.InnerText = "Invalid Date!!";

            }
            else
            {
                GetData(bonus);
                message.InnerText = "";
            }
        }

    }
}