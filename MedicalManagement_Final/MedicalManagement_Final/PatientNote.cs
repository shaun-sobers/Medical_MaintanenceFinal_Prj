using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement_Final
{
    public class PatientNote
    {
        public string NoteSenderId { get; set; }

        public string DoctorPatientId { get; set; }

        public string Message { get; set; }

        public DateTime SentDate { get; set; }
    }
}