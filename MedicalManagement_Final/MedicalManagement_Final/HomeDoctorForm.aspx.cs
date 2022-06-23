using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace MedicalManagement_Final
{
    public partial class HomeDoctorForm : System.Web.UI.Page
    {
        List<Person> listP;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userid"] == null)
            {
                MessageBox.Show("You must be logged in to view this page");
                Response.Redirect("LoginForm.aspx");
            }

            List<HospitalRoom> hr = new List<HospitalRoom>();
            hr = Database.GetHospitalRooms();


            List<Appointment> listAppointment = new List<Appointment>();
            List<DoctorPatients> doctorPatients = new List<DoctorPatients>();
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

                List<Message> msgList = new List<Message>();
                int count;
                msgList = Database.GetMessageList(Session["userid"].ToString());


                count = msgList.Count(x => x.Status == 0);
                btnInbox.Text = "Inbox(" + count + ")";


                listAppointment = Database.GetDoctorAppointmentList(Session["userid"].ToString());

                List<Appointment> listRequestAppointment = new List<Appointment>();
                listRequestAppointment = listAppointment.Where(x => x.Confirmed.Trim() == "Requested").ToList();
                gvAppointment.DataSource = listRequestAppointment;
                gvAppointment.DataBind();


                List<Appointment> ConfirmList = new List<Appointment>();

                ConfirmList = listAppointment.Where(x => x.Confirmed.Trim() == "Confirmed").ToList();

                gvConfirmedAppointments.DataSource = ConfirmList;
                gvConfirmedAppointments.DataBind();


                doctorPatients = Database.GetDoctorConfirmAppList(Session["userid"].ToString());

                gvAdmittedPatients.DataSource = doctorPatients;
                gvAdmittedPatients.DataBind();

                List<Person> ListOfPeople = new List<Person>();
                ListOfPeople = Database.GetPeopleList();


                foreach (Person item in ListOfPeople)
                {
                    ddlUsers.Items.Add("(" + item.Type + ") " + item.FullName());

                }

            }



        }



        protected void btnInbox_Click(object sender, EventArgs e)
        {
            Response.Redirect("InboxForm.aspx");
        }

        protected void gvAppointment_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Do you wish to Confirm this appointment ", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string UserAnswer = Microsoft.VisualBasic.Interaction.InputBox("Your Message ", "Pick a date for this appointment", DateTime.Today.ToString());
                DateTime date = Convert.ToDateTime(UserAnswer);
                 Database.ConfirmAppointment(gvAppointment.Rows[e.NewSelectedIndex].Cells[0].Text,date);

                MessageBox.Show("Appointment Confirmed");
                Response.Redirect("HomeDoctorForm.aspx");
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

            
        }

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            Person tmpPerson = new Person();
            tmpPerson = (Person)Session["info"];
            Response.Redirect("RegitserPeronalInfoForm.aspx");
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            List<Person> listP = new List<Person>();
            listP = Database.GetPeopleList();
            
            List<DoctorPatients> doctorPatients = new List<DoctorPatients>();
            doctorPatients = Database.GetDoctorConfirmAppList(Session["userid"].ToString());
            doctorPatients = doctorPatients.Where(x => x.PatientId == listP[ddlUsers.SelectedIndex].Id).ToList();


        if(doctorPatients.Count > 0)
            {
                Session["admittedId"] = doctorPatients[doctorPatients.Count() - 1].AdmittedId;
            }

             Session["searchUser"] = listP[ddlUsers.SelectedIndex].Id;
            Response.Redirect("InformationForm.aspx");
        }

        protected void gvConfirmedAppointments_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you wish to admit this patient? \n You will be redirected to the admission page ", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                List<Appointment> tmpList = new List<Appointment>();
                tmpList = Database.GetDoctorAppointmentList(Session["userid"].ToString());
                tmpList = tmpList.Where(x => x.Confirmed.Trim() == "Confirmed").ToList();

                Session["searchUser"] = tmpList[e.NewSelectedIndex].PatientId;
                Response.Redirect("InformationForm.aspx");
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

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
    }
}