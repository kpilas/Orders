using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;

namespace Orders.Models.Domains
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Orders = new Collection<Order>();
        }

        public ICollection<Order> Orders { get; set; }
    }
}
