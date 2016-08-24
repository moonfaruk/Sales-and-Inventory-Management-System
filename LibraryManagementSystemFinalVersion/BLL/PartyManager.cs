using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class PartyManager
    {
        PartyGateway partyGateway = new PartyGateway();
        public string Insert(Party party)
        {
            if (partyGateway.Insert(party) > 0)
            {
                return "Saved Successfully!!";

            }
            return "Could Not Save data in Database!!";
        }

        public List<Division> GetAllDivisionByDropDownList()
        {
            return partyGateway.GetAllDivisionByDropDownList();
        }

        public List<District> GetAllDistrictByDropDownList()
        {
            return partyGateway.GetAllDistrictByDropDownList();
        }

        public Party GetNextPartyCode()
        {
            return partyGateway.GetNextPartyCode();
        }

        public List<Party> GetAllPartyInfo()
        {
            return partyGateway.GetAllPartyInfo();
        }

        public Party GetParties(int i)
        {
            return partyGateway.GetParties(i);
        }
        public Party GetSearchInfo(string code)
        {
            return partyGateway.GetSearchInfo(code);
        }

        public DataTable GetEmpPartyBankReportData()
        {
            return partyGateway.GetEmpPartyBankReportData();
        }

        public Division GetDivision(int i)
        {
            return partyGateway.GetDivision(i);
        }

        public District GetDistrict(int districtId)
        {
            return partyGateway.GetDistrict(districtId);
        }
    }
}