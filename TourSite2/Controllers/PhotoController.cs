using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourSite2.Models;
using DataLayer;
using System.Drawing;
using System.Web.Helpers;
using System.Drawing.Imaging;
using System.IO;
using System.Diagnostics;

namespace TourSite2.Controllers
{
    public class PhotoController : Controller
    {
        //
        // GET: /Photo/

        public ActionResult Index(string filter = null, int page = 1, int pageSize = 20)
        {
            var records = new PagedList<Photo>();
            var context = new TourEntities1();
            ViewBag.filter = filter;

            records.Content = context.Photo
                        .Where(x => filter == null || (x.Decription.Contains(filter)))
                        .OrderByDescending(x => x.Id)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            // Count
            records.TotalRecords = context.Photo
                            .Where(x => filter == null || (x.Decription.Contains(filter))).Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;

            return View(records);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var photo = new Photo();
            return View(photo);
        }
        public Size NewImageSize(Size imageSize, Size newSize)
        {
            Size finalSize;
            double tempval;
            if (imageSize.Height > newSize.Height || imageSize.Width > newSize.Width)
            {
                if (imageSize.Height > imageSize.Width)
                    tempval = newSize.Height / (imageSize.Height * 1.0);
                else
                    tempval = newSize.Width / (imageSize.Width * 1.0);

                finalSize = new Size((int)(tempval * imageSize.Width), (int)(tempval * imageSize.Height));
            }
            else
                finalSize = imageSize; // image is already small size

            return finalSize;
        }
        private void SaveToFolder(Image img, string fileName, string extension, Size newSize, string pathToSave)
        {
            Size imgSize = NewImageSize(img.Size, newSize);
            System.Drawing.Image newImg = new Bitmap(img, imgSize.Width, imgSize.Height);

            newImg.Save(Server.MapPath(pathToSave), img.RawFormat);
            
        }
        [HttpPost]
        public ActionResult Create(Photo photo, IEnumerable<HttpPostedFileBase> files)
        {
            var context = new TourEntities1();
            if (!ModelState.IsValid)
                return View(photo);
            if (files.Count() == 0 || files.FirstOrDefault() == null)
            {
                ViewBag.error = "Please choose a file";
                return View(photo);
            }

          
            foreach (var file in files)
            {
                if (file.ContentLength == 0) continue;
                var model = new Photo();
                model.Decription = photo.Decription;
                var fileName = Guid.NewGuid().ToString();
                var extension = System.IO.Path.GetExtension(file.FileName).ToLower();

                MemoryStream ms = new MemoryStream();
                file.InputStream.CopyTo(ms);
                file.InputStream.Dispose();
                ms.Seek(0, SeekOrigin.Begin);
                //var img = System.Drawing.Image.FromStream(ms);
                //img.Save("./asd123.png");

                using (var img1 = System.Drawing.Image.FromStream(ms))
                {
                    //model.ThumbPath = String.Format("~{2}ImageGallery{2}thumbs{2}{0}{1}", fileName, extension, Path.DirectorySeparatorChar);
                    //model.ImagePath = String.Format("~{2}ImageGallery{2}{0}{1}", fileName, extension, Path.DirectorySeparatorChar);
                    model.ThumbPath = String.Format("/ImageGallery/thumbs/{0}{1}", fileName, extension);
                    model.ImagePath = String.Format("/ImageGallery/{0}{1}", fileName, extension);
                    // Save thumbnail size image, 100 x 100
                    SaveToFolder(img1, fileName, extension, new Size(100, 100), model.ThumbPath);

                    // Save large size image, 800 x 800
                    SaveToFolder(img1, fileName, extension, new Size(600, 600), model.ImagePath);
                }

                // Save record to database
                model.CreatedOn = DateTime.Now;
                context.Photo.Add(model);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Photo");
        }

    }
}
