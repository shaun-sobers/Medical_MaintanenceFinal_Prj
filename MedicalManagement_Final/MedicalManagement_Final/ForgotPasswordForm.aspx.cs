using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MedicalManagement_Final
{
    public partial class ForgotPasswordForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtSecurityQuestion.Text = "Enter Username to proceed";
                txtNewPassword.Visible = false;
                txtRepeatPassword.Visible = false;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            User user = new User();
            user = Database.SearchUsername(txtUsername.Text.Trim());
            if(user == null)
            {
                MessageBox.Show("This user does not exist");
                txtUsername.Text = "";
            }
            else
            {
                Person prs = new Person();
                prs = Database.GetAccount(user.Id);

                if (prs != null)
                {
                    Session["tmpAccnt"] = prs.Id;
                    txtUsername.Enabled = false;
                    txtSecurityQuestion.Visible = txtSecurityAnswer.Visible == true;
                    txtSecurityQuestion.Enabled = false;
                    txtSecurityQuestion.Text = prs.SecurityQuestion;
                }
            }



        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            if(txtNewPassword.Text == txtRepeatPassword.Text)
            {
                Database.UpdatePassword(Session["tmpAccnt"].ToString(),Encryption.EnryptString(txtNewPassword.Text.Trim()));
                Session["tmpAccnt"] = null;
                MessageBox.Show("Password was sucessfully changed");
                Response.Redirect("LoginForm.aspx");
            }
            else
            {
                MessageBox.Show("Passwords do not match");
                txtNewPassword.Text = "";
                txtRepeatPassword.Text = "";
            }
        }

        protected void btnNext2_Click(object sender, EventArgs e)
        {

            User user = new User();
            user = Database.SearchUsername(txtUsername.Text.Trim());
            Person prs = new Person();
            prs = Database.GetAccount(user.Id);

            if (txtSecurityAnswer.Text == prs.SecurityAnswer)
            {
                txtSecurityQuestion.Enabled = false;
                txtSecurityAnswer.Enabled = false;
                txtNewPassword.Visible = true;
                txtRepeatPassword.Visible = true;
                btnResetPassword.Visible = true;
            }
            else
            {
                MessageBox.Show("Invalid Answer");
            }
        }
    }
}