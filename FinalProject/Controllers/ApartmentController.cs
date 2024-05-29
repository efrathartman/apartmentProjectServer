
using Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IService<ApartmentDto> service;
        public ApartmentController(IService<ApartmentDto> service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task< List<ApartmentDto>> Get()
        {
            return await service.getAllAsync();
        }

        // GET api/<ApartmentController>/5
        [HttpGet("{id}")]
        public async Task< ApartmentDto> Get(int id)
        {
            return await service.getAsync(id);
        }

        // POST api/<ApartmentController>
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ApartmentDto apartmentDto)
        {
            apartmentDto.UrlImages=new List<string>();
            if(apartmentDto.FilelImages!=null)
            {
                foreach (var imageFile in apartmentDto.FilelImages)
                {
                    var myPath = Path.Combine(Environment.CurrentDirectory + "/Images/" + imageFile.FileName);
                    Console.WriteLine("myPath: "+ myPath);
                    using(FileStream fs=new FileStream(myPath,FileMode.Create))
                    {
                        imageFile.CopyTo(fs);   
                        fs.Close();
                        apartmentDto.UrlImages.Add(imageFile.FileName);
                    }
                }
            }
            return Ok(await service.AddAsync(apartmentDto));
        }
        //public async Task Post([FromForm] ApartmentDto ApartmentDto)
        //{

        //    var myPath = Path.Combine(Environment.CurrentDirectory + "/Images/" + ApartmentDto.FileImage.FileName);
        //    using (FileStream fs = new FileStream(myPath, FileMode.Create))
        //    {
        //        ApartmentDto.FileImage.CopyTo(fs);
        //        fs.Close();
        //    }
        //    ApartmentDto.UrlImage = ApartmentDto.FileImage.FileName;
        //    await service.AddAsync(ApartmentDto);
        //}
        [HttpGet("getImage/{ImageUrl}")]
        public string GetImage(string ImageUrl)
        {
            var path = Path.Combine(Environment.CurrentDirectory+ "/Images/", ImageUrl);
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            string imageBase64 = Convert.ToBase64String(bytes);
            string image = string.Format("data:image/jpeg;base64,{0}", imageBase64);
            return image;
        }


        // PUT api/<ApartmentController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromForm] ApartmentDto apartmentDto)
        {
            apartmentDto.UrlImages = new List<string>();
            if (apartmentDto.FilelImages != null)
            {
                foreach (var imageFile in apartmentDto.FilelImages)
                {
                    var myPath = Path.Combine(Environment.CurrentDirectory + "/Images/" + imageFile.FileName);
                    Console.WriteLine("myPath: " + myPath);
                    using (FileStream fs = new FileStream(myPath, FileMode.Create))
                    {
                        imageFile.CopyTo(fs);
                        fs.Close();
                        apartmentDto.UrlImages.Add(imageFile.FileName);
                    }
                }
            }
            // return Ok(await service.updateAsync(id, apartmentDto));
            // return Ok(await service.AddAsync(apartmentDto));
            await service.updateAsync(id, apartmentDto);

            //  await service.AddAsync(apartmentDto)
        }

        // DELETE api/<ApartmentController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
          await  service.deleteAsync(id);
        }

    }
}
