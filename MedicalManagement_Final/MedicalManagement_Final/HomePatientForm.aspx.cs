using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MedicalManagement_Final
{
    public partial class HomePatientForm : System.Web.UI.Page
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
                imgUser.ImageUrl = "Images/"+person.Image;
                lblBirthday.Text = "DOB: "+Encryption.ConvertDate(person.Birthday);
                lblBirthday.ForeColor = System.Drawing.Color.Black;
                if(person.Sex.Trim() == "Male")
                {
                    gender = "Mr, ";
                    lblUsersName.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    gender = "Mrs, ";
                    lblUsersName.ForeColor = System.Drawing.Color.Pink;
                }
                lblUsersName.Text = gender+person.FullName();
                lblWelcome.Text = "Welcome, " + person.FirstName;
                List<Appointment> listApp = new List<Appointment>();
                listApp = Database.GetAppointmentList(Session["userid"].ToString());
                Person tmpDoctor = new Person();
                string msg;
                foreach (Appointment app in listApp)
                {
                    tmpDoctor = Database.GetAccount(app.DoctorsId);
                    msg = "- Doctor: Dr," + tmpDoctor.LastName + "\t/ Reason for appointment: " + app.ReasonFor + "\t/ Appointment Date: " + app.ConfirmDate + "\t/ Confirmed: " + app.Confirmed;

                    if (app.ConfirmDate == Convert.ToDateTime("9999-12-31 11:59:59 PM"))
                    {
                        msg = "- Doctor: Dr," + tmpDoctor.LastName + "\t/ Reason for appointment: " + app.ReasonFor + "\t/ Confirmed: " + app.Confirmed;
                    }

                    lbAppointment.Items.Add(msg);
                    if (app.ConfirmDate.Date == DateTime.Today.Date)
                    {
                        MessageBox.Show("You have an appointment Today with Dr:" + tmpDoctor.LastName);
                    }
                }

                List<Message> msgList = new List<Message>();
                int count;
                msgList = Database.GetMessageList(Session["userid"].ToString());
                count = msgList.Count(x => x.Status == 0);
                btnInbox.Text = "Inbox(" + count + ")";

                List<Perscription> perscriptions = new List<Perscription>();
                perscriptions = Database.GetPatientsPerscriptionList(Session["userid"].ToString());

                foreach (var item in perscriptions)
                {
                    lboxPerscription.Items.Add("Perscription: " + item.perscriptionType + ", Length: " + item.Length + ", Date: " + item.PerscriptionDate);
                }
            }

        }

        protected void btnReqAppointment_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequestAppointmentForm.aspx");
        }

        protected void btnInbox_Click(object sender, EventArgs e)
        {
            Response.Redirect("InboxForm.aspx");
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Database.GetAppointmentTable(Session["userid"].ToString());

            Person tmpPerson = new Person();
            tmpPerson = (Person)Session["info"];

            string attachment = "attachment; filename="+tmpPerson.FirstName+","+tmpPerson.LastName+"_AppointmentList.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.ms-excel";
            string tab = "";
            foreach (DataColumn dc in dt.Columns)
            {
                Response.Write(tab + dc.ColumnName);
                tab = "\t";
            }
            Response.Write("\n");
            int i;
            foreach (DataRow dr in dt.Rows)
            {
                tab = "";
                for (i = 0; i < dt.Columns.Count; i++)
                {
                    Response.Write(tab + dr[i].ToString());
                    tab = "\t";
                }
                Response.Write("\n");
            }
            Response.End();
        }

        protected void Cal_DayRender(object sender, DayRenderEventArgs e)
        {
            DataTable dt = new DataTable();
            List<Appointment> app = new List<Appointment>();
            app = Database.GetAppointmentList(Session["userid"].ToString());

            List<Appointment> listApp = new List<Appointment>();
            listApp = app.Where(x => x.Confirmed.Trim() == "Confirmed").ToList();
            dt.Columns.Add("Appointment");
            dt.Columns.Add("AppointmentConfirmDate");
            foreach (Appointment appoint in listApp)
            {
                Person tmpP = new Person();
                tmpP = Database.GetAccount(appoint.DoctorsId);
                dt.Rows.Add("- Appointment:("+appoint.ReasonFor+")\n\nWith Dr: "+tmpP.LastName,Encryption.ConvertDate(appoint.ConfirmDate));
            }

            foreach (System.Data.DataRow row in dt.Rows)
            {
                if (Convert.ToDateTime(e.Day.Date) == Convert.ToDateTime(row["AppointmentConfirmDate"]))
                {
                    e.Cell.Controls.Add(new System.Web.UI.WebControls.Label { Text = "<br>" });
                    e.Cell.Controls.Add(new System.Web.UI.WebControls.Label { Text = row["Appointment"].ToString() });
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to log out? ", "Logout?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Session.Abandon();
                Response.Redirect("LoginForm.aspx");
                MessageBox.Show("Sucessfully Logged Out");

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            Person tmpPerson = new Person();
            tmpPerson = Database.GetAccount(Session["userid"].ToString());
            Session["info"] = tmpPerson;
            Response.Redirect("RegitserPeronalInfoForm.aspx");

        }

        protected void btnExportPers_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Database.GetPatientsPerscriptionTable(Session["userid"].ToString());


            Person tmpPerson = new Person();
            tmpPerson = (Person)Session["info"];

            string attachment = "attachment; filename=" + tmpPerson.FirstName + "," + tmpPerson.LastName + "_PerscriptionList.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.ms-excel";
            string tab = "";
            foreach (DataColumn dc in dt.Columns)
            {
                Response.Write(tab + dc.ColumnName);
                tab = "\t";
            }
            Response.Write("\n");
            int i;
            foreach (DataRow dr in dt.Rows)
            {
                tab = "";
                for (i = 0; i < dt.Columns.Count; i++)
                {
                    Response.Write(tab + dr[i].ToString());
                    tab = "\t";
                }
                Response.Write("\n");
            }
            Response.End();
        }

        protected void btnLoggout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to log out? ", "Confirm Logout", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Session["userid"] = null;
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