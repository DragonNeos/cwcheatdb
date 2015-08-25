Public Class MemoryManagement

    Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" ( _
      ByVal process As IntPtr, _
      ByVal minimumWorkingSetSize As Integer, _
      ByVal maximumWorkingSetSize As Integer) As Integer

    Public Sub FlushMemory()
        GC.Collect()
        GC.WaitForPendingFinalizers()
        If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
            SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1)
        End If
    End Sub

End Class
