/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OpenId.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using AmlexTradeWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class ImageController : Controller
{
    private ForumDB _db;
    IWebHostEnvironment _appEnvironment;
    public ImageController(ForumDB DB, IWebHostEnvironment appEnvironment)
    {
        _db = DB;
        _appEnvironment = appEnvironment;
    }

    public IActionResult Index()
    {
        return View(_db.Files.ToList());
    }
    [HttpPost]
    public async Task<IActionResult> AddFile(IFormFile uploadedFile)
    {
        if (uploadedFile != null)
        {
            // путь к папке Files
            string path = "/Files/" + uploadedFile.FileName;
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }
            FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
            _db.Files.Add(file);
            _db.SaveChanges();
            
        }
        return RedirectToAction("Index");
    }
}
