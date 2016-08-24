using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class ShopeManager
    {
        ShopeGateway shopeGateway = new ShopeGateway();
        public string Save(Shope shope)
        {
            if (shopeGateway.Insert(shope) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not save data in Database!!";
        }

        public List<Shope> GetAllShopeInfo()
        {
            return shopeGateway.GetAllShopeInfo();
        }


        public Shope GetNextShopeCode()
        {
            return shopeGateway.GetNextShopeCode();
        }

        public Shope GetShopeById(int shId)
        {
            return shopeGateway.GetShopeById(shId);
        }

        public bool UpdateShope(Shope shope)
        {
            bool isUpdated = false;
            if (shope.ShopeId > 0)
            {
                isUpdated = shopeGateway.UpdateShope(shope);
            }
            return isUpdated;

        }

       
        public bool DeleteShop(int shId)
        {
            bool isDeleted = shopeGateway.DeleteShop(shId);
            return isDeleted;
        }
    }
}