using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class PersonalLoanPaymentManager
    {
        PersonalLoanPaymentGateway personalLoanPaymentGateway = new PersonalLoanPaymentGateway();
        public List<Party> GetAllPartiesByIdDropDownList()
        {
            return personalLoanPaymentGateway.GetAllPartiesByIdDropDownList();
        }

        public string Save(PersonalLoanPayment personalLoanPayment)
        {
            if (personalLoanPaymentGateway.Insert(personalLoanPayment) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save data in Database!!";
        }

        public List<PersonalLoanPayment> GetAllPersonalLoanList()
        {
            return personalLoanPaymentGateway.GetAllPersonalLoanList();
        }

        public PersonalLoanPayment GetLoanParties(int i)
        {
            return personalLoanPaymentGateway.GetLoanParties(i);
        }
    }
}