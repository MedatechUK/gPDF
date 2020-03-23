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
                            Console.WriteLine("Starting {0} {1}...", e.ConvertProcessInfo.FileName, e.ConvertProcessInfo.Arguments)

                            .Start()
                            Console.WriteLine(.StandardOutput.ReadToEnd)
                            Console.WriteLine(.StandardError.ReadToEnd)
                            .WaitForExit()

                        End With

                    End Using

                Catch ex As Exception
                    Console.Write(ex.Message)

                Finally


                End Try

            End With

        End Using

    End Sub

End Module
