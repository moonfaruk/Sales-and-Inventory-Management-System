using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class PaperManager
    {
        PaperGateway paperGateway = new PaperGateway();

        public string Save(Paper paper)
        {
            if (paperGateway.Insert(paper) > 0)
            {
                return "Saved Successfull!!";
            }
            else
            {
                return "Could Not save data in database!!";
            }
        }

        public Paper GetNextPaperCode()
        {
            return paperGateway.GetNextPaperCode();
        }
    }
}