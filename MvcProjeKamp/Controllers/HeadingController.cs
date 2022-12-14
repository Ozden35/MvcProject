using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayerrr.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager (new EfHeadingDal());
        CategoryManager cm = new CategoryManager (new EfCategoryDal());
        WriterManager wm = new WriterManager (new EfWriterDal());
        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                       Text=x.CategoryName,
                                                       Value=x.CategoryID.ToString()
                                                  }
                                                        ).ToList();

            List<SelectListItem> Valuewriter=(from x in wm.GetList()
                                           select new SelectListItem
                                           { 
                                               Text=x.WriterName + " " + x.WriterSurName,
                                               Value=x.WriterID.ToString()
                                           }).ToList();
            ViewBag.vlc = valuecategory;
            ViewBag.vlw = Valuewriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        //public ActionResult ContentByHeading()
        //{
        //    return View();
        //}
    }
}