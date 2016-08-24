using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class PaperOrderManager
    {
        PaperOrderGateway paperOrderGateway = new PaperOrderGateway();
        public List<Supplier> GetSupplierInfoByDropDownList()
        {
            return paperOrderGateway.GetSupplierInfoByDropDownList();
        }

        public List<Press> GetAllPressInfoByDropDownList()
        {
            return paperOrderGateway.GetAllPressInfoByDropDownList();
        }

        public List<Paper> GetAllPaperInfoByDropDownList()
        {
            return paperOrderGateway.GetAllPaperInfoByDropDownList();
        }

        public PaperOrder GetNextSlipNo()
        {
            return paperOrderGateway.GetNextSlipNo();
        }

        public string Save(PaperOrder paperOrder)
        {
            if (paperOrderGateway.Insert(paperOrder) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save data in Database!!";
        }

        public List<PaperOrder> GetAllPaperOrder()
        {
            return paperOrderGateway.GetAllPaperOrder();
        }

        public PaperOrder GetPaperOrder(int i)
        {
            return paperOrderGateway.GetPaperOrder(i);
        }

        public DataTable GetPaperOrderReportData()
        {
            return paperOrderGateway.GetPaperOrderReportData();
        }
    }
}