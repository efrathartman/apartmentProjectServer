using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Common.Dtos
{
    public class ApartmentDto
    {
       public int? Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }

        public virtual UserDto? User { get; set; }

        //  public string NameOwn { get; set;}
        public string? City { get; set; }
        public string? Area { get; set; }
        public int? NumOfRooms { get; set; }
        public int? NumOfBeds { get; set; }
        public int? Price { get; set; }
        
        public int? CategoryId { get; set; }
        public string? Description { get; set;}
        //public IFormFile? FileImage { get; set; }
        //public string? UrlImage { get; set; }
        public List<IFormFile>? FilelImages { get; set; }
        public List<string>? UrlImages { get; set; }
        public virtual ICollection<ResponseDto>? ResponseOfUsers { get; set; }
        // public List< FormFile> files { get; set; }
        // public string? UrlImage { get; set; }
        //  public virtual List<ResponseDto> ResponseOfUsers { get; set;}



    }
}
