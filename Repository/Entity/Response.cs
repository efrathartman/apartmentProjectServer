using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class Response
    {
        public int Id { get; set; }
        //   public int IdOfUser { get; set; }
        // public int IdOfApartment { get; set; }
        //לזכור בריאקט
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int ApartmentId { get; set; }
        [ForeignKey("ApartmentId")]
        public virtual Apartment Apartment { get; set; }
        public string Description { get; set; }
    }
}
