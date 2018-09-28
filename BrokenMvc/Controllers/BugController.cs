using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace BrokenMvc.Controllers
{
    public class BugController : Controller
    {
        private readonly string _imagePath;

        public BugController(IHostingEnvironment hostingEnvironment) {
            var imagePath = System.IO.Path.Combine(hostingEnvironment.WebRootPath, "images", "Microsoft-logo_rgb_wht.png");
            var provider = new PhysicalFileProvider(hostingEnvironment.WebRootPath);
            _imagePath = provider.GetFileInfo("images/Microsoft-logo_rgb_wht.png").PhysicalPath;
        }

        public IActionResult NotWorking()
        {
            return File(_imagePath, "image/png");
        }

        public IActionResult Working()
        {
            return File(System.IO.File.ReadAllBytes(_imagePath), "image/png");
        }
    }
}
