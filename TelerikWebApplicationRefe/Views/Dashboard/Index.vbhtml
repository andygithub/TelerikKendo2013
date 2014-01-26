@ModelType Models.DashboardModel
@Code
    ViewData("Title") = "Dashboard Default"
End Code

<h2>Dashboard</h2>
<div class="row">
    <div class="col-md-8">
        <div class="well well-sm" >           
            <h4>Summary</h4>
            @code
                Html.Kendo().Grid(Of SummaryGrid).
                    Name("summarygrid").
                    Columns(Sub(c)
                                    c.Bound(Function(x) x.Id).Width(110)
                                    c.Bound(Function(x) x.FilterId).Width(110)
                                    c.Bound(Function(x) x.FilterName)
                                    c.Bound(Function(x) x.Name)
                                    c.Bound(Function(x) x.Description)
                                    c.Command(Function(x) x.Custom("Details").Click("showDetails"))
                            End Sub).
                    Sortable().
                    Filterable().
                    Pageable().
                    Scrollable().
                    Pageable(Function(p) p.Refresh(True).PageSizes(True).ButtonCount(5)).
                    HtmlAttributes(New With {.style = "height:400px;"}).
                    Resizable(Function(r) r.Columns(true)).
                    DataSource(Function(d)
                                       Return d.Ajax.PageSize(10).Read(Function(r) r.Action("Summary_Read", "Dashboard").Data("getFilters"))
                               End Function).
                                Render()

            end code
        </div>
    </div>
    <div class="col-md-4">
        @Using (Ajax.BeginForm("SaveFilters", "Dashboard", New AjaxOptions With {.HttpMethod = "post", .UpdateTargetId = "statusupdate"}))
            @<div class="well well-sm">
                <h4>Filters</h4>
                @code
                Html.Kendo.TreeView.Name("treeview-filter").
                BindTo(Model.TreeViewItemModel).
                Checkboxes(Function(x) x.CheckChildren(True).
                       Name("filters")).
                   ExpandAll(True).
                   Events(Function(e) e.Select("onSelect")).
                   Render()
                end code

                 <button id="find" class="k-button">Save Filters</button>
                 <button id="clickme" class="k-button">List Selected</button>
                 <div id="statusupdate"></div>
                 <div id="results">
                     <h4>Checked Items</h4>
                     <ul></ul>
                 </div>
            </div>        
        End Using
    </div>
    </div>

<div class="row" id="detailRow">
    <div class="col-md-8">
        <div class="well well-sm">
            <h4>Detail</h4>
            @code
                Html.Kendo().Grid(Of DetailGrid).
                    Name("detailgrid").
                    Columns(Sub(c)
                                    c.Bound(Function(x) x.Id).Width(110)
                                    c.Bound(Function(x) x.SummaryId).Width(110)
                                    c.Bound(Function(x) x.DetailName)
                                    c.Bound(Function(x) x.DetailsDesc)
                            End Sub).
                    Sortable().
                    Filterable().
                    Pageable().
                    AutoBind(False).
                    Scrollable(Function(s) s.Enabled(False)).
                    Pageable(Function(p) p.Refresh(True).PageSizes(True).ButtonCount(5)).
                    Resizable(Function(r) r.Columns(True)).
                    DataSource(Function(d)
                                       Return d.Ajax.PageSize(10).Read(Function(r) r.Action("Detail_Read", "Dashboard").Data("getSelectedSummary"))
                               End Function).
                                Render()

            end code
        </div>
    </div>
</div>

@section scripts
<script type="text/javascript">

    var summarySelectedId;

    function showDetails(e) {
        //alert('common');
        var tr = $(e.currentTarget).closest("tr");
        var item = $("#summarygrid").data("kendoGrid").dataItem(tr);
        //grab the model property we care about from the item, in this case the property is ID
        summarySelectedId = item.Id;
        //set the above variable that will be passed back in the detail grid data source parameters
        //debugger;
        $("#detailRow").show();
        var grid = $("#detailgrid").data("kendoGrid");
        grid.dataSource.page(1);
    }

    function getFilters(e) {
        //get all checked checkboxes from the filter tree view
        var checkedValueList = [];
        $('.k-treeview').find('input:checked').each(function (index, checkbox) {
            var $checkbox = $(this);
            checkedValueList.push(parseInt($checkbox.val()));
        });
        //debugger;
        return {
            firstName: "John",
            lastName: "Doe",
            dashboardFilters: JSON.stringify(checkedValueList)
        };
    }

    function getSelectedSummary(e) {
        debugger;
        return {
            summaryId: summarySelectedId
        };
    }

    function onSelect(e) {
        e.preventDefault();
        $(':checkbox:first', $(e.node)).click();
        //    kendoConsole.log("Selecting: " + this.text(e.node));

    }

    // show checked node IDs on datasource change
    $("#treeview-filter").on("change", ":checkbox", function () {
        alert('change checkbox -');
        //refresh grid with new filter selections
        var grid = $("#summarygrid").data("kendoGrid");
        //grid.refresh();
        grid.dataSource.page(1);
        //grid.dataSource.read();
        //debugger;
        //hide detail section until command button clicked
        $("#detailRow").hide();
    });

    //code to get all checked items see - http://blogs.telerik.com/kendoui/posts/13-10-17/how-to-get-the-checked-items-from-a-treeview-with-checkboxes 

    // Button handler
    // --------------

    $("#clickme").click(function (e) {
        e.preventDefault();
        var $res = $("#results ul");
        $res.html("");

        var checkedValueList = [];
        $('.k-treeview').find('input:checked').each(function (index, checkbox) {
            var $checkbox = $(this);
            checkedValueList.push(parseInt($checkbox.val()));
        });
        debugger;
        //var items = treeview.getCheckedItems();

        if (checkedValueList.length === 0) {
            $("<li>(nothing checked)</li>").appendTo($res);
        } else {
            for (var i = 0; i < checkedValueList.length; i++) {
                $("<li>" + checkedValueList[i] + "</li>").appendTo($res);
            }
        }
    });
</script>
end section
