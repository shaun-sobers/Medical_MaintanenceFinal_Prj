using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement_Final
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageText { get; set; }

        public string ToUser { get; set; }

        public string FromUser { get; set; }

        public string Subject { get; set; }

        public int Status { get; set; }

        public DateTime SentDate { get; set; }
    }
}