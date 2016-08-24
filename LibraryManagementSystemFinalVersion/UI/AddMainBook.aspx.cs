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
    public partial class AddMainBook : System.Web.UI.Page
    {
        MainBookManager mainBookManager = new MainBookManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                groupCodeTextBox.Text = LoadNextCode();
                List<MainBook> mainBookList = mainBookManager.GetAllMainBook();
                Session["mainBooks"] = mainBookList;
                Session["active"] = -1;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            MainBook mainBook = new MainBook(groupCodeTextBox.Text,groupNameTextBox.Text,classTextBox.Text);
            if (groupCodeTextBox.Text == "" || groupNameTextBox.Text == "" || classTextBox.Text == "")
            {
                message.InnerText = "All Fields are Required!!";
                messageLabel.InnerText = "";
            }
            else
            {
                messageLabel.InnerText = mainBookManager.Save(mainBook);
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            groupCodeTextBox.Text = "";
            groupNameTextBox.Text = "";
            classTextBox.Text = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            MainBook mainBook = mainBookManager.GetMainBooks(0);
            GetValueFromDatabase(mainBook);
            Session["active"] = 0;
        }

        private void GetValueFromDatabase(MainBook mainBook)
        {
            groupCodeTextBox.Text = mainBook.MainBookCode;
            groupNameTextBox.Text = mainBook.MainBookName;
            classTextBox.Text = mainBook.MainBookClass;
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<MainBook> mainBookList = (List<MainBook>)(Session["mainBooks"]);
            if (active >= mainBookList.Count)
                active = 0;
            MainBook mainBook = mainBookManager.GetMainBooks(active);
            GetValueFromDatabase(mainBook);
            Session["active"] = active;
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active--;
            List<MainBook> mainBookList = (List<MainBook>)(Session["mainBooks"]);
            if (active <= -1)
                active = mainBookList.Count - 1;
            MainBook mainBook = mainBookManager.GetMainBooks(active);
            GetValueFromDatabase(mainBook);
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<MainBook> mainBookList = (List<MainBook>)Session["mainBooks"];
            int x = mainBookList.Count - 1;
            MainBook mainBook = mainBookManager.GetMainBooks(x);
            GetValueFromDatabase(mainBook);
            Session["active"] = x;
        }

        private string LoadNextCode()
        {
            MainBook mainBook = mainBookManager.GetNextCode();
            string mBookCode = mainBook.MainBookCode;
            int c;
            if (mBookCode == null)
            {
                c = 1;
            }
            else
            {
                c = (mBookCode[3] - '0')*10 + (mBookCode[4] - '0') + 1;
            }
            string nextCode = "MBC" + c.ToString("00");
            return nextCode;
        }
    }
}