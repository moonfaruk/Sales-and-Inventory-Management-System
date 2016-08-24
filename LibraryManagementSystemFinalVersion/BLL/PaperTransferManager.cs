using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class PaperTransferManager
    {
        PaperTransferGateway paperTransferGateway = new PaperTransferGateway();
        public List<Press> GetAllPressInfoByDropDownList()
        {
            return paperTransferGateway.GetAllPressInfoByDropDownList();
        }

        public List<Paper> GetAllPaperInfoByDropDownList()
        {
            return paperTransferGateway.GetAllPaperInfoByDropDownList();
        }

        public PaperTransfer GetNextTransferNo()
        {
            return paperTransferGateway.GetNextTransferNo();
        }

        public string Save(PaperTransfer paperTransfer)
        {
            if (paperTransferGateway.Insert(paperTransfer) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save data in Database!!";
        }
    }
}