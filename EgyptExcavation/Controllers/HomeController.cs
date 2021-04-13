using EgyptExcavation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavation.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        private readonly EgyptContext _context;
        private readonly FileUploadsContext fileCtx;

        public int PictureSize = 5;

        public HomeController(ILogger<HomeController> logger, EgyptContext context, FileUploadsContext fctx)
        {
            _logger = logger;

            _context = context;
            fileCtx = fctx;
        }

        public IActionResult Index()
        {
            ViewBag.NavBar = "Home";
            return View();
        }

        [Authorize(Policy = "writepolicy")]
        public IActionResult AddRecord()
        {
            ViewBag.NavBar = "AddRecord";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            ViewBag.NavBar = "Gallery";
            return View();
        }

        [Authorize(Policy = "writepolicy")]
        [HttpGet]
        public IActionResult UploadFile()
        {
            ViewBag.NavBar = "Upload";
            return View();
        }

        [Authorize(Policy = "writepolicy")]
        [HttpPost]
        public IActionResult UploadFile(IFormFile files, Files file)
        {
            ViewBag.NavBar = "Upload";

            if (files != null)
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);
                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);
                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    var newBurialId = file.BurialId;


                    var objfiles = new Files()
                    {
                        DocumentId = 0,
                        Name = newFileName,
                        FileType = fileExtension,
                        BurialId = newBurialId
                    };

                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objfiles.DataFiles = target.ToArray();
                    }

                    fileCtx.Files.Add(objfiles);
                    fileCtx.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
            }
            return View();


            //if (ModelState.IsValid)
            //{
            //    fileCtx.Add(upload);
            //    await fileCtx.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(upload);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ImageUploads()
        {
            return View(fileCtx.Files.ToList());
        }

        public IActionResult UploadDetails(int id)
        {
            return View(fileCtx.Files.Where(x => x.DocumentId == id).FirstOrDefault());
        }
    }
}
