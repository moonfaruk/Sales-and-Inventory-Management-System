using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class DistrictManager
    {
        DistrictGateway districtGateway = new DistrictGateway();

        public string Save(District district)
        {

            if (districtGateway.Insert(district) > 0)
            {
                return "Saved Successfully!!";
            }
            else
            {
                return "Could Not save Data in Database!!";
            }
        }

        public List<Division> GetAllDivisionByDropDownList()
        {
            return districtGateway.GetAllDivisionByDropDownList();
        }

        public List<District> GetAllDistrict()
        {
            return districtGateway.GetAllDistrict();
        }

        public District GetDistrict(int row_no)
        {
            return districtGateway.GetDistrict(row_no);
        }

        public District GetNextDistrictCode()
        {
            return districtGateway.GetNextDistrictCode();
        }
    }
}