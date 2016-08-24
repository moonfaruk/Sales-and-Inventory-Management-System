using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemFinalVersion.MODEL
{
    public class Paper
    {

        public int PaperId { get; set; }
        public string PaperCode { get; set; }
        public string PaperName { get; set; }

        public Paper(string paperCode, string paperName)
        {
            PaperCode = paperCode;
            PaperName = paperName;
        }

        public Paper()
        {

        }
    }
}