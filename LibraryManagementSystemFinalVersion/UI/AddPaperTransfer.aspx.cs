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
    public partial class AddPaperTransfer : System.Web.UI.Page
    {
        PaperTransferManager paperTransferManager = new PaperTransferManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Press> pressList = paperTransferManager.GetAllPressInfoByDropDownList();
                Press press = new Press();
                press.PressId = -1;
                press.PressName = "<-- Select One Option -->";
                pressList.Insert(0, press);
                fromPressNameDropDownList.DataSource = pressList;
                fromPressNameDropDownList.DataValueField = "PressId";
                fromPressNameDropDownList.DataTextField = "PressName";
                fromPressNameDropDownList.DataBind();

                press.PressId = -1;
                press.PressName = "<-- Select One Option -->";
                pressList.Insert(0, press);
                toPressNameDropDownList.DataSource = pressList;
                toPressNameDropDownList.DataValueField = "PressId";
                toPressNameDropDownList.DataTextField = "PressName";
                toPressNameDropDownList.DataBind();

                List<Paper> paperList = paperTransferManager.GetAllPaperInfoByDropDownList();
                Paper paper = new Paper();
                paper.PaperId = -1;
                paper.PaperName = "<-- Select One Option -->";
                paperList.Insert(0, paper);
                paperNameDropDownList.DataSource = paperList;
                paperNameDropDownList.DataValueField = "PaperId";
                paperNameDropDownList.DataTextField = "PaperName";
                paperNameDropDownList.DataBind();

                transferNoTextBox.Text = LoadNextTransferNo();
            }
        }

        private string LoadNextTransferNo()
        {
            PaperTransfer paperTransfer = paperTransferManager.GetNextTransferNo();
            string transferNo = paperTransfer.TransferNo;
            int count;
            if (transferNo == null)
            {
                count = 1;
            }
            else
            {
                count = (transferNo[4] - '0') * 10 + (transferNo[5] - '0') + 1;
            }

            string nextTransferNo = "Tr-0" + count.ToString("00");
            return nextTransferNo;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            PaperTransfer paperTransfer = new PaperTransfer();
            paperTransfer.Date = dateTextBox.Value;
            paperTransfer.TransferNo = transferNoTextBox.Text;
            paperTransfer.FromPressId = int.Parse(fromPressNameDropDownList.SelectedValue);
            paperTransfer.ToPressId = int.Parse(toPressNameDropDownList.SelectedValue);
            paperTransfer.PaperId = int.Parse(paperNameDropDownList.SelectedValue);
            paperTransfer.PaperType = paperTypeDropDownList.SelectedValue;
            string quantity = quantityTextBox.Text;
            if (dateTextBox.Value == "" || transferNoTextBox.Text == "" || paperTypeDropDownList.Text == "" ||
                quantityTextBox.Text == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                paperTransfer.Quantity = Convert.ToDouble(quantity);
                messageLabel.InnerText = paperTransferManager.Save(paperTransfer);
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
            transferNoTextBox.Text = "";
            paperTypeDropDownList.Text = "";
            quantityTextBox.Text = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}