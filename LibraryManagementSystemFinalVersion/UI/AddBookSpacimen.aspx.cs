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
    public partial class AddBookSpacimen : System.Web.UI.Page
    {
        private BookSpecimanManager bookSpecimanManager = new BookSpecimanManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<District> districtList = bookSpecimanManager.GetAllDistrictByDropDownList();
                District district = new District();
                district.DistrictId = -1;
                district.DistrictName = "<--Select One Option-->";
                districtList.Insert(0, district);
                districtNameDropDownList.DataSource = districtList;
                districtNameDropDownList.DataValueField = "DistrictId";
                districtNameDropDownList.DataTextField = "DistrictName";
                districtNameDropDownList.DataBind();

                List<Party> partyList = bookSpecimanManager.GetAllPartiesByIdDropDownList();
                Party party = new Party();
                party.PartyId = -1;
                party.PartyCode = "<-- Select One Option -->";
                partyList.Insert(0, party);
                partyCodeDropDownList.DataSource = partyList;
                partyCodeDropDownList.DataValueField = "PartyId";
                partyCodeDropDownList.DataTextField = "PartyCode";
                partyCodeDropDownList.DataBind();

                List<Group> groupList = bookSpecimanManager.GetAllGroupInfoByDropDownList();
                Group group = new Group();
                group.GroupId = -1;
                group.GroupName = "<--Select One Option-->";
                groupList.Insert(0, group);
                groupNameDropDownList.DataSource = groupList;
                groupNameDropDownList.DataValueField = "GroupId";
                groupNameDropDownList.DataTextField = "GroupName";
                groupNameDropDownList.DataBind();

                List<BookInfo> bookInfoList = bookSpecimanManager.GetAllBookInfoByDropDownList();
                BookInfo bookInfo = new BookInfo();
                bookInfo.BookInfoId = -1;
                bookInfo.BookName = "<--Select One Option-->";
                bookInfoList.Insert(0, bookInfo);
                bookNameDropDownList.DataSource = bookInfoList;
                bookNameDropDownList.DataValueField = "BookInfoId";
                bookNameDropDownList.DataTextField = "BookName";
                bookNameDropDownList.DataBind();

                memoNoTextBox.Text = LoadNextMemoNo();
                List<BookSpeciman> bookSpecimanList = bookSpecimanManager.GetAllBookSpecimanList();
                Session["bookSpeciman"] = bookSpecimanList;
                Session["active"] = -1;
            }
        }

        private string LoadNextMemoNo()
        {
            BookSpeciman bookSpeciman = bookSpecimanManager.GetNextMemoNo();
            string memoNo = bookSpeciman.MemoNo;
            int count;
            if (memoNo == null)
            {
                count = 1;
            }
            else
            {
                count = (memoNo[3] - '0') * 10 + (memoNo[4] - '0') + 1;
            }

            string nextMemoNo = "M-0" + count.ToString("00");
            return nextMemoNo;
        }

        protected void bookNameDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(bookNameDropDownList.SelectedValue);
            BookInfo bookInfo = bookSpecimanManager.GetBookInfo(id);
            bookRateTextBox.Text = bookInfo.BookRate.ToString();
            commissionTextBox.Text = bookInfo.BookCommission.ToString();
            double bookRate = Convert.ToDouble(bookRateTextBox.Text);
            double commission = Convert.ToDouble(commissionTextBox.Text);
            string result = ((bookRate * commission) / 100).ToString();
            rateTextBox.Text = result;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            BookSpeciman bookSpeciman = new BookSpeciman();
            bookSpeciman.Date = dateTextBox.Value;
            bookSpeciman.DistrictId = int.Parse(districtNameDropDownList.SelectedValue);
            bookSpeciman.PartyId = int.Parse(partyCodeDropDownList.SelectedValue);
            bookSpeciman.MemoNo = memoNoTextBox.Text;
            bookSpeciman.Year = yearTextBox.Text;
            bookSpeciman.GroupId = int.Parse(groupNameDropDownList.SelectedValue);
            bookSpeciman.BookId = int.Parse(bookNameDropDownList.SelectedValue);
            string quantity = quantityTextBox.Text;
            string rate = rateTextBox.Text;
            string total = totalTextBox.Text;
            if (dateTextBox.Value == "" || memoNoTextBox.Text == "" || yearTextBox.Text == "" ||
                quantityTextBox.Text == "" || rateTextBox.Text == "" || totalTextBox.Text == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                bookSpeciman.Quantity = Convert.ToDouble(quantity);
                bookSpeciman.Rate = Convert.ToDouble(rate);
                bookSpeciman.Total = Convert.ToDouble(total);
                messageLabel.InnerText = bookSpecimanManager.Save(bookSpeciman);
            }
            ClearTextBoxes();

        }

        private void ClearTextBoxes()
        {
            dateTextBox.Value = "";
            memoNoTextBox.Text = "";
            yearTextBox.Text = "";
            rateTextBox.Text = "";
            bookRateTextBox.Text = "";
            commissionTextBox.Text = "";
            totalTextBox.Text = "";
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            BookSpeciman bookSpeciman = bookSpecimanManager.GetBookSpeciman(0);
            GetData(bookSpeciman);
            Session["active"] = 0;
        }

        private void GetData(BookSpeciman bookSpeciman)
        {
            dateTextBox.Value = bookSpeciman.Date;
            districtNameDropDownList.Text = bookSpeciman.DistrictName;
            partyCodeDropDownList.Text = bookSpeciman.PartyCode;
            memoNoTextBox.Text = bookSpeciman.MemoNo;
            yearTextBox.Text = bookSpeciman.Year;
            groupNameDropDownList.Text = bookSpeciman.GroupName;
            bookNameDropDownList.Text = bookSpeciman.BookId.ToString();
            bookRateTextBox.Text = bookSpeciman.BookRate.ToString();
            commissionTextBox.Text = bookSpeciman.Commission.ToString();
            quantityTextBox.Text = bookSpeciman.Quantity.ToString();
            rateTextBox.Text = bookSpeciman.Rate.ToString();
            totalTextBox.Text = bookSpeciman.Total.ToString();
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<BookSpeciman> bookSpecimanList = (List<BookSpeciman>)(Session["bookSpeciman"]);
            if (active >= bookSpecimanList.Count)
                active = 0;
            BookSpeciman bookSpeciman = bookSpecimanManager.GetBookSpeciman(active);
            GetData(bookSpeciman);
            Session["active"] = active;
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active--;
            List<BookSpeciman> bookSpecimanList = (List<BookSpeciman>)(Session["bookSpeciman"]);
            if (active <= -1)
                active = bookSpecimanList.Count - 1;
            BookSpeciman bookSpeciman = bookSpecimanManager.GetBookSpeciman(active);
            GetData(bookSpeciman);
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<BookSpeciman> bookSpecimanList = (List<BookSpeciman>)(Session["bookSpeciman"]);
            int x = bookSpecimanList.Count - 1;
            BookSpeciman bookSpeciman = bookSpecimanManager.GetBookSpeciman(x);
            GetData(bookSpeciman);
            Session["active"] = x;
        }

        protected void slipButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowReport/BookSpecimanReport.aspx");
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            var m = memoTextBox.Value;
            BookSpeciman bookSpeciman = bookSpecimanManager.GetSearchInfo(m);
            if (bookSpeciman.MemoNo == null)
            {
                message.InnerText = "Invalid Memo No!!";
                ClearTextBoxes();

            }
            else
            {
                GetData(bookSpeciman);
                message.InnerText = "";
            }
        }
    }
}
 