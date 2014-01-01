Namespace Models

    Public Class TreeViewRefModel
        Public Property nodesSelected As IEnumerable(Of String)
        Public Property TreeViewItemModel As IEnumerable(Of Kendo.Mvc.UI.TreeViewItemModel)
        Public Property CategoryItem As IEnumerable(Of CategoryItem)

    End Class

    Public Class CategoryItem
        Public Property CategoryName As String
        Public Property SubCategories As IEnumerable(Of SubCategoryItem)
    End Class

    Public Class SubCategoryItem
        Public Property SubCategoryName As String
    End Class

End Namespace