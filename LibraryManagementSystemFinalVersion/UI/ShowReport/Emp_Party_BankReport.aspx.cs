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
    public partial class Emp_Party_BankReport : System.Web.UI.Page
    {
        PartyManager partyManager = new PartyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewReport();
            }
        }

        private void ViewReport()
        {
            ReportViewer.Reset();
            DataTable dt = partyManager.GetEmpPartyBankReportData();
            ReportDataSource rds = new ReportDataSource("Employee_Party_BankDataSet", dt);
            ReportViewer.LocalReport.DataSources.Add(rds);
            ReportViewer.LocalReport.ReportPath = "UI/ShowReport/Emp_Party_BankReport.rdlc";
            ReportViewer.LocalReport.Refresh();
        }
    }
}