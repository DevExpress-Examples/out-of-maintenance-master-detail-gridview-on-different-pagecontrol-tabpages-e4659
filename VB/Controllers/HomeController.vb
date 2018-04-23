Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports CS.Model

Namespace CS.Controllers
	Public Class HomeController
		Inherits Controller
		Public Function Index() As ActionResult
			Return View(New MyViewModel With {.Categories = MyModel.GetCategories(), .Products = MyModel.GetProducts(0)})
		End Function
		Public Function GridViewPartialCategories() As ActionResult
			Return PartialView(MyModel.GetCategories())
		End Function
		Public Function GridViewPartialProducts() As ActionResult
			Return PartialView(MyModel.GetProducts(Request.Params("MasterRowKey")))
		End Function

    End Class
End Namespace
