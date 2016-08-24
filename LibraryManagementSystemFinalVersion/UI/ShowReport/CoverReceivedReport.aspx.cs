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
    public partial class CoverReceivedReport : System.Web.UI.Page
    {
        CoverReceivedManager coverReceivedManager = new CoverReceivedManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewReport();
            }
        }

        private void ViewReport()
        {
            CoverReceivedReportViewer.Reset();
            DataTable dt = coverReceivedManager.GetCoverReceivedReportData();
            ReportDataSource rds = new ReportDataSource("Ds_CoverReceived", dt);
            CoverReceivedReportViewer.LocalReport.DataSources.Add(rds);
            CoverReceivedReportViewer.LocalReport.ReportPath = "UI/ShowReport/CoverReceivedReport.rdlc";
            CoverReceivedReportViewer.LocalReport.Refresh();
        }

        protected void backToButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AddCoverReceived.aspx");
        }
    }
}