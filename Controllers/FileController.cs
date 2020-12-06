using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RWFM.Repositories;
using RWFM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RWFM.Controllers
{
    [VerifyUser]
    public class FileController : Controller
    {
        private readonly ILogger<FileController> _logger;

        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
        }

        public IActionResult GetRootPath()
        {
            return new JsonResult(new { path = "C://" });
        }

        public IActionResult GetFolderContent(string path)
        {
            FolderModel folder = new FolderModel(path);
            return new JsonResult(folder.GetChildFiles());
        }
    }
}
