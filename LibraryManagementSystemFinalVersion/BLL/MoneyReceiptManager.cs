using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class MoneyReceiptManager
    {
        MoneyReceiptGateway moneyReceiptGateway = new MoneyReceiptGateway();
        public List<District> GetAllDistrictByDropDownList()
        {
            return moneyReceiptGateway.GetAllDistrictByDropDownList();
        }

        public List<Party> GetAllPartiesByIdDropDownList()
        {
            return moneyReceiptGateway.GetAllPartiesByIdDropDownList();
        }

        public Party GetPartyName(int i)
        {
            return moneyReceiptGateway.GetPartyName(i);
        }

        public List<BankAccount> GetAllBankInfoByIdDropDownList()
        {
            return moneyReceiptGateway.GetAllBankInfoByIdDropDownList();
        }

        public MoneyReceipt GetNextMrNo()
        {
            return moneyReceiptGateway.GetNextMrNo();
        }

        public MoneyReceipt GetNextChequeNo()
        {
            return moneyReceiptGateway.GetNextChequeNo();
        }

        public string Save(MoneyReceipt moneyReceipt)
        {
            if (moneyReceiptGateway.Insert(moneyReceipt) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save Data in Database!!";
        }

        public List<MoneyReceipt> GetAllMoneyReceipt()
        {
            return moneyReceiptGateway.GetAllMoneyReceipt();
        }

        public MoneyReceipt GetMoneyReceipt(int i)
        {
            return moneyReceiptGateway.GetMoneyReceipt(i);
        }

        public MoneyReceipt GetSearchInfo(string mrNo)
        {
            return moneyReceiptGateway.GetSearchInfo(mrNo);
        }

        public DataTable GetMoneyReceiptData()
        {
            return moneyReceiptGateway.GetMoneyReceiptData();
        }
    }
}