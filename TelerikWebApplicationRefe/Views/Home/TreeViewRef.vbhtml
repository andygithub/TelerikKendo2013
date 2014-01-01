@ModelType Models.TreeViewRefModel

<p>Tree View Usage: Checkboxes, bound to a hiearachical UI control structure in the view model to prevent additional mapping.  </p>

@using (Html.BeginForm("TreeViewRef",  "Home", FormMethod.Post))
@<div >
    <strong>Inline data (default settings)</strong>
@code
    Html.Kendo.TreeView.Name("treeview-left").
        BindTo(Model.TreeViewItemModel).
        Checkboxes(Function(x) x.CheckChildren(True).
                       Name("filters")).
                   ItemAction(Sub(x) x.Checked = model.nodesSelected.Contains(x.id)).
                   ExpandAll(True).
                   Events(Function(e) e.Select("onSelect")).
                   Render
 end code

</div>
    @<button id="find" class="k-button">Find checked nodes</button>
End Using
<p />
<div id="result">
@if Model.nodesSelected isnot Nothing andalso Model.nodesSelected.Count > 0 then
    @<text>Checked nodes: @(String.Join(", ", Model.nodesSelected)) </text>
else
    @<text>No nodes checked.</text>
End If
</div>

<script type="text/javascript">

    function onSelect(e) {
        e.preventDefault();
        $(':checkbox:first', $(e.node)).click();
        //    kendoConsole.log("Selecting: " + this.text(e.node));
 
    }

</script>