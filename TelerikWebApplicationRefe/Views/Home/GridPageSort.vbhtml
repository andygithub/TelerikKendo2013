<p>Grid Usage: Basic usage - paging, sorting, filtering to a strongly typed list  </p>

<div >
    <strong>Grid</strong>

    @code
        Html.Kendo.Grid(Of Address).
            Name("grid").
            Columns(Sub(c)
                        c.Bound(Function(x) x.AddessLine1).Width(140)
                        c.Bound(Function(x) x.AddessLine2)
                        c.Bound(Function(x) x.City)
                        c.Bound(Function(x) x.State).Width(190)
                        c.Bound(Function(x) x.Zip)
                        c.Template(Sub()
                                        @<text>server template</text>
                                    End Sub).Title("Template column").ClientTemplate("client template")
                    End Sub).
        HtmlAttributes(New With {.style = "height: 380px;"}).
    Scrollable().
    Filterable().
    Sortable().
    Pageable(Function(x) x.Refresh(True).PageSizes(True).ButtonCount(5)).
    DataSource(Function(d)
                   Return d.Ajax().Read(Function(r) r.Action("Address_Read", "Home"))
               End Function).
           Render()
    End Code


</div>
    

