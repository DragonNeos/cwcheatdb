Public Class joker

    Public Sub add_joker()

        Dim m As Main = Main
        Dim i As Integer = 0
        Dim buffer As String() = m.cl_tb.Text.Split(CChar(vbCrLf)) ' Seperate the codes in our string array
        Dim tmp(1) As String

        For Each s As String In buffer ' Check through each code in the array

            s = s.Trim

            If s.Length = 21 Then

                If s.Substring(2, 1).ToUpper <> "D" And s.Substring(13, 1) <> "1" Then ' If it's not an existing joker

                    tmp(0) &= s & vbCrLf ' Add the code to our buffer
                    i += 1 ' Keep track of how many codes are in the array

                ElseIf s.Substring(2, 1).ToUpper <> "D" And s.Substring(13, 1) <> "3" Then ' If it's not an existing inverse joker

                    tmp(0) &= s & vbCrLf ' Add the code to our buffer
                    i += 1 ' Keep track of how many codes are in the array

                End If


            End If

        Next

        tmp(1) = Convert.ToString((i - 1), 16) ' Convert the number of codes we found into a hexadecimal string and store it in a buffer.

        Select Case tmp(1).Length ' Check the length of the converted string and add 0's to make it 10 characters long
            Case Is = 1
                tmp(1) = "0xD000000" & tmp(1)
            Case Is = 2
                tmp(1) = "0xD00000" & tmp(1)
        End Select

        If m.inverse_chk.Checked = True Then
            tmp(1) = tmp(1) & calc_button(1) & vbCrLf ' Get the values of the checkboxes checked
        Else
            tmp(1) = tmp(1) & calc_button(0) & vbCrLf ' Get the values of the checkboxes checked
        End If

        m.cl_tb.Text = tmp(1) & tmp(0) ' Write the joker + codes back into the code list


    End Sub

    Public Sub remove_joker()

        Dim m As Main = Main
        Dim buffer As String() = m.cl_tb.Text.Split(CChar(vbCrLf))
        Dim tmp As String = Nothing

        For Each s As String In buffer

            s = s.Trim

            If s.Length = 21 Then

                If s.Substring(2, 1).ToUpper <> "D" And s.Substring(13, 1) <> "1" Then ' If it's not an existing joker
                    tmp &= s & vbCrLf
                ElseIf s.Substring(2, 1).ToUpper <> "D" And s.Substring(13, 1) <> "3" Then ' If it's not an existing inverse joker
                    tmp &= s & vbCrLf
                End If

            End If

        Next

        m.cl_tb.Text = tmp

    End Sub

    Private Function calc_button(ByVal y As Integer) As String

        Dim m As Main = Main
        Dim i As Integer = 0
        Dim x As Long = 0

        For i = 0 To 19 ' Cycle through each checkbox

            If m.button_list.GetItemChecked(i) = True Then ' If it's checked, store the hexadecimal value in X

                Select Case i

                    Case Is = 0
                        x += &H1
                    Case Is = 1
                        x += &H8
                    Case Is = 2
                        x += &H10
                    Case Is = 3
                        x += &H20
                    Case Is = 4
                        x += &H40
                    Case Is = 5
                        x += &H80
                    Case Is = 6
                        x += &H100
                    Case Is = 7
                        x += &H200
                    Case Is = 8
                        x += &H1000
                    Case Is = 9
                        x += &H2000
                    Case Is = 10
                        x += &H4000
                    Case Is = 11
                        x += &H8000
                    Case Is = 12
                        x += &H10000
                    Case Is = 13
                        x += &H20000
                    Case Is = 14
                        x += &H800000
                    Case Is = 15
                        x += &H400000
                    Case Is = 16
                        x += &H100000
                    Case Is = 17
                        x += &H200000
                    Case Is = 18
                        x += &H40000
                    Case Is = 19
                        x += &H80000

                End Select

            End If

        Next

        calc_button = Convert.ToString(x, 16) ' Return the value of x into a base16 (hex) string

        If y = 1 Then ' If inverse is checked

            Select Case calc_button.Length ' Check the length of the converted hexadecimal string and add 0's to make it 10 characters long

                Case Is = 1
                    calc_button = " 0x3000000" & calc_button
                Case Is = 2
                    calc_button = " 0x300000" & calc_button
                Case Is = 3
                    calc_button = " 0x30000" & calc_button
                Case Is = 4
                    calc_button = " 0x3000" & calc_button
                Case Is = 5
                    calc_button = " 0x300" & calc_button
                Case Is = 6
                    calc_button = " 0x30" & calc_button

            End Select

        Else ' If inverse is not checked

            Select Case calc_button.Length ' Check the length of the converted hexadecimal string and add 0's to make it 10 characters long

                Case Is = 1
                    calc_button = " 0x1000000" & calc_button
                Case Is = 2
                    calc_button = " 0x100000" & calc_button
                Case Is = 3
                    calc_button = " 0x10000" & calc_button
                Case Is = 4
                    calc_button = " 0x1000" & calc_button
                Case Is = 5
                    calc_button = " 0x100" & calc_button
                Case Is = 6
                    calc_button = " 0x10" & calc_button

            End Select

        End If

        Return calc_button

    End Function

    Public Sub button_value(ByVal s As String)

        ' Until I optimize this, I'm going to determine it the long way.

        Dim m As Main = Main
        Dim i As Integer = 0

        For i = 0 To 19 ' Reset the checked list box state
            m.button_list.SetItemChecked(i, False)
        Next

        s = s.Trim.Substring(13, 8) ' Grab the value portion of the code

        Select Case s.Substring(7, 1)               ' Check 0x0000000n

            Case Is = "1"                           ' 0x000000001
                m.button_list.SetItemChecked(0, True)
            Case Is = "8"                           ' 0x000000008
                m.button_list.SetItemChecked(1, True)
            Case Is = "9"                           ' 0x000000009
                m.button_list.SetItemChecked(0, True)
                m.button_list.SetItemChecked(1, True)

        End Select

        Select Case s.Substring(6, 1).ToUpper       ' Check 0x000000n0

            Case Is = "1"                           ' 0x00000010
                m.button_list.SetItemChecked(2, True)
            Case Is = "2"                           ' 0x00000020
                m.button_list.SetItemChecked(3, True)
            Case Is = "3"                           ' 0x00000030
                m.button_list.SetItemChecked(2, True)
                m.button_list.SetItemChecked(3, True)
            Case Is = "4"                           ' 0x00000040
                m.button_list.SetItemChecked(4, True)
            Case Is = "5"                           ' 0x00000050
                m.button_list.SetItemChecked(2, True)
                m.button_list.SetItemChecked(4, True)
            Case Is = "6"                           ' 0x00000060
                m.button_list.SetItemChecked(3, True)
                m.button_list.SetItemChecked(4, True)
            Case Is = "7"                           ' 0x00000070
                m.button_list.SetItemChecked(2, True)
                m.button_list.SetItemChecked(3, True)
                m.button_list.SetItemChecked(4, True)
            Case Is = "8"                           ' 0x00000080
                m.button_list.SetItemChecked(5, True)
            Case Is = "9"                           ' 0x00000090
                m.button_list.SetItemChecked(5, True)
                m.button_list.SetItemChecked(2, True)
            Case Is = "A"                           ' 0x000000A0
                m.button_list.SetItemChecked(5, True)
                m.button_list.SetItemChecked(3, True)
            Case Is = "B"                           ' 0x000000B0
                m.button_list.SetItemChecked(2, True)
                m.button_list.SetItemChecked(3, True)
                m.button_list.SetItemChecked(5, True)
            Case Is = "C"                           ' 0x000000C0
                m.button_list.SetItemChecked(4, True)
                m.button_list.SetItemChecked(5, True)
            Case Is = "E"                           ' 0x000000E0
                m.button_list.SetItemChecked(3, True)
                m.button_list.SetItemChecked(4, True)
                m.button_list.SetItemChecked(5, True)

        End Select

        Select Case s.Substring(5, 1)               ' Check 0x00000n00

            Case Is = "1"                           ' 0x00000100
                m.button_list.SetItemChecked(6, True)
            Case Is = "2"                           ' 0x00000200
                m.button_list.SetItemChecked(7, True)
            Case Is = "3"                           ' 0x00000300
                m.button_list.SetItemChecked(6, True)
                m.button_list.SetItemChecked(7, True)

        End Select

        Select Case s.Substring(4, 1).ToUpper       ' Check 0x0000n000

            Case Is = "1"                           ' 0x00001000
                m.button_list.SetItemChecked(8, True)
            Case Is = "2"                           ' 0x00002000
                m.button_list.SetItemChecked(9, True)
            Case Is = "3"                           ' 0x00003000
                m.button_list.SetItemChecked(8, True)
                m.button_list.SetItemChecked(9, True)
            Case Is = "4"                           ' 0x00004000
                m.button_list.SetItemChecked(10, True)
            Case Is = "5"                           ' 0x00005000
                m.button_list.SetItemChecked(8, True)
                m.button_list.SetItemChecked(10, True)
            Case Is = "6"                           ' 0x00006000
                m.button_list.SetItemChecked(9, True)
                m.button_list.SetItemChecked(10, True)
            Case Is = "7"                           ' 0x00007000
                m.button_list.SetItemChecked(8, True)
                m.button_list.SetItemChecked(9, True)
                m.button_list.SetItemChecked(10, True)
            Case Is = "8"                           ' 0x00008000
                m.button_list.SetItemChecked(11, True)
            Case Is = "9"                           ' 0x00009000
                m.button_list.SetItemChecked(8, True)
                m.button_list.SetItemChecked(11, True)
            Case Is = "A"                           ' 0x0000A000
                m.button_list.SetItemChecked(9, True)
                m.button_list.SetItemChecked(11, True)
            Case Is = "B"                           ' 0x0000B000
                m.button_list.SetItemChecked(8, True)
                m.button_list.SetItemChecked(9, True)
                m.button_list.SetItemChecked(11, True)
            Case Is = "C"                           ' 0x0000C000
                m.button_list.SetItemChecked(10, True)
                m.button_list.SetItemChecked(11, True)
            Case Is = "E"                           ' 0x0000E000
                m.button_list.SetItemChecked(9, True)
                m.button_list.SetItemChecked(10, True)
                m.button_list.SetItemChecked(11, True)

        End Select

        Select Case s.Substring(3, 1).ToUpper       ' Check 0x000n0000

            Case Is = "1"                           ' 0x00010000
                m.button_list.SetItemChecked(12, True)
            Case Is = "2"                           ' 0x00020000
                m.button_list.SetItemChecked(13, True)
            Case Is = "3"                           ' 0x00030000
                m.button_list.SetItemChecked(12, True)
                m.button_list.SetItemChecked(13, True)
            Case Is = "4"                           ' 0x00040000
                m.button_list.SetItemChecked(18, True)
            Case Is = "5"                           ' 0x00050000
                m.button_list.SetItemChecked(12, True)
                m.button_list.SetItemChecked(18, True)
            Case Is = "6"                           ' 0x00060000
                m.button_list.SetItemChecked(13, True)
                m.button_list.SetItemChecked(18, True)
            Case Is = "7"                           ' 0x00070000
                m.button_list.SetItemChecked(12, True)
                m.button_list.SetItemChecked(13, True)
                m.button_list.SetItemChecked(18, True)
            Case Is = "8"                           ' 0x00080000
                m.button_list.SetItemChecked(19, True)
            Case Is = "9"                           ' 0x00090000
                m.button_list.SetItemChecked(12, True)
                m.button_list.SetItemChecked(19, True)
            Case Is = "A"                           ' 0x000A0000
                m.button_list.SetItemChecked(13, True)
                m.button_list.SetItemChecked(19, True)
            Case Is = "B"                           ' 0x000B0000
                m.button_list.SetItemChecked(12, True)
                m.button_list.SetItemChecked(13, True)
                m.button_list.SetItemChecked(19, True)
            Case Is = "C"                           ' 0x000C0000
                m.button_list.SetItemChecked(18, True)
                m.button_list.SetItemChecked(19, True)
            Case Is = "E"                           ' 0x0000E0000
                m.button_list.SetItemChecked(13, True)
                m.button_list.SetItemChecked(18, True)
                m.button_list.SetItemChecked(19, True)

        End Select

        Select Case s.Substring(2, 1).ToUpper       ' Check 0x00n00000

            Case Is = "8"                           ' 0x00800000
                m.button_list.SetItemChecked(14, True)
            Case Is = "4"                           ' 0x00400000
                m.button_list.SetItemChecked(15, True)
            Case Is = "1"                           ' 0x00100000
                m.button_list.SetItemChecked(16, True)
            Case Is = "2"                           ' 0x00200000
                m.button_list.SetItemChecked(17, True)
            Case Is = "3"                           ' 0x00300000
                m.button_list.SetItemChecked(16, True)
                m.button_list.SetItemChecked(17, True)
            Case Is = "5"                           ' 0x00500000
                m.button_list.SetItemChecked(16, True)
                m.button_list.SetItemChecked(15, True)
            Case Is = "6"                           ' 0x00600000
                m.button_list.SetItemChecked(15, True)
                m.button_list.SetItemChecked(17, True)
            Case Is = "7"                           ' 0x00700000
                m.button_list.SetItemChecked(16, True)
                m.button_list.SetItemChecked(17, True)
                m.button_list.SetItemChecked(15, True)
            Case Is = "9"                           ' 0x00900000
                m.button_list.SetItemChecked(16, True)
                m.button_list.SetItemChecked(14, True)
            Case Is = "A"                           ' 0x00A00000
                m.button_list.SetItemChecked(14, True)
                m.button_list.SetItemChecked(17, True)
            Case Is = "B"                           ' 0x00B00000
                m.button_list.SetItemChecked(14, True)
                m.button_list.SetItemChecked(16, True)
                m.button_list.SetItemChecked(17, True)
            Case Is = "C"                           ' 0x00C00000
                m.button_list.SetItemChecked(15, True)
                m.button_list.SetItemChecked(14, True)
            Case Is = "E"                           ' 0x00E00000
                m.button_list.SetItemChecked(17, True)
                m.button_list.SetItemChecked(15, True)
                m.button_list.SetItemChecked(14, True)
        End Select

    End Sub

End Class
