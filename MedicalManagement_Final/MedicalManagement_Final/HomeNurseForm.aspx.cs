using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MedicalManagement_Final
{
    public partial class HomeNurseForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userid"] == null)
            {
                MessageBox.Show("You must be logged in to view this page");
                Response.Redirect("LoginForm.aspx");
            }

            if (!IsPostBack)
            {
                
                string gender;
                Person person = new Person();
                person = Database.GetAccount(Session["userid"].ToString());
                Session["info"] = person;
                imgUser.ImageUrl = "Images/" + person.Image;

                lblBirthday.Text = "DOB: " + Encryption.ConvertDate(person.Birthday);
                lblBirthday.ForeColor = System.Drawing.Color.Black;

                if (person.Sex.Trim() == "Male")
                {
                    gender = "Mr, ";
                    lblUsersName.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    gender = "Mrs, ";
                    lblUsersName.ForeColor = System.Drawing.Color.Pink;
                }
                lblUsersName.Text = gender + person.FullName();
                LblWelcome.Text = "Welcome, " + person.FirstName;

                List<DoctorPatients> tmpList = new List<DoctorPatients>();
                tmpList = Database.GetNurseConfirmAppList(Session["userid"].ToString());
                gvAppointments.DataSource = tmpList;
                gvAppointments.DataBind();

                List<Message> msgList = new List<Message>();
                int count;
                msgList = Database.GetMessageList(Session["userid"].ToString());
                count = msgList.Count(x => x.Status == 0);
                btnInbox.Text = "Inbox(" + count + ")";

                foreach (var item in tmpList)
                {
                    Person tmpP = new Person();
                    tmpP = Database.GetAccount(item.PatientId);
                    List<string> list = new List<string>();
                    if (list.Contains(tmpP.FullName()))
                    {
                        int counter = list.IndexOf(tmpP.FullName());
                        list[counter] = tmpP.FullName();
                    }
                    else
                    {
                        dlPatients.Items.Add(tmpP.FullName());
                        list.Add(tmpP.FullName());
                    }


                }

                

            }
        }



        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            
            Person tmpPerson = new Person();
            tmpPerson = Database.GetAccount(Session["userid"].ToString());
            Session["info"] = tmpPerson;
            Response.Redirect("RegitserPeronalInfoForm.aspx");
            
        }

        protected void btnInbox_Click(object sender, EventArgs e)
        {
            Response.Redirect("InboxForm.aspx");
        }

        protected void btnLoggout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to log out? ", "Confirm Logout", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Session.Abandon();

                Response.Redirect("LoginForm.aspx");
                MessageBox.Show("You have sucessfully Logged out");
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            List<DoctorPatients> tmpList = new List<DoctorPatients>();
            tmpList = Database.GetNurseConfirmAppList(Session["userid"].ToString());

            Session["searchUser"] = tmpList[dlPatients.SelectedIndex].PatientId;
            Session["nurseSearch"] = tmpList[dlPatients.SelectedIndex].PatientId;
            Session["admittedId"] = tmpList[dlPatients.SelectedIndex].AdmittedId;


           Response.Redirect("InformationForm.aspx");

        }
    }
}