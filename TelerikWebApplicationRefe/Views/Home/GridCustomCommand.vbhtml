
<p>Grid Usage: custom command  </p>

<div >
    <strong>Grid</strong>
    @code
        Html.Kendo().Grid(Of Employee).
            Name("grid").
            Columns(Sub(c)
                            c.Bound(Function(x) x.FirstName).Width(110)
                            c.Bound(Function(x) x.LastName).Width(110)
                            c.Bound(Function(x) x.Title)
                            c.Command(Function(x) x.Custom("ViewDetails").Click("showDetails"))
                    End Sub).
            Sortable().
            Pageable().
            Scrollable().
            ClientDetailTemplateId("template").
            HtmlAttributes(New With {.style = "height:430px;"}).
            DataSource(Function(d)
                               Return d.Ajax.PageSize(10).Read(Function(r) r.Action("Employee_Read", "Home"))
                       End Function).
                        Render()
        
end code

</div>

@Html.Kendo().Window().Name("Details").Title("Customer Details").Visible(false).Modal(true).Draggable(true).Width(300)       

 <script type="text/x-kendo-template" id="template">
    <div id="details-container">
        <h2>#= FirstName # #= LastName #</h2>
        <em>#= Title #</em>
        <dl>
            <dt>City: #= City #</dt>
            <dt>Country: #= Country #</dt>
        </dl>
    </div>
</script>

<script type="text/javascript">
    var detailsTemplate = kendo.template($("#template").html());

    function showDetails(e) {
        e.preventDefault();

        var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
        var wnd = $("#Details").data("kendoWindow");

        wnd.content(detailsTemplate(dataItem));
        wnd.center().open();
    }
</script>


