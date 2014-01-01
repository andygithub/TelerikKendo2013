
<p>Grid Usage: nested grids  </p>

<div >
    <strong>Grid</strong>
    @code
        Html.Kendo().Grid(Of Employee).
            Name("grid").
            Columns(Sub(c)
                            c.Bound(Function(x) x.FirstName).Width(110)
                            c.Bound(Function(x) x.LastName).Width(110)
                            c.Bound(Function(x) x.Country).Width(110)
                            c.Bound(Function(x) x.City).Width(110)
                            c.Bound(Function(x) x.Title)
                    End Sub).
            Sortable().
            Pageable().
            Scrollable().
            ClientDetailTemplateId("template").
            HtmlAttributes(New With {.style = "height:430px;"}).
            DataSource(Function(d)
                               Return d.Ajax.PageSize(6).Read(Function(r) r.Action("Employee_Read", "Home"))
                       End Function).
                        Events(Function(e) e.DataBound("dataBound")).Render
        
end code

<script id="template" type="text/kendo-tmpl">
    @(Html.Kendo().Grid(Of Address)().
        Name("grid_#=EmployeeID#").
        Columns(Sub(c)
                        c.Bound(Function(x) x.AddessLine1).Width(140)
                        c.Bound(Function(x) x.AddessLine2)
                        c.Bound(Function(x) x.City)
                        c.Bound(Function(x) x.State).Width(190)
                        c.Bound(Function(x) x.Zip)
                End Sub).
        DataSource(Function(d)
                           Return d.Ajax().Read(Function(r) r.Action("AddressNested_Read", "Home", new with { .employeeID = "#=EmployeeID#" }))
                   End Function).
        Pageable().
    Sortable().
    ToClientTemplate()
    )
</script>
<script type="text/javascript">
    function dataBound() {
        this.expandRow(this.tbody.find("tr.k-master-row").first());
    }
</script>
    
</div>


