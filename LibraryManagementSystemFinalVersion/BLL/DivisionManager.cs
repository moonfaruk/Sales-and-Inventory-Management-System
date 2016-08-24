using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class DivisionManager
    {
        DivisionGateway divisionGateway = new DivisionGateway();

        public string Save(Division division)
        {
            if (divisionGateway.Insert(division) > 0)
            {
                return "Saved Successfully!!";
            }
            else
            {
                return "Could Not Save data in Database!!";
            }
        }

        ////public Division GetFirstDivision()
        ////{
        ////    return divisionGateway.GetFirstDivision();
        ////}


        public List<Division> GelAllDivisions()
        {
            return divisionGateway.GetAllDivisions();
        }

        public Division GetDivision(int row_no)
        {
            return divisionGateway.GetDivision(row_no);
        }

        public Division GetNextDivisionCode()
        {
            return divisionGateway.GetNextDivisionCode();
        }
    }
}