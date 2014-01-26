Imports System.Web.Mvc
Imports Kendo.Mvc.Extensions

Public Class DashboardController
    Inherits Controller

    ' GET: /Dashboard
    Function Index() As ActionResult
        Return View(InitModel)
    End Function

    <HttpPost()>
    Function SaveFilters(filters As List(Of String)) As ActionResult
        If filters Is Nothing Then filters = New List(Of String)
        'checkedFiles = checkedFiles ?? new string[0];
        'If filters IsNot Nothing Then
        '    item.nodesSelected = filters
        'End If
        'save to the database here:

        Return PartialView("SaveFilters", New FilterSaveCompleted With {.Message = String.Join(",", filters)})
    End Function

    Public Function Summary_Read(<Kendo.Mvc.UI.DataSourceRequestAttribute()> request As Kendo.Mvc.UI.DataSourceRequest, firstName As String, lastName As String, dashboardFilters As String) As ActionResult
        'annoyed with pushing json array into an MVC array, ideally the configruation on the client would push this into the dashboard without this code below
        Dim _filters As IEnumerable(Of String) = Replace(dashboardFilters, "[", "").Replace("]", "").Split(","c)
        'chain the base list with the additional filters from the cilent and then the grid filters
        Return Json(GetSummaryData.Where(Function(x) _filters.Contains(x.FilterId)).ToDataSourceResult(request))
    End Function

    Public Function Detail_Read(<Kendo.Mvc.UI.DataSourceRequestAttribute()> request As Kendo.Mvc.UI.DataSourceRequest, summaryId As String) As ActionResult
        'chain the base list with the additional filters from the cilent and then the grid filters
        Return Json(GetDetailData.Where(Function(x) summaryId = x.SummaryId).ToDataSourceResult(request))
    End Function

    Private Function InitModel() As Models.DashboardModel
        Return New Models.DashboardModel With {.TreeViewItemModel = GetTelerikStructure()}
    End Function

    Private Function GetTelerikStructure() As IEnumerable(Of Kendo.Mvc.UI.TreeViewItemModel)
        Return New List(Of Kendo.Mvc.UI.TreeViewItemModel)() From {New Kendo.Mvc.UI.TreeViewItemModel With {.Id = -100, .Text = "All", .Items = New List(Of Kendo.Mvc.UI.TreeViewItemModel)() From
                                                                  {New Kendo.Mvc.UI.TreeViewItemModel() With {.Id = "100", .Text = "Furniture", .Items = New List(Of Kendo.Mvc.UI.TreeViewItemModel)() From {
           New Kendo.Mvc.UI.TreeViewItemModel() With {.Id = "10", .Text = "Tables & Chairs"},
           New Kendo.Mvc.UI.TreeViewItemModel() With {.Id = "11", .Text = "Sofas", .Checked = True},
           New Kendo.Mvc.UI.TreeViewItemModel() With {.Id = "12", .Text = "Occasional Furniture"}
          }
         },
         New Kendo.Mvc.UI.TreeViewItemModel() With {.Id = "200", .Text = "Decor", .Items = New List(Of Kendo.Mvc.UI.TreeViewItemModel)() From {
            New Kendo.Mvc.UI.TreeViewItemModel() With {.Id = "20", .Text = "Bed Linen"},
           New Kendo.Mvc.UI.TreeViewItemModel() With {.Id = "21", .Text = "Curtains & Blinds"},
           New Kendo.Mvc.UI.TreeViewItemModel() With {.Id = "22", .Text = "Carpets", .Checked = True}
          }
         }
        }
        }}
    End Function

    Public Function GetSummaryData() As IEnumerable(Of Models.SummaryGrid)
        Return New List(Of Models.SummaryGrid) From {New Models.SummaryGrid With {.Id = 100, .FilterId = "10", .FilterName = "Tables & Chairs", .Name = "name 100", .Description = "edes"},
                                                 New Models.SummaryGrid With {.Id = 200, .FilterId = "11", .FilterName = "Sofas", .Name = "name 200", .Description = "adf 1"},
                                                 New Models.SummaryGrid With {.Id = 300, .FilterId = "12", .FilterName = "Occasional Furniture", .Name = "name 300", .Description = "adf  1"},
                                                 New Models.SummaryGrid With {.Id = 400, .FilterId = "20", .FilterName = "Bed Linen", .Name = "name 400", .Description = "a df1"},
                                                 New Models.SummaryGrid With {.Id = 500, .FilterId = "21", .FilterName = "Curtains & Blinds", .Name = "namd 500", .Description = "ad f1"},
                                                 New Models.SummaryGrid With {.Id = 600, .FilterId = "22", .FilterName = "Carpets", .Name = "name 600", .Description = "aadsf df1"},
                                                 New Models.SummaryGrid With {.Id = 700, .FilterId = "10", .FilterName = "Tables & Chairs", .Name = "name 700", .Description = "aadsf df1"},
                                                 New Models.SummaryGrid With {.Id = 800, .FilterId = "11", .FilterName = "Sofas", .Name = "name 80", .Description = "aasdf df1"},
                                                 New Models.SummaryGrid With {.Id = 900, .FilterId = "12", .FilterName = "Occasional Furniture", .Name = "name 900", .Description = "adads fzcvf1"},
                                                 New Models.SummaryGrid With {.Id = 910, .FilterId = "20", .FilterName = "Bed Linen", .Name = "name 910", .Description = "azcvdf1"},
                                                 New Models.SummaryGrid With {.Id = 921, .FilterId = "21", .FilterName = "Curtains & Blinds", .Name = "name 921", .Description = "azvcxdf1"},
                                                 New Models.SummaryGrid With {.Id = 10, .FilterId = "22", .FilterName = "Carpets", .Name = "name 10", .Description = "adzcxvf1"}
                                                }
    End Function

    Public Function GetDetailData() As IEnumerable(Of Models.DetailGrid)
        Return New List(Of Models.DetailGrid) From {New Models.DetailGrid With {.Id = -100, .SummaryId = 100, .DetailName = "name 100", .DetailsDesc = "edes"},
                                                 New Models.DetailGrid With {.Id = -200, .SummaryId = 200, .DetailName = "name 200", .DetailsDesc = "adf 1"},
                                                 New Models.DetailGrid With {.Id = -300, .SummaryId = 300, .DetailName = "name 300", .DetailsDesc = "adf  1"},
                                                 New Models.DetailGrid With {.Id = -400, .SummaryId = 400, .DetailName = "name 400", .DetailsDesc = "a df1"},
                                                 New Models.DetailGrid With {.Id = -500, .SummaryId = 500, .DetailName = "namd 500", .DetailsDesc = "ad f1"},
                                                 New Models.DetailGrid With {.Id = -600, .SummaryId = 600, .DetailName = "name 600", .DetailsDesc = "aadsf df1"},
                                                 New Models.DetailGrid With {.Id = -700, .SummaryId = 700, .DetailName = "name 700", .DetailsDesc = "aadsf df1"},
                                                 New Models.DetailGrid With {.Id = -800, .SummaryId = 800, .DetailName = "name 80", .DetailsDesc = "aasdf df1"},
                                                 New Models.DetailGrid With {.Id = -900, .SummaryId = 900, .DetailName = "name 900", .DetailsDesc = "adads fzcvf1"},
                                                 New Models.DetailGrid With {.Id = -910, .SummaryId = 910, .DetailName = "name 910", .DetailsDesc = "azcvdf1"},
                                                 New Models.DetailGrid With {.Id = -921, .SummaryId = 921, .DetailName = "name 921", .DetailsDesc = "azvcxdf1"},
                                                 New Models.DetailGrid With {.Id = -10, .SummaryId = 10, .DetailName = "name 10", .DetailsDesc = "adzcxvf1"}
                                                }
    End Function

End Class