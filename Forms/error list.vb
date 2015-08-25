Public Class error_window


    Private Sub error_list_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
        Main.options_error.Checked = False
        Main.options_error.Text = "Show Error Window"
    End Sub

    Private Sub error_window_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim point As New Point
        point.X = Main.Location.X
        point.Y = Main.Location.Y + Main.Height
        Me.Width = Main.Width
        Me.Location = point
    End Sub

    Private Sub error_window_visible(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        Dim point As New Point
        point.X = Main.Location.X
        point.Y = Main.Location.Y + Main.Height
        Me.Width = Main.Width
        Me.Location = point
    End Sub

End Class
