using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MedicalManagement_Final
{
    public partial class RequestAppointmentForm : System.Web.UI.Page
    {
        List<Person> drsNames = new List<Person>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> Appointmentlist = new List<string>();
                Appointmentlist.Add("Regular Check Up");
                Appointmentlist.Add("Pregnancy");
                Appointmentlist.Add("Kids Check up");
                Appointmentlist.Add("Eye Check up");


                ddlAppointment.DataSource = Appointmentlist;
                ddlAppointment.DataBind();

                List<string> Seveirtylist = new List<string>();
                Seveirtylist.Add("Urgent");
                Seveirtylist.Add("Follow up Consultation");
                Seveirtylist.Add("Minor Urgancy");

                ddlSeverity.DataSource = Seveirtylist;
                ddlSeverity.DataBind();


                drsNames = Database.GetDoctorsList();
                List<string> strings = new List<string>();
                foreach (Person person in drsNames)
                {
                    strings.Add("DR. " + person.FullName());
                }

                ddlDrsNames.DataSource = strings;
                ddlDrsNames.DataBind();
            }
            

        }

        protected void btnSendRequest_Click(object sender, EventArgs e)
        {

            drsNames = Database.GetDoctorsList();
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to send this Appointment Request? ", "Appointment Request", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Appointment tmpAppointment = new Appointment();

                tmpAppointment.PatientId = Session["userid"].ToString();
                tmpAppointment.DoctorsId = drsNames[ddlDrsNames.SelectedIndex].Id;
                tmpAppointment.ReasonFor = txtReasonfor.Text;
                tmpAppointment.ExtraInfo = txtExtraInfo.Text;
                tmpAppointment.RequestDate = DateTime.Now;
                tmpAppointment.ConfirmDate = DateTime.MaxValue;
                tmpAppointment.Severity = ddlSeverity.SelectedValue;
                tmpAppointment.TypeOfAppointment = ddlAppointment.SelectedValue;
                tmpAppointment.Confirmed = "Requested";
                  Database.CreateAppointment(tmpAppointment);
                MessageBox.Show("Appointment request was sent");
                Person tmpPers = new Person();
                tmpPers = Database.GetAccount(Session["userid"].ToString());

                switch (tmpPers.Type)
                {
                    case "Patient":
                        Response.Redirect("HomePatientForm.aspx");
                        break;

                    case "Doctor":
                        Response.Redirect("HomeDoctorForm.aspx");
                        break;

                    case "Nurse":
                        Response.Redirect("HomeNurseForm.aspx");
                        break;
                }

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtExtraInfo.Text = "";
            txtReasonfor.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to cancel? ", "Return to previous page", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Person tmpPers = new Person();
                tmpPers = Database.GetAccount(Session["userid"].ToString());

                switch (tmpPers.Type)
                {
                    case "Patient":
                        Response.Redirect("HomePatientForm.aspx");
                        break;

                    case "Doctor":
                        Response.Redirect("HomeDoctorForm.aspx");
                        break;

                    case "Nurse":
                        Response.Redirect("HomeNurseForm.aspx");
                        break;
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
    }
}