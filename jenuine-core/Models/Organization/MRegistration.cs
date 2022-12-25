using System;
using System.Collections.Generic;

namespace Its.Jenuiue.Core.Models.Organization
{
    public class MRegistration : BaseOrgModel
    {
        public String RegistrationId { get; set; }
        public String RegistrationName { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string IP { get; set; }
        public List<string> Headers { get; set; }
    }
}