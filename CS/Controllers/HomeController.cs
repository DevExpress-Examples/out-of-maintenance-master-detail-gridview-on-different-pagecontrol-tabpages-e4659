using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using CS.Model;

namespace CS.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View(new MyViewModel { Categories = MyModel.GetCategories(), Products = MyModel.GetProducts(0) });
        }
        public ActionResult GridViewPartialCategories() {
            return PartialView(MyModel.GetCategories());
        }
        public ActionResult GridViewPartialProducts() {
            return PartialView(MyModel.GetProducts(Request.Params["MasterRowKey"]));
        }
    }
}
