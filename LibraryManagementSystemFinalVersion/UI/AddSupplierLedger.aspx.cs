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
    public partial class AddSupplierLedger : System.Web.UI.Page
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
            }
        }

        protected void partyLedgerButton_Click(object sender, EventArgs e)
        {
            DateTime fromDate = Convert.ToDateTime(fromTextBox.Value);
            DateTime toDate = Convert.ToDateTime(toTextBox.Value);
            Session["fromDate"] = fromDate;
            Session["toDate"] = toDate;
            Response.Redirect("ShowReport/SupplierLedgerReport.aspx");
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void clearButton_Click(object sender, EventArgs e)
        {
            fromTextBox.Value = "";
            toTextBox.Value = "";
        }
    }
}