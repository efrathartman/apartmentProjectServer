using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class ResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual UserDto? User { get; set; }
        public int ApartmentId { get; set; }
        public string Description { get; set; }
        
    }
}
