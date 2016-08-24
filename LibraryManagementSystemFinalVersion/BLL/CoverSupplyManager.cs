using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class CoverSupplyManager
    {
        CoverSupplyGateway coverSupplyGateway = new CoverSupplyGateway();
        public List<Binder> GetAllBinderInfoByDropDownList()
        {
            return coverSupplyGateway.GetAllBinderInfoByDropDownList();
        }

        public List<Group> GetAllGroupInfoByDropDownList()
        {
            return coverSupplyGateway.GetAllGroupInofByDropDownList();
        }

        public List<BookInfo> GetAllBookInfoByDropDownList()
        {
            return coverSupplyGateway.GetAllBookInfoByDropDownList();
        }

        public CoverSupply GetNextSupplyNo()
        {
            return coverSupplyGateway.GetNextSupplyNo();
        }

        public string Save(CoverSupply coverSupply)
        {
            if (coverSupplyGateway.Insert(coverSupply) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save data in Database!!";
        }

        public List<CoverSupply> GetAllCoverSupply()
        {
            return coverSupplyGateway.GetAllCoverSupply();
        }

        public CoverSupply GetSupplier(int i)
        {
            return coverSupplyGateway.GetSupplier(i);
        }

        public CoverSupply GetSearchInfo(string s)
        {
            return coverSupplyGateway.GetSearchInfo(s);
        }

        public DataTable GetCoverSupplyReportData()
        {
            return coverSupplyGateway.GetCoverSupplyReportData();
        }
    }
}