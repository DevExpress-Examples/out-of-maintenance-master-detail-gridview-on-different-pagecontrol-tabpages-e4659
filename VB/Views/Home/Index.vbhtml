@ModelType CS.Model.MyViewModel
<script type="text/javascript">
    var TabPageActivated = false;
    function OnFocusedRowChanged(s, e) {
        if (!TabPageActivated) {
            TabPageActivated = true;
        }
        else {
            pc.SetActiveTabIndex(1);
            gvProducts.PerformCallback();
        }
    }
    function OnActiveTabChanged(s, e) {
        gvProducts.PerformCallback();
    }
    function OnBeginCallback(s, e) {
        e.customArgs["MasterRowKey"] = gvCategories.GetRowKey(gvCategories.GetFocusedRowIndex());
    }
</script>
@Html.DevExpress().PageControl( _
    Sub(settings)
            settings.Name = "pc"
            settings.TabPages.Add("Tab 0").SetContent( _
                Sub()
                        Html.RenderPartial("GridViewPartialCategories", Model.Categories)
                End Sub)
            settings.TabPages.Add("Tab 1").SetContent( _
                Sub()
                        Html.RenderPartial("GridViewPartialProducts", Model.Products)
                End Sub)
            settings.EnableClientSideAPI = True
            settings.ClientSideEvents.ActiveTabChanged = "OnActiveTabChanged"
    End Sub).GetHtml()
