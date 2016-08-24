using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class BankManager
    {
        BankGateway bankGateway = new BankGateway();
        public string Save(BankAccount bankAccount)
        {
            if (bankGateway.Insert(bankAccount) > 0)
            {
                return "Saved Successfully!!";
            }
            else
            {
                return "Could Not save data in database!!";
            }
        }

        public BankAccount GetNextBankCode()
        {
            return bankGateway.GetNextBankCode();
        }

        public List<BankAccount> GetAllBankInfo()
        {
            return bankGateway.GetAllBankInfo();
        }

        public BankAccount GetBankAccountById(int bankAccountId)
        {
            return bankGateway.GetBankAccountById(bankAccountId);
        }


        public bool UpdateBankAccount(BankAccount bankAccount)
        {
            bool isUpdated = false;
            if (bankAccount.BankAccountId > 0)
            {
                isUpdated = bankGateway.UpdateBankAccount(bankAccount);
            }
            return isUpdated;
        }

        public bool DeleteBankAccount(int dId)
        {
            return bankGateway.DeleteBankAccount(dId);
        }
    }
}