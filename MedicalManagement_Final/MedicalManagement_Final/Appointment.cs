using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement_Final
{
    public class Appointment
    {
        public string AppointmentId { get; set; }
       public string PatientId { get; set; }
       public string DoctorsId { get; set; }

       public DateTime RequestDate { get; set; }

       public DateTime ConfirmDate { get; set; }

       public string ReasonFor { get; set; }

       public string TypeOfAppointment { get; set; }

        public string Severity { get; set; }

        public string ExtraInfo { get; set; }

        public string Confirmed { get; set; }


    }
}