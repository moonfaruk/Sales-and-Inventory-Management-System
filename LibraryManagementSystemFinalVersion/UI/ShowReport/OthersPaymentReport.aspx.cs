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
    public partial class OthersPaymentReport : System.Web.UI.Page
    {
        OthersBillPaymentManager othersBillPaymentManager = new OthersBillPaymentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewReport();
            }
        }

        private void ViewReport()
        {
            OthersPaymentReportViewer.Reset();
            DataTable dt = othersBillPaymentManager.GetOthersPaymentReportData();
            ReportDataSource rds = new ReportDataSource("Ds_OthersPayment", dt);
            OthersPaymentReportViewer.LocalReport.DataSources.Add(rds);
            OthersPaymentReportViewer.LocalReport.ReportPath = "UI/ShowReport/OthersPaymentReport.rdlc";
            OthersPaymentReportViewer.LocalReport.Refresh();
        }

        protected void backToButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AddOtherBillPayment.aspx");
        }
    }
}