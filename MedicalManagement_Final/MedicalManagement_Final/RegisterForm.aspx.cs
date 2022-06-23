using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MedicalManagement_Final
{
    public partial class RegisterForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Database.toggleConnection();
        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text== "")
            {
                MessageBox.Show("Your username cannot be empty");
                txtUsername.Focus();
            }
            else if(txtPassword.Text== "")
            {
                MessageBox.Show("Your password cannot be empty");
                txtPassword.Focus();
            }
            else if(txtPassword.Text != txtRepeatPassword.Text)
            {
                MessageBox.Show("Passwords do not match");
                txtPassword.Text = "";
                txtRepeatPassword.Text = "";
                txtPassword.Focus();
            }
            else
            {
                User user = new User();
                user = Database.GetUser(txtUsername.Text.Trim());
                if (user == null)
                {
                    User tmpUser = new User();
                    tmpUser.Username = txtUsername.Text;
                    tmpUser.Password = Encryption.EnryptString(txtPassword.Text);

                    tmpUser.Id = tmpUser.generateUniqueID();

                    Session["userProfile"] = tmpUser;
                    Session["userid"] = tmpUser.Id;

                    Response.Redirect("RegitserPeronalInfoForm.aspx");

                }
                else
                {
                    MessageBox.Show("This username already exists");
                }
            }

        }
    }
}