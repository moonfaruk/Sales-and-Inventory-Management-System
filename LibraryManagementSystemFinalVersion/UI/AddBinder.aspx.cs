using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryManagementSystemFinalVersion.BLL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.UI
{
    public partial class AddBinder : System.Web.UI.Page
    {
        BinderManager binderManager = new BinderManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Binder> binderList = binderManager.GetAllBinderList();
                binderCodeTextBox.Text = LoadBinderNextCode();
                Session["binders"] = binderList;
                Session["active"] = -1;
          
            }
                
        }

        private string LoadBinderNextCode()
        {
            Binder binder = binderManager.GetNextBinderCode();
            string code = binder.BinderCode;
            int count;
            if (code == null)
            {
                count = 1;
            }
            else
            {
                count = (code[3] - '0') * 10 + (code[4] - '0') + 1;
            }

            string nextCode = "Bin" + count.ToString("00");
            return nextCode; 
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Binder binder = new Binder();
            binder.BinderCode = binderCodeTextBox.Text;
            binder.BinderName = binderNameTextBox.Text;
            binder.BinderAddress = binderAddressTextArea.InnerText;
            string openingBalance = binderOpeningBalanceTextBox.Text;
            if (binderCodeTextBox.Text == "" || binderNameTextBox.Text == "" || binderAddressTextArea.InnerText == "" ||
                binderOpeningBalanceTextBox.Text == "")
            {
                message.InnerText = "All Fields are Required!!";
            }
            else
            {
                binder.BinderOpeningBalance = Convert.ToDouble(openingBalance);
                messageLabel.InnerText = binderManager.Save(binder);
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            binderCodeTextBox.Text = "";
            binderNameTextBox.Text = "";
            binderAddressTextArea.InnerText = "";
            binderOpeningBalanceTextBox.Text = "";
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            Binder binder = binderManager.GetBinder(0);
            GetValueFromDataBase(binder);
            Session["active"] = 0;
        }

        private void GetValueFromDataBase(Binder binder)
        {
            binderCodeTextBox.Text = binder.BinderCode;
            binderNameTextBox.Text = binder.BinderName;
            binderAddressTextArea.InnerText = binder.BinderAddress;
            binderOpeningBalanceTextBox.Text = binder.BinderOpeningBalance.ToString();
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<Binder> binderList = (List<Binder>)(Session["binders"]);
            if (active >= binderList.Count)
                active = 0;
            Binder binder = binderManager.GetBinder(active);
            GetValueFromDataBase(binder);
            Session["active"] = active;
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active--;
            List<Binder> binderList = (List<Binder>)(Session["binders"]);
            if (active <= -1)
                active = binderList.Count - 1;
            Binder binder = binderManager.GetBinder(active);
            GetValueFromDataBase(binder);
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<Binder> binderlList = (List<Binder>)Session["binders"];
            int x = binderlList.Count - 1;
            Binder binder = binderManager.GetBinder(x);
            GetValueFromDataBase(binder);
            Session["active"] = x;
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            var b = bTextBox.Value ;
            Binder binder = binderManager.GetSearchInfo(b);
            if (binder.BinderCode == null)
            {
                message.InnerText = "Invalid Binder Code!!";

            }
            else
            {
                GetAllBinderProperty(binder);
                message.InnerText = "";
            }
        }

        private void GetAllBinderProperty(Binder binder)
        {
            binderCodeTextBox.Text = binder.BinderCode;
            binderNameTextBox.Text = binder.BinderName;
            binderAddressTextArea.InnerText = binder.BinderAddress;
            binderOpeningBalanceTextBox.Text = binder.BinderOpeningBalance.ToString();
        }
    }
}