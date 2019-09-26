using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcUI.Models
{
  public class FileUploadVM
  {
    public IFormFile FileToUpload { get; set; }
  }
}
