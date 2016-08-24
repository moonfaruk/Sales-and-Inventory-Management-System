using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class District
    {

        public int DistrictId { get; set; }
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }



        public District(string districtCode, string districtName, string divisionName)
        {
            DistrictCode = districtCode;
            DistrictName = districtName;
            DivisionName = divisionName;
        }

        public District()
        {
            
        }
    }
}