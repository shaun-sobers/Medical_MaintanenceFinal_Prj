using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MedicalManagement_Final
{
    public partial class TestForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> test = new List<string>();
            test.Add("test");
            test.Add("test");
            test.Add("test");
            test.Add("test");


            ddlAppointment.DataSource = test;
            ddlAppointment.DataBind();

           // lblDate.Text = DateTime.Today.ToString();
        }

        public void Loggout()
        {
            MessageBox.Show("Hello");
        }
    }
}