using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryManagementSystemFinalVersion.BLL;
using LibraryManagementSystemFinalVersion.MODEL;

namespace LibraryManagementSystemFinalVersion.UI
{
    public partial class AddShope : System.Web.UI.Page
    {
        ShopeManager shopeManager = new ShopeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllShopeInfo();
                shopeCodeTextBox.Text = LoadNextShopCode();
            }
            
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (saveButton.Text == "Update")
            {
                Shope shope = new Shope();
                shope.ShopeCode = shopeCodeTextBox.Text;
                shope.ShopeName = shopeNameTextBox.Text;
                shope.ShopePhone = phoneTextBox.Text;
                shope.ShopeAddress = addressTextArea.InnerText;
                shope.MonthlyRent = Convert.ToDouble(monthlyRentTextBox.Text);
                shope.OpeningBalance = Convert.ToDouble(openingBalanceTextBox.Text);

                shope.ShopeId = int.Parse(formWithShopIdHiddenField.Value);
                if (shopeManager.UpdateShope(shope))
                {
                    message.InnerText = "Updated Successfully!!";
                    saveButton.Text = "Save";
                    ClearTextBoxes();
                }
                else
                {
                    message.InnerText = "No data Update in Database!!";
                }
            }
            else
            {
                InsertShope();
            }
            LoadAllShopeInfo();
           
        }

        private void InsertShope()
        {
            Shope shope = new Shope();
            shope.ShopeCode = shopeCodeTextBox.Text;
            shope.ShopeName = shopeNameTextBox.Text;
            shope.ShopePhone = phoneTextBox.Text;
            shope.ShopeAddress = addressTextArea.InnerText;
            string monthlyRent = monthlyRentTextBox.Text;
            string shOpeningBalance = openingBalanceTextBox.Text;
            if (shopeCodeTextBox.Text == "" || shopeNameTextBox.Text == "" || phoneTextBox.Text == "" ||
                addressTextArea.InnerText == "" || monthlyRentTextBox.Text == "" || openingBalanceTextBox.Text == "")
            {
                message.InnerText = "All Fields are Required";
            }
            else
            {
                shope.MonthlyRent = Convert.ToDouble(monthlyRent);
                shope.OpeningBalance = Convert.ToDouble(shOpeningBalance);
                message.InnerText = shopeManager.Save(shope);
                LoadAllShopeInfo();
            }
        }

        private void ClearTextBoxes()
        {
            shopeCodeTextBox.Text = "";
            shopeNameTextBox.Text = "";
            phoneTextBox.Text = "";
            addressTextArea.InnerText = "";
            monthlyRentTextBox.Text = "";
            openingBalanceTextBox.Text = "";
        }
        protected void clearButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        protected void exitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        private void LoadAllShopeInfo()
        {
            List<Shope> shopeList = shopeManager.GetAllShopeInfo();
            showShopInfoGridView.DataSource = shopeList;
            showShopInfoGridView.DataBind();
        }

        private string LoadNextShopCode()
        {
            Shope shope = shopeManager.GetNextShopeCode();
            string shCode = shope.ShopeCode;
            int count;
            if (shCode == null)
            {
                count = 1;
            }
            else
            {
                count = (shCode[2] - '0')*10 + (shCode[3] - '0') + 1;
            }

            string nextCode = "Sh" + count.ToString("00");
            return nextCode; 
        }

        protected void updateButton_OnClick(object sender, EventArgs e)
        {
           GridViewRow clickedRow = (GridViewRow) ((LinkButton) sender).Parent.Parent;
           HiddenField shHiddenField = (HiddenField) clickedRow.FindControl("shopIdHiddenFieldGridView");
           int shId = int.Parse(shHiddenField.Value);
            Shope shope = shopeManager.GetShopeById(shId);
            if (LoadFormWithShopeId(shope))
            {
                saveButton.Text = "Update";
            }
        }

        private bool LoadFormWithShopeId(Shope shope)
        {
            if (shope != null)
            {
                shopeCodeTextBox.Text = shope.ShopeCode;
                shopeNameTextBox.Text = shope.ShopeName;
                phoneTextBox.Text = shope.ShopePhone;
                addressTextArea.InnerText = shope.ShopeAddress;
                monthlyRentTextBox.Text = shope.MonthlyRent.ToString();
                openingBalanceTextBox.Text = shope.OpeningBalance.ToString();
                formWithShopIdHiddenField.Value = shope.ShopeId.ToString();
                return true;
            }
            return false;

        }

        protected void deleteButton_OnClick(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((Control) sender).Parent.Parent;
            HiddenField hField = (HiddenField)row.FindControl("shopIdHiddenFieldGridView");
            int shId = int.Parse(hField.Value);
            if (shopeManager.DeleteShop(shId))
            {
                message.InnerText = "Deleted Successfully!!";
                LoadAllShopeInfo();
                ClearTextBoxes();
            }
            else
            {
                message.InnerText = "No data has been Deleted!!";
            }
        }
    }
}