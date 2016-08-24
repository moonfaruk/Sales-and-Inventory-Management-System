using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class PressManager
    {
        PressGateway pressGateway = new PressGateway();

        public string Save(Press press)
        {
            if (pressGateway.Insert(press) > 0)
            {
                return "Saved Successfully!!";
            }
            else
            {
                return "Could Not Save Data in Database!!";
            }
        }

        public Press GetNextPressCode()
        {
            return pressGateway.GetNextPressCode();
        }
    }
}