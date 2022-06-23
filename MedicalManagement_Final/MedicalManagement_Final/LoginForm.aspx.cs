using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace MedicalManagement_Final
{
    public partial class Inde : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Database.toggleConnection();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "" || txtPassword.Text== "")
            {
                MessageBox.Show("Username and Password cannot be empty");
            }
            else
            {

                User tmpUser = new User();
                tmpUser.Username = txtUsername.Text;
                tmpUser.Password = txtPassword.Text;
                User tmp2 = new User();
                tmp2 = Database.GetUser(txtUsername.Text);
                if(tmp2 == null)
                {
                    MessageBox.Show("This username does not exist");
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                }
                else
                {

                    if (tmp2.Password == Encryption.EnryptString(txtPassword.Text))
                    {
                        Person person = new Person();
                        person = Database.GetAccount(tmp2.Id);

                        Session["userid"] = tmp2.Id;
                        switch (person.Type)
                        {
                            default:
                                break;

                            case "Patient":
                                Response.Redirect("HomePatientForm.aspx");
                                break;

                            case "Nurse":
                                Response.Redirect("HomeNurseForm.aspx");
                                break;

                            case "Doctor":
                                Response.Redirect("HomeDoctorForm.aspx");
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password");
                    }
                }
            }
           
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterForm.aspx");
        }
    }
}