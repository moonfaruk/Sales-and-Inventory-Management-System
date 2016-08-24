using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class Division
    {
        public int DivisionId { get; set; }
        public string DivisionCode { get; set; }
        public string DivisionName { get; set; }

        public Division(string divisionCode, string divisionName)
        {
            DivisionCode = divisionCode;
            DivisionName = divisionName;
        }

        public Division()
        {

        }
    }
}