<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")

    <link rel="stylesheet" href="@Url.Content("~/Content/2013.2.611/kendo.common.min.css")">
    <link rel="stylesheet" href="@Url.Content("~/Content/2013.2.611/kendo.default.min.css")">
    <link rel="stylesheet" href="@Url.Content("~/Content/2013.2.611/kendo.rtl.min.css")">
    <script type="text/javascript" src="@Url.Content("~/Scripts/2013.2.611/jquery.min.js")"></script>
    <script type="text/javascript" src="@Url.Content("~/Scripts/2013.2.611/kendo.web.min.js")"></script>
    <script type="text/javascript" src="@Url.Content("~/Scripts/2013.2.611/kendo.aspnetmvc.min.js")"></script>
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Application name", "Index", "Home", Nothing, New With {.[class] = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li>@Html.ActionLink("Home", "Index", "Home")</li>
                    <li>@Html.ActionLink("About", "About", "Home")</li>
                    <li>@Html.ActionLink("Contact", "Contact", "Home")</li>
                </ul>
                @Html.Partial("_LoginPartial")
            </div>
        </div>
    </div>
    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - My ASP.NET Application</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
