Imports System.IO

Public Class load_db

    Public Sub read_PSP(ByVal filename As String)

        Dim m As Main = Main
        Dim ew As error_window = error_window
        Dim memory As New MemoryManagement
        Dim file As New FileStream(filename, FileMode.Open, FileAccess.Read)
        Dim sr As New StreamReader(file)
        Dim buffer(3) As String ' 0 = stream buffer, 1 = Game ID address, 2 = Game name, 3 = Codes
        Dim counts(2) As Integer ' 0 = Line #, 1 = Progress bar counter, 2 = Total formatting errors
        Dim percent As Double = 0
        Dim gnode As New TreeNode ' Game name node for the TreeView control
        Dim cnode As New TreeNode ' Code name node for the TreeView control
        Dim skip As Boolean = False

        m.codetree.Nodes.Add(Path.GetFileNameWithoutExtension(filename)).ImageIndex = 0 ' Add the root node and set its icon
        m.progbar.Value = 0 ' Reset the progress bar
        m.progbar.Visible = True ' Show the progress bar 

        reset_errors() ' Clear the error list before loading

        Try

            Do Until sr.EndOfStream = True ' Begin reading the file and stop when we reach the end

                If skip = False Then

                    buffer(0) = sr.ReadLine
                    percent = (sr.BaseStream.Position * 100) / sr.BaseStream.Length
                    counts(0) += 1 ' Keep track of the line #
                    counts(1) += 1

                End If

                If buffer(0).Length >= 4 Or buffer(0).Substring(0) = "#" Then

                    Select Case buffer(0).Substring(0, 2)

                        Case Is = "_S"
                            skip = False
                            buffer(3) = Nothing
                            buffer(1) = buffer(0).Substring(3, buffer(0).Length - 3).Trim

                        Case Is = "_G"
                            skip = False
                            buffer(2) = buffer(0).Substring(3, buffer(0).Length - 3).Trim
                            gnode = New TreeNode(buffer(0).Substring(3, buffer(0).Length - 3).Trim)
                            With gnode
                                .Name = buffer(0).Substring(3, buffer(0).Length - 3).Trim
                                .Tag = buffer(1)
                                .ImageIndex = 1
                            End With
                            m.codetree.Nodes(0).Nodes.Add(gnode)

                        Case Is = "_C"
                            skip = False
                            buffer(3) = Nothing

                            If buffer(0).Substring(2, 1) = "1" Then
                                buffer(3) = "1" & vbCrLf
                            Else
                                buffer(3) = "0" & vbCrLf
                            End If

                            cnode = New TreeNode(buffer(0).Substring(3, buffer(0).Length - 3).Trim)
                            cnode.Name = buffer(0).Substring(3, buffer(0).Length - 3).Trim
                            cnode.ImageIndex = 2
                            gnode.Nodes.Add(cnode)

                        Case Is = "_L"

                            skip = False

                            If buffer(0).Trim.Length = 24 Then 'If it is a correctly formed code record it
                                buffer(3) &= buffer(0).Substring(3, buffer(0).Length - 3).Trim & vbCrLf
                            Else ' If it is incorrectly formed, ignore it.

                                counts(2) += 1
                                If buffer(0).Replace(" ", "") = Nothing Then 'If the line is blank
                                    write_errors(counts(0), counts(2), "<Line is blank>", gnode.Text, cnode.Text)
                                Else
                                    write_errors(counts(0), counts(2), buffer(0) & " <not added>", gnode.Text, cnode.Text) ' Write the ignored line to the error list
                                End If

                                If ew.Visible = False Then

                                    ew.Show()
                                    ew.tab_error.SelectedIndex = 0 ' Give focus to the "Load Error" tab
                                    m.Focus()
                                    reset_toolbar()

                                End If

                            End If

                            Do Until skip = True

                                buffer(0) = sr.ReadLine
                                counts(0) += 1 ' Keep track of the line #
                                percent = (sr.BaseStream.Position * 100) / sr.BaseStream.Length
                                counts(1) += 1

                                If buffer(0) = Nothing Then ' If we've reached the end of the file or a blank line

                                    If sr.EndOfStream = True Then 'Check if we are at the end of the file
                                        cnode.Tag = buffer(3)
                                        buffer(3) = Nothing
                                        Exit Do
                                    End If

                                ElseIf buffer(0).Substring(0, 2) = "_L" Then

                                    If buffer(0).Trim.Length = 24 Then 'If it is a correctly formed code record it
                                        buffer(3) &= buffer(0).Substring(3, buffer(0).Length - 3).Trim & vbCrLf
                                    Else ' If it is incorrectly formed, add it to the error list and ignore it

                                        counts(2) += 1
                                        If buffer(0).Replace(" ", "") = Nothing Then 'If the line is blank
                                            write_errors(counts(0), counts(2), "<Line is blank>", gnode.Text, cnode.Text)
                                        Else
                                            write_errors(counts(0), counts(2), buffer(0) & " <not added>", gnode.Text, cnode.Text) ' Write the ignored line to the error list
                                        End If

                                        If ew.Visible = False Then

                                            ew.Show()
                                            ew.tab_error.SelectedIndex = 0 ' Give focus to the "Load Error" tab
                                            m.Focus()
                                            reset_toolbar()

                                        End If

                                    End If

                                ElseIf buffer(0).Substring(0, 1).Trim = "#" Then
                                    buffer(3) &= buffer(0) & vbCrLf

                                Else
                                    cnode.Tag = buffer(3) ' Store all collected codes in the nodes 'tag'
                                    buffer(3) = Nothing
                                    skip = True ' If a new game or code is found, skip the initial read so it is processed

                                End If

                                If counts(1) >= 20 Then
                                    ' Update the progressbar every 20 repetitions otherwise the program 
                                    ' will slow to a crawl from the constant re-draw of the progress bar
                                    m.progbar.Value = Convert.ToInt32(percent)
                                    m.progbar.PerformStep()
                                    Application.DoEvents()
                                    counts(1) = 0
                                End If

                            Loop

                        Case Is = "_M" ' Used for PSPar codes, exactly the same as _L

                            skip = False

                            If buffer(0).Trim.Length = 24 Then 'If it is a correctly formed code record it
                                buffer(3) &= buffer(0).Substring(3, buffer(0).Length - 3).Trim & vbCrLf
                            Else ' If it is incorrectly formed, ignore it.

                                counts(2) += 1
                                If buffer(0).Replace(" ", "") = Nothing Then 'If the line is blank
                                    write_errors(counts(0), counts(2), "<Line is blank>", gnode.Text, cnode.Text)
                                Else
                                    write_errors(counts(0), counts(2), buffer(0) & " <not added>", gnode.Text, cnode.Text) ' Write the ignored line to the error list
                                End If

                                If ew.Visible = False Then

                                    ew.Show()
                                    ew.tab_error.SelectedIndex = 0 ' Give focus to the "Load Error" tab
                                    m.Focus()
                                    reset_toolbar()

                                End If

                            End If

                            Do Until skip = True

                                buffer(0) = sr.ReadLine
                                counts(0) += 1 ' Keep track of the line #
                                percent = (sr.BaseStream.Position * 100) / sr.BaseStream.Length
                                counts(1) += 1

                                If buffer(0) = Nothing Then ' If we've reached the end of the file

                                    If sr.EndOfStream = True Then
                                        cnode.Tag = buffer(3)
                                        buffer(3) = Nothing
                                    End If

                                    Exit Do

                                ElseIf buffer(0).Substring(0, 2) = "_M" Then

                                    If buffer(0).Trim.Length = 24 Then 'If it is a correctly formed code record it
                                        buffer(3) &= buffer(0).Substring(3, buffer(0).Length - 3).Trim & vbCrLf
                                    Else ' If it is incorrectly formed, add it to the error list and ignore it

                                        counts(2) += 1

                                        If buffer(0).Replace(" ", "") = Nothing Then 'If the line is blank
                                            write_errors(counts(0), counts(2), "<Line is blank>", gnode.Text, cnode.Text)
                                        Else
                                            write_errors(counts(0), counts(2), buffer(0) & " <not added>", gnode.Text, cnode.Text) ' Write the ignored line to the error list
                                        End If

                                        If ew.Visible = False Then

                                            ew.Show()
                                            ew.tab_error.SelectedIndex = 0 ' Give focus to the "Load Error" tab
                                            m.Focus()
                                            reset_toolbar()

                                        End If

                                    End If

                                ElseIf buffer(0).Substring(0, 1).Trim = "#" Then
                                    buffer(3) &= buffer(0) & vbCrLf

                                Else
                                    cnode.Tag = buffer(3) ' Store all collected codes in the nodes 'tag'
                                    buffer(3) = Nothing
                                    skip = True ' If a new game or code is found, skip the initial read so it is processed

                                End If

                                If counts(1) >= 20 Then
                                    ' Update the progressbar every 20 repetitions otherwise the program 
                                    ' will slow to a crawl from the constant re-draw of the progress bar
                                    m.progbar.Value = Convert.ToInt32(percent)
                                    m.progbar.PerformStep()
                                    Application.DoEvents()
                                    counts(1) = 0
                                End If

                            Loop

                        Case Else ' This will catch anything that is out of place

                            If buffer(0).Substring(0, 1) <> "#" Then ' If what we found isn't a comment, ignore it

                                counts(2) += 1

                                If buffer(0).Replace(" ", "") = Nothing Then 'If the line is blank
                                    write_errors(counts(0), counts(2), "<Line is blank>", gnode.Text, cnode.Text)
                                Else
                                    write_errors(counts(0), counts(2), buffer(0) & " <not added>", gnode.Text, cnode.Text) ' Write the ignored line to the error list
                                End If

                                If ew.Visible = False Then

                                    ew.Show()
                                    ew.tab_error.SelectedIndex = 0 ' Give focus to the "Load Error" tab
                                    m.Focus()
                                    reset_toolbar()

                                End If

                                buffer(0) = sr.ReadLine ' Read the next line after the error
                                counts(0) += 1
                                counts(1) += 1
                                skip = True ' Skip the intial read

                            End If

                    End Select

                Else
                    ' This is set if there is a garbage line in the database and
                    ' will write the line to the error window and try to continue loading
                    counts(2) += 1
                    'Determine if it's a blank line
                    If buffer(0).Replace(" ", "") = Nothing Then
                        write_errors(counts(0), counts(2), "<Line is blank>", gnode.Text, cnode.Text)
                    Else
                        write_errors(counts(0), counts(2), buffer(0) & " <not added>", gnode.Text, cnode.Text)
                    End If

                    skip = False
                End If

                If counts(1) >= 20 Then

                    ' Update the progressbar every 20 repetitions otherwise the program 
                    ' will slow to a crawl from the constant re-draw of the progress bar
                    m.progbar.Value = Convert.ToInt32(percent)
                    m.progbar.PerformStep()
                    Application.DoEvents()
                    counts(1) = 0

                End If
            Loop

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

        If ew.list_load_error.Items.Count = 0 And ew.list_save_error.Items.Count > 0 Then
            ew.Show()
            ew.tab_error.SelectedIndex = 1
            m.Focus()
            reset_toolbar()

        End If

        m.progbar.Visible = False
        sr.Close()
        file.Close()
        memory.FlushMemory() ' Force a garbage collection after all the memory processing

    End Sub

    Public Sub read_PSX(ByVal filename As String)

        Dim m As Main = Main
        Dim ew As error_window = error_window
        Dim memory As New MemoryManagement
        Dim file As New FileStream(filename, FileMode.Open, FileAccess.Read)
        Dim sr As New StreamReader(file)
        Dim buffer(4) As String ' 0 = stream buffer, 1 = SLUS address, 2 = Game name, 3 = Codes, 4 = fixed codes
        Dim counts(2) As Integer ' 0 = Line #, 1 = Progress bar counter, 2 = Total formatting errors, 3 = Error number
        Dim percent As Double = 0
        Dim gnode As New TreeNode ' Game name node for the TreeView control
        Dim cnode As New TreeNode ' Code name node for the TreeView control
        Dim skip As Boolean = False

        m.codetree.Nodes.Add(Path.GetFileNameWithoutExtension(filename)).ImageIndex = 0 ' Add the root node and set its icon
        m.progbar.Visible = True ' Show the progress bar and reset it's value
        m.progbar.Value = 0 ' Reset the progress bar

        reset_errors() ' Clear the error list before loading

        Try

            Do Until sr.EndOfStream = True ' Begin reading the file and stop when we reach the end

                If skip = False Then

                    buffer(0) = sr.ReadLine
                    percent = (sr.BaseStream.Position * 100) / sr.BaseStream.Length
                    counts(0) += 1 ' Keep track of the line #
                    counts(1) += 1

                End If

                If buffer(0).Length >= 4 Or buffer(0).Substring(0) = "#" Then

                    Select Case buffer(0).Substring(0, 2)

                        Case Is = "_S"
                            skip = False
                            buffer(3) = Nothing
                            buffer(1) = buffer(0).Substring(3, buffer(0).Length - 3).Trim

                        Case Is = "_G"
                            skip = False
                            buffer(2) = buffer(0).Substring(3, buffer(0).Length - 3).Trim
                            gnode = New TreeNode(buffer(0).Substring(3, buffer(0).Length - 3).Trim)
                            With gnode
                                .Name = buffer(0).Substring(3, buffer(0).Length - 3).Trim
                                .Tag = buffer(1)
                                .ImageIndex = 1
                            End With
                            m.codetree.Nodes(0).Nodes.Add(gnode)

                        Case Is = "_C"
                            skip = False
                            buffer(3) = Nothing

                            If buffer(0).Substring(2, 1) = "1" Then
                                buffer(3) = "1" & vbCrLf
                            Else
                                buffer(3) = "0" & vbCrLf
                            End If

                            cnode = New TreeNode(buffer(0).Substring(3, buffer(0).Length - 3).Trim)
                            cnode.Name = buffer(0).Substring(3, buffer(0).Length - 3).Trim
                            cnode.ImageIndex = 2
                            gnode.Nodes.Add(cnode)

                        Case Is = "_L"

                            skip = False

                            If buffer(0).Trim.Length = 16 Then 'If it is a correctly formed code record it
                                buffer(3) &= buffer(0).Substring(3, buffer(0).Length - 3).Trim & vbCrLf
                            Else

                                buffer(4) = clean_PSX(buffer(0).Trim)

                                If buffer(4).Length = 16 Then 'Attempt to remove white spaces and re-check

                                    buffer(3) &= buffer(4).Substring(3, buffer(4).Length - 3) & vbCrLf

                                Else ' If it is incorrectly formed, ignore it.

                                    counts(2) += 1
                                    If buffer(0).Replace(" ", "") = Nothing Then 'If the line is blank
                                        write_errors(counts(0), counts(2), "<Line is blank>", gnode.Text, cnode.Text)
                                    Else
                                        write_errors(counts(0), counts(2), buffer(0) & " <not added>", gnode.Text, cnode.Text) ' Write the ignored line to the error list
                                    End If

                                    If ew.Visible = False Then

                                        ew.Show()
                                        ew.tab_error.SelectedIndex = 0 ' Give focus to the "Load Error" tab
                                        m.Focus()
                                        reset_toolbar()

                                    End If

                                End If

                            End If

                            Do Until skip = True

                                buffer(0) = sr.ReadLine
                                counts(0) += 1 ' Keep track of the line #
                                percent = (sr.BaseStream.Position * 100) / sr.BaseStream.Length
                                counts(1) += 1

                                If buffer(0) = Nothing Then ' If we've reached the end of the file

                                    If sr.EndOfStream = True Then
                                        cnode.Tag = buffer(3)
                                        buffer(3) = Nothing
                                    End If

                                    Exit Do

                                ElseIf buffer(0).Substring(0, 2) = "_L" Then

                                    If buffer(0).Trim.Length = 16 Then 'If it is a correctly formed code record it
                                        buffer(3) &= buffer(0).Substring(3, buffer(0).Length - 3).Trim & vbCrLf
                                    Else

                                        buffer(4) = clean_PSX(buffer(0).Trim)

                                        If buffer(4).Length = 16 Then 'Attempt to remove white spaces and re-check

                                            buffer(3) &= buffer(4).Substring(3, buffer(4).Length - 3) & vbCrLf

                                        Else ' If it is incorrectly formed, ignore it.

                                            counts(2) += 1
                                            If buffer(0).Replace(" ", "") = Nothing Then 'If the line is blank
                                                write_errors(counts(0), counts(2), "<Line is blank>", gnode.Text, cnode.Text)
                                            Else
                                                write_errors(counts(0), counts(2), buffer(0) & " <not added>", gnode.Text, cnode.Text) ' Write the ignored line to the error list
                                            End If

                                            If ew.Visible = False Then

                                                ew.Show()
                                                ew.tab_error.SelectedIndex = 0 ' Give focus to the "Load Error" tab
                                                m.Focus()
                                                reset_toolbar()

                                            End If

                                        End If

                                    End If

                                ElseIf buffer(0).Substring(0, 1).Trim = "#" Then
                                    buffer(3) &= buffer(0) & vbCrLf

                                Else
                                    cnode.Tag = buffer(3) ' Store all collected codes in the nodes 'tag'
                                    buffer(3) = Nothing
                                    skip = True ' If a new game or code is found, skip the initial read so it is processed

                                End If

                                If counts(1) >= 20 Then
                                    ' Update the progressbar every 20 repetitions otherwise the program 
                                    ' will slow to a crawl from the constant re-draw of the progress bar
                                    m.progbar.Value = Convert.ToInt32(percent)
                                    m.progbar.PerformStep()
                                    Application.DoEvents()
                                    counts(1) = 0
                                End If

                            Loop

                        Case Else ' This will catch anything that is out of place

                            If buffer(0).Substring(0, 1) <> "#" Then ' If what we found isn't a comment, ignore it

                                counts(2) += 1
                                If buffer(0).Replace(" ", "") = Nothing Then 'If the line is blank
                                    write_errors(counts(0), counts(2), "<Line is blank>", gnode.Text, cnode.Text)
                                Else
                                    write_errors(counts(0), counts(2), buffer(0) & " <not added>", gnode.Text, cnode.Text) ' Write the ignored line to the error list
                                End If

                                If ew.Visible = False Then

                                    ew.Show()
                                    ew.tab_error.SelectedIndex = 0 ' Give focus to the "Load Error" tab
                                    m.Focus()
                                    reset_toolbar()

                                End If

                                buffer(0) = sr.ReadLine
                                counts(0) += 1
                                counts(1) += 1
                                skip = True

                            End If

                    End Select

                Else
                    ' This is set if there is a garbage line or blank line in the database and
                    ' will write the line to the error window and try to continue loading
                    counts(2) += 1
                    'Determine if it's a blank line
                    If buffer(0).Replace(" ", "") = Nothing Then
                        write_errors(counts(0), counts(2), "<Line is blank>", gnode.Text, cnode.Text)
                    Else
                        write_errors(counts(0), counts(2), buffer(0) & " <not added>", gnode.Text, cnode.Text)
                    End If

                    skip = False

                End If

                If counts(1) >= 20 Then

                    ' Update the progressbar every 20 repetitions otherwise the program 
                    ' will slow to a crawl from the constant re-draw of the progress bar
                    m.progbar.Value = Convert.ToInt32(percent)
                    m.progbar.PerformStep()
                    Application.DoEvents()
                    counts(1) = 0

                End If
            Loop

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

        If ew.list_load_error.Items.Count = 0 And ew.list_save_error.Items.Count > 0 Then
            ew.Show()
            ew.tab_error.SelectedIndex = 1
            m.Focus()
            reset_toolbar()
        End If

        m.progbar.Visible = False
        sr.Close()
        file.Close()
        memory.FlushMemory() ' Force a garbage collection after all the memory processing

    End Sub

    Private Sub write_errors(ByVal line As Integer, ByVal error_n As Integer, ByVal error_t As String, _
                             ByVal game_t As String, ByVal code_t As String)

        Dim ew As error_window = error_window

        With ew.list_load_error
            .Items.Add(error_n.ToString)
            .Items(error_n - 1).SubItems.Add(line.ToString)
            .Items(error_n - 1).SubItems.Add(game_t)
            .Items(error_n - 1).SubItems.Add(code_t)
            .Items(error_n - 1).SubItems.Add(error_t.Trim)
        End With

        Application.DoEvents()

    End Sub

    Private Sub reset_errors()

        Dim ew As error_window = error_window
        Dim m As Main = Main

        ew.Hide()
        m.options_error.Text = "Show Error Log"
        m.options_error.Checked = False
        ew.list_load_error.Items.Clear()

    End Sub

    Private Sub reset_toolbar()

        If Main.options_error.Checked = False Then
            Main.options_error.Checked = True
            Main.options_error.Text = "Hide Error Log"
        End If

    End Sub

    Private Function clean_PSX(ByVal s As String) As String

        ' This will attempt to remove any extra white spaces
        ' if the attempt fails, it will be marked as incorrect
        ' and written into the error list.

        Dim i As Integer = 0
        clean_PSX = Nothing

        For i = 0 To s.Length - 1

            If s.Substring(i, 1) = " " And i <> 10 And i <> 2 Then ' If we're not on the 3rd space or the 11th
            Else
                clean_PSX &= s.Substring(i, 1)
            End If

        Next

        ' This will attempt to fix a broken code missing the code type after the white spaces are removed.
        ' First it will check if the length is incorrect. If so, calculate the value and place the correct code type.
        ' The only problem with this is if the code was a 16-bit 'equal to' type (AKA joker), it will be incorrect
        ' since there is no way to determine if it was.  More than likely it won't be.

        If clean_PSX.Length = 15 Then ' If we are 1 characters short of an actual code

            If clean_PSX.Substring(3, 1) = "0" Then ' We know it's missing its code type

                If clean_PSX.Substring(clean_PSX.Length - 4, 4) = "????" _
                Or clean_PSX.Substring(clean_PSX.Length - 3, 3) = "???" _
                Or clean_PSX.Substring(clean_PSX.Length - 4, 2) = "??" _
                Or clean_PSX.Substring(clean_PSX.Length - 4, 1) = "?" Then

                    clean_PSX = clean_PSX.Substring(0, 3) & "8" & clean_PSX.Substring(3, clean_PSX.Length - 3) ' 16-bit write

                ElseIf clean_PSX.Substring(clean_PSX.Length - 2, 2) = "??" Or clean_PSX.Substring(clean_PSX.Length - 1, 1) = "?" Then

                    clean_PSX = clean_PSX.Substring(0, 3) & "3" & clean_PSX.Substring(3, clean_PSX.Length - 3) ' 8-bit write

                Else

                    If Convert.ToInt32(clean_PSX.Substring(clean_PSX.Length - 4, 4), 16) < 256 Then

                        clean_PSX = clean_PSX.Substring(0, 3) & "3" & clean_PSX.Substring(3, clean_PSX.Length - 3) ' 8-bit write

                    Else

                        clean_PSX = clean_PSX.Substring(0, 3) & "8" & clean_PSX.Substring(3, clean_PSX.Length - 3) ' 16-bit write

                    End If

                End If

            End If

        End If

    End Function

    Public Function check_db(ByVal filename As String) As Boolean

        Dim file As New FileStream(filename, FileMode.Open, FileAccess.Read)
        Dim sr As New StreamReader(file)
        Dim buffer As String = Nothing

        Do Until sr.EndOfStream = True

            buffer = sr.ReadLine

            Try

                If buffer.Substring(0, 2) = "_L" Then ' If we're on a code line

                    If buffer.Substring(3, 2) <> "0x" And buffer.Length <> 24 Then ' If the format isn't a PSP format

                        If buffer.Length = 16 And buffer.Substring(11, 1) = " " Then ' Check if the length and space is correct for PSX

                            check_db = True ' It's a POPs file
                            Exit Do

                        End If

                    Else

                        check_db = False ' Not a POPs file
                        Exit Do

                    End If

                End If

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        Loop

        sr.Close()

    End Function

End Class