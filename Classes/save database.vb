Imports System.IO
Public Class save_db

    Public Sub save_cwcheat(ByVal filename As String)

        Dim m As Main = Main
        Dim i As Integer = 0 ' Error count
        Dim buffer As String()
        Dim tw As TextWriter = File.CreateText(filename)
        Dim ew As error_window = error_window
        Dim errors As Boolean = False

        reset_errors() ' Clear prior save errors if any

        Try

            For Each n As TreeNode In m.codetree.Nodes(0).Nodes

                tw.Write("_S " & n.Tag.ToString.Trim & vbLf)
                tw.Write("_G " & n.Text.Trim & vbLf)

                For Each n1 As TreeNode In n.Nodes

                    If n1.Tag Is Nothing Then

                        ' If the code title had no actual codes, don't save it
                        i += 1
                        write_errors(i, n.Text.Trim, n1.Text.Trim, "Error:  Code title contained no codes, not saved.")
                        errors = True

                    ElseIf n1.Tag.ToString.Trim = "0" Or n1.Tag.ToString.Trim = "1" Then

                        ' If the code title had no actual codes, don't save it
                        i += 1
                        write_errors(i, n.Text.Trim, n1.Text.Trim, "Error:  Code title contained no codes, not saved.")
                        errors = True

                    Else

                        If n1.Tag.ToString.Substring(0, 1) = "0" Then
                            tw.Write("_C0 " & n1.Text.Trim & vbLf)
                        Else
                            tw.Write("_C1 " & n1.Text.Trim & vbLf)
                        End If


                        buffer = n1.Tag.ToString.Split(CChar(vbCrLf))

                        For Each s As String In buffer

                            If s.Length > 1 Then

                                If s.Contains("#") Then

                                    tw.Write(s.Trim & vbLf)

                                Else

                                    If s.Trim.Length = 21 Then

                                        tw.Write("_L " & s.Trim & vbLf)

                                    Else
                                        ' Error, code length was incorrect
                                        i += 1
                                        write_errors(i, n.Text.Trim, n1.Text.Trim, "Incorrectly formatted code: " & s.Trim)
                                        errors = True
                                    End If

                                End If

                            End If

                        Next

                    End If

                Next

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        tw.Close()

    End Sub

    Public Sub save_pspar(ByVal filename As String)

        Dim m As Main = Main
        Dim i As Integer = 0 ' Error count
        Dim buffer As String()
        Dim tw As TextWriter = File.CreateText(filename)
        Dim ew As error_window = error_window
        Dim errors As Boolean = False

        reset_errors() ' Clear prior save errors if any

        Try

            For Each n As TreeNode In m.codetree.Nodes(0).Nodes

                tw.Write("_S " & n.Tag.ToString.Trim & vbLf)
                tw.Write("_G " & n.Text.Trim & vbLf)

                For Each n1 As TreeNode In n.Nodes

                    If n1.Tag Is Nothing Then

                        ' If the code title had no actual codes, don't save it
                        i += 1
                        write_errors(i, n.Text.Trim, n1.Text.Trim, "Error:  Code title contained no codes, not saved.")
                        errors = True

                    ElseIf n1.Tag.ToString.Trim = "0" Or n1.Tag.ToString.Trim = "1" Then

                        ' If the code title had no actual codes, don't save it
                        i += 1
                        write_errors(i, n.Text.Trim, n1.Text.Trim, "Error:  Code title contained no codes, not saved.")
                        errors = True

                    Else

                        If n1.Tag.ToString.Substring(0, 1) = "0" Then
                            tw.Write("_C0 " & n1.Text.Trim & vbLf)
                        Else
                            tw.Write("_C1 " & n1.Text.Trim & vbLf)
                        End If


                        buffer = n1.Tag.ToString.Split(CChar(vbCrLf))

                        For Each s As String In buffer

                            If s.Length > 1 Then

                                If s.Contains("#") Then

                                    tw.Write(s.Trim & vbLf)

                                Else

                                    If s.Trim.Length = 21 Then

                                        tw.Write("_M " & s.Trim & vbLf)

                                    Else
                                        ' Error, code length was incorrect
                                        i += 1
                                        write_errors(i, n.Text.Trim, n1.Text.Trim, "Incorrectly formatted code: " & s.Trim)
                                        errors = True
                                    End If

                                End If

                            End If

                        Next

                    End If

                Next

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        tw.Close()

    End Sub

    Public Sub save_psx(ByVal filename As String)

        Dim m As Main = Main
        Dim i As Integer = 0 ' Error count
        Dim buffer As String()
        Dim tw As TextWriter = File.CreateText(filename)
        Dim ew As error_window = error_window
        Dim errors As Boolean = False

        reset_errors() ' Clear prior save errors if any

        For Each n As TreeNode In m.codetree.Nodes(0).Nodes

            tw.Write("_S " & n.Tag.ToString.Trim & vbLf)
            tw.Write("_G " & n.Text.Trim & vbLf)

            For Each n1 As TreeNode In n.Nodes

                If n1.Tag Is Nothing Then

                    ' If the code title had no actual codes, don't save it
                    i += 1
                    write_errors(i, n.Text.Trim, n1.Text.Trim, "Error:  Code title contained no codes, not saved.")
                    errors = True

                ElseIf n1.Tag.ToString.Trim = "0" Or n1.Tag.ToString.Trim = "1" Then

                    ' If the code title had no actual codes, don't save it
                    i += 1
                    write_errors(i, n.Text.Trim, n1.Text.Trim, "Error:  Code title contained no codes, not saved.")
                    errors = True

                Else

                    If n1.Tag.ToString.Substring(0, 1) = "0" Then
                        tw.Write("_C0 " & n1.Text.Trim & vbLf)
                    Else
                        tw.Write("_C1 " & n1.Text.Trim & vbLf)
                    End If


                    buffer = n1.Tag.ToString.Split(CChar(vbCrLf))

                    For Each s As String In buffer

                        If s.Length > 1 Then

                            If s.Contains("#") Then

                                tw.Write(s.Trim & vbLf)

                            Else

                                If s.Trim.Length = 13 Then

                                    tw.Write("_L " & s.Trim & vbLf)

                                Else
                                    ' Error, code length was incorrect
                                    i += 1
                                    write_errors(i, n.Text.Trim, n1.Text.Trim, "Incorrectly formatted code: " & s.Trim)
                                    errors = True
                                End If

                            End If

                        End If

                    Next

                End If

            Next

        Next

        tw.Close()

    End Sub

    Private Sub reset_errors()

        Dim ew As error_window = error_window
        Dim m As Main = Main

        ew.Hide()
        m.options_error.Text = "Show Error Log"
        m.options_error.Checked = False
        ew.list_save_error.Items.Clear()

    End Sub

    Private Sub write_errors(ByVal error_n As Integer, ByVal game_t As String, ByVal code_t As String, _
                             ByVal error_r As String)

        Dim ew As error_window = error_window

        With ew.list_save_error
            .Items.Add(error_n.ToString)
            .Items(error_n - 1).SubItems.Add(game_t)
            .Items(error_n - 1).SubItems.Add(code_t)
            .Items(error_n - 1).SubItems.Add(error_r)
        End With

        Application.DoEvents()

    End Sub

End Class
