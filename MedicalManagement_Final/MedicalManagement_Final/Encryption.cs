using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement_Final
{
    public static class Encryption
    {
        public static string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }

        public static string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

        public static string ConvertDate(DateTime datetime)
        {

            string date = datetime.ToString("dd/MMMM/yyyy");
            string[] newdate = date.Split('-');
            string finalDate = newdate[0] + "/" + newdate[1] + "/" + newdate[2];
            return finalDate;
        }
    }
}