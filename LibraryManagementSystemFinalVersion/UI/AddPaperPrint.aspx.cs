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
    public partial class AddPaperPrint : System.Web.UI.Page
    {
        PaperPrintManager paperPrintManager = new PaperPrintManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Press> pressList = paperPrintManager.GetAllPressInfoByDropDownList();
                Press press = new Press();
                press.PressId = -1;
                press.PressName = "<-- Select One Option -->";
                pressList.Insert(0, press);
                pressNameDropDownList.DataSource = pressList;
                pressNameDropDownList.DataValueField = "PressId";
                pressNameDropDownList.DataTextField = "PressName";
                pressNameDropDownList.DataBind();

                List<Group> groupList = paperPrintManager.GetAllGroupInfoByDropDownList();
                Group group = new Group();
                group.GroupId = -1;
                group.GroupName = "<--Select One Option-->";
                groupList.Insert(0, group);
                groupNameDropDownList.DataSource = groupList;
                groupNameDropDownList.DataValueField = "GroupId";
                groupNameDropDownList.DataTextField = "GroupName";
                groupNameDropDownList.DataBind();

                List<BookInfo> bookInfoList = paperPrintManager.GetAllBookInfoByDropDownList();
                BookInfo bookInfo = new BookInfo();
                bookInfo.BookInfoId = -1;
                bookInfo.BookName = "<--Select One Option-->";
                bookInfoList.Insert(0, bookInfo);
                bookNameDropDownList.DataSource = bookInfoList;
                bookNameDropDownList.DataValueField = "BookInfoId";
                bookNameDropDownList.DataTextField = "BookName";
                bookNameDropDownList.DataBind();

                List<Paper> paperList = paperPrintManager.GetAllPaperInfoByDropDownList();
                Paper paper = new Paper();
                paper.PaperId = -1;
                paper.PaperName = "<-- Select One Option -->";
                paperList.Insert(0, paper);
                paperNameDropDownList.DataSource = paperList;
                paperNameDropDownList.DataValueField = "PaperId";
                paperNameDropDownList.DataTextField = "PaperName";
                paperNameDropDownList.DataBind();

                orderNoTextBox.Text = LoadNextOrderNo();

                List<PaperPrint> paperPrintList = paperPrintManager.GetAllPaperPrint();
                Session["paperPrint"] = paperPrintList;
                Session["active"] = -1;
            }
        }

        private string LoadNextOrderNo()
        {
            PaperPrint paperPrint = paperPrintManager.GetNextOrderNo();
            string orderNo = paperPrint.OrderNo;
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
            PaperPrint paperPrint = new PaperPrint();
            paperPrint.Date = dateTextBox.Value;
            paperPrint.OrderNo = orderNoTextBox.Text;
            paperPrint.PressId = int.Parse(pressNameDropDownList.SelectedValue);
            paperPrint.Year = yearTextBox.Text;
            paperPrint.PrintingType = printingTypeDropDownList.SelectedValue;
            paperPrint.GroupId = int.Parse(groupNameDropDownList.SelectedValue);
            paperPrint.BookId = int.Parse(bookNameDropDownList.SelectedValue);
            string plate = plateTextBox.Text;
            string forma = formaTextBox.Text;
            paperPrint.FormaType = formaTypeDropDownList.SelectedValue;
            paperPrint.ColorType = colorTypeDropDownList.SelectedValue;
            paperPrint.PaperId = int.Parse(paperNameDropDownList.SelectedValue);
            paperPrint.PaperType = paperTypeDropDownList.SelectedValue;
            string book = bookQuantityTextBox.Text;
            string paper = paperQuantityTextBox.Text;
            if (dateTextBox.Value == "" || orderNoTextBox.Text == "" || yearTextBox.Text == "" ||
                plateTextBox.Text == "" || formaTextBox.Text == "" || bookQuantityTextBox.Text == "" ||
                paperQuantityTextBox.Text == "" || paperTypeDropDownList.Text == "" || formaTypeDropDownList.Text == "" ||
                colorTypeDropDownList.Text == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                paperPrint.Plate = Convert.ToDouble(plate);
                paperPrint.Forma = Convert.ToDouble(forma);
                paperPrint.BookQuantity = Convert.ToDouble(book);
                paperPrint.PaperQuantity = Convert.ToDouble(paper);
                messageLabel.InnerText = paperPrintManager.Save(paperPrint);
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
            orderNoTextBox.Text = "";
            yearTextBox.Text = "";
            printingTypeDropDownList.Text = "";
            plateTextBox.Text = "";
            formaTextBox.Text = "";
            formaTypeDropDownList.Text = "";
            colorTypeDropDownList.Text = "";
            paperTypeDropDownList.Text = "";
            bookQuantityTextBox.Text = "";
            paperQuantityTextBox.Text = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            PaperPrint paperPrint = paperPrintManager.GetPaperPrint(0);
            GetData(paperPrint);
            Session["active"] = 0;
        }

        private void GetData(PaperPrint paperPrint)
        {
            dateTextBox.Value = paperPrint.Date;
            orderNoTextBox.Text = paperPrint.OrderNo;
            pressNameDropDownList.Text = paperPrint.PressName;
            yearTextBox.Text = paperPrint.Year;
            printingTypeDropDownList.Text = paperPrint.PrintingType;
            groupNameDropDownList.Text = paperPrint.GroupName;
            bookNameDropDownList.Text = paperPrint.BookName;
            plateTextBox.Text = paperPrint.Plate.ToString();
            formaTextBox.Text = paperPrint.Forma.ToString();
            formaTypeDropDownList.Text = paperPrint.FormaType;
            colorTypeDropDownList.Text = paperPrint.ColorType;
            paperNameDropDownList.Text = paperPrint.PaperName;
            paperTypeDropDownList.Text = paperPrint.PaperType;
            bookQuantityTextBox.Text = paperPrint.BookQuantity.ToString();
            paperQuantityTextBox.Text = paperPrint.PaperQuantity.ToString();
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<PaperPrint> paperPrintList = (List<PaperPrint>)(Session["paperPrint"]);
            if (active >= paperPrintList.Count)
                active = 0;
            PaperPrint paperPrint = paperPrintManager.GetPaperPrint(active);
            GetData(paperPrint);
            Session["active"] = active;
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active--;
            List<PaperPrint> paperPrintList = (List<PaperPrint>)(Session["paperPrint"]);
            if (active <= -1)
                active = paperPrintList.Count - 1;
            PaperPrint paperPrint = paperPrintManager.GetPaperPrint(active);
            GetData(paperPrint);
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<PaperPrint> paperPrintList = (List<PaperPrint>)(Session["paperPrint"]);
            int x = paperPrintList.Count - 1;
            PaperPrint paperPrint = paperPrintManager.GetPaperPrint(x);
            GetData(paperPrint);
            Session["active"] = x;
        }
    }
}