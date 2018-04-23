Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks
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

		Public Function ExportTo(ByVal MasterRowKey As Integer) As ActionResult
			Dim ps As New PrintingSystem()

			Dim link1 As New PrintableComponentLink(ps)
			Dim categoriesGridSettings As New GridViewSettings()
			categoriesGridSettings.Name = "gvCategories"
			categoriesGridSettings.KeyFieldName = "CategoryID"
			categoriesGridSettings.Columns.Add("CategoryID")
			categoriesGridSettings.Columns.Add("CategoryName")
			categoriesGridSettings.Columns.Add("Description")
			link1.Component = GridViewExtension.CreatePrintableObject(categoriesGridSettings, MyModel.GetCategories())

			Dim link2 As New PrintableComponentLink(ps)
			Dim productsGridSettings As New GridViewSettings()
			productsGridSettings.Name = "gvProducts"
			productsGridSettings.KeyFieldName = "ProductID"
			productsGridSettings.Columns.Add("ProductID")
			productsGridSettings.Columns.Add("ProductName")
			productsGridSettings.Columns.Add("CategoryID")
			productsGridSettings.Columns.Add("UnitPrice")
			link2.Component = GridViewExtension.CreatePrintableObject(productsGridSettings, MyModel.GetProducts(MasterRowKey))

			Dim compositeLink As New CompositeLink(ps)
			compositeLink.Links.AddRange(New Object() { link1, link2 })
			compositeLink.CreateDocument()

			Dim result As FileStreamResult = CreateExcelExportResult(compositeLink)
			ps.Dispose()

			Return result
		End Function

		Private Function CreateExcelExportResult(ByVal link As CompositeLink) As FileStreamResult
			Dim stream As New MemoryStream()
			link.PrintingSystem.ExportToXls(stream)
			stream.Position = 0
			Dim result As New FileStreamResult(stream, "application/xls")
			result.FileDownloadName = "MyData.xls"
			Return result
		End Function
	End Class
End Namespace
