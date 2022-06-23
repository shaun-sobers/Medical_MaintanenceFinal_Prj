using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MedicalManagement_Final
{
    public partial class InformationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Person person = new Person();
            person = Database.GetAccount(Session["searchUser"].ToString());
            person.LoadAllergies();
            lblName.Text = person.FullName();
            lblBirthday.Text = person.Birthday.ToString();
            imgProfile.ImageUrl = "~/Images/" + person.Image;
            lblGender.Text = person.Sex;

            if (person.Type != "Patient")
            {
                ddlNurse.Visible = false;
                ddlRoom.Visible = false;
                gvAllergies.Visible = false;
                gvAppointmentHistory.Visible = false;
                gvPerscriptionHistory.Visible = false;
                lblAllergyList.Visible = false;
                lblAppointmentList.Visible = false;
                lblPerscriptionList.Visible = false;
                lblNurse.Visible = false;
                lblRoom.Visible = false;
                btnAdmit.Visible = false;
                btnDischarge.Visible = false;
                btnSaveAdmission.Visible = false;
                btnPerscription.Visible = false;

            }
            else
            {

                if (Session["admittedId"] != null)
                {
                    List<PatientNote> patNotes = new List<PatientNote>();
                    patNotes = Database.GetDoctorsNote(Session["admittedId"].ToString());


                    foreach (var item in patNotes)
                    {
                        Person tmpP = new Person();
                        tmpP = Database.GetAccount(item.NoteSenderId);
                        lbNotes.Items.Add("---" + item.Message + "\t Date: " + item.SentDate + "\n -Sent by (" + tmpP.Type + ")" + tmpP.FullName());
                    }
                }
                btnAddNotes.Visible = true;
                txtAddNote.Visible = true;
                lblAddNotes.Visible = true;

                if (Session["nurseSearch"] != null)
                {
                    btnAdmit.Visible = false;
                    btnPerscription.Visible = false;

                }
                else
                {
                    List<Appointment> tmpAppList = new List<Appointment>();
                    List<Person> listNurse = new List<Person>();
                    listNurse = Database.GetPeopleList();
                    listNurse = listNurse.Where(x => x.Type == "Nurse").ToList();
                    foreach (Person nurse in listNurse)
                    {
                        ddlNurse.Items.Add(nurse.FullName());
                    }

                    List<HospitalRoom> hspRoomList = new List<HospitalRoom>();
                    hspRoomList = Database.GetHospitalRooms();
                    hspRoomList = hspRoomList.Where(x => x.Availabilty == 0).ToList();

                    foreach (HospitalRoom hospitalRoom in hspRoomList)
                    {
                        ddlRoom.Items.Add(hospitalRoom.HosiptalRoom.ToString());
                    }

                    List<Appointment> listApp = new List<Appointment>();
                    listApp = Database.GetAppointmentList(Session["searchUser"].ToString());

                    List<DoctorPatients> listPatients = new List<DoctorPatients>();
                    listPatients = Database.GetDoctorConfirmAppList(Session["userid"].ToString());

                    int countPatients = listPatients.Count(x => x.PatientId == Session["searchUser"].ToString());

                    int countList = listApp.Count(x => x.DoctorsId == Session["userid"].ToString() && x.Confirmed.Trim() == "Confirmed");

                    if (countList > 0 || countPatients > 0)
                    {
                        btnPerscription.Visible = true;
                    }
                    else
                    {
                        btnPerscription.Visible = false;
                    }
                    gvAppointmentHistory.DataSource = listApp;
                    gvAppointmentHistory.DataBind();

                    ddlNurse.SelectedIndex = 0;
                    ddlRoom.SelectedIndex = 0;

                    List<DoctorPatients> docPat = new List<DoctorPatients>();
                    docPat = Database.GetDoctorConfirmAppList(Session["userid"].ToString());

                    docPat = docPat.Where(x => x.PatientId == Session["searchUser"].ToString() && x.Admitted == "Admitted").ToList();

                    if (docPat.Count != 0)
                    {
                        Session["appId"] = docPat[0].AdmittedId;
                        Session["roomNum"] = docPat[0].RoomNumber;
                        btnDischarge.Visible = true;
                        btnAdmit.Visible = false;
                    }

                    List<Perscription> listPerscription = new List<Perscription>();
                    listPerscription = Database.GetPatientsPerscriptionList(Session["searchUser"].ToString());
                    gvPerscriptionHistory.DataSource = listPerscription;
                    gvPerscriptionHistory.DataBind();

                    gvAllergies.DataSource = person._Allergies;
                    gvAllergies.DataBind();
                }
            }


        }

        protected void lblAdmit_Click(object sender, EventArgs e)
        {
            lblNurse.Visible = true;
            lblRoom.Visible = true;
            ddlNurse.Visible = true;
            ddlRoom.Visible = true;
            btnSaveAdmission.Visible = true;
            txtExtraInfo.Visible = true;
            lblExtraInfo.Visible = true;
        }

        protected void ddlRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSaveAdmission.Text = "Admit to Room:" + ddlRoom.SelectedValue;
        }

        protected void btnSaveAdmission_Click(object sender, EventArgs e)
        {


            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to admit this patient? ", "Admission", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Person person = new Person();
                person = Database.GetAccount(Session["searchUser"].ToString());

                HospitalRoom hspRoom = new HospitalRoom();
                DoctorPatients patientDoc = new DoctorPatients();

                hspRoom.PatientId = person.Id;
                hspRoom.HosiptalRoom = Convert.ToInt32(ddlRoom.SelectedValue);


                List<Person> listNurse = new List<Person>();
                listNurse = Database.GetPeopleList();
                listNurse = listNurse.Where(x => x.Type == "Nurse").ToList();
                patientDoc.AdmittedDate = DateTime.UtcNow;
                patientDoc.Admitted = "Admitted";
                patientDoc.PatientId = person.Id;
                patientDoc.DoctorId = Session["userid"].ToString();
                patientDoc.NurseId = listNurse[ddlNurse.SelectedIndex].Id;
                patientDoc.ExtraInfo = txtExtraInfo.Text;
                patientDoc.RoomNumber = ddlRoom.SelectedValue;

                Database.AddAdmitPatient(patientDoc);
                Database.AdmitRoom(hspRoom);

                Session["searchUser"] = null;

                Response.Redirect("HomeDoctorForm.aspx");
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }



        }

        protected void btnDischarge_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to discharge this patient? ", "Discharge Patient", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Database.DischareRoom(Convert.ToInt32(Session["roomNum"].ToString()));
                Database.DischargePatient(Convert.ToInt32(Session["appId"].ToString()));

                Response.Redirect("HomeDoctorForm.aspx");
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }


        }

        protected void btnPerscription_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssignPerscriptionForm.aspx");
        }

        protected void btnSendMessage_Click(object sender, EventArgs e)
        {
            Session["msgid"] = "reply";
            Session["msgreplyid"] = Session["searchUser"].ToString();
            Response.Redirect("InboxMsgForm.aspx");

            Session["searchUser"] = null;
            Session["nurseSearch"] = null;
            Session["admittedId"] = null;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to cancel? ", "Return to previous page", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Person tmpPers = new Person();
                tmpPers = Database.GetAccount(Session["userid"].ToString());
                Session["searchUser"] = null;
                Session["nurseSearch"] = null;
                Session["admittedId"] = null;
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

        protected void btnAddNotes_Click(object sender, EventArgs e)
        {
            if (txtAddNote.Text == "")
            {
                MessageBox.Show("Please enter a note");
            }
            else
            {
                PatientNote note = new PatientNote();
                note.NoteSenderId = Session["userid"].ToString();
                note.Message = txtAddNote.Text;
                note.DoctorPatientId = Session["admittedId"].ToString();
                note.SentDate = DateTime.Today;

                Database.CreatePatientNote(note);

                MessageBox.Show("Note was sucessfully submitted");

                Session["searchUser"] = null;
                Session["nurseSearch"] = null;
                Session["admittedId"] = null;

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
        }
    }
}