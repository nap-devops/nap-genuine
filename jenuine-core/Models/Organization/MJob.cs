using System;

namespace Its.Jenuiue.Core.Models.Organization
{
    public class MJob : BaseOrgModel
    {
        public DateTime JobDate { get; set; }
        public string JobId { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int Progress { get; set; }
        public int Quantity { get; set; }
        public string Tags { get; set; }
        public string Organization { get; set; }

        public string ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
