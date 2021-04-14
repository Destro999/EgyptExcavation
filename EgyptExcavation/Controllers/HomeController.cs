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

        // File storage is in separate database from burials and biological samples. Contexts here
        private readonly EgyptContext _context;
        private readonly FileUploadsContext fileCtx;

        public int PictureSize = 5;

        // constructor
        public HomeController(ILogger<HomeController> logger, EgyptContext context, FileUploadsContext fctx)
        {
            _logger = logger;

            _context = context;
            fileCtx = fctx;
        }

        // Home page
        public IActionResult Index()
        {
            ViewBag.NavBar = "Home";
            return View();
        }

        // Takes user to portal to add burial, biological info, or file upload. Requires priveleges
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

        // Takes user to gallery view
        public IActionResult Gallery()
        {
            ViewBag.NavBar = "Gallery";
            return View();
        }

        // Form to upload new file
        [Authorize(Policy = "writepolicy")]
        [HttpGet]
        public IActionResult UploadFile(int? id = null)
        {
            ViewBag.NavBar = "Upload";

            string? burialId = null;
            if (id != null)
            {
                burialId = _context.Burial.Where(x => x.BurialIdInt == id).Select(x => x.BurialId).FirstOrDefault();
            }

            ViewBag.BurialId = burialId;
            return View();
        }

        // Post that adds file to database as varbinary
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
                        //DocumentId = 0,
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
                    return View("FileUploadSuccessful");

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

        // returns list of all the image uploads. Not currently in use in production.
        public IActionResult ImageUploads()
        {
            return View(fileCtx.Files.ToList());
        }

        // shows details of an individual file upload
        public IActionResult UploadDetails(int id)
        {
            return View(fileCtx.Files.Where(x => x.DocumentId == id).FirstOrDefault());
        }

        //Asks user if they really want to delete a file upload
        [Authorize(Policy = "adminpolicy")]
        public IActionResult DeleteUploadConfirmation(int id)
        {
            return View(fileCtx.Files.Where(x => x.DocumentId == id).FirstOrDefault());
        }

        // Actually deletes the file upload and sends user back to list of burials
        [Authorize(Policy = "adminpolicy")]
        public IActionResult DeleteUpload(int id)
        {
            var upload = fileCtx.Files.Where(x => x.DocumentId == id).FirstOrDefault();
            fileCtx.Files.Remove(upload);
            fileCtx.SaveChanges();
            return RedirectToAction("Index","Burials");
        }
    }
}
