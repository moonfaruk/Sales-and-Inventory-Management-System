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
    public partial class EmployeeBillEntryReport : System.Web.UI.Page
    {
       EmployeeSalaryBillEntryManager employeeSalaryBillEntryManager = new EmployeeSalaryBillEntryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewReport();
            }
        }

        private void ViewReport()
        {
            
            EmployeeBillEntryReportViewer.Reset();
            DataTable dt = employeeSalaryBillEntryManager.GetEmployeeSalaryReportData();
            ReportDataSource rds = new ReportDataSource("Ds_EmployeeBillEntry", dt);
            EmployeeBillEntryReportViewer.LocalReport.DataSources.Add(rds);
            EmployeeBillEntryReportViewer.LocalReport.ReportPath = "UI/ShowReport/EmployeeBillEntryReport.rdlc";
            EmployeeBillEntryReportViewer.LocalReport.Refresh();
        }

        protected void backToButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../AddEmployeeBillEntry.aspx");
        }
    }
}