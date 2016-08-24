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
    public partial class AddMoneyReceipt : System.Web.UI.Page
    {
        MoneyReceiptManager moneyReceiptManager = new MoneyReceiptManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<District> districtList = moneyReceiptManager.GetAllDistrictByDropDownList();
                District district = new District();
                district.DistrictId = -1;
                district.DistrictName = "<--Select One Option-->";
                districtList.Insert(0, district);
                districtNameDropDownList.DataSource = districtList;
                districtNameDropDownList.DataValueField = "DistrictId";
                districtNameDropDownList.DataTextField = "DistrictName";
                districtNameDropDownList.DataBind();

                List<Party> partyList = moneyReceiptManager.GetAllPartiesByIdDropDownList();
                Party party = new Party();
                party.PartyId = -1;
                party.PartyCode = "<-- Select One Option -->";
                partyList.Insert(0, party);
                partyCodeDropDownList.DataSource = partyList;
                partyCodeDropDownList.DataValueField = "PartyId";
                partyCodeDropDownList.DataTextField = "PartyCode";
                partyCodeDropDownList.DataBind();

                List<BankAccount> bankAccountList = moneyReceiptManager.GetAllBankInfoByIdDropDownList();
                BankAccount bankAccount = new BankAccount();
                bankAccount.BankAccountId = -1;
                bankAccount.BankAccountName = "<--Select One Option-->";
                bankAccountList.Insert(0, bankAccount);
                bankNameDropDownList.DataSource = bankAccountList;
                bankNameDropDownList.DataValueField = "BankAccountId";
                bankNameDropDownList.DataTextField = "BankAccountName";
                bankNameDropDownList.DataBind();

                mrNoTextBox.Text = LoadNextMrNo();
                chequeNoTextBox.Text = LoadNextChequeNo();

                List<MoneyReceipt> moneyReceiptList = moneyReceiptManager.GetAllMoneyReceipt();
                Session["moneyReceipt"] = moneyReceiptList;
                Session["active"] = -1;
            }
        }

        private string LoadNextChequeNo()
        {
            MoneyReceipt moneyReceipt = moneyReceiptManager.GetNextChequeNo();
            string chequeNo = moneyReceipt.ChequeNo;
            int count;
            if (chequeNo == null)
            {
                count = 1;
            }
            else
            {
                count = (chequeNo[4] - '0') * 10 + (chequeNo[5] - '0') + 1;
            }

            string nextChequeNo = "Ch-0" + count.ToString("00");
            return nextChequeNo; 
        }

        private string LoadNextMrNo()
        {
            MoneyReceipt moneyReceipt = moneyReceiptManager.GetNextMrNo();
            string mrNo = moneyReceipt.MrNo;
            int count;
            if (mrNo == null)
            {
                count = 1;
            }
            else
            {
                count = (mrNo[4] - '0') * 10 + (mrNo[5] - '0') + 1;
            }

            string nextmrNo = "Mr-0" + count.ToString("00");
            return nextmrNo; 
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            MoneyReceipt moneyReceipt = new MoneyReceipt();
            moneyReceipt.Date = dateTextBox.Value;
            moneyReceipt.MrNo = mrNoTextBox.Text;
            moneyReceipt.DistrictId = int.Parse(districtNameDropDownList.SelectedValue);
            moneyReceipt.PartyId = int.Parse(partyCodeDropDownList.SelectedValue);
            moneyReceipt.Mode = modeDropDownList.SelectedValue;
            moneyReceipt.ChequeNo = chequeNoTextBox.Text;
            moneyReceipt.ChequeDate = chequeDateTextBox.Value;
            moneyReceipt.BankId = int.Parse(bankNameDropDownList.SelectedValue);
            moneyReceipt.BranchName = branchNameTextBox.Text;
            string amount = amountTextBox.Text;
            moneyReceipt.Remarks = remarksTextArea.InnerText;
            if (dateTextBox.Value == "" || mrNoTextBox.Text == "" || modeDropDownList.Text == "" ||
                chequeNoTextBox.Text == "" || chequeDateTextBox.Value == "" || branchNameTextBox.Text == "" ||
                amountTextBox.Text == "" || remarksTextArea.InnerText == "")
            {
                messageLabel.InnerText = "All Fields are Required!!";
            }
            else
            {
                moneyReceipt.Amount = Convert.ToDouble(amount);
                messageLabel.InnerText = moneyReceiptManager.Save(moneyReceipt);
            }
            ClearTextBoxes();
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            dateTextBox.Value = "";
            mrNoTextBox.Text = "";
            partyNameTextBox.Text = "";
            modeDropDownList.Text = "";
            chequeNoTextBox.Text = "";
            chequeDateTextBox.Value = "";
            branchNameTextBox.Text = "";
            amountTextBox.Text = "";
            remarksTextArea.InnerText = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            MoneyReceipt moneyReceipt = moneyReceiptManager.GetMoneyReceipt(0);
            GetData(moneyReceipt);
            Session["active"] = 0;
        }

        private void GetData(MoneyReceipt moneyReceipt)
        {
            dateTextBox.Value = moneyReceipt.Date;
            mrNoTextBox.Text = moneyReceipt.MrNo;
            districtNameDropDownList.Text = moneyReceipt.DistrictName;
            partyCodeDropDownList.Text = moneyReceipt.PartyId.ToString();
            partyNameTextBox.Text = moneyReceipt.PartyName;
            modeDropDownList.Text = moneyReceipt.Mode;
            chequeNoTextBox.Text = moneyReceipt.ChequeNo;
            chequeDateTextBox.Value = moneyReceipt.ChequeDate;
            bankNameDropDownList.Text = moneyReceipt.BankName;
            branchNameTextBox.Text = moneyReceipt.BranchName;
            amountTextBox.Text = moneyReceipt.Amount.ToString();
            remarksTextArea.InnerText = moneyReceipt.Remarks;
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<MoneyReceipt> moneyReceiptList = (List<MoneyReceipt>)(Session["moneyReceipt"]);
            if (active >= moneyReceiptList.Count)
                active = 0;
            MoneyReceipt moneyReceipt = moneyReceiptManager.GetMoneyReceipt(active);
            GetData(moneyReceipt);
            Session["active"] = active;
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active--;
            List<MoneyReceipt> moneyReceiptList = (List<MoneyReceipt>)(Session["moneyReceipt"]);
            if (active <= -1)
                active = moneyReceiptList.Count - 1;
            MoneyReceipt moneyReceipt = moneyReceiptManager.GetMoneyReceipt(active);
            GetData(moneyReceipt);
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<MoneyReceipt> moneyReceiptList = (List<MoneyReceipt>)(Session["moneyReceipt"]);
            int x = moneyReceiptList.Count - 1;
            MoneyReceipt moneyReceipt = moneyReceiptManager.GetMoneyReceipt(x);
            GetData(moneyReceipt);
            Session["active"] = x;
        }

        protected void moneyReceiptButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowReport/MoneyReceiptReport.aspx");
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            var mrNo = mrTextBox.Value;
            MoneyReceipt moneyReceipt = moneyReceiptManager.GetSearchInfo(mrNo);
            if (moneyReceipt.MrNo == null)
            {
                message.InnerText = "Invalid Mr No!!";

            }
            else
            {
                GetData(moneyReceipt);
                message.InnerText = "";
            }
        }

        protected void partyCodeDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(partyCodeDropDownList.SelectedValue);
            Party party = moneyReceiptManager.GetPartyName(id);
            partyNameTextBox.Text = party.PartyName;
        }
    }
}