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
    public partial class MoneyReceiptReport : System.Web.UI.Page
    {
        MoneyReceiptManager moneyReceiptManager = new MoneyReceiptManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewReport();
            }
        }

        private void ViewReport()
        {
            MoneyReceiptReportViewer.Reset();
            DataTable dt = moneyReceiptManager.GetMoneyReceiptData();
            ReportDataSource rds = new ReportDataSource("Ds_MoneyReceipt", dt);
            MoneyReceiptReportViewer.LocalReport.DataSources.Add(rds);
            MoneyReceiptReportViewer.LocalReport.ReportPath = "UI/ShowReport/MoneyReceiptReport.rdlc";
            MoneyReceiptReportViewer.LocalReport.Refresh();
        }

        protected void backToButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AddMoneyReceipt.aspx");
        }
    }
}