using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement_Final
{
    public class Perscription
    {
        public string PatientId { get; set; }

        public string assignedByDoctor { get; set; }

        public string perscriptionType { get; set; }

        public string Length { get; set; }

        public DateTime PerscriptionDate { get; set; }
    }
}