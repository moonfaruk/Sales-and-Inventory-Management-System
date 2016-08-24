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
    public partial class AddDistrict : System.Web.UI.Page
    {
        DistrictManager districtManager = new DistrictManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Division> divisionList = districtManager.GetAllDivisionByDropDownList();
                divisionNameDropDownList.DataSource = divisionList;
                divisionNameDropDownList.DataValueField = "DivisionId";
                divisionNameDropDownList.DataTextField = "DivisionName";
                divisionNameDropDownList.DataBind();

                List<District> districtList = districtManager.GetAllDistrict();
                Session["district"] = districtList;
                Session["active"] = -1;

                districtCodeTextBox.Text = LoadNextDistrictCode();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            District district = new District(districtCodeTextBox.Text,districtNameTextBox.Text,divisionNameDropDownList.SelectedValue);
            if (districtCodeTextBox.Text == "" || districtNameTextBox.Text == "" || divisionNameDropDownList.Text == "")
            {
                message.InnerText = "All feilds are required!!";
            }
            else
            {
                messageLabel.InnerText = districtManager.Save(district);
            }
        }

        private void CancelTextBoxes()
        {
            districtCodeTextBox.Text = "";
            districtNameTextBox.Text = "";
            //divisionNameDropDownList.SelectedIndex = -1;
            //divisionNameDropDownList.Items.Clear();
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            CancelTextBoxes();
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
          
            District district = districtManager.GetDistrict(0);
            districtCodeTextBox.Text = district.DistrictCode;
            districtNameTextBox.Text = district.DistrictName;
            divisionNameDropDownList.SelectedValue = district.DivisionName;
            Session["active"] = 0;

        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<District> districtList = (List<District>) (Session["district"]);
            if (active >= districtList.Count)
                active = 0;
            District district = districtManager.GetDistrict(active);
            districtCodeTextBox.Text = district.DistrictCode;
            districtNameTextBox.Text = district.DistrictName;
            divisionNameDropDownList.SelectedValue = district.DivisionName;
            Session["active"] = active;
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active--;
            List<District> districtList = (List<District>)(Session["district"]);
            if (active <= -1 )
                active = districtList.Count-1;
            District district = districtManager.GetDistrict(active);
            districtCodeTextBox.Text = district.DistrictCode;
            districtNameTextBox.Text = district.DistrictName;
            divisionNameDropDownList.SelectedValue = district.DivisionName;
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<District> districtList = (List<District>) Session["district"];
            int x = districtList.Count - 1;
            District district = districtManager.GetDistrict(x);
            districtCodeTextBox.Text = district.DistrictCode;
            districtNameTextBox.Text = district.DistrictName;
            divisionNameDropDownList.SelectedValue = district.DivisionName;
            Session["active"] = x;
        }

        private string LoadNextDistrictCode()
        {
            District district = districtManager.GetNextDistrictCode();
            string code = district.DistrictCode;
            int count;
            if (code == null)
            {
                count = 1;
            }
            else
            {
                count = (code[3] - '0') * 10 + (code[4] - '0') + 1;
            }

            string nextCode = "Dis" + count.ToString("00");
            return nextCode; 
        }

        protected void reportButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowReport/DistrictReport.aspx");
        }
    }
}