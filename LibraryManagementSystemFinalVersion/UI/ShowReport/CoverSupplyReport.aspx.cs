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
    public partial class CoverSupplyReport : System.Web.UI.Page
    {
        CoverSupplyManager coverSupplyManager = new CoverSupplyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewReport();
            }
        }

        private void ViewReport()
        {
            CoverSupplyReportViewer.Reset();
            DataTable dt = coverSupplyManager.GetCoverSupplyReportData();
            ReportDataSource rds = new ReportDataSource("Ds_CoverSupply", dt);
            CoverSupplyReportViewer.LocalReport.DataSources.Add(rds);
            CoverSupplyReportViewer.LocalReport.ReportPath = "UI/ShowReport/CoverSupplyReport.rdlc";
            CoverSupplyReportViewer.LocalReport.Refresh();
        }

        protected void backToButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AddCoverSupply.aspx");
        }
    }
}