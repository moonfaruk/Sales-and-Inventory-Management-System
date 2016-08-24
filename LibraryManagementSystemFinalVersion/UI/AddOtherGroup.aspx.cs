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
    public partial class AddOtherGroup : System.Web.UI.Page
    {
        OtherGroupManager otherGroupManager = new OtherGroupManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Group> groupList = otherGroupManager.GetAllGroupByDropDownList();
                groupNameDropDownList.DataSource = groupList;
                groupNameDropDownList.DataValueField = "GroupId";
                groupNameDropDownList.DataTextField = "GroupName";
                groupNameDropDownList.DataBind();
                otherGroupCodeTextBox.Text = LoadNextCode();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            OthersGroup othersGroup = new OthersGroup(otherGroupCodeTextBox.Text,otherGroupNameTextBox.Text,otherGroupRemarksTextArea.InnerText,groupNameDropDownList.Text);
            if (otherGroupCodeTextBox.Text == "" || otherGroupNameTextBox.Text == "" ||
                otherGroupRemarksTextArea.InnerText == "" || groupNameDropDownList.SelectedValue == "")
            {
                message.InnerText = "All Fields are Required!!";
            }
            else
            {
                messageLabel.InnerText = otherGroupManager.Save(othersGroup);
                message.InnerText = "";
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            otherGroupCodeTextBox.Text = "";
            otherGroupNameTextBox.Text = "";
            otherGroupRemarksTextArea.InnerText = "";
            
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            OthersGroup otherGroup = otherGroupManager.GetLastGroup();
            otherGroupCodeTextBox.Text = otherGroup.OtherGroupCode;
            otherGroupNameTextBox.Text = otherGroup.OtherGroupName;
            otherGroupRemarksTextArea.InnerText = otherGroup.OtherGroupRemarks;
            groupNameDropDownList.SelectedValue = otherGroup.GroupName;
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            var oGroup = otherGroupTextBox.Value;
            OthersGroup otherGroup = otherGroupManager.GetSearchInfo(oGroup);
            if (otherGroup.OtherGroupCode == null)
            {
                message.InnerText = "Invalid Group Code!!";

            }
            else
            {
                otherGroupCodeTextBox.Text = otherGroup.OtherGroupCode;
                otherGroupNameTextBox.Text = otherGroup.OtherGroupName;
                otherGroupRemarksTextArea.InnerText = otherGroup.OtherGroupRemarks;
                groupNameDropDownList.SelectedValue = otherGroup.GroupName;
                message.InnerText = "";
            }
        }

        private string LoadNextCode()
        {
            OthersGroup othersGroup = otherGroupManager.GetNextCode();
            string otherGCode = othersGroup.OtherGroupCode;
            int c;
            if (otherGCode == null)
            {
                c = 1;
            }
            else
            {
                c = (otherGCode[2] - '0')*10 + (otherGCode[3] - '0') + 1;
            }
            string nextCode = "OG" + c.ToString("00");
            return nextCode;
        }
    }
}