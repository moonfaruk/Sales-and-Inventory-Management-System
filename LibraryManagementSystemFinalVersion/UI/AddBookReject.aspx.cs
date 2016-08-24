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
    public partial class AddBookReject : System.Web.UI.Page
    {
        BookRejectManager bookRejectManager = new BookRejectManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<District> districtList = bookRejectManager.GetAllDistrictByDropDownList();
                District district = new District();
                district.DistrictId = -1;
                district.DistrictName = "<--Select One Option-->";
                districtList.Insert(0, district);
                districtNameDropDownList.DataSource = districtList;
                districtNameDropDownList.DataValueField = "DistrictId";
                districtNameDropDownList.DataTextField = "DistrictName";
                districtNameDropDownList.DataBind();

                List<Party> partyList = bookRejectManager.GetAllPartiesByIdDropDownList();
                Party party = new Party();
                party.PartyId = -1;
                party.PartyName = "<-- Select One Option -->";
                partyList.Insert(0, party);
                partyNameDropDownList.DataSource = partyList;
                partyNameDropDownList.DataValueField = "PartyId";
                partyNameDropDownList.DataTextField = "PartyName";
                partyNameDropDownList.DataBind();

                List<Group> groupList = bookRejectManager.GetAllGroupInfoByDropDownList();
                Group group = new Group();
                group.GroupId = -1;
                group.GroupName = "<--Select One Option-->";
                groupList.Insert(0, group);
                groupNameDropDownList.DataSource = groupList;
                groupNameDropDownList.DataValueField = "GroupId";
                groupNameDropDownList.DataTextField = "GroupName";
                groupNameDropDownList.DataBind();

                List<BookInfo> bookInfoList = bookRejectManager.GetAllBookInfoByDropDownList();
                BookInfo bookInfo = new BookInfo();
                bookInfo.BookInfoId = -1;
                bookInfo.BookName = "<--Select One Option-->";
                bookInfoList.Insert(0, bookInfo);
                bookNameDropDownList.DataSource = bookInfoList;
                bookNameDropDownList.DataValueField = "BookInfoId";
                bookNameDropDownList.DataTextField = "BookName";
                bookNameDropDownList.DataBind();

                rejectNoTextBox.Text = LoadNextRejectNo();
                List<BookReject> bookRejectList = bookRejectManager.GetAllBookRejectList();
                Session["bookReject"] = bookRejectList;
                Session["active"] = -1;
            }
        }

        private string LoadNextRejectNo()
        {
            BookReject bookReject = bookRejectManager.GetNextRejectNo();
            string rejectNo = bookReject.RejectNo;
            int count;
            if (rejectNo == null)
            {
                count = 1;
            }
            else
            {
                count = (rejectNo[4] - '0') * 10 + (rejectNo[5] - '0') + 1;
            }

            string nextRejectNo = "Rj-0" + count.ToString("00");
            return nextRejectNo;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            BookReject bookReject = new BookReject();
            bookReject.Date = dateTextBox.Value;
            bookReject.DistrictId = int.Parse(districtNameDropDownList.SelectedValue);
            bookReject.PartyId = int.Parse(partyNameDropDownList.SelectedValue);
            bookReject.RejectNo = rejectNoTextBox.Text;
            bookReject.Year = yearTextBox.Text;
            bookReject.GroupId = int.Parse(groupNameDropDownList.SelectedValue);
            bookReject.BookId = int.Parse(bookNameDropDownList.SelectedValue);
            string quantity = quantityTextBox.Text;
            string rejectRate = rejectRateTextBox.Text;
            string total = totalTextBox.Text;
            if (dateTextBox.Value == "" || rejectNoTextBox.Text == "" || yearTextBox.Text == "" ||
                quantityTextBox.Text == "" || rejectRateTextBox.Text == "" || totalTextBox.Text == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                bookReject.Quantity = Convert.ToDouble(quantity);
                bookReject.RejectRate = Convert.ToDouble(rejectRate);
                bookReject.Total = Convert.ToDouble(total);
                messageLabel.InnerText = bookRejectManager.Save(bookReject);
            }
            ClearTextBoxes();
        }

        protected void bookNameDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(bookNameDropDownList.SelectedValue);
            BookInfo bookInfo = bookRejectManager.GetRejectBook(id);
            bookRateTextBox.Text = bookInfo.BookRate.ToString();
            commissionTextBox.Text = bookInfo.BookCommission.ToString();
            double rate = Convert.ToDouble(bookRateTextBox.Text);
            double commission = Convert.ToDouble(commissionTextBox.Text);
            string result = ((rate*commission)/100).ToString();
            rejectRateTextBox.Text = result;
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            dateTextBox.Value = "";
            rejectNoTextBox.Text = "";
            quantityTextBox.Text = "";
            yearTextBox.Text = "";
            bookRateTextBox.Text = "";
            rejectRateTextBox.Text = "";
            totalTextBox.Text = "";
            rejectTextBox.Value = "";
            commissionTextBox.Text = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            BookReject bookReject = bookRejectManager.GetBookReject(0);
            GetData(bookReject);
            Session["active"] = 0;
        }

        private void GetData(BookReject bookReject)
        {
            dateTextBox.Value = bookReject.Date;
            districtNameDropDownList.Text = bookReject.DistrictName;
            partyNameDropDownList.Text = bookReject.PartyName;
            rejectNoTextBox.Text = bookReject.RejectNo;
            yearTextBox.Text = bookReject.Year;
            groupNameDropDownList.Text = bookReject.GroupName;
            bookNameDropDownList.Text = bookReject.BookId.ToString();
            bookRateTextBox.Text = bookReject.BookRate.ToString();
            commissionTextBox.Text = bookReject.Commission.ToString();
            quantityTextBox.Text = bookReject.Quantity.ToString();
            rejectRateTextBox.Text = bookReject.RejectRate.ToString();
            totalTextBox.Text = bookReject.Total.ToString();
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<BookReject> bookRejectList = (List<BookReject>)(Session["bookReject"]);
            if (active >= bookRejectList.Count)
                active = 0;
            BookReject bookReject = bookRejectManager.GetBookReject(active);
            GetData(bookReject);
            Session["active"] = active;
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active--;
            List<BookReject> bookRejectList = (List<BookReject>)(Session["bookReject"]);
            if (active <= -1)
                active = bookRejectList.Count - 1;
            BookReject bookReject = bookRejectManager.GetBookReject(active);
            GetData(bookReject);
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<BookReject> bookRejectList = (List<BookReject>)(Session["bookReject"]);
            int x = bookRejectList.Count - 1;
            BookReject bookReject = bookRejectManager.GetBookReject(x);
            GetData(bookReject);
            Session["active"] = x;
        }
        protected void searchButton_Click(object sender, EventArgs e)
        {
            var m = rejectTextBox.Value;
            BookReject bookReject = bookRejectManager.GetSearchInfo(m);
            if (bookReject.RejectNo == null)
            {
                message.InnerText = "Invalid Reject No!!";
                ClearTextBoxes();

            }
            else
            {
                GetData(bookReject);
                message.InnerText = "";
            }
        }
    }
}