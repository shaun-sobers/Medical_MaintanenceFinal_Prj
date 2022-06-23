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
    public partial class InboxForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {


                for (int i = 0; i < gvInbox.Rows.Count; i++)
                {
                    if (gvInbox.Rows[i].Cells[5].Text == "1")
                    {

                        gvInbox.Rows[i].Cells[6].BackColor = System.Drawing.Color.Green;
                        gvInbox.Rows[i].Cells[6].Text = "Read";

                    }
                    else
                    {
                        gvInbox.Rows[i].Cells[6].BackColor = System.Drawing.Color.Red;
                        gvInbox.Rows[i].Cells[6].Text = "Unread";
                    }
                }
                gvInbox.Columns[1].Visible = false;
                gvInbox.Columns[2].Visible = false;
                gvInbox.Columns[5].Visible = false;
            }

            List<Message> tmpList = new List<Message>();
            tmpList = Database.GetMessageList(Session["userid"].ToString());
            int count = tmpList.Count;

            if (count == 0)
            {
                lblEmailcount.Visible = true;
                lblEmailcount.Text = "No messages in your inbox";
            }


            

        }


        protected void gvInbox_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Session["msgId"] = gvInbox.Rows[e.NewSelectedIndex].Cells[0].Text;
            Database.ReadMessage(Session["msgId"].ToString());
            Response.Redirect("InboxMsgForm.aspx");
        }

        protected void btnComposeMsg_Click(object sender, EventArgs e)
        {
            Session["msgId"] = null;
            Response.Redirect("InboxMsgForm.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to return? ", "Return to previous page", MessageBoxButtons.YesNo);
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