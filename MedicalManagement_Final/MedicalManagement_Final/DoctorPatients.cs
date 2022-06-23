using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement_Final
{
    public class DoctorPatients
    {

        public int AdmittedId { get; set; }

        public string DoctorId { get; set; }

        public string PatientId { get; set; }

        public string NurseId { get; set; }

        public string RoomNumber { get; set; }

        public string Admitted { get; set; }

        public DateTime AdmittedDate { get; set; }

        public DateTime DischargedDate { get; set; }

        public string ExtraInfo { get; set; }
    }
}