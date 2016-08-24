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
    public partial class AddWritter : System.Web.UI.Page
    {
        WritterManager writterManager = new WritterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Writter> writterList = writterManager.GetAllWritter();
                Session["writters"] = writterList;
                Session["active"] = -1;
                writterCodeTextBox.Text = LoadNextCode();
            }

        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            writterCodeTextBox.Text = "";
            writterNameTextBox.Text = "";
            writterPhoneTextBox.Text = "";
            writterAddressTextArea.InnerText = "";
            openingBalanceTextBox.Text = "";
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Writter writter = new Writter();
            writter.WritterCode = writterCodeTextBox.Text;
            writter.WritterName = writterNameTextBox.Text;
            writter.WritterPhone = writterPhoneTextBox.Text;
            writter.WritterAddress = writterAddressTextArea.InnerText;
            string openingBalance = openingBalanceTextBox.Text;
            if (writterCodeTextBox.Text == "" || writterNameTextBox.Text == "" || writterPhoneTextBox.Text == "" ||
                writterAddressTextArea.InnerText == "" || openingBalanceTextBox.Text == "")
            {
                message.InnerText = "All Fields are Required!!";
               

            }
            else
            {
                writter.WritterOpeningBalance = Convert.ToDouble(openingBalance);
                messageLabel.InnerText = writterManager.Save(writter);
                message.InnerText = "";
            }
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void firstButton_Click(object sender, EventArgs e)
        {
            Writter writter = writterManager.GetWritter(0);
            GetValueFromDatabase(writter);
            Session["active"] = 0;
        }

        private void GetValueFromDatabase(Writter writter)
        {
            writterCodeTextBox.Text = writter.WritterCode;
            writterNameTextBox.Text = writter.WritterName;
            writterPhoneTextBox.Text = writter.WritterPhone;
            writterAddressTextArea.InnerText = writter.WritterAddress;
            openingBalanceTextBox.Text = writter.WritterOpeningBalance.ToString();
        }

        protected void nextButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active++;
            List<Writter> writterList = (List<Writter>)(Session["writters"]);
            if (active >= writterList.Count)
                active = 0;
            Writter writter = writterManager.GetWritter(active);
            GetValueFromDatabase(writter);
            Session["active"] = active;
        }

        protected void previousButton_Click(object sender, EventArgs e)
        {
            int active = (int)Session["active"];
            active--;
            List<Writter> writterList = (List<Writter>)(Session["writters"]);
            if (active <= -1)
                active = writterList.Count - 1;
            Writter writter = writterManager.GetWritter(active);
            GetValueFromDatabase(writter);
            Session["active"] = active;
        }

        protected void lastButton_Click(object sender, EventArgs e)
        {
            List<Writter> writterList = (List<Writter>)Session["writters"];
            int x = writterList.Count - 1;
            Writter writter = writterManager.GetWritter(x);
            GetValueFromDatabase(writter);
            Session["active"] = x;
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            var w = writterTextBox.Value;
            Writter writter = writterManager.GetSearchInfo(w);
            if (writter.WritterCode == null)
            {
                message.InnerText = "Invalid Writter Code!!";

            }
            else
            {
                GetValueFromDatabase(writter);
                message.InnerText = "";
            }
        }

        private string LoadNextCode()
        {
            Writter writter = writterManager.GetNextCode();
            string wCode = writter.WritterCode;
            int c;
            if (wCode == null)
            {
                c = 1;
            }
            else
            {
                c = (wCode[2] - '0')*10 + (wCode[3] - '0') + 1;
            }
            string nextCode = "Wr" + c.ToString("00");
            return nextCode;
        }
    }
}