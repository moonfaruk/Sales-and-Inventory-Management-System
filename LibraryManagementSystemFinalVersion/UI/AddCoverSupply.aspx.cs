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
    public partial class AddCoverSupply : System.Web.UI.Page
    {
        CoverSupplyManager coverSupplyManager = new CoverSupplyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Binder> binderList = coverSupplyManager.GetAllBinderInfoByDropDownList();
                Binder binder = new Binder();
                binder.BinderId = -1;
                binder.BinderName = "<--Select One Option-->";
                binderList.Insert(0, binder);
                binderNameDropDownList.DataSource = binderList;
                binderNameDropDownList.DataValueField = "BinderId";
                binderNameDropDownList.DataTextField = "BinderName";
                binderNameDropDownList.DataBind();

                List<Group> groupList = coverSupplyManager.GetAllGroupInfoByDropDownList();
                Group group = new Group();
                group.GroupId = -1;
                group.GroupName = "<--Select One Option-->";
                groupList.Insert(0, group);
                groupNameDropDownList.DataSource = groupList;
                groupNameDropDownList.DataValueField = "GroupId";
                groupNameDropDownList.DataTextField = "GroupName";
                groupNameDropDownList.DataBind();

                List<BookInfo> bookInfoList = coverSupplyManager.GetAllBookInfoByDropDownList();
                BookInfo bookInfo = new BookInfo();
                bookInfo.BookInfoId = -1;
                bookInfo.BookName = "<--Select One Option-->";
                bookInfoList.Insert(0, bookInfo);
                bookNameDropDownList.DataSource = bookInfoList;
                bookNameDropDownList.DataValueField = "BookInfoId";
                bookNameDropDownList.DataTextField = "BookName";
                bookNameDropDownList.DataBind();

                supplyNoTextBox.Text = LoadNextSupplyNo();

                List<CoverSupply> coverSupplyList = coverSupplyManager.GetAllCoverSupply();
                Session["coverSupply"] = coverSupplyList;
                Session["active"] = -1;
            }
        }

        private string LoadNextSupplyNo()
        {
            CoverSupply coverSupply = coverSupplyManager.GetNextSupplyNo();
            string supNo = coverSupply.SupplyNo;
            int count;
            if (supNo == null)
            {
                count = 1;
            }
            else
            {
                count = (supNo[6] - '0') * 10 + (supNo[7] - '0') + 1;
            }

            string nextSupplyNo = "Supp-0" + count.ToString("00");
            return nextSupplyNo;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            CoverSupply coverSupply = new CoverSupply();
            coverSupply.Date = dateTextBox.Value;
            coverSupply.SupplyNo = supplyNoTextBox.Text;
            coverSupply.BinderId = int.Parse(binderNameDropDownList.SelectedValue);
            coverSupply.GroupId = int.Parse(groupNameDropDownList.SelectedValue);
            coverSupply.BookId = int.Parse(bookNameDropDownList.SelectedValue);
            string quantity = quantityTextBox.Text;
            if (dateTextBox.Value == "" || supplyNoTextBox.Text == "" || quantityTextBox.Text == "")
            {
                messageLabel.InnerText = "Saved Successfully!!";
            }
            else
            {
                coverSupply.Quantity = Convert.ToDouble(quantity);
                messageLabel.InnerText = coverSupplyManager.Save(coverSupply);
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
            supplyNoTextBox.Text = "";
            quantityTextBox.Text = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            CoverSupply coverSupply = coverSupplyManager.GetSupplier(0);
            GetData(coverSupply);
            Session["active"] = 0;
        }

        private void GetData(CoverSupply coverSupply)
        {
            dateTextBox.Value = coverSupply.Date;
            supplyNoTextBox.Text = coverSupply.SupplyNo;
            binderNameDropDownList.Text = coverSupply.BinderName;
            groupNameDropDownList.Text = coverSupply.GroupName;
            bookNameDropDownList.Text = coverSupply.BookName;
            quantityTextBox.Text = coverSupply.Quantity.ToString();
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<CoverSupply> coverSupplyList = (List<CoverSupply>)(Session["coverSupply"]);
            if (active >= coverSupplyList.Count)
                active = 0;
            CoverSupply coverSupply = coverSupplyManager.GetSupplier(active);
            GetData(coverSupply);
            Session["active"] = active;
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active--;
            List<CoverSupply> coverSupplyList = (List<CoverSupply>)(Session["coverSupply"]);
            if (active <= -1)
                active = coverSupplyList.Count - 1;
            CoverSupply coverSupply = coverSupplyManager.GetSupplier(active);
            GetData(coverSupply);
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<CoverSupply> coverSupplyList = (List<CoverSupply>)(Session["coverSupply"]);
            int x = coverSupplyList.Count - 1;
            CoverSupply coverSupply = coverSupplyManager.GetSupplier(x);
            GetData(coverSupply);
            Session["active"] = x;
        }

        protected void slipButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowReport/CoverSupplyReport.aspx");
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            var r = supplyTextBox.Value;
            CoverSupply coverSupply = coverSupplyManager.GetSearchInfo(r);
            if (coverSupply.SupplyNo == null)
            {
                message.InnerText = "Invalid Supply No!!";

            }
            else
            {
                GetData(coverSupply);
                message.InnerText = "";
            }
        }
    }
}