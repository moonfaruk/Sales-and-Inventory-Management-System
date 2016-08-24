using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class BankWithdrawManager
    {
        BankWithdrawGateway bankWithdrawGateway = new BankWithdrawGateway();
        public List<BankAccount> GetAllBankInfoByDropDownList()
        {
            return bankWithdrawGateway.GetAllBankInfoByDropDownList();
        }

        public BankAccount GetBank(int i)
        {
            return bankWithdrawGateway.GetBank(i);
        }

        public string Save(BankWithdraw bankWithdraw)
        {
            if (bankWithdrawGateway.Insert(bankWithdraw) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save data in Database!!";
        }

        public BankWithdraw GetLastBankWithdrawInfo()
        {
            return bankWithdrawGateway.GetLastBankWithdrawInfo();
        }

        public BankAccount GetAccountNo(int i)
        {
            return bankWithdrawGateway.GetAccountNo(i);
        }
    }
}