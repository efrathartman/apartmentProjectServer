using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        
       public virtual ICollection<Apartment> ApartmentsOfUsers { get; set; }
      //  [InverseProperty("UserId")]
     //  public virtual ICollection<Order> OrderssOfUsers { get; set; }

    }
}
