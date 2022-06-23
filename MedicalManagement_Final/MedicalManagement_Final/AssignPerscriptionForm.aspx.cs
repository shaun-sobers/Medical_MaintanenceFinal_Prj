using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MedicalManagement_Final
{
    public partial class AssignPerscriptionForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Today.ToString();
            if (Session["searchUser"] != null)
            {
                Person prs = new Person();
                prs = Database.GetAccount(Session["searchUser"].ToString());
                prs.LoadAllergies();
                gvListOfAllergies.DataSource = prs._Allergies;
                gvListOfAllergies.DataBind();
                txtPatientName.Text = prs.FullName();
            }
            else
            {
                txtPatientName.Visible = false;
                ddlPatientList.Visible = true;

                List<Person> listPatients = new List<Person>();
                listPatients = Database.GetPeopleList();
                listPatients = listPatients.Where(x => x.Type == "Patient").ToList();

                foreach (Person person in listPatients)
                {
                    ddlPatientList.Items.Add(person.FullName());
                }
            }
        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to assign this perscription? ", "Assign perscription", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Perscription perscription = new Perscription();
                perscription.Length = txtLength.Text;
                perscription.PerscriptionDate = Convert.ToDateTime(txtDate.Text);
                perscription.perscriptionType = txtPerscription.Text;

                if (Session["searchUser"] != null)
                {
                    Person prs = new Person();
                    prs = Database.GetAccount(Session["searchUser"].ToString());
                    perscription.PatientId = prs.Id;
                }
                else
                {
                    List<Person> listPatients = new List<Person>();
                    listPatients = Database.GetPeopleList();
                    listPatients = listPatients.Where(x => x.Type == "Patient").ToList();
                    perscription.PatientId = listPatients[ddlPatientList.SelectedIndex].Id;
                }
                perscription.assignedByDoctor = Session["userid"].ToString();

                Database.CreatePerscription(perscription);
                MessageBox.Show("Perscription was submitted");

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