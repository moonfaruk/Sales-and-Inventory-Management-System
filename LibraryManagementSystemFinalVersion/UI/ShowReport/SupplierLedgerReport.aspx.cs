using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryManagementSystemFinalVersion.BLL;
using Microsoft.Reporting.WebForms;

namespace LibraryManagementSystemFinalVersion.UI.ShowReport
{
    public partial class SupplierLedgerReport : System.Web.UI.Page
    {
        SupplierBillPaymentManager supplierBillPaymentManager = new SupplierBillPaymentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewReport();

            }
        }

        private void ViewReport()
        {
            DateTime from = (DateTime)Session["fromDate"];
            DateTime to = (DateTime)Session["toDate"];
            SupplierLedgerReportViewer.Reset();
            DataTable dt = supplierBillPaymentManager.GetSupplierReportDateWise(from, to);
            ReportDataSource rds = new ReportDataSource("DS_SupplierLedger", dt);
            SupplierLedgerReportViewer.LocalReport.DataSources.Add(rds);
            SupplierLedgerReportViewer.LocalReport.ReportPath = "UI/ShowReport/SupplierLedgerReport.rdlc";
            SupplierLedgerReportViewer.LocalReport.Refresh();
        }

        protected void backToButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AddSupplierLedger.aspx");
        }
    }
}