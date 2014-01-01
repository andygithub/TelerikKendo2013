Imports Kendo.Mvc.Extensions

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function

    Function TreeViewRef() As ActionResult
        Return View(InitModel)
    End Function

    <HttpPost()>
    Function TreeViewRef(filters As List(Of String)) As ActionResult
        Dim item As Models.TreeViewRefModel = InitModel()
        'checkedFiles = checkedFiles ?? new string[0];
        If filters IsNot Nothing Then
            item.nodesSelected = filters
        End If
        Return View(item)
    End Function

    Private Function InitModel() As Models.TreeViewRefModel
        Return New Models.TreeViewRefModel With {.CategoryItem = GetInlineData(), .TreeViewItemModel = GetTelerikStructure(), .nodesSelected = New List(Of String)}
    End Function

    Private Function GetTelerikStructure() As IEnumerable(Of Kendo.Mvc.UI.TreeViewItemModel)
        Return New List(Of Kendo.Mvc.UI.TreeViewItemModel)() From {New Kendo.Mvc.UI.TreeViewItemModel() With {.Id = "100", .Text = "Furniture", .Items = New List(Of Kendo.Mvc.UI.TreeViewItemModel)() From {
           New Kendo.Mvc.UI.TreeViewItemModel() With {.Id = "10", .Text = "Tables & Chairs"},
           New Kendo.Mvc.UI.TreeViewItemModel() With {.Id = "11", .Text = "Sofas"},
           New Kendo.Mvc.UI.TreeViewItemModel() With {.Id = "12", .Text = "Occasional Furniture"}
          }
         },
         New Kendo.Mvc.UI.TreeViewItemModel() With {.Id = "200", .Text = "Decor", .Items = New List(Of Kendo.Mvc.UI.TreeViewItemModel)() From {
            New Kendo.Mvc.UI.TreeViewItemModel() With {.Id = "20", .Text = "Bed Linen"},
           New Kendo.Mvc.UI.TreeViewItemModel() With {.Id = "21", .Text = "Curtains & Blinds"},
           New Kendo.Mvc.UI.TreeViewItemModel() With {.Id = "22", .Text = "Carpets"}
          }
         }
        }
    End Function

    Private Function GetInlineData() As IEnumerable(Of Models.CategoryItem)
        Return New List(Of Models.CategoryItem)() From { _
         New Models.CategoryItem() With {.CategoryName = "Storage", .SubCategories = New List(Of Models.SubCategoryItem)() From {
           New Models.SubCategoryItem() With {.SubCategoryName = "Wall Shelving"},
           New Models.SubCategoryItem() With {.SubCategoryName = "Floor Shelving"},
           New Models.SubCategoryItem() With {.SubCategoryName = "Kids Storag"}
          }
         },
         New Models.CategoryItem() With {.CategoryName = "Lights", .SubCategories = New List(Of Models.SubCategoryItem)() From {
           New Models.SubCategoryItem() With {.SubCategoryName = "Ceiling"},
           New Models.SubCategoryItem() With {.SubCategoryName = "Table"},
           New Models.SubCategoryItem() With {.SubCategoryName = "Floor"}
          }
         }
        }
    End Function

    Function GridPageSort() As ActionResult
        Return View()
    End Function

    Function GridNested() As ActionResult
        Return View()
    End Function

    Function GridCustomCommand() As ActionResult
        Return View()
    End Function

    Public Function Address_Read(<Kendo.Mvc.UI.DataSourceRequestAttribute()> request As Kendo.Mvc.UI.DataSourceRequest) As ActionResult
        Return Json(GetAddresses.ToDataSourceResult(request))
    End Function

    Public Function Employee_Read(<Kendo.Mvc.UI.DataSourceRequestAttribute()> request As Kendo.Mvc.UI.DataSourceRequest) As ActionResult
        Return Json(GetEmployees.ToDataSourceResult(request))
    End Function

    Public Function AddressNested_Read(employeeID As Integer, <Kendo.Mvc.UI.DataSourceRequestAttribute()> request As Kendo.Mvc.UI.DataSourceRequest) As ActionResult
        Return Json(GetAddresses.Take(employeeID / 100).ToDataSourceResult(request))
    End Function

    Public Function GetAddresses() As IEnumerable(Of Models.Address)
        Return New List(Of Models.Address) From {New Models.Address With {.AddessLine1 = "adfadfa1 ", .AddessLine2 = "adfadfdafadf1", .City = "adxvzxc1", .State = "adf1", .Zip = "09091"},
                                                 New Models.Address With {.AddessLine1 = "adfadfa2 ", .AddessLine2 = "adfadfdafadf2", .City = "adxvzxc2", .State = "adf2", .Zip = "09092"},
                                                 New Models.Address With {.AddessLine1 = "adfadfa3 ", .AddessLine2 = "adfadfdafadf3", .City = "adxvzxc3", .State = "adf3", .Zip = "09093"},
                                                 New Models.Address With {.AddessLine1 = "adfadfa 4", .AddessLine2 = "adfadfdafadf4", .City = "adxvzxc4", .State = "adf4", .Zip = "09094"},
                                                 New Models.Address With {.AddessLine1 = "adfadfa5 ", .AddessLine2 = "adfadfdafadf5", .City = "adxvzxc5", .State = "adf5", .Zip = "09095"},
                                                 New Models.Address With {.AddessLine1 = "adfadfa6 ", .AddessLine2 = "adfadfdafadf6", .City = "adxvzxc6", .State = "adf6", .Zip = "09096"},
                                                 New Models.Address With {.AddessLine1 = "adfadfa7 ", .AddessLine2 = "adfadfdafadf7", .City = "adxvzxc7", .State = "adf7", .Zip = "09097"},
                                                 New Models.Address With {.AddessLine1 = "adfadfa8 ", .AddessLine2 = "adfadfdafadf8", .City = "adxvzxc8", .State = "adf8", .Zip = "09098"},
                                                 New Models.Address With {.AddessLine1 = "adfadfa9 ", .AddessLine2 = "adfadfdafadf9", .City = "adxvzxc9", .State = "adf9", .Zip = "09099"},
                                                 New Models.Address With {.AddessLine1 = "adfadfa10 ", .AddessLine2 = "adfadfdafad10f", .City = "adxvzxc10", .State = "adf10", .Zip = "090910"},
                                                 New Models.Address With {.AddessLine1 = "adfadfa11 ", .AddessLine2 = "adfadfdafadf11", .City = "adxvzxc11", .State = "adf11", .Zip = "090911"}, New Models.Address With {.AddessLine1 = "adfadfa ", .AddessLine2 = "adfadfdafadf", .City = "adxvzxc", .State = "adf", .Zip = "0909"}
                                                }
    End Function

    Public Function GetEmployees() As IEnumerable(Of Models.Employee)
        Return New List(Of Models.Employee) From {New Models.Employee With {.EmployeeID = 100, .FirstName = "adfadfa1 ", .LastName = "adfadfdafadf1", .City = "adxvzxc1", .Country = "adf1", .Title = "09091"},
                                                 New Models.Employee With {.EmployeeID = 200, .FirstName = "adfadfa2 ", .LastName = "adfadfdafadf2", .City = "adxvzxc2", .Country = "adf2", .Title = "09092"},
                                                 New Models.Employee With {.EmployeeID = 300, .FirstName = "adfadfa3 ", .LastName = "adfadfdafadf3", .City = "adxvzxc3", .Country = "adf3", .Title = "09093"},
                                                 New Models.Employee With {.EmployeeID = 400, .FirstName = "adfadfa 4", .LastName = "adfadfdafadf4", .City = "adxvzxc4", .Country = "adf4", .Title = "09094"},
                                                 New Models.Employee With {.EmployeeID = 500, .FirstName = "adfadfa5 ", .LastName = "adfadfdafadf5", .City = "adxvzxc5", .Country = "adf5", .Title = "09095"},
                                                 New Models.Employee With {.EmployeeID = 600, .FirstName = "adfadfa6 ", .LastName = "adfadfdafadf6", .City = "adxvzxc6", .Country = "adf6", .Title = "09096"},
                                                 New Models.Employee With {.EmployeeID = 700, .FirstName = "adfadfa7 ", .LastName = "adfadfdafadf7", .City = "adxvzxc7", .Country = "adf7", .Title = "09097"},
                                                 New Models.Employee With {.EmployeeID = 800, .FirstName = "adfadfa8 ", .LastName = "adfadfdafadf8", .City = "adxvzxc8", .Country = "adf8", .Title = "09098"},
                                                 New Models.Employee With {.EmployeeID = 900, .FirstName = "adfadfa9 ", .LastName = "adfadfdafadf9", .City = "adxvzxc9", .Country = "adf9", .Title = "09099"},
                                                 New Models.Employee With {.EmployeeID = 1000, .FirstName = "adfadfa10 ", .LastName = "adfadfdafad10f", .City = "adxvzxc10", .Country = "adf10", .Title = "090910"},
                                                 New Models.Employee With {.EmployeeID = 1100, .FirstName = "adfadfa11 ", .LastName = "adfadfdafadf11", .City = "adxvzxc11", .Country = "adf11", .Title = "090911"}
                                                }
    End Function

End Class
