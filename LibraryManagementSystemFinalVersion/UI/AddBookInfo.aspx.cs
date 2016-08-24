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
    public partial class AddBookInfo : System.Web.UI.Page
    {
        BookInfoManager bookInfoManager = new BookInfoManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Press> pressList = bookInfoManager.GetAllPressListByDropDownList();
                pressNameDropDownList.DataSource = pressList;
                pressNameDropDownList.DataValueField = "PressId";
                pressNameDropDownList.DataTextField = "PressName";
                pressNameDropDownList.DataBind();

                List<Binder> binderList = bookInfoManager.GetAllBinderByDropDownList();
                binderNameDropDownList.DataSource = binderList;
                binderNameDropDownList.DataValueField = "BinderId";
                binderNameDropDownList.DataTextField = "BinderName";
                binderNameDropDownList.DataBind();

                List<MainBook> mainBookList = bookInfoManager.GetAllMainBookByDropDownList();
                mainBookCodeDropDownList.DataSource = mainBookList;
                mainBookCodeDropDownList.DataValueField = "MainBookId";
                mainBookCodeDropDownList.DataTextField = "MainBookCode";
                mainBookCodeDropDownList.DataBind();

                bookCodeTextBox.Text = LoadNextCode();
                List<BookInfo> bookInfoList = bookInfoManager.GetAllBookInfo();
                Session["bookInformation"] = bookInfoList;
                Session["active"] = -1;

            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            BookInfo bookInfo = new BookInfo();
            bookInfo.BookCode = bookCodeTextBox.Text;
            bookInfo.BookName = bookNameTextBox.Text;
            bookInfo.BookSize = bookSizeTextBox.Text;
            string forma = bookFormaTextBox.Text;
            string inar = bookInarTextBox.Text;
            bookInfo.PressName = pressNameDropDownList.SelectedValue;
            bookInfo.BinderName = binderNameDropDownList.SelectedValue;
            bookInfo.MainBookCode = mainBookCodeDropDownList.SelectedValue;
            string rate = bookRateTextBox.Text;
            string returnRate = returnRateTextBox.Text;
            string commission = commissionTextBox.Text;
            string openingBalance = bookOpeningBalanceTextBox.Text;
            bookInfo.BookStatus = statusTextBox.Text;
            if (bookCodeTextBox.Text == "" || bookNameTextBox.Text == "" || bookSizeTextBox.Text == "" ||
                bookFormaTextBox.Text == "" || bookInarTextBox.Text == "" || pressNameDropDownList.Text == "" ||
                binderNameDropDownList.Text
                == "" || mainBookCodeDropDownList.Text == "" || bookRateTextBox.Text == "" || returnRateTextBox.Text == "" || commissionTextBox.Text == "" ||
                bookOpeningBalanceTextBox.Text == "" || statusTextBox.Text == "")
            {
                message.InnerText = "All Field are Required!!";
                messageLabel.InnerText = "";
            }
            else
            {
                bookInfo.BookForma = Convert.ToDouble(forma);
                bookInfo.BookInar = Convert.ToDouble(inar);
                bookInfo.BookRate = Convert.ToDouble(rate);
                bookInfo.BookReturnRate = Convert.ToDouble(returnRate);
                bookInfo.BookCommission = Convert.ToDouble(commission);
                bookInfo.BookOpeningBalance = Convert.ToDouble(openingBalance);
                messageLabel.InnerText = bookInfoManager.Save(bookInfo);
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            bookCodeTextBox.Text = "";
            bookNameTextBox.Text = "";
            bookSizeTextBox.Text = "";
            bookFormaTextBox.Text = "";
            bookInarTextBox.Text = "";
            bookRateTextBox.Text = "";
            returnRateTextBox.Text = "";
            commissionTextBox.Text = "";
            bookOpeningBalanceTextBox.Text = "";
            statusTextBox.Text = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            BookInfo bookInfo = bookInfoManager.GetBooks(0);
            GetValueFromDatabase(bookInfo);
            Session["active"] = 0;
        }

        private void GetValueFromDatabase(BookInfo bookInfo)
        {
            bookCodeTextBox.Text = bookInfo.BookCode;
            bookNameTextBox.Text = bookInfo.BookName;
            bookSizeTextBox.Text = bookInfo.BookSize;
            bookFormaTextBox.Text = bookInfo.BookForma.ToString();
            bookInarTextBox.Text = bookInfo.BookInar.ToString();
            pressNameDropDownList.SelectedValue = bookInfo.PressName;
            binderNameDropDownList.SelectedValue = bookInfo.BinderName;
            mainBookCodeDropDownList.SelectedValue = bookInfo.MainBookCode;
            bookRateTextBox.Text = bookInfo.BookRate.ToString();
            returnRateTextBox.Text = bookInfo.BookReturnRate.ToString();
            commissionTextBox.Text = bookInfo.BookCommission.ToString();
            bookOpeningBalanceTextBox.Text = bookInfo.BookOpeningBalance.ToString();
            statusTextBox.Text = bookInfo.BookStatus;
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<BookInfo> bookInfoList = (List<BookInfo>)(Session["bookInformation"]);
            if (active >= bookInfoList.Count)
                active = 0;
            BookInfo bookInfo = bookInfoManager.GetBooks(active);
            GetValueFromDatabase(bookInfo);
            Session["active"] = active;
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active--;
            List<BookInfo> bookInfoList = (List<BookInfo>)(Session["bookInformation"]);
            if (active <= -1)
                active = bookInfoList.Count - 1;
            BookInfo bookInfo = bookInfoManager.GetBooks(active);
            GetValueFromDatabase(bookInfo);
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<BookInfo> bookInfoList = (List<BookInfo>)Session["bookInformation"];
            int x = bookInfoList.Count - 1;
            BookInfo bookInfo = bookInfoManager.GetBooks(x);
            GetValueFromDatabase(bookInfo);
            Session["active"] = x;
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            var book = bookInfoTextBox.Value;
            BookInfo bookInfo = bookInfoManager.GetSearchInfo(book);
            if (bookInfo.BookCode == null)
            {
                message.InnerText = "Invalid Book Code!!";

            }
            else
            {
                GetValueFromDatabase(bookInfo);
                message.InnerText = "";
            }
        }

        private string LoadNextCode()
        {
            BookInfo bookInfo = bookInfoManager.GetNextBookCode();
            string bCode = bookInfo.BookCode;
            int c;
            if (bCode == null)
            {
                c = 1;
            }
            else
            {
                c = (bCode[4] - '0')*10 + (bCode[5] - '0') + 1;
            }
            string nextCode = "Book" + c.ToString("00");
            return nextCode;
        }
    }
}