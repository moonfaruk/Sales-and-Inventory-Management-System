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
    public partial class SupplierBillEntryReport : System.Web.UI.Page
    {
        SupplierBillEntryManager supplierBillEntryManager = new SupplierBillEntryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewReport();
            }
        }

        private void ViewReport()
        {
            SupplierBillEntryReportViewer.Reset();
            DataTable dt = supplierBillEntryManager.GetSupplierBillReportData();
            ReportDataSource rds = new ReportDataSource("Ds_SupplierBillEntry", dt);
            SupplierBillEntryReportViewer.LocalReport.DataSources.Add(rds);
            SupplierBillEntryReportViewer.LocalReport.ReportPath = "UI/ShowReport/SupplierBillEntryReport.rdlc";
            SupplierBillEntryReportViewer.LocalReport.Refresh();
        }

        protected void backToButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AddSupplierBillEntry.aspx");
        }
    }
}