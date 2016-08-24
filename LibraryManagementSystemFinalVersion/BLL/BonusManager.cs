using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class BonusManager
    {
        BonusGateway bonusGateway = new BonusGateway();
        public List<District> GetAllDistrictByDropDownList()
        {
            return bonusGateway.GetAllDistrictByDropDownList();
        }

        public List<Party> GetAllPartiesByIdDropDownList()
        {
            return bonusGateway.GetAllPartiesByIdDropDownList();
        }

        public Party GetPartyName(int i)
        {
            return bonusGateway.GetPartyName(i);
        }

        public string Save(Bonus bonus)
        {
            if (bonusGateway.Insert(bonus) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save Data in Database!!";
        }

        public List<Bonus> GetAllBonus()
        {
            return bonusGateway.GetAllBonus();
        }

        public Bonus GetBonus(int i)
        {
            return bonusGateway.GetBonus(i);
        }

        public Bonus GetSearchInfo(string s)
        {
            return bonusGateway.GetSearchInfo(s);
        }
    }
}