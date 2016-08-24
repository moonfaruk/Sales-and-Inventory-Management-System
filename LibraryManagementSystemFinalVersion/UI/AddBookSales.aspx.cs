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
    public partial class AddBookSales : System.Web.UI.Page
    {
        BookSalesManager bookSalesManager = new BookSalesManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<District> districtList = bookSalesManager.GetAllDistrictByDropDownList();
                District district = new District();
                district.DistrictId = -1;
                district.DistrictName = "<--Select One Option-->";
                districtList.Insert(0, district);
                districtNameDropDownList.DataSource = districtList;
                districtNameDropDownList.DataValueField = "DistrictId";
                districtNameDropDownList.DataTextField = "DistrictName";
                districtNameDropDownList.DataBind();

                List<Party> partyList = bookSalesManager.GetAllPartiesByIdDropDownList();
                Party party = new Party();
                party.PartyId = -1;
                party.PartyCode = "<-- Select One Option -->";
                partyList.Insert(0, party);
                partyCodeDropDownList.DataSource = partyList;
                partyCodeDropDownList.DataValueField = "PartyId";
                partyCodeDropDownList.DataTextField = "PartyCode";
                partyCodeDropDownList.DataBind();

                List<Group> groupList = bookSalesManager.GetAllGroupInfoByDropDownList();
                Group group = new Group();
                group.GroupId = -1;
                group.GroupName = "<--Select One Option-->";
                groupList.Insert(0, group);
                groupNameDropDownList.DataSource = groupList;
                groupNameDropDownList.DataValueField = "GroupId";
                groupNameDropDownList.DataTextField = "GroupName";
                groupNameDropDownList.DataBind();

                List<BookInfo> bookInfoList = bookSalesManager.GetAllBookInfoByDropDownList();
                BookInfo bookInfo = new BookInfo();
                bookInfo.BookInfoId = -1;
                bookInfo.BookName = "<--Select One Option-->";
                bookInfoList.Insert(0, bookInfo);
                bookNameDropDownList.DataSource = bookInfoList;
                bookNameDropDownList.DataValueField = "BookInfoId";
                bookNameDropDownList.DataTextField = "BookName";
                bookNameDropDownList.DataBind();

                memoNoTextBox.Text = LoadNextMemoNo();

                List<BookSales> bookSalesList = bookSalesManager.GetAllBookSalesList();
                Session["bookSales"] = bookSalesList;
                Session["active"] = -1;
            }
        }

        private string LoadNextMemoNo()
        {
            BookSales bookSales = bookSalesManager.GetNextMemoNo();
            string memoNo  = bookSales.MemoNo;
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
            BookInfo bookInfo = bookSalesManager.GetBookInfo(id);
            bookRateTextBox.Text = bookInfo.BookRate.ToString();
            commissionTextBox.Text = bookInfo.BookCommission.ToString();
            double bookRate = Convert.ToDouble(bookRateTextBox.Text);
            double commission = Convert.ToDouble(commissionTextBox.Text);
            string result = ((bookRate*commission)/100).ToString();
            saleRateTextBox.Text = result;

        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            BookSales bookSales = new BookSales();
            bookSales.Date = dateTextBox.Value;
            bookSales.DistrictId = int.Parse(districtNameDropDownList.SelectedValue);
            bookSales.PartyId = int.Parse(partyCodeDropDownList.SelectedValue);
            bookSales.MemoNo = memoNoTextBox.Text;
            bookSales.SalesType = salesTypeDropDownList.SelectedValue;
            bookSales.Year = yearTextBox.Text;
            bookSales.GroupId = int.Parse(groupNameDropDownList.SelectedValue);
            bookSales.BookId = int.Parse(bookNameDropDownList.SelectedValue);
            string quantity = quantityTextBox.Text;
            string saleRate = saleRateTextBox.Text;
            string total = totalTextBox.Text;
            string packing = packingTextBox.Text;
            string bonus = bonusTextBox.Text;
            string totalPrice = totalPriceTextBox.Text;
            string paymentAmount = paymentAmountTextBox.Text;
            string dues = duesTextBox.Text;
            if (dateTextBox.Value == "" || memoNoTextBox.Text == "" || salesTypeDropDownList.Text == "" ||
                yearTextBox.Text == "" || quantityTextBox.Text == "" || saleRateTextBox.Text == "" ||
                packingTextBox.Text == "" || bonusTextBox.Text == "" || paymentAmountTextBox.Text == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                bookSales.Quantity = Convert.ToDouble(quantity);
                bookSales.SalesRate = Convert.ToDouble(saleRate);
                bookSales.Total = Convert.ToDouble(total);
                bookSales.Packing = Convert.ToDouble(packing);
                bookSales.Bonus = Convert.ToDouble(bonus);
                bookSales.TotalPrice = Convert.ToDouble(totalPrice);
                bookSales.PaymentAmount = Convert.ToDouble(paymentAmount);
                bookSales.Dues = Convert.ToDouble(dues);
                messageLabel.InnerText = bookSalesManager.Save(bookSales);
            }
            ClearTextBoxes();


        }

        private void ClearTextBoxes()
        {
            dateTextBox.Value = "";
            memoNoTextBox.Text = "";
            salesTypeDropDownList.Text = "";
            yearTextBox.Text = "";
            quantityTextBox.Text = "";
            bookRateTextBox.Text = "";
            commissionTextBox.Text = "";
            saleRateTextBox.Text = "";
            packingTextBox.Text = "";
            totalTextBox.Text = "";
            bonusTextBox.Text = "";
            totalPriceTextBox.Text = "";
            paymentAmountTextBox.Text = "";
            duesTextBox.Text = "";

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
            BookSales bookSales = bookSalesManager.GetBookSales(0);
            GetData(bookSales);
            Session["active"] = 0;
        }

        private void GetData(BookSales bookSales)
        {
            dateTextBox.Value = bookSales.Date;
            districtNameDropDownList.Text = bookSales.DistrictName;
            partyCodeDropDownList.Text = bookSales.PartyCode;
            memoNoTextBox.Text = bookSales.MemoNo;
            salesTypeDropDownList.Text = bookSales.SalesType;
            yearTextBox.Text = bookSales.Year;
            groupNameDropDownList.Text = bookSales.GroupName;
            bookNameDropDownList.Text = bookSales.BookId.ToString();
            bookRateTextBox.Text = bookSales.BookRate.ToString();
            commissionTextBox.Text = bookSales.Commisssion.ToString();
            saleRateTextBox.Text = bookSales.SalesRate.ToString();
            quantityTextBox.Text = bookSales.Quantity.ToString();
            totalTextBox.Text = bookSales.Total.ToString();
            packingTextBox.Text = bookSales.Packing.ToString();
            bonusTextBox.Text = bookSales.Bonus.ToString();
            totalPriceTextBox.Text = bookSales.TotalPrice.ToString();
            paymentAmountTextBox.Text = bookSales.PaymentAmount.ToString();
            duesTextBox.Text = bookSales.Dues.ToString();

        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<BookSales> bookSalesList = (List<BookSales>)(Session["bookSales"]);
            if (active >= bookSalesList.Count)
                active = 0;
            BookSales bookSales = bookSalesManager.GetBookSales(active);
            GetData(bookSales);
            Session["active"] = active;
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active--;
            List<BookSales> bookSalesList = (List<BookSales>)(Session["bookSales"]);
            if (active <= -1)
                active = bookSalesList.Count - 1;
            BookSales bookSales = bookSalesManager.GetBookSales(active);
            GetData(bookSales);
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<BookSales> bookSalesList = (List<BookSales>)(Session["bookSales"]);
            int x = bookSalesList.Count - 1;
            BookSales bookSales = bookSalesManager.GetBookSales(x);
            GetData(bookSales);
            Session["active"] = x;
        }

        protected void slipButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowReport/BookSalesReport.aspx");
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            var m = memoTextBox.Value;
            BookSales bookSales = bookSalesManager.GetSearchInfo(m);
            if (bookSales.MemoNo == null)
            {
                message.InnerText = "Invalid Memo No!!";
                ClearTextBoxes();

            }
            else
            {
                GetData(bookSales);
                message.InnerText = "";
            }
        }
    }
}