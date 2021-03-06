﻿@Code
    ViewData("Title") = "Home Page"
End Code

<div class="jumbotron">
    <h1>Telerik Reference</h1>
    <p class="lead">Common Scenario Usage</p>
    <ul>
        <li>@Html.ActionLink( "Tree View", "TreeViewRef")</li>
        <li>@Html.ActionLink("Grid - Paging, Sorting, Filtering", "GridPageSort")</li>
        <li>@Html.ActionLink("Grid - Nested", "GridNested")</li>
        <li>@Html.ActionLink("Grid - Custom Command", "GridCustomCommand")</li>
        <li>@Html.ActionLink("Dashboard - Custom Master Detail","Index" ,"Dashboard")</li>
    </ul>
</div>

<div class="row">
    <div class="col-md-4">
        <h2>Getting started</h2>
        <p>

        </p>
       
    </div>
    <div class="col-md-4">
        <h2>Get more libraries</h2>
        <p>NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.</p>
        <p><a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301866">Learn more &raquo;</a></p>
    </div>
    <div class="col-md-4">
        <h2>Web Hosting</h2>
        <p>You can easily find a web hosting company that offers the right mix of features and price for your applications.</p>
        <p><a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301867">Learn more &raquo;</a></p>
    </div>
</div>
