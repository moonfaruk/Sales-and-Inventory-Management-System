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
    public partial class BookSalesReport : System.Web.UI.Page
    {
        BookSalesManager bookSalesManager = new BookSalesManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewReport();
            }
        }

        private void ViewReport()
        {
            BookSalesReportViewer.Reset();
            DataTable dt = bookSalesManager.GetBookSalesReportData();
            ReportDataSource rds = new ReportDataSource("Ds_BookSales", dt);
            BookSalesReportViewer.LocalReport.DataSources.Add(rds);
            BookSalesReportViewer.LocalReport.ReportPath = "UI/ShowReport/BookSalesReport.rdlc";
            BookSalesReportViewer.LocalReport.Refresh();
        }

        protected void backToButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AddBookSales.aspx");
        }
    }
}