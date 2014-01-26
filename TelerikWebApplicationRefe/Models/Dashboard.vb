Namespace Models

    Public Class DashboardModel
        Public Property TreeViewItemModel As IEnumerable(Of Kendo.Mvc.UI.TreeViewItemModel)
    End Class

    Public Class SummaryGrid

        Public Property Id As Integer
        Public Property FilterId As String
        Public Property FilterName As String
        Public Property Name As String
        Public Property Description As String

    End Class

    Public Class DetailGrid

        Public Property Id As Integer

        Public Property SummaryId As Integer

        Public Property DetailName As String

        Public Property DetailsDesc As String


    End Class

End Namespace