using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class SpacymenPartyManager
    {
        SpacymenPartyGateway spacymenPartyGateway = new SpacymenPartyGateway();
        public List<District> GetAllDistrictByDropDownList()
        {
            return spacymenPartyGateway.GetAllDistrictByDropDownList();
        }

        //public Party GetSpacymenParty(int i)
        //{
        //    return spacymenPartyGateway.GetSpacymenParty(i);
        //}

        public string Save(SpacymenParty spacymenParty)
        {
            if (spacymenPartyGateway.Insert(spacymenParty) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save data in Database!!";
        }

        public SpacymenParty GetNextPartyCode()
        {
            return spacymenPartyGateway.GetNextCode();
        }

        public List<SpacymenParty> GetAllSpacymenPartyList()
        {
            return spacymenPartyGateway.GetAllSpacymenPartyList();
        }

        public SpacymenParty GetAllSpacymenParties(int i)
        {
            return spacymenPartyGateway.GetAllSpacymenParties(i);
        }
    }
}