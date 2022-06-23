using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace MedicalManagement_Final
{
    public partial class RegitserPeronalInfo : System.Web.UI.Page
    {
        const string AdminCode = "OpenPlease";
        string test = "";
        User curUser = new User();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //  Allergy = new List<string>();
            curUser = (User)Session["userProfile"];
            if (Session["filename"] != null)
            {
                FileUpload1.Visible = false;
                btnUpload.Visible = false;

                string[] filePaths = Directory.GetFiles(Server.MapPath("~/Images/"));
                List<ListItem> files = new List<ListItem>();
                foreach (string filePath in filePaths)
                {
                    string fileName = Path.GetFileName(filePath);
                    if (fileName == Session["filename"].ToString())
                    {
                        files.Add(new ListItem(fileName, "~/Images/" + fileName));
                    }


                }
                gvImage.DataSource = files;
                gvImage.DataBind();
            }

            if (!IsPostBack)
            {

                List<string> listAllergy = new List<string>();
                Session["listAllergy"] = listAllergy;

                if (Session["info"] != null)
                {
                    Person tmpP = new Person();
                    tmpP = (Person)Session["info"];
                    Session["id"]= tmpP.Id;
                    txtEmergName.Text = tmpP.EmergancyContactName;
                    txtEmergNum.Text = tmpP.EmergancyContactNum;
                    txtBirthday.Text = tmpP.Birthday.ToString("yyyy/MM/dd");
                    txtFname.Text = tmpP.FirstName;
                    txtLname.Text = tmpP.LastName;
                    txtPhone.Text = tmpP.PhoneNumber;
                    txtFname.ReadOnly = true;
                    txtLname.ReadOnly = true;
                    lblType.Visible = true;
                    ddlType.Visible = true;
                    ddlType.Enabled = false;
                    txtSecurityAnswer.Text = tmpP.SecurityAnswer;
                    tmpP.LoadAllergies();

                    Session["listAllergy"] = tmpP._Allergies;



                    string[] filePaths = Directory.GetFiles(Server.MapPath("~/Images/"));
                    List<ListItem> files = new List<ListItem>();
                    foreach (string filePath in filePaths)
                    {
                        string fileName = Path.GetFileName(filePath);
                        if (Session["filename"] != null)
                        {
                            if (fileName == Session["filename"].ToString())
                            {
                                files.Add(new ListItem(fileName, "~/Images/" + fileName));
                            }
                        }
                        else
                        {
                            if (fileName == tmpP.Image)
                            {
                                files.Add(new ListItem(fileName, "~/Images/" + fileName));
                            }
                        }



                    }
                    gvImage.DataSource = files;
                    gvImage.DataBind();


                    switch (tmpP.BloodType.Trim())
                    {
                        case "Type A":
                            ddlBloodType.SelectedIndex = 0; break;

                        case "Type B":
                            ddlBloodType.SelectedIndex = 1; break;

                        case "Type AB":
                            ddlBloodType.SelectedIndex = 2; break;

                        case "Type O":
                            ddlBloodType.SelectedIndex = 3; break;


                        default:
                            break;
                    }


                    switch (tmpP.Sex.Trim())
                    {
                        case "Male":
                            ddlSex.SelectedIndex = 0; break;

                        case "Female":
                            ddlSex.SelectedIndex = 1; break;
                        default:
                            break;
                    }

                    switch (tmpP.Type.Trim())
                    {
                        case "Patient":
                            ddlType.SelectedIndex = 0; break;

                        case "Nurse":
                            ddlType.SelectedIndex = 1; break;

                        case "Doctor":
                            ddlType.SelectedIndex = 2; break;



                        default:
                            break;
                    }

                    switch (tmpP.SecurityQuestion.Trim())
                    {
                        case "What city were you born in?":
                            ddlSecurityQuestion.SelectedIndex = 0;
                            break;

                        case "What was the first concert you attended?":
                            ddlSecurityQuestion.SelectedIndex = 1;
                            break;

                        case "What was your childhood nickname?":
                            ddlSecurityQuestion.SelectedIndex = 2;
                            break;

                        case "What school did you attend for sixth grade?":
                            ddlSecurityQuestion.SelectedIndex = 3;
                            break;

                        case "In what city or town was your first job?":
                            ddlSecurityQuestion.SelectedIndex = 4;
                            break;

                        case "What is your maternal grandmother's maiden name?":
                            ddlSecurityQuestion.SelectedIndex = 5;
                            break;
                    }

                 

                    
                }



                List<string> bloodTypelist = new List<string>();
                bloodTypelist.Add("Type A");
                bloodTypelist.Add("Type B");
                bloodTypelist.Add("Type AB");
                bloodTypelist.Add("Type O");
                ddlBloodType.DataSource = bloodTypelist;
                ddlBloodType.DataBind();


                List<string> sexTypelist = new List<string>();
                sexTypelist.Add("Male");
                sexTypelist.Add("Female");
                ddlSex.DataSource = sexTypelist;
                ddlSex.DataBind();


                List<string> accountType = new List<string>();
                accountType.Add("Patient");
                accountType.Add("Nurse");
                accountType.Add("Doctor");
                ddlType.DataSource = accountType;
                ddlType.DataBind();


                List<string> secuirityQues = new List<string>();
                secuirityQues.Add("What city were you born in?");
                secuirityQues.Add("What was the first concert you attended?");
                secuirityQues.Add("What was your childhood nickname?");
                secuirityQues.Add("What school did you attend for sixth grade?");
                secuirityQues.Add("In what city or town was your first job?");
                secuirityQues.Add("What is your maternal grandmother's maiden name?");
                ddlSecurityQuestion.DataSource = secuirityQues;
                ddlSecurityQuestion.DataBind();

            }

            if (Session["listAllergy"] != null)
            {
                List<string> listAllergy = new List<string>();
                listAllergy = (List<string>)Session["listAllergy"];
                lbAllergies.DataSource = listAllergy;
                lbAllergies.DataBind();
            }


        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to cancel registration? ", "Cancel?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Session.Abandon();
                Response.Redirect("LoginForm.aspx");

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

            protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtFname.Text == "")
            {
                MessageBox.Show("Your First Name cannot be empty");
                txtFname.Focus();
            }
            else if (txtLname.Text =="")
            {
                MessageBox.Show("Your Last Name cannot be empty");
                txtLname.Focus();
            }
            else if(txtBirthday.Text == "")
            {
                MessageBox.Show("Your Birthday cannot be empty");
                txtBirthday.Focus();
            }
            else if(txtPhone.Text == "")
            {
                MessageBox.Show("Your Phone number cannot be empty");
                txtPhone.Focus();
            }
           else if (txtSecurityAnswer.Text == "")
            {
                MessageBox.Show("Please answer the security question");
                txtSecurityAnswer.Focus();
            }
            else if (txtEmergName.Text == "")
            {
                MessageBox.Show("Emergancy Contact Name cannot be empty");
                txtEmergName.Focus();
            }
           else if (txtEmergNum.Text == "")
            {
                MessageBox.Show("Emergancy Contact Number cannot be empty");
                txtEmergNum.Focus();
            }
            else
            {


                Person tmpPerson = new Person();
                tmpPerson.FirstName = txtFname.Text;
                tmpPerson.LastName = txtLname.Text;
                tmpPerson.PhoneNumber = txtPhone.Text;
                tmpPerson.Birthday = Convert.ToDateTime(txtBirthday.Text);
                tmpPerson.BloodType = ddlBloodType.SelectedValue;
                tmpPerson.Sex = ddlSex.SelectedValue;
                tmpPerson.EmergancyContactName = txtEmergName.Text;
                tmpPerson.EmergancyContactNum = txtEmergNum.Text;
                tmpPerson.SecurityQuestion = ddlSecurityQuestion.SelectedValue;
                tmpPerson.SecurityAnswer = txtSecurityAnswer.Text;
                List<string> allergies = new List<string>();

                foreach (var item in lbAllergies.Items)
                {
                    allergies.Add(item.ToString());
                }
                tmpPerson._Allergies = allergies;

                if (Session["filename"] == null)
                {
                    if (tmpPerson.Sex == "Male")
                    {
                        tmpPerson.Image = "Default-Male.jpg";
                    }
                    else
                    {
                        tmpPerson.Image = "Default-Female.jpg";
                    }
                }
                else
                {
                    
                   tmpPerson.Image = Session["filename"].ToString();
                }
                List<string> listAllergy = new List<string>();
                listAllergy = (List<string>)Session["listAllergy"];
                tmpPerson._Allergies = listAllergy;

                if (Session["typeOfAcnt"] != null)
                {
                    if (Session["typeOfAcnt"].ToString() == "true")
                    {
                        tmpPerson.Type = ddlType.SelectedValue;
                    }
                }
                else
                {
                    

                    if (Session["info"] != null)
                    {
                        tmpPerson.Type= ddlType.SelectedValue;
                    }
                    else
                    {
                        tmpPerson.Type = "Patient";
                    }
                }

                if (Session["info"] != null)
                {

                    tmpPerson.Id = Session["id"].ToString();
                    Database.UpdatePerson(tmpPerson);
                    MessageBox.Show("User account was sucessfully update");
                    switch (tmpPerson.Type)
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
                else
                {

                    tmpPerson.Id = Session["userid"].ToString();
                    Database.CreatePerson(tmpPerson);
                    Database.CreateUser(curUser);
                    MessageBox.Show("User account was sucessfully created");
                    Session["userid"] = null;
                    Session["filename"] = null;
                    Response.Redirect("LoginForm.aspx");
                }



                Session["typeOfAcnt"] = null;
            }

        }


        protected void Upload(object sender, EventArgs e)
        {
            // Check file exist or not  
            if (FileUpload1.PostedFile != null)
            {
                string extension = Path.GetExtension(FileUpload1.FileName);
                if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg")
                {
                    Stream strm = FileUpload1.PostedFile.InputStream;
                    using (var image = System.Drawing.Image.FromStream(strm))
                    {

                        int newWidth = 240;
                        int newHeight = 240; 
                        var thumbImg = new Bitmap(newWidth, newHeight);
                        var thumbGraph = Graphics.FromImage(thumbImg);
                        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        var imgRectangle = new Rectangle(0, 0, newWidth, newHeight);
                        thumbGraph.DrawImage(image, imgRectangle);
                        string targetPath = Server.MapPath(@"~\Images\") + FileUpload1.FileName;
                        thumbImg.Save(targetPath, image.RawFormat);
                        string filename = FileUpload1.FileName;
                        Session["filename"] = filename;
                        Response.Redirect("RegitserPeronalInfoForm.aspx");

                    }
                }
            }
        }



        protected void txtAllergies_TextChanged(object sender, EventArgs e)
        {

        }



        protected void btnTest_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddAllergy_Click(object sender, EventArgs e)
        {
            if(txtAllergies.Text == "")
            {
                MessageBox.Show("Please enter a valid allergy");
                txtAllergies.Focus();
            }
            else
            {
                List<string> listAllergy = new List<string>();
                listAllergy = (List<string>)Session["listAllergy"];
                listAllergy.Add(txtAllergies.Text);
                Session["listAllergy"] = listAllergy;
                txtAllergies.Text = "";
                lbAllergies.DataSource = listAllergy;
                lbAllergies.DataBind();
            }

        }

        protected void txtAdminCode_TextChanged(object sender, EventArgs e)
        {
            if (txtAdminCode.Text == AdminCode)
            {
                ddlType.Visible = true;
                lblType.Visible = true;
                Session["typeOfAcnt"] = "true";
            }
            else
            {
                MessageBox.Show("Invalid Admin Code\n Try Again or Contact your admin");
            }

            //AdminCode = 'OpenPlease'
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

    }
}