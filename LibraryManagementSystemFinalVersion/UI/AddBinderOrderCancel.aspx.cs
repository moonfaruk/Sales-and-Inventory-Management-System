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
    public partial class AddBinderOrderCancel : System.Web.UI.Page
    {
        BinderOrderCancelManager binderOrderCancelManager = new BinderOrderCancelManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Binder> binderList = binderOrderCancelManager.GetAllBinderInfoByDropDownList();
                Binder binder = new Binder();
                binder.BinderId = -1;
                binder.BinderName = "<--Select One Option-->";
                binderList.Insert(0, binder);
                binderNameDropDownList.DataSource = binderList;
                binderNameDropDownList.DataValueField = "BinderId";
                binderNameDropDownList.DataTextField = "BinderName";
                binderNameDropDownList.DataBind();

                List<Group> groupList = binderOrderCancelManager.GetAllGroupInfoByDropDownList();
                Group group = new Group();
                group.GroupId = -1;
                group.GroupName = "<--Select One Option-->";
                groupList.Insert(0, group);
                groupNameDropDownList.DataSource = groupList;
                groupNameDropDownList.DataValueField = "GroupId";
                groupNameDropDownList.DataTextField = "GroupName";
                groupNameDropDownList.DataBind();

                List<BookInfo> bookInfoList = binderOrderCancelManager.GetAllBookInfoByDropDownList();
                BookInfo bookInfo = new BookInfo();
                bookInfo.BookInfoId = -1;
                bookInfo.BookName = "<--Select One Option-->";
                bookInfoList.Insert(0, bookInfo);
                bookNameDropDownList.DataSource = bookInfoList;
                bookNameDropDownList.DataValueField = "BookInfoId";
                bookNameDropDownList.DataTextField = "BookName";
                bookNameDropDownList.DataBind();

                orderNoTextBox.Text = LoadNextOrderNo();


                List<BinderOrderCancel> binderOrderCancelList = binderOrderCancelManager.GetAllBinderOrderCancel();
                Session["binderOrderCancel"] = binderOrderCancelList;
                Session["active"] = -1;
            }

        }
        private string LoadNextOrderNo()
        {
            BinderOrderCancel bindrOrderCancel = binderOrderCancelManager.GetNextOrderNo();
            string orderNo = bindrOrderCancel.OrderNo;
            int count;
            if (orderNo == null)
            {
                count = 1;
            }
            else
            {
                count = (orderNo[2] - '0') * 10 + (orderNo[3] - '0') + 1;
            }

            string nextOrderNo = "Or" + count.ToString("00");
            return nextOrderNo;
        } 

        protected void saveButton_Click(object sender, EventArgs e)
        {
            BinderOrderCancel binderOrderCancel = new BinderOrderCancel();
            binderOrderCancel.Date = dateTextBox.Value;
            binderOrderCancel.Year = yearTextBox.Text;
            binderOrderCancel.BinderId = int.Parse(binderNameDropDownList.SelectedValue);
            binderOrderCancel.OrderNo = orderNoTextBox.Text;
            binderOrderCancel.GroupId = int.Parse(groupNameDropDownList.SelectedValue);
            binderOrderCancel.BookId = int.Parse(bookNameDropDownList.SelectedValue);
            string quantity = quantityTextBox.Text;
            if (dateTextBox.Value == "" || yearTextBox.Text == "" || orderNoTextBox.Text == "" ||
                quantityTextBox.Text == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                binderOrderCancel.Quantity = Convert.ToDouble(quantity);
                messageLabel.InnerText = binderOrderCancelManager.Save(binderOrderCancel);
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
            yearTextBox.Text = "";
            orderNoTextBox.Text = "";
            quantityTextBox.Text = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            BinderOrderCancel binderOrderCancel = binderOrderCancelManager.GetBinderOrderCancel(0);
            GetData(binderOrderCancel);
            Session["active"] = 0;
        }

        private void GetData(BinderOrderCancel binderOrderCancel)
        {
            dateTextBox.Value = binderOrderCancel.Date;
            yearTextBox.Text = binderOrderCancel.Year;
            binderNameDropDownList.Text = binderOrderCancel.BinderName;
            orderNoTextBox.Text = binderOrderCancel.OrderNo;
            groupNameDropDownList.Text = binderOrderCancel.GroupName;
            bookNameDropDownList.Text = binderOrderCancel.BookName;
            quantityTextBox.Text = binderOrderCancel.Quantity.ToString();
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active--;
            List<BinderOrderCancel> binderOrderCancelList = (List<BinderOrderCancel>)(Session["binderOrderCancel"]);
            if (active <= -1)
                active = binderOrderCancelList.Count - 1;
            BinderOrderCancel binderOrderCancel = binderOrderCancelManager.GetBinderOrderCancel(active);
            GetData(binderOrderCancel);
            Session["active"] = active;
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {

            int active = (int)Session["active"];
            active++;
            List<BinderOrderCancel> binderOrderCancelList = (List<BinderOrderCancel>)(Session["binderOrderCancel"]);
            if (active >= binderOrderCancelList.Count)
                active = 0;
            BinderOrderCancel binderOrderCancel = binderOrderCancelManager.GetBinderOrderCancel(active);
            GetData(binderOrderCancel);
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<BinderOrderCancel> binderOrderCancelList = (List<BinderOrderCancel>)(Session["binderOrderCancel"]);
            int x = binderOrderCancelList.Count - 1;
            BinderOrderCancel binderOrderCancel = binderOrderCancelManager.GetBinderOrderCancel(x);
            GetData(binderOrderCancel);
            Session["active"] = x;
        }
    }
}