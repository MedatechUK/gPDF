Imports System.IO
Imports System.Threading

Module Module1

    Sub Main()

        Using e As New pdffile(New IO.FileInfo(Environment.GetCommandLineArgs(1)))
            With e
                Try
                    Using proc As New Process
                        With proc
                            .StartInfo = e.ConvertProcessInfo
                            .Start() ' the conversion
                            While Not .HasExited ' the conversion
                                Thread.Sleep(100)

                            End While
                        End With

                        File.Copy(
                            .pxl.FullName,
                            Environment.GetCommandLineArgs(2)
                        )

                    End Using

                Catch ex As Exception
                    Console.Write(ex.Message)

                Finally
                    .DeleteAndWait()

                End Try

            End With

        End Using

    End Sub

End Module
