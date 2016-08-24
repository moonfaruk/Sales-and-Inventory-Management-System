using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class PPLiminationManager
    {
        PPLiminationGateway ppLiminationGateway = new PPLiminationGateway();

        public string Save(PPLimination ppLimination)
        {
            if (ppLiminationGateway.Insert(ppLimination) > 0)
            {
                return "Saved Successfully!!";

            }
            else
            {
                return "Could Not Save data in Database!!";
            }
        }

        public PPLimination GetNextPPLiminationCode()
        {
            return ppLiminationGateway.GetNextPPLiminationCode();
        }

        public PPLimination GetPpLiminations(int row_no)
        {
            return ppLiminationGateway.GetPpLiminations(row_no);
        }

        public List<PPLimination> GetAllPpLiminationInfo()
        {
            return ppLiminationGateway.GetAllPpLiminationInfo();
        }
    }
}