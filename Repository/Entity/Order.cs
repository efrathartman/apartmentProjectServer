using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class Order
    {
        public int Id { get; set; }
        //  public int IdUser { get; set; }
        //   public int IdApartment { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        //לזכור בריאקט
        public virtual User User { get; set; } 
        public int ApartmentId { get; set; }
        [ForeignKey("ApartmentId")]
        public virtual Apartment Apartment { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    
    }
}
