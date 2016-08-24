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
    public partial class BinderOrderReport : System.Web.UI.Page
    {
        BinderOrderManager binderOrderManager = new BinderOrderManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewReport();
            }
        }

        private void ViewReport()
        {
            BinderOrderReportViewer.Reset();
            DataTable dt = binderOrderManager.GetBinderOrderReportData();
            ReportDataSource rds = new ReportDataSource("Ds_BinderOrder", dt);
            BinderOrderReportViewer.LocalReport.DataSources.Add(rds);
            BinderOrderReportViewer.LocalReport.ReportPath = "UI/ShowReport/BinderOrderReport.rdlc";
            BinderOrderReportViewer.LocalReport.Refresh();
        }

        protected void backToButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AddBinderOrder.aspx");
        }
    }
}