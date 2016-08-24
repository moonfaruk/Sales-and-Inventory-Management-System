using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class LoanManager
    {
        LoanGateway loanGateway = new LoanGateway();
        public string Save(LoanParty loanParty)
        {
            if (loanGateway.Insert(loanParty) > 0)
            {
                return "Saved Successfully!!";
            }
            else
            {
                return "Could Not save data in DataBase";
            }
        }

        public LoanParty GetNextLoanCode()
        {
            return loanGateway.GetNextLoanCode();
        }
    }
}