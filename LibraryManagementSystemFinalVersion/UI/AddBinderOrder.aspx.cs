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
    public partial class AddBinderOrder : System.Web.UI.Page
    {
        BinderOrderManager binderOrderManager = new BinderOrderManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Binder> binderList = binderOrderManager.GetAllBinderInfoByDropDownList();
                Binder binder = new Binder();
                binder.BinderId = -1;
                binder.BinderName = "<--Select One Option-->";
                binderList.Insert(0, binder);
                binderNameDropDownList.DataSource = binderList;
                binderNameDropDownList.DataValueField = "BinderId";
                binderNameDropDownList.DataTextField = "BinderName";
                binderNameDropDownList.DataBind();

                List<Group> groupList = binderOrderManager.GetAllGroupInfoByDropDownList();
                Group group = new Group();
                group.GroupId = -1;
                group.GroupCode = "<--Select One Option-->";
                groupList.Insert(0, group);
                groupCodeDropDownList.DataSource = groupList;
                groupCodeDropDownList.DataValueField = "GroupId";
                groupCodeDropDownList.DataTextField = "GroupCode";
                groupCodeDropDownList.DataBind();

                List<BookInfo> bookInfoList = binderOrderManager.GetAllBookInfoByDropDownList();
                BookInfo bookInfo = new BookInfo();
                bookInfo.BookInfoId = -1;
                bookInfo.BookCode = "<--Select One Option-->";
                bookInfoList.Insert(0, bookInfo);
                bookCodeDropDownList.DataSource = bookInfoList;
                bookCodeDropDownList.DataValueField = "BookInfoId";
                bookCodeDropDownList.DataTextField = "BookCode";
                bookCodeDropDownList.DataBind();

                List<Press> pressList = binderOrderManager.GetAllPressInfoByDropDownList();
                Press press = new Press();
                press.PressId = -1;
                press.PressName = "<-- Select One Option -->";
                pressList.Insert(0, press);
                pressNameDropDownList.DataSource = pressList;
                pressNameDropDownList.DataValueField = "PressId";
                pressNameDropDownList.DataTextField = "PressName";
                pressNameDropDownList.DataBind();

                orderNoTextBox.Text = LoadNextOrderNo();

                List<BinderOrder> binderOrderList = binderOrderManager.GetAllBinderOrder();
                Session["binderOrder"] = binderOrderList;
                Session["active"] = -1;
            }
        }
        private string LoadNextOrderNo()
        {
            BinderOrder binderOrder = binderOrderManager.GetNextOrderNo();
            string orderNo = binderOrder.OrderNo;
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
            BinderOrder binderOrder = new BinderOrder();
            binderOrder.Date = dateTextBox.Value;
            binderOrder.Year = yearTextBox.Text;
            binderOrder.OrderNo = orderNoTextBox.Text;
            binderOrder.BinderId = int.Parse(binderNameDropDownList.SelectedValue);
            binderOrder.GroupId = int.Parse(groupCodeDropDownList.SelectedValue);
            binderOrder.BookId = int.Parse(bookCodeDropDownList.SelectedValue);
            string quantity = quantityTextBox.Text;
            string formaQuantity = formaQuantityTextBox.Text;
            binderOrder.PressId = int.Parse(pressNameDropDownList.SelectedValue);
            string forma = formaTextBox.Text;
            if (dateTextBox.Value == "" || yearTextBox.Text == "" || orderNoTextBox.Text == "" ||
                quantityTextBox.Text == "" || formaQuantityTextBox.Text == "" || formaTextBox.Text == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                binderOrder.Quantity = Convert.ToDouble(quantity);
                binderOrder.FormaQuantity = Convert.ToDouble(formaQuantity);
                binderOrder.Forma = Convert.ToDouble(forma);
                messageLabel.InnerText = binderOrderManager.Save(binderOrder);
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
            formaQuantityTextBox.Text = "";
            formaTextBox.Text = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            BinderOrder binderOrder = binderOrderManager.GetBinderOrder(0);
            GetData(binderOrder);
            Session["active"] = 0;
        }

        private void GetData(BinderOrder binderOrder)
        {
            dateTextBox.Value = binderOrder.Date;
            yearTextBox.Text = binderOrder.Year;
            orderNoTextBox.Text = binderOrder.OrderNo;
            binderNameDropDownList.Text = binderOrder.BinderName;
            groupCodeDropDownList.Text = binderOrder.GroupCode;
            bookCodeDropDownList.Text = binderOrder.BookCode;
            quantityTextBox.Text = binderOrder.Quantity.ToString();
            formaQuantityTextBox.Text = binderOrder.FormaQuantity.ToString();
            pressNameDropDownList.Text = binderOrder.PressName;
            formaTextBox.Text = binderOrder.Forma.ToString();
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<BinderOrder> binderOrderList = (List<BinderOrder>)(Session["binderOrder"]);
            if (active >= binderOrderList.Count)
                active = 0;
            BinderOrder binderOrder = binderOrderManager.GetBinderOrder(active);
            GetData(binderOrder);
            Session["active"] = active;
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active--;
            List<BinderOrder> binderOrderList = (List<BinderOrder>)(Session["binderOrder"]);
            if (active <= -1)
                active = binderOrderList.Count - 1;
            BinderOrder binderOrder = binderOrderManager.GetBinderOrder(active);
            GetData(binderOrder);
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<BinderOrder> binderOrderList = (List<BinderOrder>)(Session["binderOrder"]);
            int x = binderOrderList.Count - 1;
            BinderOrder binderOrder = binderOrderManager.GetBinderOrder(x);
            GetData(binderOrder);
            Session["active"] = x;
        }

        protected void slipButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowReport/BinderOrderReport.aspx");
        }
    }
}