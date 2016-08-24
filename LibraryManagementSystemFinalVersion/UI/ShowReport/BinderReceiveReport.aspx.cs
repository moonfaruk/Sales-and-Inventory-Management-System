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
    public partial class BinderReceiveReport : System.Web.UI.Page
    {
        BinderReceiveManager binderReceiveManager = new BinderReceiveManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewReport();
            }
        }

        private void ViewReport()
        {
            BinderReceiveReportViewer.Reset();
            DataTable dt = binderReceiveManager.GetBinderReceiveReportData();
            ReportDataSource rds = new ReportDataSource("Ds_BinderReceive", dt);
            BinderReceiveReportViewer.LocalReport.DataSources.Add(rds);
            BinderReceiveReportViewer.LocalReport.ReportPath = "UI/ShowReport/BinderReceiveReport.rdlc";
            BinderReceiveReportViewer.LocalReport.Refresh();
        }

        protected void backToButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AddBinderReceive.aspx");
        }
    }
}