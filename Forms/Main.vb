Public Class Main
    Friend database As String = Nothing
    Friend loaded As Boolean = False
    Friend PSX As Boolean = False

#Region "Menubar procedures"

#Region "Open Database/Save Database"

    Private Sub new_psp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles new_psp.Click
        If loaded = False Then
            codetree.BeginUpdate()
            reset_PSP()
            codetree.Nodes.Clear()
            codetree.Nodes.Add("New Database").ImageIndex = 0 ' Add the root node and set its icon
            codetree.EndUpdate()
            loaded = True
        ElseIf MessageBox.Show("Close the database without saving?", "Database not saved", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.OK Then
            codetree.BeginUpdate()
            reset_PSP()
            codetree.Nodes.Clear()
            codetree.Nodes.Add("New Database").ImageIndex = 0 ' Add the root node and set its icon
            codetree.EndUpdate()
        End If

    End Sub

    Private Sub new_psx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles new_psx.Click
        If loaded = False Then
            codetree.BeginUpdate()
            reset_PSX()
            codetree.Nodes.Clear()
            codetree.Nodes.Add("New Database").ImageIndex = 0 ' Add the root node and set its icon
            codetree.EndUpdate()
            loaded = True
        ElseIf MessageBox.Show("Close the database without saving?", "Database not saved", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.OK Then
            codetree.BeginUpdate()
            reset_PSX()
            codetree.Nodes.Clear()
            codetree.Nodes.Add("New Database").ImageIndex = 0 ' Add the root node and set its icon
            codetree.EndUpdate()
        End If
    End Sub

    Private Sub file_open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles file_open.Click

        Dim open As New load_db

        If open_file.ShowDialog = Windows.Forms.DialogResult.OK And open_file.FileName <> Nothing Then
            database = open_file.FileName
            error_window.list_save_error.Items.Clear() 'Clear any save errors from a previous database
            PSX = open.check_db(database) ' Check the file's format
            codetree.Nodes.Clear()
            codetree.BeginUpdate()
            error_window.list_load_error.BeginUpdate()

            If PSX = False Then
                reset_PSP()
                Application.DoEvents()
                open.read_PSP(database)
            Else
                reset_PSX()
                Application.DoEvents()
                open.read_PSX(database)
            End If

            codetree.EndUpdate()
            error_window.list_load_error.EndUpdate()
            loaded = True
            file_saveas.Enabled = True

        End If


    End Sub


    Private Sub file_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles file_exit.Click

        Close()

    End Sub

#End Region

#Region "Sort procedures"

    Private Sub sort_GID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sort_GID.Click
        error_window.Visible = False
        codetree.BeginUpdate() ' This will stop the tree view from constantly drawing the changes while we sort the nodes
        codetree.TreeViewNodeSorter = New GID_sort
        codetree.EndUpdate() ' Update the changes made to the tree view.

        If options_error.Checked = True Then
            error_window.Visible = True
        End If

    End Sub

    Private Sub Sort_GTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sort_GTitle.Click

        error_window.Visible = False
        codetree.BeginUpdate() ' This will stop the tree view from constantly drawing the changes while we sort the nodes
        codetree.TreeViewNodeSorter = New G_Title_sort
        codetree.EndUpdate() ' Update the changes made to the tree view.

        If options_error.Checked = True Then
            error_window.Visible = True
        End If

    End Sub

    Private Sub Sort_CTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sort_CTitle.Click

        error_window.Visible = False
        codetree.BeginUpdate() ' This will stop the tree view from constantly drawing the changes while we sort the nodes
        codetree.TreeViewNodeSorter = New C_Title_sort
        codetree.EndUpdate() ' Update the changes made to the tree view.

        If options_error.Checked = True Then
            error_window.Visible = True
        End If

    End Sub

#End Region

#Region "Options"

    Private Sub options_error_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles options_error.Click

        If options_error.Checked = False Then
            error_window.Show()
            options_error.Checked = True
            options_error.Text = "Hide Error Log"
            Me.Focus()

            If options_ontop.Checked = True Then
                Me.TopMost = True
                error_window.TopMost = True
            End If

        Else
            error_window.Hide()
            options_error.Checked = False
            options_error.Text = "Show Error Log"
        End If

    End Sub

    Private Sub options_ontop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles options_ontop.Click

        If options_ontop.Checked = False Then
            Me.TopMost = True
            error_window.TopMost = True
            options_ontop.Checked = True
        Else
            Me.TopMost = False
            error_window.TopMost = False
            options_ontop.Checked = False
        End If

    End Sub

#End Region

#End Region

#Region "Toolbar buttons procedures"
    Private Sub add_game_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles add_game.Click

        Try

            Dim newgame As New TreeNode
            With newgame
                .Name = "New Game"
                .Text = "New Game"
                .ImageIndex = 1
                .Tag = "0000-00000"
            End With
            codetree.Nodes(0).Nodes.Add(newgame)
            codetree.SelectedNode = newgame
            GT_tb.Enabled = True
            GT_tb.Text = "New Game"

        Catch ex As Exception

        End Try


    End Sub

    Private Sub rem_game_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rem_game.Click

        Try
            Select Case codetree.SelectedNode.Level

                Case Is <> 0
                    If MessageBox.Show("Delete the current game and associated codes?", "Confirm deletion", _
                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                        Select Case codetree.SelectedNode.Level
                            Case Is = 1
                                codetree.SelectedNode.Remove()
                            Case Is = 2
                                codetree.SelectedNode.Parent.Remove()
                        End Select

                    End If

            End Select

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Add_cd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add_cd.Click

        Try
            Dim newcode As New TreeNode

            With newcode
                .ImageIndex = 2
                .SelectedImageIndex = 3
                .Name = "New Code"
                .Text = "New Code"
                .Tag = "0"
            End With

            Select Case codetree.SelectedNode.Level

                Case Is = 1

                    off_rd.Checked = True
                    CT_tb.Enabled = True
                    CT_tb.Text = "New Code"
                    cmt_tb.Enabled = True
                    cl_tb.Enabled = True
                    codetree.SelectedNode.Nodes.Add(newcode)
                    codetree.SelectedNode = newcode
                Case Is = 2

                    off_rd.Checked = True
                    CT_tb.Enabled = True
                    CT_tb.Text = "New Code"
                    cmt_tb.Enabled = True
                    cl_tb.Enabled = True
                    codetree.SelectedNode.Parent.Nodes.Add(newcode)
                    codetree.SelectedNode = newcode

            End Select

        Catch ex As Exception

        End Try

    End Sub

    Private Sub rem_cd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rem_cd.Click

        Try
            If codetree.SelectedNode.Level = 2 Then

                If MessageBox.Show("Delete selected code?", "Confirm deletion", MessageBoxButtons.OKCancel, _
                   MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

                    codetree.SelectedNode.Remove()

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub save_gc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save_gc.Click

        Try

            Select Case codetree.SelectedNode.Level

                Case Is = 1
                    With codetree.SelectedNode
                        .Name = GT_tb.Text
                        .Text = GT_tb.Text
                        .Tag = GID_tb.Text
                    End With

                Case Is = 2
                    With codetree.SelectedNode.Parent
                        .Name = GT_tb.Text
                        .Text = GT_tb.Text
                        .Tag = GID_tb.Text
                    End With

            End Select

        Catch ex As Exception

        End Try

    End Sub

    Private Sub save_cc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save_cc.Click

        Try

            Dim b1 As String() = cl_tb.Text.Split(CChar(vbCrLf))
            Dim buffer As String = Nothing
            Dim i As Integer = 0

            If codetree.SelectedNode.Level = 2 Then
                codetree.SelectedNode.Name = CT_tb.Text
                codetree.SelectedNode.Text = CT_tb.Text

                For Each s As String In b1

                    If s <> vbCrLf Then
                        If i = 0 Then
                            If off_rd.Checked = True Then
                                buffer = "0" & vbCrLf
                            Else
                                buffer = "1" & vbCrLf
                            End If
                            i += 1
                        End If

                        If i > 0 And s.Length > 2 Then
                            buffer &= s.Trim & vbCrLf
                        End If
                    End If

                Next

                If cmt_tb.Text <> Nothing Then
                    buffer &= "#" & cmt_tb.Text
                End If

                codetree.SelectedNode.Tag = buffer
            End If


        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "Code tree procedures"

    Private Sub codetree_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles codetree.AfterSelect
        Dim j As New joker

        Select Case codetree.SelectedNode.Level

            Case Is = 0
                codetree.SelectedNode.SelectedImageIndex = 0
                resets_level1() ' Sets appropriate access to code editing
            Case Is = 1
                codetree.SelectedNode.SelectedImageIndex = 1
                GID_tb.Text = codetree.SelectedNode.Tag.ToString.Trim
                GT_tb.Text = codetree.SelectedNode.Text.Trim
                resets_level2() ' Sets appropriate access to code editing
            Case Is = 2
                Dim b1 As String = codetree.SelectedNode.Tag.ToString
                Dim b2 As String() = b1.Split(CChar(vbCrLf))
                Dim i As Integer = 0
                Dim skip As Boolean = False

                codetree.SelectedNode.SelectedImageIndex = 3
                CT_tb.Text = codetree.SelectedNode.Text.Trim
                GID_tb.Text = codetree.SelectedNode.Parent.Tag.ToString.Trim
                GT_tb.Text = codetree.SelectedNode.Parent.Text.Trim
                resets_level3() ' Sets appropriate access to code editing

                For Each s As String In b2

                    skip = False

                    s = s.Trim ' Remove the new line character so it doesn't interfere with checks

                    If i = 0 Then ' If on the first line, check if the code is enabled by default

                        If s = "1" Then
                            on_rd.Checked = True
                        Else
                            off_rd.Checked = True
                        End If

                        skip = True

                    End If

                    i += 1

                    Try

                        If s <> Nothing And skip = False Then

                            ' Check for a joker
                            If s.Trim.Length = 21 Then

                                If s.Substring(2, 1).ToUpper = "D" And s.Substring(13, 1) = "1" Then
                                    j.button_value(s)
                                ElseIf s.Substring(2, 1).ToUpper = "D" And s.Substring(13, 1) = "3" Then
                                    inverse_chk.Checked = True
                                    j.button_value(s)
                                End If

                            End If

                            If s.Length >= 2 Then

                                If s.Contains("#") Then
                                    cmt_tb.Text = s.Substring(1, s.Length - 1)
                                Else
                                    cl_tb.Text &= s & vbCrLf
                                End If

                            End If

                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                Next

        End Select

    End Sub

#End Region

#Region "Joker code procedures"

    Private Sub button_list_keypress(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_list.KeyPress

        ' Used if a user checks the options using spacebar since
        ' for some reason, IndexChanged doesn't work when the
        ' spacebar is used

        Dim j As New joker
        Dim x As Integer = 0
        Dim proceed As Boolean = False

        If cl_tb.Text.Trim.Length >= 21 Then ' If the code text box contains at least one code or more

            For x = 0 To 19  ' Check if any joker buttons were selected
                If button_list.GetItemChecked(x) = True Then
                    proceed = True
                    Exit For ' No need to continue since we know something is checked
                End If
            Next

        End If

        If proceed = True Then ' If a joker was selected, calculate the code
            j.add_joker()
        Else ' If not, remove any jokers if they exist
            j.remove_joker()
        End If

    End Sub

    Private Sub button_list_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_list.SelectedIndexChanged

        Dim j As New joker
        Dim x As Integer = 0
        Dim proceed As Boolean = False

        If cl_tb.Text.Trim.Length >= 21 Then ' If the code text box contains at least one code or more

            For x = 0 To 19  ' Check if any joker buttons were selected
                If button_list.GetItemChecked(x) = True Then
                    proceed = True
                    Exit For ' No need to continue since we know something is checked
                End If
            Next

        End If

        If proceed = True Then ' If a joker was selected, calculate the code
            j.add_joker()
        Else ' If not, remove any jokers if they exist
            j.remove_joker()
        End If

    End Sub

    Private Sub button_list_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_list.DoubleClick

        ' For some reason, when clicking quickly on the checkbox list it will not fire 
        ' off the SelectedIndexChanged event  so this is used to capture any changes 
        ' when the user clicks on the control quickly.

        Dim x As Integer = 0
        Dim proceed As Boolean = False
        Dim j As New joker

        If cl_tb.Text.Trim.Length >= 21 Then ' If the code text box contains at least one code or more

            For x = 0 To 19  ' Check if any joker buttons were selected
                If button_list.GetItemChecked(x) = True Then
                    proceed = True
                    Exit For ' No need to continue since we know something is checked
                End If
            Next

        End If

        If proceed = True Then ' If a joker was selected, calculate the code
            j.add_joker()
        Else ' If not, remove any jokers if they exist
            j.remove_joker()
        End If

    End Sub

    Private Sub inverse_chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles inverse_chk.CheckedChanged

        Dim x As Integer = 0
        Dim proceed As Boolean = False
        Dim j As New joker

        If cl_tb.Text.Trim.Length >= 21 Then ' If the code text box contains at least one code or more

            For x = 0 To 19  ' Check if any joker buttons were selected
                If button_list.GetItemChecked(x) = True Then
                    proceed = True
                End If
            Next

        End If

        If proceed = True Then ' If a joker was selected, calculate the code
            j.add_joker()
        Else ' If not, remove any jokers if they exist
            j.remove_joker()
        End If

    End Sub

    Private Sub button_list_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles button_list.ItemCheck


        ' Restricts the amount of checked items to 3 since CWcheat 
        ' only supports a 3 button press combination for joker codes

        If button_list.CheckedItems.Count >= 3 Then

            e.NewValue = CheckState.Unchecked

        End If

    End Sub

#End Region

#Region "Control resets"

    Private Sub resets_level1()

        ' Disable editing of games and codes if the root node is selected
        GID_tb.Enabled = False
        GID_tb.Text = Nothing
        GT_tb.Enabled = False
        GT_tb.Text = Nothing
        cmt_tb.Enabled = False
        cmt_tb.Text = Nothing
        cl_tb.Enabled = False
        cl_tb.Text = Nothing
        CT_tb.Enabled = False
        CT_tb.Text = Nothing
        off_rd.Enabled = False
        on_rd.Enabled = False

        If PSX = False Then

            button_list.Enabled = False
            inverse_chk.Enabled = False
            inverse_chk.Checked = False

        End If

        For i = 0 To 19 ' Reset the checked list box state
            button_list.SetItemChecked(i, False)
        Next

    End Sub

    Private Sub resets_level2()

        ' Disable editing of a code if one is not selected
        GID_tb.Enabled = True
        GT_tb.Enabled = True
        cmt_tb.Enabled = False
        cmt_tb.Text = Nothing
        cl_tb.Enabled = False
        cl_tb.Text = Nothing
        CT_tb.Enabled = False
        CT_tb.Text = Nothing
        off_rd.Enabled = False
        on_rd.Enabled = False

        If PSX = False Then

            button_list.Enabled = False
            inverse_chk.Enabled = False
            inverse_chk.Checked = False

        End If

        For i = 0 To 19 ' Reset the checked list box state
            button_list.SetItemChecked(i, False)
        Next

    End Sub

    Private Sub resets_level3()

        ' Enable editing of all controls
        cmt_tb.Enabled = True
        cmt_tb.Text = Nothing
        cl_tb.Enabled = True
        cl_tb.Text = Nothing
        CT_tb.Enabled = True
        off_rd.Enabled = True
        on_rd.Enabled = True

        If PSX = False Then

            button_list.Enabled = True
            inverse_chk.Enabled = True

        End If

        For i = 0 To 19 ' Reset the checked list box state
            button_list.SetItemChecked(i, False)
        Next

    End Sub

    Private Sub reset_PSX()

        button_list.Enabled = False
        inverse_chk.Enabled = False
        codetree.ImageList = PSX_iconset
        Sort_GTitle.Image = My.Resources.sony_playstation
        With tool_menu
            add_game.Image = My.Resources.Resources.add_PSX_game
            rem_game.Image = My.Resources.Resources.remove_PSX_game
            save_gc.Image = My.Resources.Resources.save_PSX_game
        End With

    End Sub

    Private Sub reset_PSP()

        button_list.Enabled = True
        inverse_chk.Enabled = True
        codetree.ImageList = iconset
        Sort_GTitle.Image = My.Resources.sony_psp
        With tool_menu
            add_game.Image = My.Resources.Resources.add_game
            rem_game.Image = My.Resources.remove_game
            save_gc.Image = My.Resources.Resources.save_game
        End With

    End Sub

#End Region

#Region "Window control"

    ' This makes sure the error list window always ends up below the main window
    Private Sub Main_locationchanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.LocationChanged

        If error_window.Visible = True Then

            Dim point As New Point
            point.X = Me.Location.X
            point.Y = Me.Location.Y + Me.Height
            error_window.Location = point

        End If

    End Sub

    Private Sub Main_resized(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        If error_window.Visible = True Then

            Dim point As New Point
            error_window.Width = Me.Width
            point.X = Me.Location.X
            point.Y = Me.Location.Y + Me.Height
            error_window.Location = point

        End If

    End Sub

#End Region

#Region "Hotkeys"

    Private Sub main_key_down(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        ' CTRL + V
        If e.Control = True AndAlso e.KeyCode = Keys.V Then
            'to do
        End If

        ' CTRL + C
        If e.Control = True AndAlso e.KeyCode = Keys.C Then
            'to do
        End If

    End Sub

#End Region


    Private Sub saveas_cwcheat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveas_cwcheat.Click
        Dim open As New load_db
        Dim s As New save_db

        If save_file.ShowDialog = Windows.Forms.DialogResult.OK And save_file.FileName <> Nothing Then
            database = save_file.FileName


            s.save_cwcheat(database)

            ' Reload the file
            codetree.Nodes.Clear()
            codetree.BeginUpdate()
            error_window.list_load_error.BeginUpdate()

            reset_PSP()
            Application.DoEvents()
            open.read_PSP(database)

            codetree.EndUpdate()
            error_window.list_load_error.EndUpdate()
            file_saveas.Enabled = True

        End If
    End Sub

    Private Sub saveas_psx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveas_psx.Click
        Dim open As New load_db
        Dim s As New save_db

        If save_file.ShowDialog = Windows.Forms.DialogResult.OK And save_file.FileName <> Nothing Then
            database = save_file.FileName

            s.save_psx(database)

            ' Reload the file
            codetree.Nodes.Clear()
            codetree.BeginUpdate()
            error_window.list_load_error.BeginUpdate()

            reset_PSX()
            Application.DoEvents()
            open.read_PSX(database)

            codetree.EndUpdate()
            error_window.list_load_error.EndUpdate()
            file_saveas.Enabled = True

        End If
    End Sub

    Private Sub saveas_pspar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveas_pspar.Click
        Dim open As New load_db
        Dim s As New save_db

        If save_file.ShowDialog = Windows.Forms.DialogResult.OK And save_file.FileName <> Nothing Then
            database = save_file.FileName


            s.save_pspar(database)

            ' Reload the file
            codetree.Nodes.Clear()
            codetree.BeginUpdate()
            error_window.list_load_error.BeginUpdate()

            reset_PSP()
            Application.DoEvents()
            open.read_PSP(database)

            codetree.EndUpdate()
            error_window.list_load_error.EndUpdate()
            file_saveas.Enabled = True

        End If
    End Sub
End Class
