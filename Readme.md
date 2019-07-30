<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Controllers/HomeController.vb))
* [Model.cs](./CS/Models/Model.cs) (VB: [Model.vb](./VB/Models/Model.vb))
* [GridViewPartialCategories.cshtml](./CS/Views/Home/GridViewPartialCategories.cshtml)
* [GridViewPartialProducts.cshtml](./CS/Views/Home/GridViewPartialProducts.cshtml)
* **[Index.cshtml](./CS/Views/Home/Index.cshtml)**
<!-- default file list end -->
# Master-Detail GridView on different PageControl TabPages
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4659/)**
<!-- run online end -->


<p>This example illustrates how to define a master-detail GridView located on different PageControl TabPages.<br /><br />The main implementation details:<br /><br />- Define both grids in separate PartialView files. See the <a href="https://www.devexpress.com/Support/Center/p/KA20010">KA20010: Why can the alert message with the HTML/JavaScript/CSS content appear when using callback-aware extensions?</a> KB Article for more information;<br />- Handle the master grid's client-side <strong>FocusedRowChanged</strong> event;<br />- Perform a custom callback of the detail grid via the client-side <strong>ASPxClientGridView.PerformCallback</strong> method;<br />- Handle the detail grid's client-side <strong>BeginCallback</strong> event;<br />- Pass the required data (for example, the master grid's data FocusedRow keyValue / visibleIndex) as a parameter. See the <a href="https://documentation.devexpress.com/#AspNet/CustomDocument9941">Passing Values to a Controller Action through Callbacks</a> help topic for more information;<br />- Handle the detail grid's <strong>CallbackRouteValues.Action</strong> method, retrieve the passed parameter and initialize the Model object according to this data.</p>

<br/>


