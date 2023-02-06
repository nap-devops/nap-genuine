using System.ComponentModel.DataAnnotations;

namespace Its.Jenuiue.Core.ModelsViews.Organization
{
    public class MVCustomer : BaseModelView
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string PhoneNo { get; set; }
        
        [StringLength(200)]
        public string Description { get; set; }
        public string Email { get; set; }
    }
}
