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
    public partial class AddCoverReceived : System.Web.UI.Page
    {
        CoverReceivedManager coverReceivedManager = new CoverReceivedManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Group> groupList = coverReceivedManager.GetAllGroupInfoByDropDownList();
                Group group = new Group();
                group.GroupId = -1;
                group.GroupName = "<--Select One Option-->";
                groupList.Insert(0, group);
                groupNameDropDownList.DataSource = groupList;
                groupNameDropDownList.DataValueField = "GroupId";
                groupNameDropDownList.DataTextField = "GroupName";
                groupNameDropDownList.DataBind();

                List<BookInfo> bookInfoList = coverReceivedManager.GetAllBookInfoByDropDownList();
                BookInfo bookInfo = new BookInfo();
                bookInfo.BookInfoId = -1;
                bookInfo.BookName = "<--Select One Option-->";
                bookInfoList.Insert(0, bookInfo);
                bookNameDropDownList.DataSource = bookInfoList;
                bookNameDropDownList.DataValueField = "BookInfoId";
                bookNameDropDownList.DataTextField = "BookName";
                bookNameDropDownList.DataBind();

                recvNoTextBox.Text = LoadNextRecvNo();

                List<CoverReceived> coverReceivedList = coverReceivedManager.GetAllCoverReceived();
                Session["coverReceived"] = coverReceivedList;
                Session["active"] = -1;

            }

        }

        private string LoadNextRecvNo()
        {
            CoverReceived coverReceived = coverReceivedManager.GetNextReceiveNo();
            string recvNo = coverReceived.RecNo;
            int count;
            if (recvNo == null)
            {
                count = 1;
            }
            else
            {
                count = (recvNo[4] - '0') * 10 + (recvNo[5] - '0') + 1;
            }

            string nextRecvNo = "Rc-0" + count.ToString("00");
            return nextRecvNo;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            CoverReceived coverReceived = new CoverReceived();
            coverReceived.Date = dateTextBox.Value;
            coverReceived.RecNo = recvNoTextBox.Text;
            coverReceived.Year = yearTextBox.Text;
            coverReceived.GroupId = int.Parse(groupNameDropDownList.SelectedValue);
            coverReceived.BookId = int.Parse(bookNameDropDownList.SelectedValue);
            string quantity = quantityTextBox.Text;
            if (dateTextBox.Value == "" || recvNoTextBox.Text == "" || yearTextBox.Text == "" ||
                quantityTextBox.Text == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                coverReceived.Quantity = Convert.ToDouble(quantity);
                messageLabel.InnerText = coverReceivedManager.Save(coverReceived);
            }
            ClearTextBoxes();
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            dateTextBox.Value = "";
            recvNoTextBox.Text = "";
            yearTextBox.Text = "";
            quantityTextBox.Text = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            CoverReceived coverReceived = coverReceivedManager.GetCovers(0);
            GetValue(coverReceived);
            Session["active"] = 0;
        }

        private void GetValue(CoverReceived coverReceived)
        {
            dateTextBox.Value = coverReceived.Date;
            recvNoTextBox.Text = coverReceived.RecNo;
            yearTextBox.Text = coverReceived.Year;
            groupNameDropDownList.Text = coverReceived.GroupName;
            bookNameDropDownList.Text = coverReceived.BookName;
            quantityTextBox.Text = coverReceived.Quantity.ToString();
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<CoverReceived> coverReceivedList = (List<CoverReceived>)(Session["coverReceived"]);
            if (active >= coverReceivedList.Count)
                active = 0;
            CoverReceived coverReceived = coverReceivedManager.GetCovers(active);
            GetValue(coverReceived);
            Session["active"] = active;
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active--;
            List<CoverReceived> coverReceivedList = (List<CoverReceived>)(Session["coverReceived"]);
            if (active <= -1)
                active = coverReceivedList.Count - 1;
            CoverReceived coverReceived = coverReceivedManager.GetCovers(active);
            GetValue(coverReceived);
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<CoverReceived> coverReceivedList = (List<CoverReceived>)(Session["coverReceived"]);
            int x = coverReceivedList.Count - 1;
            CoverReceived coverReceived = coverReceivedManager.GetCovers(x);
            GetValue(coverReceived);
            Session["active"] = x;
        }

        protected void slipButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowReport/CoverReceivedReport.aspx");
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            var r = recvTextBox.Value;
            CoverReceived coverReceived = coverReceivedManager.GetSearchInfo(r);
            if (coverReceived.RecNo == null)
            {
                message.InnerText = "Invalid Receive No!!";

            }
            else
            {
                GetValue(coverReceived);
                message.InnerText = "";
            }
        }
    }
}