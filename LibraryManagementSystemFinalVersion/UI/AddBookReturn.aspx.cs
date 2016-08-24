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
    public partial class AddBookRetutn : System.Web.UI.Page
    {
        BookReturnManager bookReturnManager = new BookReturnManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<District> districtList = bookReturnManager.GetAllDistrictByDropDownList();
                District district = new District();
                district.DistrictId = -1;
                district.DistrictName = "<--Select One Option-->";
                districtList.Insert(0, district);
                districtNameDropDownList.DataSource = districtList;
                districtNameDropDownList.DataValueField = "DistrictId";
                districtNameDropDownList.DataTextField = "DistrictName";
                districtNameDropDownList.DataBind();

                List<Party> partyList = bookReturnManager.GetAllPartiesByIdDropDownList();
                Party party = new Party();
                party.PartyId = -1;
                party.PartyName = "<-- Select One Option -->";
                partyList.Insert(0, party);
                partyNameDropDownList.DataSource = partyList;
                partyNameDropDownList.DataValueField = "PartyId";
                partyNameDropDownList.DataTextField = "PartyName";
                partyNameDropDownList.DataBind();

                List<Group> groupList = bookReturnManager.GetAllGroupInfoByDropDownList();
                Group group = new Group();
                group.GroupId = -1;
                group.GroupName = "<--Select One Option-->";
                groupList.Insert(0, group);
                groupNameDropDownList.DataSource = groupList;
                groupNameDropDownList.DataValueField = "GroupId";
                groupNameDropDownList.DataTextField = "GroupName";
                groupNameDropDownList.DataBind();

                List<BookInfo> bookInfoList = bookReturnManager.GetAllBookInfoByDropDownList();
                BookInfo bookInfo = new BookInfo();
                bookInfo.BookInfoId = -1;
                bookInfo.BookName = "<--Select One Option-->";
                bookInfoList.Insert(0, bookInfo);
                bookNameDropDownList.DataSource = bookInfoList;
                bookNameDropDownList.DataValueField = "BookInfoId";
                bookNameDropDownList.DataTextField = "BookName";
                bookNameDropDownList.DataBind();


                returnNoTextBox.Text = LoadNextReturnNo();

                List<BookReturn> bookReturnList = bookReturnManager.GetAllBookReturnList();
                Session["bookReturn"] = bookReturnList;
                Session["active"] = -1;

            }
        }

        private string LoadNextReturnNo()
        {
            BookReturn bookReturn = bookReturnManager.GetNextReturnNo();
            string returnNo = bookReturn.ReturnNo;
            int count;
            if (returnNo == null)
            {
                count = 1;
            }
            else
            {
                count = (returnNo[3] - '0') * 10 + (returnNo[4] - '0') + 1;
            }

            string nextReturnNo = "R-0" + count.ToString("00");
            return nextReturnNo;
        }

        protected void bookNameDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(bookNameDropDownList.SelectedValue);
            BookInfo bookInfo = bookReturnManager.GetBookReturn(id);
            bookRateTextBox.Text = bookInfo.BookRate.ToString();
            commissionTextBox.Text = bookInfo.BookCommission.ToString();
            double rate = Convert.ToDouble(bookRateTextBox.Text);
            double commission = Convert.ToDouble(commissionTextBox.Text);
            string result = ((rate * commission) / 100).ToString();
            returnRateTextBox.Text = result;
        }
        //protected void quantityTextBox_OnTextChanged(object sender, EventArgs e)
        //{
        //    double quantity = Convert.ToDouble(quantityTextBox.Text);
        //    double reject = Convert.ToDouble(returnRateTextBox.Text);
        //    double total = quantity*reject;
        //    totalTextBox.Text = total.ToString();
        //    netReturnTextBox.Text = total.ToString();
        //    //quantityTextBox.Text = "";
        //}

        //protected void transportBillTextBox_OnTextChanged(object sender, EventArgs e)
        //{
        //    double transport = Convert.ToDouble(transportBillTextBox.Text);
        //    double netReturn = Convert.ToDouble(netReturnTextBox.Text);
        //    double totalResult = netReturn + transport;
        //    netReturnTextBox.Text = totalResult.ToString();
        //    //transportBillTextBox.Text = "";
        //}

        //protected void lessTextBox_OnTextChanged(object sender, EventArgs e)
        //{
        //    double less = Convert.ToDouble(lessTextBox.Text);
        //    double netReturn = Convert.ToDouble(netReturnTextBox.Text);
        //    double totalResult = netReturn - less;
        //    netReturnTextBox.Text = totalResult.ToString();
        //    //lessTextBox.Text = "";
        //}

        protected void saveButton_Click(object sender, EventArgs e)
        {
            BookReturn bookReturn = new BookReturn();
            bookReturn.Date = dateTextBox.Value;
            bookReturn.DistrictId = int.Parse(districtNameDropDownList.SelectedValue);
            bookReturn.PartyId = int.Parse(partyNameDropDownList.SelectedValue);
            bookReturn.ReturnNo = returnNoTextBox.Text;
            bookReturn.ChallanReturn = challanReturnDropDownList.SelectedValue;
            bookReturn.Year = yearTextBox.Text;
            bookReturn.GroupId = int.Parse(groupNameDropDownList.SelectedValue);
            bookReturn.BookId = int.Parse(bookNameDropDownList.SelectedValue);
            string quantity = quantityTextBox.Text;
            string returnRate = returnRateTextBox.Text;
            string total = totalTextBox.Text;
            string transportBill = transportBillTextBox.Text;
            string less = lessTextBox.Text;
            string netReturn = netReturnTextBox.Text;
            if (dateTextBox.Value == "" || returnNoTextBox.Text == "" || yearTextBox.Text == "" ||
                quantityTextBox.Text == "" || returnRateTextBox.Text == "" || transportBillTextBox.Text == "" ||
                lessTextBox.Text == "" || netReturnTextBox.Text == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                bookReturn.Quantity = Convert.ToDouble(quantity);
                bookReturn.ReturnRate = Convert.ToDouble(returnRate);
                bookReturn.Total = Convert.ToDouble(total);
                bookReturn.TransportBill = Convert.ToDouble(transportBill);
                bookReturn.Less = Convert.ToDouble(less);
                bookReturn.NetReturn = Convert.ToDouble(netReturn);
                messageLabel.InnerText = bookReturnManager.Save(bookReturn);
            }
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            dateTextBox.Value = "";
            returnNoTextBox.Text = "";
            challanReturnDropDownList.Text = "";
            yearTextBox.Text = "";
            quantityTextBox.Text = "";
            bookRateTextBox.Text = "";
            commissionTextBox.Text = "";
            returnRateTextBox.Text = "";
            totalTextBox.Text = "";
            transportBillTextBox.Text = "";
            lessTextBox.Text = "";
            netReturnTextBox.Text = "";
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
            BookReturn bookReturn = bookReturnManager.GetReturns(0);
            GetData(bookReturn);
            Session["active"] = 0;
        }

        private void GetData(BookReturn bookReturn)
        {
            dateTextBox.Value = bookReturn.Date;
            districtNameDropDownList.Text = bookReturn.DistrictName;
            partyNameDropDownList.Text = bookReturn.PartyName;
            returnNoTextBox.Text = bookReturn.ReturnNo;
            challanReturnDropDownList.Text = bookReturn.ChallanReturn;
            yearTextBox.Text = bookReturn.Year;
            groupNameDropDownList.Text = bookReturn.GroupName;
            bookNameDropDownList.Text = bookReturn.BookId.ToString();
            bookRateTextBox.Text = bookReturn.BookRate.ToString();
            commissionTextBox.Text = bookReturn.Commission.ToString();
            returnRateTextBox.Text = bookReturn.ReturnRate.ToString();
            quantityTextBox.Text = bookReturn.Quantity.ToString();
            totalTextBox.Text = bookReturn.Total.ToString();
            transportBillTextBox.Text = bookReturn.TransportBill.ToString();
            lessTextBox.Text = bookReturn.Less.ToString();
            netReturnTextBox.Text = bookReturn.NetReturn.ToString();

        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<BookReturn> bookReturnList = (List<BookReturn>)(Session["bookReturn"]);
            if (active >= bookReturnList.Count)
                active = 0;
            BookReturn bookReturn = bookReturnManager.GetReturns(active);
            GetData(bookReturn);
            Session["active"] = active;
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active--;
            List<BookReturn> bookReturnList = (List<BookReturn>)(Session["bookReturn"]);
            if (active <= -1)
                active = bookReturnList.Count - 1;
            BookReturn bookReturn = bookReturnManager.GetReturns(active);
            GetData(bookReturn);
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<BookReturn> bookReturnList = (List<BookReturn>)(Session["bookReturn"]);
            int x = bookReturnList.Count - 1;
            BookReturn bookReturn = bookReturnManager.GetReturns(x);
            GetData(bookReturn);
            Session["active"] = x;
        }

        protected void slipButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowReport/BookReturnReport.aspx");
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
             var r = returnTextBox.Value;
             BookReturn bookReturn = bookReturnManager.GetSearchInfo(r);
             if (bookReturn.ReturnNo == null)
             {
                message.InnerText = "Invalid Return No!!";
                ClearTextBoxes();

             }
             else
             {
                GetData(bookReturn);
                message.InnerText = "";
             }
        }
    }
}