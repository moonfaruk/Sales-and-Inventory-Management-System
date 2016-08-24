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
    public partial class AddEmployeeSalaryPayment : System.Web.UI.Page
    {
       EmployeeSalaryPaymentManager employeeSalaryPaymentManager = new EmployeeSalaryPaymentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Employee> employeeList = employeeSalaryPaymentManager.GetAllEmployeeByDropDownList();
                Employee employee = new Employee();
                employee.EmployeeId = -1;
                employee.EmployeeName = "<- Select One Option ->";
                employeeList.Insert(0, employee);
                employeeNameDropDownList.DataSource = employeeList;
                employeeNameDropDownList.DataValueField = "EmployeeId";
                employeeNameDropDownList.DataTextField = "EmployeeName";
                employeeNameDropDownList.DataBind();

                List<BankAccount> bankAccountList = employeeSalaryPaymentManager.GetAllBankInfoByIdDropDownList();
                BankAccount bankAccount = new BankAccount();
                bankAccount.BankAccountId = -1;
                bankAccount.BankAccountName = "<--Select One Option-->";
                bankAccountList.Insert(0, bankAccount);
                bankNameDropDownList.DataSource = bankAccountList;
                bankNameDropDownList.DataValueField = "BankAccountId";
                bankNameDropDownList.DataTextField = "BankAccountName";
                bankNameDropDownList.DataBind();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            EmployeeSalaryPayment employeeSalaryPayment = new EmployeeSalaryPayment();
            employeeSalaryPayment.EmployeeDate = employeeDateTextBox.Value;
            string year = yearTextBox.Text;
            employeeSalaryPayment.EmployeeMonth = monthTypeDropDownList.SelectedValue;
            employeeSalaryPayment.EmployeeId = int.Parse(employeeNameDropDownList.SelectedValue);
            employeeSalaryPayment.PaymentMode = paymentModeDropDownList.SelectedValue;
            employeeSalaryPayment.BankId = int.Parse(bankNameDropDownList.SelectedValue);
            employeeSalaryPayment.CheckNo = checkNoTextBox.Text;
            employeeSalaryPayment.CheckDate = checkDateTextBox.Value;
            string amount = amountTextBox.Text;
            employeeSalaryPayment.Remarks = remarksDropDownList.SelectedValue;
            if (employeeDateTextBox.Value == "" || yearTextBox.Text == "" || monthTypeDropDownList.Text == "" ||
                paymentModeDropDownList.Text == "" || checkNoTextBox.Text == "" || checkDateTextBox.Value == "" ||
                amountTextBox.Text == "" || remarksDropDownList.Text == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                employeeSalaryPayment.EmployeeYear = Convert.ToDouble(year);
                employeeSalaryPayment.Amount = Convert.ToDouble(amount);
                messageLabel.InnerText = employeeSalaryPaymentManager.Save(employeeSalaryPayment);

            }
            ClearTextBoxes();

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
            paymentModeDropDownList.Text = "";
            checkNoTextBox.Text = "";
            checkDateTextBox.Value = "";
            amountTextBox.Text = "";
            remarksDropDownList.Text = "";

        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            EmployeeSalaryPayment employeeSalaryPayment = employeeSalaryPaymentManager.GetLastEmployeeSalary();
            employeeDateTextBox.Value = employeeSalaryPayment.EmployeeDate;
            yearTextBox.Text = employeeSalaryPayment.EmployeeYear.ToString();
            monthTypeDropDownList.Text = employeeSalaryPayment.EmployeeMonth;
            employeeNameDropDownList.Text = employeeSalaryPayment.EmployeeName;
            paymentModeDropDownList.Text = employeeSalaryPayment.PaymentMode;
            bankNameDropDownList.Text = employeeSalaryPayment.BankName;
            checkNoTextBox.Text = employeeSalaryPayment.CheckNo;
            checkDateTextBox.Value = employeeSalaryPayment.CheckDate;
            amountTextBox.Text = employeeSalaryPayment.Amount.ToString();
            remarksDropDownList.Text = employeeSalaryPayment.Remarks;

        }
    }
}