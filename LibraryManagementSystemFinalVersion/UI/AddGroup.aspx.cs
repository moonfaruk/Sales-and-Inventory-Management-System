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
    public partial class AddGroup : System.Web.UI.Page
    {
        GroupManager groupManager = new GroupManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                groupCodeTextBox.Text = LoadNextCode();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Group group = new Group(groupCodeTextBox.Text,groupNameTextBox.Text);
            if (groupCodeTextBox.Text == "" || groupNameTextBox.Text == "")
            {
                message.InnerText = "All Fields are Required!!";
            }
            else
            {
                messageLabel.InnerText = groupManager.Save(group);
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            groupCodeTextBox.Text = "";
            groupNameTextBox.Text = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            Group group  = groupManager.GetLastGroup();
            groupCodeTextBox.Text = group.GroupCode;
            groupNameTextBox.Text = group.GroupName;
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            var g = gTextBox.Value;
            Group group = groupManager.GetSearchInfo(g);
            if (group.GroupCode == null)
            {
                message.InnerText = "Invalid Group Code!!";

            }
            else
            {
                groupCodeTextBox.Text = group.GroupCode;
                groupNameTextBox.Text = group.GroupName;
                message.InnerText = "";
            }
        }

        private string LoadNextCode()
        {
            Group g = groupManager.GetNextGroupCode();
            string gCode = g.GroupCode;
            int c;
            if (gCode == null)
            {
                c = 1;
            }
            else
            {
                c =  (gCode[3] - '0')*10 + (gCode[4] - '0') + 1;
            }
            string nextCode = "Grp" + c.ToString("00");
            return nextCode;
        }
    }
}