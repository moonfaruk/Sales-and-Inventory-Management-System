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
    public partial class BankDepositReport : System.Web.UI.Page
    {
        BankDepositManager bankDepositManager = new BankDepositManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewReport();
            }
        }

        private void ViewReport()
        {
            BankDepositReportViewer.Reset();
            DataTable dt = bankDepositManager.GetBankDepositReportData();
            ReportDataSource rds = new ReportDataSource("Ds_BankDeposit", dt);
            BankDepositReportViewer.LocalReport.DataSources.Add(rds);
            BankDepositReportViewer.LocalReport.ReportPath = "UI/ShowReport/BankDepositReport.rdlc";
            BankDepositReportViewer.LocalReport.Refresh();
        }

        protected void backToButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AddBankDeposit.aspx");
        }
    }
}