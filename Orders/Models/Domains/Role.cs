using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Orders.Models.Domains
{
    public class Role
    {
        public Role()
        {
            Users = new Collection<ApplicationUser>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
    }
}
