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
    public partial class PaperOrderReport : System.Web.UI.Page
    {
        PaperOrderManager paperOrderManager = new PaperOrderManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewReport();
            }
        }

        private void ViewReport()
        {
            PaperOrderReportViewer.Reset();
            DataTable dt = paperOrderManager.GetPaperOrderReportData();
            ReportDataSource rds = new ReportDataSource("Ds_PaperOrder", dt);
            PaperOrderReportViewer.LocalReport.DataSources.Add(rds);
            PaperOrderReportViewer.LocalReport.ReportPath = "UI/ShowReport/PaperOrderReport.rdlc";
            PaperOrderReportViewer.LocalReport.Refresh();
        }

        protected void backToButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AddPaperOrder.aspx");
        }
    }
}