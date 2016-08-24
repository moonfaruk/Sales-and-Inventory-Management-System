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
    public partial class BookSpecimanReport : System.Web.UI.Page
    {
        BookSpecimanManager bookSpecimanManager = new BookSpecimanManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewReport();
            }
        }

        private void ViewReport()
        {
            BookSpecimanReportViewer.Reset();
            DataTable dt = bookSpecimanManager.GetBookSpecimanReportData();
            ReportDataSource rds = new ReportDataSource("Ds_BookSpeciman", dt);
            BookSpecimanReportViewer.LocalReport.DataSources.Add(rds);
            BookSpecimanReportViewer.LocalReport.ReportPath = "UI/ShowReport/BookSpecimanReport.rdlc";
            BookSpecimanReportViewer.LocalReport.Refresh();
        }

        protected void backToButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AddBookSpacimen.aspx");
        }
    }
}