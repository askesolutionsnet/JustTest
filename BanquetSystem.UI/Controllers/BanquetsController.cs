using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BanquetSystem.Services;
using BanquetSystem.Domain;
using System.IO;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace BanquetSystem.UI.Controllers
{
    public class BanquetsController : Controller
    {
        private BanquetAPIService service = new BanquetAPIService();
        // GET: Banquets
        public async Task<ActionResult> Index()
        {
           // var absolute_path = Path.GetDirectoryName(Application.);
            var GetBanquestAsync = await service.GetBanquestAsync();

            return View("Index", GetBanquestAsync);
        }

        // GET: Banquets/Details/5
        public async Task<ActionResult> Details(int id=0)
        {
            ViewBag.Title = "Banquet Detail";
            ViewBag.Heading = "Banquet Detail";

            if (id == 0)
                return RedirectToAction("Index");

            var GetBanquestDetailAsync = await service.GetBanquestDetailAsync(id);

            return View("Details", GetBanquestDetailAsync);
        }

        // GET: Banquets/Create
        public ActionResult Create()
        {
            CustomerDetailBDO model = new CustomerDetailBDO();

            model.Cities = new List<SelectListItem>()
                    { new SelectListItem() { Text = "Karachi", Value = "1"}};

            model.Countries = new List<SelectListItem>()
                    { new SelectListItem() { Text = "Pakistan", Value = "1"}};

            return View("Create", model);
        }

        // POST: Banquets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomerDetailBDO customerdetails)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    HttpFileCollectionBase files = HttpContext.Request.Files;
                    int fileCount = files.Count;
                    for (int i = 0; i < fileCount; i++)
                    {
                        HttpPostedFileBase file = files.Get(i);
                        string filepath = @"\Content\BanquetImages\" + file.FileName;
                        file.SaveAs(@"E:\GitHub\BanquetSystem\BanquetSystem\BanquetSystem.UI\" + filepath);
                        customerdetails.CustomerImages[i].Image = filepath;
                    }
                    var SaveBanquestAsync = await service.SaveBanquestAsync(customerdetails);                 
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Banquets/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Banquets/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Banquets/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Banquets/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
