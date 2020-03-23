Imports System.IO
Imports System.Reflection
Imports System.Threading

Public Class pdffile : Implements IDisposable

    Private _file As FileInfo

    Public Sub New(fileInfo As FileInfo)
        _file = fileInfo

        If Not New FileInfo(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly.Location), "gswin64c.exe")).Exists Then
            File.WriteAllBytes(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly.Location), "gswin64c.exe"), My.Resources.gswin64c)
        End If
        If Not New FileInfo(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly.Location), "gsdll64.lib")).Exists Then
            File.WriteAllBytes(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly.Location), "gsdll64.lib"), My.Resources.gsdll64lib)
        End If
        If Not New FileInfo(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly.Location), "gsdll64.dll")).Exists Then
            File.WriteAllBytes(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly.Location), "gsdll64.dll"), My.Resources.gsdll64dll)
        End If

    End Sub

    Public ReadOnly Property ConvertProcessInfo() As ProcessStartInfo
        Get
            Dim ret As New ProcessStartInfo
            With ret
                .FileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly.Location), "gswin64c.exe")
                .CreateNoWindow = True
                .UseShellExecute = False
                .RedirectStandardOutput = True
                .RedirectStandardError = True
                .Arguments = String.Format(
                    "-dNOPAUSE -dBATCH -sDEVICE=mswinpr2 -sPAPERSIZE=a4 -dFIXEDMEDIA -dPDFFitPage -dNoCancel " &
                    "-sOutputFile={2}%printer%{1}{2} " &
                    "-c {2}<</BeginPage{3}0.9 0.9 scale 29.75 42.1 translate{4}>> setpagedevice{2} " &
                    "-f {2}{0}{2}",
                    _file.FullName,
                    Environment.GetCommandLineArgs(2),
                    Chr(34),
                    "{",
                    "}"
                )

            End With

            Return ret
        End Get
    End Property

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region


End Class
