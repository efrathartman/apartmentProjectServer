using Common.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class Apartment
    {
        //[Key]
        public int Id { get; set; }
        //   public int IdOwn { get; set; }
        //  public string NameOwn { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
       [ForeignKey("UserId")]
        public virtual User User { get; set; }
        
        // public virtual User UserName { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public int NumOfRooms { get; set; }
        public int NumOfBeds { get; set; }
        public int Price { get; set; }
        // public int IdCategory { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Response> ResponseOfUsers { get; set; }
       //public string UrlImage {  get; set; }
        public List<string>? UrlImages { get; set; }
        // public virtual ICollection<Order> OrdersForApartment { get; set; }
        
    }
}
