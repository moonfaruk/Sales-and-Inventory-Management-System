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
    public partial class SupplierBillPaymentReport : System.Web.UI.Page
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
            SupplierBillPaymentReportViewer.Reset();
            DataTable dt = supplierBillPaymentManager.GetSupplierBillPaymentReportData();
            ReportDataSource rds = new ReportDataSource("Ds_SupplierBillPayment", dt);
            SupplierBillPaymentReportViewer.LocalReport.DataSources.Add(rds);
            SupplierBillPaymentReportViewer.LocalReport.ReportPath = "UI/ShowReport/SupplierBillPaymentReport.rdlc";
            SupplierBillPaymentReportViewer.LocalReport.Refresh();
        }

        protected void backToButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AddSupplierBillPayment.aspx");
        }
    }
}