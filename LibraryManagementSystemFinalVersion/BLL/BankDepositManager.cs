using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class BankDepositManager
    {
        BankDepositGateway bankDepositGateway = new BankDepositGateway();
        public List<BankAccount> GetAllBankInfoByIdDropDownList()
        {
            return bankDepositGateway.GetAllBankInfoByIdDropDownList();
        }

        public List<District> GetAllDistrictByDropDownList()
        {
            return bankDepositGateway.GetAllDistrictByDropDownList();
        }

        public List<Party> GetAllPartyByDropDownList()
        {
            return bankDepositGateway.GetAllPartyByDropDownList();
        }

        public string Save(BankDeposit bankDeposit)
        {
            if (bankDepositGateway.Insert(bankDeposit) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save data In Database!!";
        }

        public List<BankDeposit> GetAllBankDeposit()
        {
            return bankDepositGateway.GetAllBankDeposit();
        }

        public BankDeposit GetBankDepositInfo(int i)
        {
            return bankDepositGateway.GetBankDepositInfo(i);
        }

        public DataTable GetBankDepositReportData()
        {
            return bankDepositGateway.GetBankDepositReportData();
        }
    }
}