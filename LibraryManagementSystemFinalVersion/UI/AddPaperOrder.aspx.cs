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
    public partial class AddPaperOrder : System.Web.UI.Page
    {
        PaperOrderManager paperOrderManager = new PaperOrderManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Supplier> sullpierList = paperOrderManager.GetSupplierInfoByDropDownList();

                Supplier supplier = new Supplier();
                supplier.SupplierId = -1;
                supplier.SupplierName = "<-- Select One Option -->";
                sullpierList.Insert(0, supplier);
                supplierNameDropDownList.DataSource = sullpierList;
                supplierNameDropDownList.DataValueField = "SupplierId";
                supplierNameDropDownList.DataTextField = "SupplierName";
                supplierNameDropDownList.DataBind();

                List<Press> pressList = paperOrderManager.GetAllPressInfoByDropDownList();
                Press press = new Press();
                press.PressId = -1;
                press.PressCode = "<-- Select One Option -->";
                pressList.Insert(0, press);
                pressCodeDropDownList.DataSource = pressList;
                pressCodeDropDownList.DataValueField = "PressId";
                pressCodeDropDownList.DataTextField = "PressCode";
                pressCodeDropDownList.DataBind();

                List<Paper> paperList = paperOrderManager.GetAllPaperInfoByDropDownList();
                Paper paper = new Paper();
                paper.PaperId = -1;
                paper.PaperName = "<-- Select One Option -->";
                paperList.Insert(0, paper);
                paperNameDropDownList.DataSource = paperList;
                paperNameDropDownList.DataValueField = "PaperId";
                paperNameDropDownList.DataTextField = "PaperName";
                paperNameDropDownList.DataBind();

                slipNoTextBox.Text = LoadNextSlipNo();

                List<PaperOrder> paperOrderList = paperOrderManager.GetAllPaperOrder();
                Session["paperOrder"] = paperOrderList;
                Session["active"] = -1;
            }
        }

        private string LoadNextSlipNo()
        {
            PaperOrder paperOrder = paperOrderManager.GetNextSlipNo();
            string slipNo = paperOrder.SlipNo;
            int count;
            if (slipNo == null)
            {
                count = 1;
            }
            else
            {
                count = (slipNo[4] - '0') * 10 + (slipNo[5] - '0') + 1;
            }

            string nextSlipNo = "Sl-0" + count.ToString("00");
            return nextSlipNo;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            PaperOrder paperOrder = new PaperOrder();
            paperOrder.Date = dateTextBox.Value;
            paperOrder.SupplierId = int.Parse(supplierNameDropDownList.SelectedValue);
            paperOrder.SlipNo = slipNoTextBox.Text;
            paperOrder.PressId = int.Parse(pressCodeDropDownList.SelectedValue);
            paperOrder.PaperId = int.Parse(paperNameDropDownList.SelectedValue);
            paperOrder.PaperType = paperTypeDropDownList.SelectedValue;
            string quantity = quantityTextBox.Text;
            if (dateTextBox.Value == "" || slipNoTextBox.Text == "" || paperTypeDropDownList.Text == "" ||
                quantityTextBox.Text == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                paperOrder.Quantity = Convert.ToDouble(quantity);
                messageLabel.InnerText = paperOrderManager.Save(paperOrder);
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
            slipNoTextBox.Text = "";
            paperTypeDropDownList.Text = "";
            quantityTextBox.Text = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            PaperOrder paperOrder = paperOrderManager.GetPaperOrder(0);
            GetData(paperOrder);
            Session["active"] = 0;
        }

        private void GetData(PaperOrder paperOrder)
        {
            dateTextBox.Value = paperOrder.Date;
            supplierNameDropDownList.Text = paperOrder.SupplierName;
            slipNoTextBox.Text = paperOrder.SlipNo;
            pressCodeDropDownList.Text = paperOrder.PressCode;
            paperNameDropDownList.Text = paperOrder.PaperName;
            paperTypeDropDownList.Text = paperOrder.PaperType;
            quantityTextBox.Text = paperOrder.Quantity.ToString();
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<PaperOrder> paperOrderList = (List<PaperOrder>)(Session["paperOrder"]);
            if (active >= paperOrderList.Count)
                active = 0;
            PaperOrder paperOrder = paperOrderManager.GetPaperOrder(active);
            GetData(paperOrder);
            Session["active"] = active;
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active--;
            List<PaperOrder> paperOrderList = (List<PaperOrder>)(Session["paperOrder"]);
            if (active <= -1)
                active = paperOrderList.Count - 1;
            PaperOrder paperOrder = paperOrderManager.GetPaperOrder(active);
            GetData(paperOrder);
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<PaperOrder> paperOrderList = (List<PaperOrder>)(Session["paperOrder"]);
            int x = paperOrderList.Count - 1;
            PaperOrder paperOrder = paperOrderManager.GetPaperOrder(x);
            GetData(paperOrder);
            Session["active"] = x;
        }

        protected void slipButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowReport/PaperOrderReport.aspx");
        }

       
    }
}