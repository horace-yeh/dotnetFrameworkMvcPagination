using PartialViewExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartialViewExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Detail()
        {
            ViewData["NowPage"] = 1;
            ViewData["TotalPage"] = 3;
            var model = new DetailViewModel();
            model.Master = new MasterInfo { Id = 6666, No = "PartialViewMaster" };
            model.Details = GetDetialInfoList().Take(10);
            return View(model);
        }
       
        [OutputCache(NoStore = true, Duration = 0)]
        [HttpPost]
        public ActionResult DetailPartialView(PaginationInfo paginationInfo)
        {
            var pageNum = 10;
            var list = GetDetialInfoList();
            var query = list.Skip((paginationInfo.Page - 1) * pageNum).Take(pageNum);
            ViewData["NowPage"] = paginationInfo.Page;
            return PartialView("DetailPartialView", query);
        }

        private IList<DetailInfo> GetDetialInfoList()
        {
            var temp = new List<DetailInfo>(); 
            for(var i = 1; i < 31; i++)
            {
                temp.Add(new DetailInfo { Id = i, Name = i.ToString() });
            }
            return temp;
        }
    }
}