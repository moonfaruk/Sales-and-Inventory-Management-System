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
    public partial class AddSupplierBillEntry : System.Web.UI.Page
    {
        SupplierBillEntryManager supplierBillEntryManager = new SupplierBillEntryManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Supplier> sullpierList = supplierBillEntryManager.GetSupplierInfoByDropDownList();
                Supplier supplier = new Supplier();
                supplier.SupplierId = -1;
                supplier.SupplierName = "<-- Select One Option -->";
                sullpierList.Insert(0, supplier);
                supplierNameDropDownList.DataSource = sullpierList;
                supplierNameDropDownList.DataValueField = "SupplierId";
                supplierNameDropDownList.DataTextField = "SupplierName";
                supplierNameDropDownList.DataBind();

                List<Press> pressList = supplierBillEntryManager.GetAllPressInfoByDropDownList();
                Press press = new Press();
                press.PressId = -1;
                press.PressName = "<-- Select One Option -->";
                pressList.Insert(0, press);
                pressNameDropDownList.DataSource = pressList;
                pressNameDropDownList.DataValueField = "PressId";
                pressNameDropDownList.DataTextField = "PressName";
                pressNameDropDownList.DataBind();

                List<Paper> paperList = supplierBillEntryManager.GetAllPaperInfoByDropDownList();
                Paper paper = new Paper();
                paper.PaperId = -1;
                paper.PaperName = "<-- Select One Option -->";
                paperList.Insert(0, paper);
                paperNameDropDownList.DataSource = paperList;
                paperNameDropDownList.DataValueField = "PaperId";
                paperNameDropDownList.DataTextField = "PaperName";
                paperNameDropDownList.DataBind();

                billNoTextBox.Text = LoadNextBillNo();

                List<SupplierBillEntry> supplierBillEntryList = supplierBillEntryManager.GetAllSupplierBillEntryList();
                Session["supplies"] = supplierBillEntryList;
                Session["active"] = -1;
            }
        }

        private string LoadNextBillNo()
        {
            SupplierBillEntry supplierBillEntry = supplierBillEntryManager.GetNextBillNo();
            string billNo = supplierBillEntry.BillNo;
            int count;
            if (billNo == null)
            {
                count = 1;
            }
            else
            {
                count = (billNo[4] - '0')*10 + (billNo[5] - '0') + 1;
            }

            string nextBillNo = "Bill" + count.ToString("00");
            return nextBillNo;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            SupplierBillEntry supplierBillEntry = new SupplierBillEntry();
            supplierBillEntry.SupplierDate = supplierDateTextBox.Value;
            supplierBillEntry.SupplierBillDate = supplierBillDateTextBox.Value;
            supplierBillEntry.BillNo = billNoTextBox.Text;
            supplierBillEntry.SupplierType = supplierTypeDropDownList.SelectedValue;
            supplierBillEntry.PressName = supplierTypeDropDownList.SelectedValue;
            string supplierId = supplierNameDropDownList.SelectedValue;
            string pressId = pressNameDropDownList.SelectedValue;
            string paperId = paperNameDropDownList.SelectedValue;
            supplierBillEntry.PaperType = paperTypeDropDownList.SelectedValue;
            string paperQuantity = paperQuantityTextBox.Text;
            string prize = prizeTextBox.Text;
            supplierBillEntry.Description = descriptionTextArea.InnerText;
            string billAmount = billAmountTextBox.Text;

            if (supplierDateTextBox.Value == "" || supplierBillDateTextBox.Value == "" ||  billNoTextBox.Text == "" || paperQuantityTextBox.Text == "" || prizeTextBox.Text == "" ||
                descriptionTextArea.InnerText == "" || billAmountTextBox.Text == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                supplierBillEntry.SupplierId = int.Parse(supplierId);
                supplierBillEntry.PressId = int.Parse(pressId);
                supplierBillEntry.PaperId = int.Parse(paperId);
                supplierBillEntry.PaperQuantity = Convert.ToDouble(paperQuantity);
                supplierBillEntry.Prize = Convert.ToDouble(prize);
                supplierBillEntry.BillAmount = Convert.ToDouble(billAmount);
                messageLabel.InnerText = supplierBillEntryManager.Save(supplierBillEntry);
            }

        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            supplierDateTextBox.Value = "";
            supplierBillDateTextBox.Value = "";
            billNoTextBox.Text = "";
            supplierTypeDropDownList.SelectedValue = "";
            paperTypeDropDownList.SelectedValue = "";
            paperQuantityTextBox.Text = "";
            prizeTextBox.Text = "";
            descriptionTextArea.InnerText = "";
            billAmountTextBox.Text = "";

        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            SupplierBillEntry supplierBillEntry = supplierBillEntryManager.GetSupplierBillEntities(0);
            GetValue(supplierBillEntry);
            Session["active"] = 0;
        }

        private void GetValue(SupplierBillEntry supplierBillEntry)
        {
            supplierDateTextBox.Value = supplierBillEntry.SupplierDate;
            supplierBillDateTextBox.Value = supplierBillEntry.SupplierBillDate;
            billNoTextBox.Text = supplierBillEntry.BillNo;
            supplierTypeDropDownList.SelectedValue = supplierBillEntry.SupplierType;
            supplierNameDropDownList.SelectedValue = supplierBillEntry.SupplierId.ToString();
            pressNameDropDownList.SelectedValue = supplierBillEntry.PressId.ToString();
            paperNameDropDownList.SelectedValue = supplierBillEntry.PaperId.ToString();
            int x = 1; if (supplierBillEntry.PaperType == "S/S") x = 2;
            else if (supplierBillEntry.PaperType == "D/C") x = 3;
            paperTypeDropDownList.SelectedIndex= x;
            paperQuantityTextBox.Text = supplierBillEntry.PaperQuantity.ToString();
            prizeTextBox.Text = supplierBillEntry.Prize.ToString();
            descriptionTextArea.InnerText = supplierBillEntry.Description;
            billAmountTextBox.Text = supplierBillEntry.BillAmount.ToString();
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<SupplierBillEntry> supplierBillEntryList = (List<SupplierBillEntry>)(Session["supplies"]);
            if (active >= supplierBillEntryList.Count)
                active = 0;
            SupplierBillEntry supplierBillEntry = supplierBillEntryManager.GetSupplierBillEntities(active);
            GetValue(supplierBillEntry);
            Session["active"] = active;
           
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<SupplierBillEntry> supplierBillEntryList = (List<SupplierBillEntry>)(Session["supplies"]);
            int x = supplierBillEntryList.Count - 1;
            SupplierBillEntry supplierBillEntry = supplierBillEntryManager.GetSupplierBillEntities(x);
            GetValue(supplierBillEntry);
            Session["active"] = x;
            
        }

        protected void slipButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowReport/SupplierBillEntryReport.aspx");
        }
                
    }
}