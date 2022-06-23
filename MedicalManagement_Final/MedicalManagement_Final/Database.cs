using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace MedicalManagement_Final
{
    public static class Database
    {
        private static SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");

        public static void toggleConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
        }

        // User -- Create
        public static void CreateUser(User user)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into userinfo values ('" + user.Id.Trim() + "','" + user.Username.Trim() + "','" + user.Password.Trim() + "')";
            cmd.ExecuteNonQuery();
        }

        public static void CreatePerscription(Perscription persc)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Perscription values ('" + persc.PatientId + "','" + persc.assignedByDoctor + "','" + persc.perscriptionType +"','"+persc.Length+"','"+persc.PerscriptionDate+ "')";
            cmd.ExecuteNonQuery();
        }

        public static void CreateAppointment(Appointment app)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Appointments values ('" + app.PatientId + "','" + app.DoctorsId + "','" + app.ReasonFor + "','" + app.TypeOfAppointment + "','" + app.Severity + "','" + app.ExtraInfo + "','" + app.RequestDate + "','" + app.ConfirmDate + "','" + app.Confirmed + "')";
            cmd.ExecuteNonQuery();
        }

        public static void CreatePatientNote(PatientNote note)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into PatientNotes values ('" + note.NoteSenderId+ "','" + note.DoctorPatientId + "','" + note.Message + "','" + note.SentDate + "')";
            cmd.ExecuteNonQuery();
        }


        public static void AddAllergy(string id,List<string> allergyList)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            foreach (string item in allergyList)
            {
                cmd.CommandText = "insert into PatientAllergyList values ('" + id + "','" + item + "')";
                cmd.ExecuteNonQuery();
            }
        }


        public static void CreatePerson(Person person)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Person values ('" + person.Id.Trim() + "','" + person.FirstName.Trim() + "','" + person.LastName.Trim() + "','" + person.Sex.Trim() + "','" + person.Birthday + "','" + person.PhoneNumber.Trim() + "','" + person.BloodType.Trim() + "','" + person.EmergancyContactName.Trim() + "','" + person.EmergancyContactNum.Trim() + "','" + person.Type.Trim() +"','"+person.Image.Trim()+"','"+person.SecurityQuestion.Trim()+"','"+person.SecurityAnswer.Trim()+ "')";

            if (person._Allergies.Count > 0 )
            {
                AddAllergy(person.Id, person._Allergies);
            }
            cmd.ExecuteNonQuery();
        }


        public static void SendMessage(Message msg)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Messages values ('" +  msg.ToUser + "','" + msg.FromUser + "','" + msg.Subject + "','" + msg.MessageText + "','" + msg.Status + "','" + msg.SentDate + "')";
            cmd.ExecuteNonQuery();
        }

        public static void AddAdmitPatient(DoctorPatients pts)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into DoctorPatients values ('" + pts.DoctorId +"','" + pts.PatientId + "','" + pts.RoomNumber+ "','" + pts.NurseId + "','" + pts.Admitted + "','" + pts.AdmittedDate + "','" + DateTime.MaxValue + "','" + pts.ExtraInfo + "')";
            cmd.ExecuteNonQuery();
        }

        public static User GetUser(string username)
        {

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Parameterized Query
            cmd.CommandText = "SELECT * FROM userinfo " +
                                    "WHERE username =  @username";


            cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            cmd.Parameters["@UserName"].Value = username;

            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT
            User user = new User();
            if (sqlReader.Read())
            {
                user.Id = sqlReader["Id"].ToString();
                user.Username = sqlReader["username"].ToString();
                user.Password = sqlReader["Password"].ToString();

            }
            else
            {
                user = null;
            }

            sqlReader.Close();
            return user;

        }

        public static List<string> GetPatientAllergyList(string id)
        {
            List<string> allergyList = new List<string>();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Parameterized Query
            cmd.CommandText = "SELECT * FROM PatientAllergyList " +
                                    "WHERE PatientId = @Id";


            cmd.Parameters.Add("@Id", SqlDbType.VarChar);
            cmd.Parameters["@Id"].Value = id;

            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT
            while (sqlReader.Read())
            {
                string allergy;
                allergy = sqlReader["Allergy"].ToString();

                allergyList.Add(allergy);
            }

            sqlReader.Close();
            return allergyList;

        }

        public static User SearchUsername(string username)
        {

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Parameterized Query
            cmd.CommandText = "SELECT * FROM UserInfo " +
                                    "WHERE Username =  @Username";


            cmd.Parameters.Add("@Username", SqlDbType.VarChar);
            cmd.Parameters["@Username"].Value = username;

            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT
            User usr = new User();
            if (sqlReader.Read())
            {

                usr.Id = sqlReader["Id"].ToString();
                usr.Username = sqlReader["Username"].ToString();
                usr.Password = sqlReader["Password"].ToString();
            }
            else
            {
                usr = null;
            }

            sqlReader.Close();
            return usr;

        }

        public static List<PatientNote> GetDoctorsNote(string id)
        {

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Parameterized Query
            cmd.CommandText = "SELECT * FROM PatientNotes " +
                                    "WHERE DoctorPatientId =  @Id";


            cmd.Parameters.Add("@Id", SqlDbType.VarChar);
            cmd.Parameters["@Id"].Value = id;
            List<PatientNote> listNotes = new List<PatientNote>();
            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT
            while (sqlReader.Read())
            {
                PatientNote note = new PatientNote();
                note.DoctorPatientId = sqlReader["DoctorPatientId"].ToString();
                note.NoteSenderId = sqlReader["NoteSenderId"].ToString();
                note.Message = sqlReader["Message"].ToString();
                note.SentDate = Convert.ToDateTime(sqlReader["SentDate"].ToString());

                listNotes.Add(note);
            }

            sqlReader.Close();
            return listNotes;

        }

        public static Person GetAccount(string id)
        {

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Parameterized Query
            cmd.CommandText = "SELECT * FROM Person " +
                                    "WHERE Id =  @Id";


            cmd.Parameters.Add("@Id", SqlDbType.VarChar);
            cmd.Parameters["@Id"].Value = id;

            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT
            Person person = new Person();
            if (sqlReader.Read())
            {

                person.Id = sqlReader["Id"].ToString();
                person.FirstName = sqlReader["FirstName"].ToString();
                person.LastName = sqlReader["LastName"].ToString();
                person.EmergancyContactNum = sqlReader["EmergNum"].ToString();
                person.EmergancyContactName = sqlReader["EmergName"].ToString();
                person.Birthday = Convert.ToDateTime(sqlReader["Birthday"].ToString());
                person.BloodType = sqlReader["BloodType"].ToString();
                person.Sex = sqlReader["Sex"].ToString();
                person.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                person.Type = sqlReader["Type"].ToString();
                person.Image = sqlReader["Image"].ToString();
                person.SecurityQuestion = sqlReader["SecurityQuestion"].ToString();
                person.SecurityAnswer = sqlReader["SecurityAnswer"].ToString();

            }
            else
            {
                person = null;
            }

            sqlReader.Close();
            return person;

        }

        public static DataTable GetPatientsPerscriptionTable(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from Perscription where PatientId = @Id", conn);
            try
            {

                cmd.Parameters.Add("@Id", SqlDbType.VarChar);
                cmd.Parameters["@Id"].Value = id;
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                conn.Close();
                return dt;


            }

            catch { throw; }

        }
        public static List<Perscription> GetPatientsPerscriptionList(string id)
        {
            List<Perscription> perscriptionList = new List<Perscription>();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Parameterized Query
            cmd.CommandText = "SELECT * FROM Perscription " +
                                    "WHERE PatientId = @Id";


            cmd.Parameters.Add("@Id", SqlDbType.VarChar);
            cmd.Parameters["@Id"].Value = id;

            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT
            while (sqlReader.Read())
            {
                Perscription perscript = new Perscription();
                perscript.perscriptionType = sqlReader["perscriptionType"].ToString();
                perscript.PatientId = sqlReader["PatientId"].ToString();
                perscript.Length = sqlReader["Length"].ToString();
                perscript.assignedByDoctor = sqlReader["Assignedby"].ToString();
                perscript.PerscriptionDate = Convert.ToDateTime(sqlReader["PerscriptionDate"].ToString());

                perscriptionList.Add(perscript);
            }

            sqlReader.Close();
            return perscriptionList;

        }

        /*
        public static Perscription GetAPerscription(string id)
        {
            List<Perscription> perscriptionList = new List<Perscription>();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Parameterized Query
            cmd.CommandText = "SELECT * FROM Perscription " +
                                    "WHERE Id = @Id";


            cmd.Parameters.Add("@Id", SqlDbType.VarChar);
            cmd.Parameters["@Id"].Value = id;

            Perscription perscript = new Perscription();

            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT
            if (sqlReader.Read())
            {
                perscript.perscriptionType = sqlReader["perscriptionType"].ToString();
                perscript.PatientId = sqlReader["PatientId"].ToString();
                perscript.Length = sqlReader["Length"].ToString();
                perscript.assignedByDoctor = sqlReader["Assignedby"].ToString();


            }
            else
            {
                perscript = null;
            }

            sqlReader.Close();
            return perscript;

        }

        */


        public static Message GetInboxMessage(string id)
        {

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Parameterized Query
            cmd.CommandText = "SELECT * FROM Messages " +
                                    "WHERE MessageId =  @Id";


            cmd.Parameters.Add("@Id", SqlDbType.VarChar);
            cmd.Parameters["@Id"].Value = id;

            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT
            Message msg = new Message();
            if (sqlReader.Read())
            {

                msg.MessageId = Convert.ToInt32(sqlReader["MessageId"].ToString());
                msg.Subject = sqlReader["Subject"].ToString();
                msg.MessageText = sqlReader["Message"].ToString();
                msg.FromUser = sqlReader["FromUser"].ToString();
                msg.ToUser = sqlReader["ToUser"].ToString();
                msg.Status = Convert.ToInt32(sqlReader["Status"].ToString());
                msg.SentDate = Convert.ToDateTime(sqlReader["SentDate"].ToString());

            }
            else
            {
                msg = null;
            }

            sqlReader.Close();
            return msg;

        }


        public static void ReadMessage(string id)
        {

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            //Parameterized Query


            cmd.CommandText = "UPDATE Messages " +
             "SET Status= '1' " +
             "WHERE MessageId =" + id;



            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT


            sqlReader.Close();

        }


        public static void DeleteAllergy(string id)
        {

            SqlCommand cmdDelete = conn.CreateCommand();

            cmdDelete.CommandType = CommandType.Text;
            //Parameterized Query

            cmdDelete.CommandType = CommandType.Text;
            cmdDelete.CommandText = "DELETE  FROM PatientAllergyList " +
                                    "WHERE PatientId = @Id";

            cmdDelete.Parameters.Add("@Id", SqlDbType.VarChar);
            cmdDelete.Parameters["@Id"].Value = id;


            SqlDataReader sqlReader = cmdDelete.ExecuteReader(); //Applied to SELECT


            sqlReader.Close();




        }

        public static void UpdatePassword(string id, string password)
        {

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            //Parameterized Query


            cmd.CommandText = "UPDATE UserInfo " +
             "SET Password= @Password " +
             "WHERE Id = @Id";

            cmd.Parameters.Add("@Id", SqlDbType.VarChar);
            cmd.Parameters["@Id"].Value = id;

            cmd.Parameters.Add("@Password", SqlDbType.VarChar);
            cmd.Parameters["@Password"].Value = password;



            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT


            sqlReader.Close();

        }

        public static void ConfirmAppointment(string id, DateTime date)
        {

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            //Parameterized Query


            cmd.CommandText = "UPDATE Appointments " +
             "SET Confirmed = 'Confirmed' , AppointmentConfirmDate = '" + date + "'"+
             "WHERE AppointmentId =" + id;



            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT


            sqlReader.Close();

        }


        public static void AdmitRoom(HospitalRoom hsp)
        {

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            //Parameterized Query


            cmd.CommandText = "UPDATE PatientRoom " +
             "SET Available= '1', PatientId= @Id " +
             "WHERE HospitalRoom = @RoomId";


            cmd.Parameters.Add("@Id", SqlDbType.VarChar);
            cmd.Parameters["@Id"].Value = hsp.PatientId;


            cmd.Parameters.Add("@RoomId", SqlDbType.VarChar);
            cmd.Parameters["@RoomId"].Value = hsp.HosiptalRoom;

            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT


            sqlReader.Close();

        }


        public static void DischareRoom(int id)
        {

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            //Parameterized Query


            cmd.CommandText = "UPDATE PatientRoom " +
             "SET Available= '0', PatientId= '' " +
             "WHERE HospitalRoom = @RoomId";




            cmd.Parameters.Add("@RoomId", SqlDbType.VarChar);
            cmd.Parameters["@RoomId"].Value = id;

            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT


            sqlReader.Close();

        }

        public static void DischargePatient(int id)
        {

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            //Parameterized Query


            cmd.CommandText = "UPDATE DoctorPatients " +
             "SET Admitted= 'Discharged', DischargedDate = @Date "+
             "WHERE Id = @Id";




            cmd.Parameters.Add("@Id", SqlDbType.VarChar);
            cmd.Parameters["@Id"].Value = id;


            cmd.Parameters.Add("@Date", SqlDbType.DateTime);
            cmd.Parameters["@Date"].Value = DateTime.Now;

            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT


            sqlReader.Close();

        }



        public static void UpdatePerson(Person person)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update Person Set FirstName= @Fname , LastName= @Lname, Sex = @Sex , Birthday= @Bday, PhoneNumber= @Num, BloodType= @BType, EmergName= @Ename, EmergNum= @ENum , Type= @Type , Image = @Image, SecurityQuestion = @SecQ, SecurityAnswer =  @SecA" +
                " WHERE Id = @Id";


            cmd.Parameters.Add("@Id", SqlDbType.VarChar);
            cmd.Parameters["@Id"].Value = person.Id;

            cmd.Parameters.Add("@Fname", SqlDbType.VarChar);
            cmd.Parameters["@Fname"].Value = person.FirstName;
            cmd.Parameters.Add("@Lname", SqlDbType.VarChar);
            cmd.Parameters["@Lname"].Value = person.LastName;
            cmd.Parameters.Add("@Sex", SqlDbType.VarChar);
            cmd.Parameters["@Sex"].Value = person.Sex;

            cmd.Parameters.Add("@Bday", SqlDbType.DateTime);
            cmd.Parameters["@Bday"].Value = person.Birthday;
            cmd.Parameters.Add("@Num", SqlDbType.VarChar);
            cmd.Parameters["@Num"].Value = person.PhoneNumber;
            cmd.Parameters.Add("@BType", SqlDbType.VarChar);
            cmd.Parameters["@BType"].Value = person.BloodType;

            cmd.Parameters.Add("@Ename", SqlDbType.VarChar);
            cmd.Parameters["@Ename"].Value = person.EmergancyContactName;

            cmd.Parameters.Add("@ENum", SqlDbType.VarChar);
            cmd.Parameters["@ENum"].Value = person.EmergancyContactNum;

            cmd.Parameters.Add("@Type", SqlDbType.VarChar);
            cmd.Parameters["@Type"].Value = person.Type;

            cmd.Parameters.Add("@Image", SqlDbType.VarChar);
            cmd.Parameters["@Image"].Value = person.Image;

            cmd.Parameters.Add("@SecQ", SqlDbType.VarChar);
            cmd.Parameters["@SecQ"].Value = person.SecurityQuestion;

            cmd.Parameters.Add("@SecA", SqlDbType.VarChar);
            cmd.Parameters["@SecA"].Value = person.SecurityAnswer;

            SqlDataReader sqlReader = cmd.ExecuteReader(); 

            sqlReader.Close();

            
            DeleteAllergy(person.Id);
            AddAllergy(person.Id, person._Allergies);
            
            
        }


        public static List<Person> GetDoctorsList()
        {
            List<Person> DoctorList = new List<Person>();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Parameterized Query
            cmd.CommandText = "SELECT * FROM Person " +
                                    "WHERE Type =  'Doctor'";



            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT
            while (sqlReader.Read())
            {
                Person person = new Person();
                person.Id = sqlReader["Id"].ToString();
                person.FirstName = sqlReader["FirstName"].ToString();
                person.LastName = sqlReader["LastName"].ToString();
                person.EmergancyContactNum = sqlReader["EmergNum"].ToString();
                person.EmergancyContactName = sqlReader["EmergName"].ToString();
                person.Birthday = Convert.ToDateTime(sqlReader["Birthday"].ToString());
                person.BloodType = sqlReader["BloodType"].ToString();
                person.Sex = sqlReader["Sex"].ToString();
                person.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                person.Type = sqlReader["Type"].ToString();

                DoctorList.Add(person);
            }

            sqlReader.Close();
            return DoctorList;

        }

        public static List<Person> GetPeopleList()
        {
            List<Person> DoctorList = new List<Person>();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Parameterized Query
            cmd.CommandText = "SELECT * FROM Person ";



            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT
            while (sqlReader.Read())
            {
                Person person = new Person();
                person.Id = sqlReader["Id"].ToString();
                person.FirstName = sqlReader["FirstName"].ToString();
                person.LastName = sqlReader["LastName"].ToString();
                // person.Allergies = sqlReader["Allergies"].ToString();
                person.EmergancyContactNum = sqlReader["EmergNum"].ToString();
                person.EmergancyContactName = sqlReader["EmergName"].ToString();
                person.Birthday = Convert.ToDateTime(sqlReader["Birthday"].ToString());
                person.BloodType = sqlReader["BloodType"].ToString();
                person.Sex = sqlReader["Sex"].ToString();
                person.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                person.Type = sqlReader["Type"].ToString();
                person.Image = sqlReader["Image"].ToString();

                DoctorList.Add(person);
            }

            sqlReader.Close();
            return DoctorList;

        }



        public static List<Person> SearchPeople(string search)
        {
            List<Person> PeopleList = new List<Person>();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Parameterized Query
            cmd.CommandText = "SELECT * FROM Person WHERE FirstName LIKE @Search";

            cmd.Parameters.Add("@Search", SqlDbType.VarChar);
            cmd.Parameters["@Search"].Value = search;


            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT
            while (sqlReader.Read())
            {
                Person person = new Person();
                person.Id = sqlReader["Id"].ToString();
                person.FirstName = sqlReader["FirstName"].ToString();
                person.LastName = sqlReader["LastName"].ToString();
                // person.Allergies = sqlReader["Allergies"].ToString();
                person.EmergancyContactNum = sqlReader["EmergNum"].ToString();
                person.EmergancyContactName = sqlReader["EmergName"].ToString();
                person.Birthday = Convert.ToDateTime(sqlReader["Birthday"].ToString());
                person.BloodType = sqlReader["BloodType"].ToString();
                person.Sex = sqlReader["Sex"].ToString();
                person.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                person.Type = sqlReader["Type"].ToString();
                person.Type = sqlReader["Image"].ToString();

                PeopleList.Add(person);
            }

            sqlReader.Close();
            return PeopleList;

        }


        public static void DeleteMessage(int Id)
        {

            SqlCommand cmdDelete = conn.CreateCommand();
            cmdDelete.CommandType = CommandType.Text;
            cmdDelete.CommandText = "DELETE  FROM Messages " +
                                    "WHERE MessageId = " + Id;

            SqlDataReader sqlReader = cmdDelete.ExecuteReader();
            sqlReader.Close();

        }

        public static List<Appointment> GetAppointmentList(string id)
        {
            List<Appointment> AppointmentList = new List<Appointment>();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Parameterized Query
            cmd.CommandText = "SELECT * FROM Appointments " +
                                    "WHERE PatientId =  @Id";



            cmd.Parameters.Add("@Id", SqlDbType.VarChar);
            cmd.Parameters["@Id"].Value = id;

            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT
            while (sqlReader.Read())
            {
                Appointment tmpApp = new Appointment();
                tmpApp.PatientId = sqlReader["PatientId"].ToString();
                tmpApp.DoctorsId = sqlReader["DoctorsId"].ToString();
                tmpApp.AppointmentId = sqlReader["AppointmentId"].ToString();
                tmpApp.ExtraInfo = sqlReader["ExtraInfo"].ToString();
                tmpApp.RequestDate = Convert.ToDateTime(sqlReader["AppointmentRequestDate"].ToString());
                tmpApp.ConfirmDate = Convert.ToDateTime(sqlReader["AppointmentConfirmDate"].ToString());
                tmpApp.ReasonFor = sqlReader["ReasonFor"].ToString();
                tmpApp.Confirmed = sqlReader["Confirmed"].ToString();
                tmpApp.TypeOfAppointment = sqlReader["TypeOfAppointment"].ToString();

                AppointmentList.Add(tmpApp);
            }

            sqlReader.Close();
            return AppointmentList;

        }


        public static List<Appointment> GetDoctorAppointmentList(string id)
        {
            List<Appointment> AppointmentList = new List<Appointment>();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Parameterized Query
            cmd.CommandText = "SELECT * FROM Appointments " +
                                    "WHERE DoctorsId =  @Id";



            cmd.Parameters.Add("@Id", SqlDbType.VarChar);
            cmd.Parameters["@Id"].Value = id;

            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT
            while (sqlReader.Read())
            {
                Appointment tmpApp = new Appointment();
                tmpApp.PatientId = sqlReader["PatientId"].ToString();
                tmpApp.DoctorsId = sqlReader["DoctorsId"].ToString();
                tmpApp.AppointmentId = sqlReader["AppointmentId"].ToString();
                tmpApp.ExtraInfo = sqlReader["ExtraInfo"].ToString();
                tmpApp.RequestDate = Convert.ToDateTime(sqlReader["AppointmentRequestDate"].ToString());
                tmpApp.ConfirmDate = Convert.ToDateTime(sqlReader["AppointmentConfirmDate"].ToString());
                tmpApp.ReasonFor = sqlReader["ReasonFor"].ToString();
                tmpApp.Confirmed = sqlReader["Confirmed"].ToString();
                tmpApp.TypeOfAppointment = sqlReader["TypeOfAppointment"].ToString();

                AppointmentList.Add(tmpApp);
            }

            sqlReader.Close();
            return AppointmentList;

        }

        public static List<HospitalRoom> GetHospitalRooms()
        {
            List<HospitalRoom> hspRoomList = new List<HospitalRoom>();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Parameterized Query
            cmd.CommandText = "SELECT * FROM PatientRoom";




            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT
            while (sqlReader.Read())
            {
                HospitalRoom hspRoom = new HospitalRoom();

                hspRoom.HosiptalRoom = Convert.ToInt32(sqlReader["HospitalRoom"].ToString());
                hspRoom.Availabilty = Convert.ToInt32(sqlReader["Available"].ToString());
                hspRoom.PatientId = sqlReader["PatientId"].ToString();


                hspRoomList.Add(hspRoom);
            }

            sqlReader.Close();
            return hspRoomList;

        }

        public static List<DoctorPatients> GetDoctorConfirmAppList(string id)
        {
            List<DoctorPatients> DoctorsPatList = new List<DoctorPatients>();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Parameterized Query
            cmd.CommandText = "SELECT * FROM DoctorPatients " +
                                    "WHERE DoctorId =  @Id";



            cmd.Parameters.Add("@Id", SqlDbType.VarChar);
            cmd.Parameters["@Id"].Value = id;

            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT
            while (sqlReader.Read())
            {
                DoctorPatients DoctorPatients = new DoctorPatients();
                DoctorPatients.PatientId = sqlReader["PatientId"].ToString();
                DoctorPatients.DoctorId = sqlReader["DoctorId"].ToString();
                DoctorPatients.AdmittedId = Convert.ToInt32(sqlReader["Id"].ToString());
                DoctorPatients.ExtraInfo = sqlReader["ExtraInfo"].ToString();
                DoctorPatients.AdmittedDate = Convert.ToDateTime(sqlReader["AdmittedDate"].ToString());
                DoctorPatients.DischargedDate = Convert.ToDateTime(sqlReader["DischargedDate"].ToString());
                DoctorPatients.NurseId = sqlReader["NurseId"].ToString();
                DoctorPatients.Admitted = sqlReader["Admitted"].ToString();
                DoctorPatients.RoomNumber = sqlReader["Room"].ToString();


                DoctorsPatList.Add(DoctorPatients);
            }

            sqlReader.Close();
            return DoctorsPatList;

        }


        public static List<DoctorPatients> GetNurseConfirmAppList(string id)
        {
            List<DoctorPatients> DoctorsPatList = new List<DoctorPatients>();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Parameterized Query
            cmd.CommandText = "SELECT * FROM DoctorPatients " +
                                    "WHERE NurseId =  @Id";



            cmd.Parameters.Add("@Id", SqlDbType.VarChar);
            cmd.Parameters["@Id"].Value = id;

            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT
            while (sqlReader.Read())
            {
                DoctorPatients DoctorPatients = new DoctorPatients();
                DoctorPatients.PatientId = sqlReader["PatientId"].ToString();
                DoctorPatients.DoctorId = sqlReader["DoctorId"].ToString();
                DoctorPatients.AdmittedId = Convert.ToInt32(sqlReader["Id"].ToString());
                DoctorPatients.ExtraInfo = sqlReader["ExtraInfo"].ToString();
                DoctorPatients.AdmittedDate = Convert.ToDateTime(sqlReader["AdmittedDate"].ToString());
                DoctorPatients.DischargedDate = Convert.ToDateTime(sqlReader["DischargedDate"].ToString());
                DoctorPatients.NurseId = sqlReader["NurseId"].ToString();
                DoctorPatients.Admitted = sqlReader["Admitted"].ToString();
                DoctorPatients.RoomNumber = sqlReader["Room"].ToString();


                DoctorsPatList.Add(DoctorPatients);
            }

            sqlReader.Close();
            return DoctorsPatList;

        }

        public static List<Message> GetMessageList(string id)
        {
            List<Message> MessageList = new List<Message>();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //Parameterized Query
            cmd.CommandText = "SELECT * FROM Messages " +
                                    "WHERE ToUser =  @Id";



            cmd.Parameters.Add("@Id", SqlDbType.VarChar);
            cmd.Parameters["@Id"].Value = id;

            SqlDataReader sqlReader = cmd.ExecuteReader(); //Applied to SELECT
            while (sqlReader.Read())
            {
                Message msg = new Message();
                msg.MessageText = sqlReader["Message"].ToString();
                msg.Subject = sqlReader["Subject"].ToString();
                msg.ToUser = sqlReader["ToUser"].ToString();
                msg.FromUser = sqlReader["FromUser"].ToString();
                msg.MessageId = Convert.ToInt32(sqlReader["MessageId"].ToString());
                msg.Status = Convert.ToInt32(sqlReader["Status"].ToString());
                msg.SentDate = Convert.ToDateTime(sqlReader["SentDate"].ToString());
                MessageList.Add(msg);
            }

            sqlReader.Close();
            return MessageList;

        }

        public static DataTable GetAppointmentTable(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from Appointments where PatientId = @Id", conn);
            try
            {

                cmd.Parameters.Add("@Id", SqlDbType.VarChar);
                cmd.Parameters["@Id"].Value = id;
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                conn.Close();
                return dt;


            }

            catch { throw; }
        }


        [WebMethod]
        public static List<string> GetPeopleName(string empName)
        {
            List<string> PeopleNames = new List<string>();
            SqlCommand cmd = new SqlCommand("select Top 10 FirstName from Person where FirstName LIKE ''+@SearchEmpName+'%'", conn);
               try { 
                    cmd.Parameters.AddWithValue("@SearchEmpName", empName);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                    PeopleNames.Add(dr["FirstName"].ToString());
                    }
                    
                    return PeopleNames;
                }

            catch { throw;  }
            
        }

        public static DataTable GetUserMessageList(string id)
        {

            SqlCommand cmd = new SqlCommand("select * from Messages where ToUser = @Id", conn);
            try
            {

                cmd.Parameters.Add("@Id", SqlDbType.VarChar);
                cmd.Parameters["@Id"].Value = id;
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                conn.Close();
                return dt;


            }

            catch { throw; }
        }

    }
}