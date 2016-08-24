using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryManagementSystemFinalVersion.BLL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.UI
{
    public partial class AddEmployeeBillEntry : System.Web.UI.Page
    {
       EmployeeSalaryBillEntryManager employeeSalaryBillEntryManager = new EmployeeSalaryBillEntryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Employee> employeeList = employeeSalaryBillEntryManager.GetAllEmployeeByDropDownList();
                Employee employee = new Employee();
                employee.EmployeeId = -1;
                employee.EmployeeName = "<- Select One Option ->";
                employeeList.Insert(0,employee);
                employeeNameDropDownList.DataSource = employeeList;
                employeeNameDropDownList.DataValueField = "EmployeeId";
                employeeNameDropDownList.DataTextField = "EmployeeName";
                employeeNameDropDownList.DataBind();

                List<EmployeeSalaryBillEntry> employeeSalaryBillEntryList = employeeSalaryBillEntryManager.GetAllEmployeesBillEntryList();
                Session["employees"] = employeeSalaryBillEntryList;
                Session["active"] = -1;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            EmployeeSalaryBillEntry employeeSalaryBillEntry = new EmployeeSalaryBillEntry();
            employeeSalaryBillEntry.EmployeeDate = employeeDateTextBox.Value;
            string year = yearTextBox.Text;
            employeeSalaryBillEntry.EmployeeMonth = monthTypeDropDownList.SelectedValue;
            employeeSalaryBillEntry.EmployeeName = employeeNameDropDownList.SelectedValue;
            string salaryReduce = salaryReduceTextBox.Text;
            string bonus = bonusTextBox.Text;
            string salary = salaryTextBox.Text;
            employeeSalaryBillEntry.Remarks = remarksDropDownList.SelectedValue;

            if (employeeDateTextBox.Value == "" || yearTextBox.Text == "" || monthTypeDropDownList.Text == "" ||
                employeeNameDropDownList.Text == "" || salaryReduceTextBox.Text == "" || bonusTextBox.Text == "" ||
                salaryTextBox.Text == "" || remarksDropDownList.Text == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                employeeSalaryBillEntry.EmployeeYear = Convert.ToDouble(year);
                employeeSalaryBillEntry.SalaryReduce = Convert.ToDouble(salaryReduce);
                employeeSalaryBillEntry.Bonus = Convert.ToDouble(bonus);
                employeeSalaryBillEntry.Salary = Convert.ToDouble(salary);
                messageLabel.InnerText = employeeSalaryBillEntryManager.Save(employeeSalaryBillEntry);
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            employeeDateTextBox.Value = "";
            yearTextBox.Text = "";
            monthTypeDropDownList.Text = "";
            salaryReduceTextBox.Text = "";
            bonusTextBox.Text = "";
            salaryTextBox.Text = "";
            remarksDropDownList.Text = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            GetValue(0);
            Session["active"] = 0;
        }

        private void GetValue(int k)
        {
            EmployeeSalaryBillEntry employeeSalaryBillEntry = employeeSalaryBillEntryManager.GetEmployees(k);
            employeeDateTextBox.Value = employeeSalaryBillEntry.EmployeeDate;
            yearTextBox.Text = employeeSalaryBillEntry.EmployeeYear.ToString();
            monthTypeDropDownList.Text = employeeSalaryBillEntry.EmployeeMonth;
            employeeNameDropDownList.Text = employeeSalaryBillEntry.EmployeeName;
            salaryReduceTextBox.Text = employeeSalaryBillEntry.SalaryReduce.ToString();
            bonusTextBox.Text = employeeSalaryBillEntry.Bonus.ToString();
            salaryTextBox.Text = employeeSalaryBillEntry.Salary.ToString();
            remarksDropDownList.Text = employeeSalaryBillEntry.Remarks;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<EmployeeSalaryBillEntry> employeeSalaryBillEntryList = (List<EmployeeSalaryBillEntry>)(Session["employees"]);
            int x = employeeSalaryBillEntryList.Count - 1;
            GetValue(x);
            Session["active"] = x;
        }

        protected void slipButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowReport/EmployeeBillEntryReport.aspx");
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<EmployeeSalaryBillEntry> employeeSalaryBillEntryList = (List<EmployeeSalaryBillEntry>)(Session["employees"]);
            if (active >= employeeSalaryBillEntryList.Count)
                active = 0;
            GetValue(active);
            Session["active"] = active;
        }
    }
}