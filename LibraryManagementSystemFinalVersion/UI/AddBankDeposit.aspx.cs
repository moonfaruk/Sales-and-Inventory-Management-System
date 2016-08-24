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
    public partial class AddBankDeposit : System.Web.UI.Page
    {
        private BankDepositManager bankDepositManager = new BankDepositManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<BankAccount> bankAccountList = bankDepositManager.GetAllBankInfoByIdDropDownList();
                BankAccount bankAccount = new BankAccount();
                bankAccount.BankAccountId = -1;
                bankAccount.BankAccountName = "<--Select One Option-->";
                bankAccountList.Insert(0, bankAccount);
                bankNameDropDownList.DataSource = bankAccountList;
                bankNameDropDownList.DataValueField = "BankAccountId";
                bankNameDropDownList.DataTextField = "BankAccountName";
                bankNameDropDownList.DataBind();

                List<District> districtList = bankDepositManager.GetAllDistrictByDropDownList();
                District district = new District();
                district.DistrictId = -1;
                district.DistrictName = "<--Select One Option-->";
                districtList.Insert(0, district);
                districtDropDownList.DataSource = districtList;
                districtDropDownList.DataValueField = "DistrictId";
                districtDropDownList.DataTextField = "DistrictName";
                districtDropDownList.DataBind();

                List<Party> partyList = bankDepositManager.GetAllPartyByDropDownList();
                Party party = new Party();
                party.PartyId = -1;
                party.PartyName = "<--Select One Option-->";
                partyList.Insert(0, party);
                partyDropDownList.DataSource = partyList;
                partyDropDownList.DataValueField = "PartyId";
                partyDropDownList.DataTextField = "PartyName";
                partyDropDownList.DataBind();

                List<BankDeposit> bankDepositList = bankDepositManager.GetAllBankDeposit();
                Session["bankDeposit"] = bankDepositList;
                Session["active"] = -1;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            BankDeposit bankDeposit = new BankDeposit();
            bankDeposit.BankDate = bankDateTextBox.Value;
            bankDeposit.BankId = int.Parse(bankNameDropDownList.SelectedValue);
            bankDeposit.Mode = modeDropDownList.SelectedValue;
            bankDeposit.PartyBankName = partyBankNameTextBox.Text;
            bankDeposit.CheckNo = checkTextBox.Text;
            bankDeposit.DistrictId = int.Parse(districtDropDownList.SelectedValue);
            bankDeposit.PartyId = int.Parse(partyDropDownList.SelectedValue);
            string amount = amountTextBox.Text;
            if (bankDateTextBox.Value == "" || modeDropDownList.Text == "" || checkTextBox.Text == "" ||
                partyBankNameTextBox.Text == "" || amountTextBox.Text == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                bankDeposit.Amount = Convert.ToDouble(amount);
                messageLabel.InnerText = bankDepositManager.Save(bankDeposit);
            }
            ClearTextBoxes();
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            bankDateTextBox.Value = "";
            modeDropDownList.Text = "";
            partyBankNameTextBox.Text = "";
            checkTextBox.Text = "";
            amountTextBox.Text = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void slipButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowReport/BankDepositReport.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            BankDeposit bankDeposit = bankDepositManager.GetBankDepositInfo(0);
            GetValue(bankDeposit);
            Session["active"] = 0;
        }

        private void GetValue(BankDeposit bankDeposit)
        {
            bankDateTextBox.Value = bankDeposit.BankDate;
            bankNameDropDownList.Text = bankDeposit.BankName;
            modeDropDownList.Text = bankDeposit.Mode;
            partyBankNameTextBox.Text = bankDeposit.PartyBankName;
            checkTextBox.Text = bankDeposit.CheckNo;
            districtDropDownList.Text = bankDeposit.DistrictName;
            partyDropDownList.Text = bankDeposit.PartyName;
            amountTextBox.Text = bankDeposit.Amount.ToString();
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<BankDeposit> bankDepositList = (List<BankDeposit>)(Session["bankDeposit"]);
            if (active >= bankDepositList.Count)
                active = 0;
            BankDeposit bankDeposit = bankDepositManager.GetBankDepositInfo(active);
            GetValue(bankDeposit);
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<BankDeposit> bankDepositList = (List<BankDeposit>)(Session["bankDeposit"]);
            int x = bankDepositList.Count - 1;
            BankDeposit bankDeposit = bankDepositManager.GetBankDepositInfo(x);
            GetValue(bankDeposit);
            Session["active"] = x;
        }
    }
}
