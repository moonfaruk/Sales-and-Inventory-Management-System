using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagementSystemFinalVersion.DAL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.BLL
{
    public class WritterManager
    {
        WritterGateway writterGateway = new WritterGateway();
        public string Save(Writter writter)
        {
            if (writterGateway.Insert(writter) > 0)
            {
                return "Saved Successfully!!";
            }
            return "Could Not Save data in Database!!";

        }

        public Writter GetNextCode()
        {
            return writterGateway.GetNextCode();
        }

        public List<Writter> GetAllWritter()
        {
            return writterGateway.GetAllWritter();
        }

        public Writter GetWritter(int i)
        {
            return writterGateway.GetWritter(i);
        }

        public Writter GetSearchInfo(string s)
        {
            return writterGateway.GetSearchInfo(s);
        }
    }
}