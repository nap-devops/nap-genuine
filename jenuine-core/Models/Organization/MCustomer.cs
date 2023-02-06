namespace Its.Jenuiue.Core.Models.Organization
{
    public class MCustomer : BaseOrgModel
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}
