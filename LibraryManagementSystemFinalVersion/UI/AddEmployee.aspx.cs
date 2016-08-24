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
    public partial class AddEmployee : System.Web.UI.Page
    {
        EmployeeManager employeeManager = new EmployeeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            employeeCodeTextBox.Text = LoadNextEmployeeCode();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.EmployeeCode = employeeCodeTextBox.Text;
            employee.EmployeeName = employeeNameTextBox.Text;
            string eNationalId = employeeNationalIdTextBox.Text;
            employee.EmployeeContactNo = employeePhoneTextBox.Text;
            employee.EmployeeAddress = employeeAddressTextArea.InnerText;
            string eBasicSalary = employeeBasicSalaryTextBox.Text;
            string eOpeningBalance = employeeOpeningBalanceTextBox.Text;
            if (employeeCodeTextBox.Text == "" || employeeNameTextBox.Text == "" || employeeNationalIdTextBox.Text == "" ||
                employeePhoneTextBox.Text == "" || employeeAddressTextArea.InnerText == "" ||
                employeeBasicSalaryTextBox.Text == "" || employeeOpeningBalanceTextBox.Text == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
                message.InnerText = "";
            }
            else
            {
                employee.EmployeeNationalId = Convert.ToDouble(eNationalId);
                employee.EmployeeBasicSalary = Convert.ToDouble(eBasicSalary);
                employee.EmployeeOpeningBalance = Convert.ToDouble(eOpeningBalance);
                message.InnerText = employeeManager.Save(employee);
                messageLabel.InnerText = "";
            }

        }

        private void ClearTextBoxes()
        {
            employeeCodeTextBox.Text = "";
            employeeNameTextBox.Text = "";
            employeeNationalIdTextBox.Text = "";
            employeePhoneTextBox.Text = "";
            employeeAddressTextArea.InnerText = "";
            employeeBasicSalaryTextBox.Text = "";
            employeeOpeningBalanceTextBox.Text = "";
        }
        protected void clearButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        private string LoadNextEmployeeCode()
        {
            Employee emp = employeeManager.GetNextEmployeeCode();
            string empCode = emp.EmployeeCode;
            int count;
            if (empCode == null)
            {
                count = 1;
            }
            else
            {
                count = (empCode[3] - '0')*10 + (empCode[4] - '0') + 1;
            }
            string nextCode = "Emp" + count.ToString("00");
            return nextCode;
        }

        protected void reportButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowReport/EmpReport.aspx");
        }
    }
}