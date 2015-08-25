Public Class GID_sort

    Implements IComparer

    Private Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare

        Dim tx As TreeNode = CType(x, TreeNode)
        Dim ty As TreeNode = CType(y, TreeNode)

        If tx.Level = 1 Then ' If the treenode is level 1, aka a Game title
            Return String.Compare(tx.Tag.ToString, ty.Tag.ToString) ' Sort the nodes by the game node tags which contain the GID's
        Else
            Return 1 ' If not, don't sort it.
        End If

    End Function

End Class

Public Class G_Title_sort

    Implements IComparer

    Private Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare

        Dim tx As TreeNode = CType(x, TreeNode)
        Dim ty As TreeNode = CType(y, TreeNode)

        If tx.Level = 1 Then ' If the treenode is level 1, aka a Game title
            Return String.Compare(tx.Text, ty.Text) ' Sort the nodes by the game node titles
        Else
            Return 1 ' If not, don't sort it.
        End If

    End Function

End Class

Public Class C_Title_sort

    Implements IComparer

    Private Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare

        Dim tx As TreeNode = CType(x, TreeNode)
        Dim ty As TreeNode = CType(y, TreeNode)

        If tx.Level = 2 Then ' If the tree node is level 2, aka Code name
            Return String.Compare(tx.Text, ty.Text) ' Sort the nodes by the code node titles
        Else
            Return 1 ' If not, don't sort it.
        End If

    End Function

End Class
