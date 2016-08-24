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
    public partial class BookReturnReport : System.Web.UI.Page
    {
        BookReturnManager bookReturnManager = new BookReturnManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewReport();
            }
        }

        private void ViewReport()
        {
            BookReturnReportViewer.Reset();
            DataTable dt = bookReturnManager.GetBookReturnReportData();
            ReportDataSource rds = new ReportDataSource("Ds_BookReturn", dt);
            BookReturnReportViewer.LocalReport.DataSources.Add(rds);
            BookReturnReportViewer.LocalReport.ReportPath = "UI/ShowReport/BookReturnReport.rdlc";
            BookReturnReportViewer.LocalReport.Refresh();
        }

        protected void backToButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AddBookReturn.aspx");
        }
    }
}