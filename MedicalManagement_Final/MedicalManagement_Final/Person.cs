using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement_Final
{
    public class Person
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public List<string> _Allergies = new List<string>();

        public string PhoneNumber { get; set; }

        public string BloodType { get; set; }

        public string Sex { get; set; }

        public string EmergancyContactNum { get; set; }

        public string EmergancyContactName { get; set; }

        public string Type { get; set; }

        public string Image { get; set; }

        public string SecurityQuestion { get; set; }

        public string SecurityAnswer { get; set; }
        public void AddAllergy(string allergy)
        {
            _Allergies.Add(allergy);
        }
        
        public List<string> GetAllergies()
        {
            return _Allergies;
        }
        public string FullName()
        {
            return this.FirstName.Trim()+", "+this.LastName.Trim();
        }

        public void LoadAllergies()
        {
            this._Allergies = Database.GetPatientAllergyList(this.Id);
        }
    }

}