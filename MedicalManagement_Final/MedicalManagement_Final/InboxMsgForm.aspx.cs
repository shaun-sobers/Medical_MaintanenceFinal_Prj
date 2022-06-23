using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MedicalManagement_Final
{
    public partial class InboxMsgForm : System.Web.UI.Page
    {
        List<Person> listPeople = new List<Person>();
        string fromid="";
        Person me = new Person();
        protected void Page_Load(object sender, EventArgs e)
        {
            me = Database.GetAccount(Session["userid"].ToString());
            if (Session["msgid"] != null)
            {
                if (Session["msgid"].ToString() == "reply")
                {
                    Person toUser = new Person();
                    toUser = Database.GetAccount(Session["msgreplyid"].ToString());
                    tbTo.Text = toUser.FullName();
                    tbFrom.Text = me.FullName() + " (Me)";
                    tbSubject.ReadOnly = false;
                    tbDate.Visible = false;
                    tbReply.Visible = false;
                    tbMessage.ReadOnly = false;
                    ddlSentList.Visible = false;
                    btnSend.Visible = true;
                    btnReply.Visible = false;
                    btnDelete.Visible = false;
                  

                }
                else
                {
                    Message msg = new Message();
                    msg = Database.GetInboxMessage(Session["msgid"].ToString());
                    tbDate.Text = msg.SentDate.ToString();
                    Person p1 = new Person();
                    p1 = Database.GetAccount(msg.FromUser);
                    fromid = msg.FromUser;
                    tbFrom.Text = p1.FullName();
                    tbMessage.Text = msg.MessageText;
                    tbSubject.Text = msg.Subject;
                    p1 = Database.GetAccount(msg.ToUser);
                    tbTo.Text = p1.FullName();
                    ddlSentList.Visible = false;
                    // lblTo.Visible = false;
                    tbReply.Visible = false;
                    btnReply.Visible = true;
                    // lblMessage2.Visible = false;
                    btnSend.Visible = false;
                }
            }
            else
            {
                tbFrom.Text = Session["userid"].ToString();
                listPeople = Database.GetPeopleList();
                tbSubject.ReadOnly = false;
              //  lblDate.Visible = false;
                tbDate.Visible = false;
                ddlSentList.Visible = true;
                //lblTooSerach.Visible = false;
                tbTo.Visible = false;
                btnSend.Visible = true;
                btnReply.Visible = false;
                btnDelete.Visible = false;
               // lblMessage1.Visible = false;
                tbMessage.Visible = false;

                foreach(Person person in listPeople)
                {
                    ddlSentList.Items.Add(person.FullName() + "("+person.Type+")");
                }
            }

            
        }

        protected void btnReply_Click(object sender, EventArgs e)
        {
            tbReply.Visible = true;
            btnSend.Visible = true;
            btnReply.Visible = false;
            btnDelete.Visible = false;


        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

                Message tmpMsg = new Message();
                if (Session["msgid"] != null)
                {
                    tmpMsg.ToUser = fromid;
                    tmpMsg.Subject = "RE: " + tbSubject.Text;
                }
                else
                {
                    tmpMsg.ToUser = listPeople[ddlSentList.SelectedIndex].Id;
                    tmpMsg.Subject = tbSubject.Text;
                }


                tmpMsg.FromUser = Session["userid"].ToString();
                tmpMsg.MessageText = tbReply.Text;
                tmpMsg.Status = 0;
                tmpMsg.SentDate = DateTime.Now;

                MessageBox.Show("Message Sent");
                Database.SendMessage(tmpMsg);

            switch (me.Type)
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete this message? ", "Delete Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Message deleted");
                Database.DeleteMessage(Convert.ToInt32(Session["msgid"].ToString()));

                switch (me.Type)
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
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to Cancel this message? ", "Cancel Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                switch (me.Type)
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