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
    public partial class AddBinderReceive : System.Web.UI.Page
    {
        BinderReceiveManager binderReceiveManager = new BinderReceiveManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Binder> binderList = binderReceiveManager.GetAllBinderInfoByDropDownList();
                Binder binder = new Binder();
                binder.BinderId = -1;
                binder.BinderName = "<--Select One Option-->";
                binderList.Insert(0, binder);
                binderNameDropDownList.DataSource = binderList;
                binderNameDropDownList.DataValueField = "BinderId";
                binderNameDropDownList.DataTextField = "BinderName";
                binderNameDropDownList.DataBind();

                List<Group> groupList = binderReceiveManager.GetAllGroupInfoByDropDownList();
                Group group = new Group();
                group.GroupId = -1;
                group.GroupName = "<--Select One Option-->";
                groupList.Insert(0, group);
                groupNameDropDownList.DataSource = groupList;
                groupNameDropDownList.DataValueField = "GroupId";
                groupNameDropDownList.DataTextField = "GroupName";
                groupNameDropDownList.DataBind();

                List<BookInfo> bookInfoList = binderReceiveManager.GetAllBookInfoByDropDownList();
                BookInfo bookInfo = new BookInfo();
                bookInfo.BookInfoId = -1;
                bookInfo.BookName = "<--Select One Option-->";
                bookInfoList.Insert(0, bookInfo);
                bookNameDropDownList.DataSource = bookInfoList;
                bookNameDropDownList.DataValueField = "BookInfoId";
                bookNameDropDownList.DataTextField = "BookName";
                bookNameDropDownList.DataBind();

                receiveNoTextBox.Text = LoadNextReceiveNo();

                List<BinderReceive> binderReceiveList = binderReceiveManager.GetAllBinderReceive();
                Session["binderReceive"] = binderReceiveList;
                Session["active"] = -1;
            }
        }

        private string LoadNextReceiveNo()
        {
            BinderReceive binderReceive = binderReceiveManager.GetNextReceiveNo();
            string recvNo = binderReceive.ReceiveNo;
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
            BinderReceive binderReceive = new BinderReceive();
            binderReceive.Date = dateTextBox.Value;
            binderReceive.ReceiveNo = receiveNoTextBox.Text;
            binderReceive.BinderId = int.Parse(binderNameDropDownList.SelectedValue);
            binderReceive.OrderNo = orderNoTextBox.Text;
            binderReceive.ChallanNo = challanNoTextBox.Text;
            binderReceive.Year = yearTextBox.Text;
            binderReceive.GroupId = int.Parse(groupNameDropDownList.SelectedValue);
            binderReceive.BookId = int.Parse(bookNameDropDownList.SelectedValue);
            string quantity = quantityTextBox.Text;
            if (dateTextBox.Value == "" || receiveNoTextBox.Text == "" || orderNoTextBox.Text == "" ||
                challanNoTextBox.Text == "" || yearTextBox.Text == "" || quantityTextBox.Text == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                binderReceive.Quantity = Convert.ToDouble(quantity);
                messageLabel.InnerText = binderReceiveManager.Save(binderReceive);
                
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
            receiveNoTextBox.Text = "";
            orderNoTextBox.Text = "";
            challanNoTextBox.Text = "";
            yearTextBox.Text = "";
            quantityTextBox.Text = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            BinderReceive binderReceive = binderReceiveManager.GetBinderReceive(0);
            GetData(binderReceive);
            Session["active"] = 0;
        }

        private void GetData(BinderReceive binderReceive)
        {
            dateTextBox.Value = binderReceive.Date;
            receiveNoTextBox.Text = binderReceive.ReceiveNo;
            binderNameDropDownList.Text = binderReceive.BinderName;
            orderNoTextBox.Text = binderReceive.OrderNo;
            challanNoTextBox.Text = binderReceive.ChallanNo;
            yearTextBox.Text = binderReceive.Year;
            groupNameDropDownList.Text = binderReceive.GroupName;
            bookNameDropDownList.Text = binderReceive.BookName;
            quantityTextBox.Text = binderReceive.Quantity.ToString();
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<BinderReceive> binderReceiveList = (List<BinderReceive>)(Session["binderReceive"]);
            if (active >= binderReceiveList.Count)
                active = 0;
            BinderReceive binderReceive = binderReceiveManager.GetBinderReceive(active);
            GetData(binderReceive);
            Session["active"] = active;
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active--;
            List<BinderReceive> binderReceiveList = (List<BinderReceive>)(Session["binderReceive"]);
            if (active <= -1)
                active = binderReceiveList.Count - 1;
            BinderReceive binderReceive = binderReceiveManager.GetBinderReceive(active);
            GetData(binderReceive);
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<BinderReceive> binderReceiveList = (List<BinderReceive>)(Session["binderReceive"]);
            int x = binderReceiveList.Count - 1;
            BinderReceive binderReceive = binderReceiveManager.GetBinderReceive(x);
            GetData(binderReceive);
            Session["active"] = x;
        }

        protected void slipButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowReport/BinderReceiveReport.aspx");
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            var r = recvTextBox.Value;
            BinderReceive binderReceive = binderReceiveManager.GetSearchInfo(r);
            if (binderReceive.ReceiveNo == null)
            {
                message.InnerText = "Invalid Receive No!!";

            }
            else
            {
                GetData(binderReceive);
                message.InnerText = "";
            }
        }
    }
}