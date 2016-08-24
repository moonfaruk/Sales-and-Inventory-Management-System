using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class PaperPrintManager
    {
        PaperPrintGateway paperPrintGateway = new PaperPrintGateway();
        public List<Press> GetAllPressInfoByDropDownList()
        {
            return paperPrintGateway.GetAllPressInfoByDropDownList();

        }

        public List<Group> GetAllGroupInfoByDropDownList()
        {
            return paperPrintGateway.GetAllGroupInfoByDropDownList();
        }

        public List<BookInfo> GetAllBookInfoByDropDownList()
        {
            return paperPrintGateway.GetAllBookInfoByDropDownList();
        }

        public List<Paper> GetAllPaperInfoByDropDownList()
        {
            return paperPrintGateway.GetAllPaperInfoByDropDownList();
        }

        public PaperPrint GetNextOrderNo()
        {
            return paperPrintGateway.GetNextOrderNo();
        }

        public string Save(PaperPrint paperPrint)
        {
            if (paperPrintGateway.Insert(paperPrint) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save data In Database!!";
        }

        public List<PaperPrint> GetAllPaperPrint()
        {
            return paperPrintGateway.GetAllPaperPrint();
        }

        public PaperPrint GetPaperPrint(int i)
        {
            return paperPrintGateway.GetPaperPrint(i);
        }
    }
}