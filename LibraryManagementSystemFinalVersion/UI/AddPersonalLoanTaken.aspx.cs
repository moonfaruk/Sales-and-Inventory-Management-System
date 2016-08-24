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
    public partial class AddPersonalLoanTaken : System.Web.UI.Page
    {
        PersonalLoanPaymentManager personalLoanPaymentManager = new PersonalLoanPaymentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Party> partyList = personalLoanPaymentManager.GetAllPartiesByIdDropDownList();
                Party party = new Party();
                party.PartyId = -1;
                party.PartyName = "<-- Select One Option -->";
                partyList.Insert(0,party);
                partyDropDownList.DataSource = partyList;
                partyDropDownList.DataValueField = "PartyId";
                partyDropDownList.DataTextField = "PartyName";
                partyDropDownList.DataBind();


                List<PersonalLoanPayment> personalLoanPaymentList = personalLoanPaymentManager.GetAllPersonalLoanList();
                Session["loan"] = personalLoanPaymentList;
                Session["active"] = -1;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            PersonalLoanPayment personalLoanPayment = new PersonalLoanPayment();
            personalLoanPayment.LoanDate = dateTextBox.Value;
            personalLoanPayment.LoanType = typeDropDownList.SelectedValue;
            personalLoanPayment.PartyId = int.Parse(partyDropDownList.SelectedValue);
            string amount = amountTextBox.Text;
            if (dateTextBox.Value == "" || typeDropDownList.Text == "" || amountTextBox.Text == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                personalLoanPayment.Amount = Convert.ToDouble(amount);
                messageLabel.InnerText = personalLoanPaymentManager.Save(personalLoanPayment);
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            dateTextBox.Value = "";
            typeDropDownList.SelectedValue = "";
            amountTextBox.Text = "";
        }
        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<PersonalLoanPayment> personalLoanPaymentList = (List<PersonalLoanPayment>)Session["loan"];
            int x = personalLoanPaymentList.Count - 1;
            PersonalLoanPayment personalLoanPayment = personalLoanPaymentManager.GetLoanParties(x);
            dateTextBox.Value = personalLoanPayment.LoanDate;
            typeDropDownList.Text = personalLoanPayment.LoanType;
            partyDropDownList.Text = personalLoanPayment.PartyName;
            amountTextBox.Text = personalLoanPayment.Amount.ToString();
            Session["active"] = x;
        }
    }
}