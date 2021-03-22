using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarImagesOperationDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
