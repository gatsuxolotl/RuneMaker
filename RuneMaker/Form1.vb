Imports System.ComponentModel
Imports System.Threading

Public Class Form1

    Declare Function apimouse_event Lib "user32.dll" Alias "mouse_event" (ByVal dwFlags As Int32, ByVal dX As Int32, ByVal dY As Int32, ByVal cButtons As Int32, ByVal dwExtraInfo As Int32) As Boolean
    Public Const MOUSEEVENTF_LEFTDOWN = &H2
    Public Const MOUSEEVENTF_LEFTUP = &H4
    Public nextInt As Integer
    Dim configFilePath = "C:\RuneMaker\config.txt"
    Dim startDate As Date = Date.Now
    Dim errorLogFilePath = "C:\RuneMaker\errorLog.txt"
    Dim mainDir = "C:\RuneMaker\"

    Sub New()
        Try
            InitializeComponent()
            Me.BackgroundWorker1.WorkerReportsProgress = True
            If System.IO.Directory.Exists(mainDir) Then

                If System.IO.File.Exists(configFilePath) Then
                    'The file exists
                    Dim fileReader As String
                    fileReader = My.Computer.FileSystem.ReadAllText(configFilePath)
                    fillValues(fileReader)
                Else
                    'the file doesn't exist
                    System.IO.File.Create(configFilePath).Dispose()
                End If
            Else
                System.IO.Directory.CreateDirectory(mainDir)
                System.IO.File.Create(configFilePath).Dispose()
            End If

        Catch ex As Exception
            Dim errormessage = "on the constructor"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub

    Private Sub fillValues(fileReader As String)
        Try
            Dim configValues = fileReader.Split(New Char() {"*"c})
            TextBox1.Text = configValues(0)
            TextBox2.Text = configValues(1)
            TextBox3.Text = configValues(2)
            TextBox4.Text = configValues(3)
        Catch ex As Exception
            Dim errormessage = "Filling the text box"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Button1.Enabled = False
            BackgroundWorker1.RunWorkerAsync()
        Catch ex As Exception
            Dim errormessage = "when i call the BackgroundWorker on the click event"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub


    Private Sub feed()
        Try
            For index As Integer = 1 To 5
                Windows.Forms.Cursor.Position = New Point(TextBox1.Text, TextBox2.Text)
                Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
                Thread.Sleep(1000)
            Next
        Catch ex As Exception
            Dim errormessage = "while feed the char"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub

    Private Sub makeRune()
        Try
            For index As Integer = 1 To 4
                Windows.Forms.Cursor.Position = New Point(TextBox3.Text, TextBox4.Text)
                Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
                Thread.Sleep(2300)
            Next
        Catch ex As Exception
            Dim errormessage = "making the rune"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            addConfigLine()
            Windows.Forms.Cursor.Position = New Point(TextBox3.Text, TextBox4.Text)
        Catch ex As Exception
            Dim errormessage = "checkin the rune cursor position"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            addConfigLine()
            Windows.Forms.Cursor.Position = New Point(TextBox1.Text, TextBox2.Text)
        Catch ex As Exception
            Dim errormessage = "checkin the food cursor position"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try

    End Sub

    Sub addConfigLine()
        Try
            System.IO.File.WriteAllText(configFilePath, String.Empty)
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(configFilePath, True)
            file.WriteLine(TextBox1.Text & "*" & TextBox2.Text & "*" & TextBox3.Text & "*" & TextBox4.Text)
            file.Close()
        Catch ex As Exception
            Dim errormessage = "saving the configuration values"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Close()
        Catch ex As Exception
            Dim errormessage = "trying to close the programm"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            addConfigLine()
            Do
                If CheckBox1.Checked = True Then
                    If startDate.Hour < 3 Then
                        If Date.Now.Hour >= 3 Then
                            Close()
                            If CheckBox2.Checked = True Then
                                System.Diagnostics.Process.Start("shutdown", "-s -t 00")
                            End If
                        End If
                    End If
                End If

                feed()
                makeRune()
                TopMost = True
                Dim Rnd As Random = New Random()
                nextInt = CInt(rnd.Next(840000, 870000))
                'timer
                For i = 0 To 100
                    BackgroundWorker1.ReportProgress(i)
                    Thread.Sleep(nextInt / 100)
                Next
            Loop
        Catch ex As Exception
            Dim errormessage = "runing the main program"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Try
            ProgressBar1.Value = e.ProgressPercentage
        Catch ex As Exception
            Dim errormessage = "on the ProgressChanged"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Try
            ProgressBar1.Value = 0
        Catch ex As Exception
            Dim errormessage = "whn the BackgroundWorker1 completed hes proccess"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub

    Sub writeErrorLog(errorMessage As String)
        If System.IO.Directory.Exists(mainDir) Then

            If System.IO.File.Exists(errorLogFilePath) Then
                'The file exists
                Dim file As System.IO.StreamWriter
                file = My.Computer.FileSystem.OpenTextFileWriter(errorLogFilePath, True)
                file.WriteLine(Date.Now.ToString & " " & errorMessage)
                file.Close()
            Else
                'the file doesn't exist
                System.IO.File.Create(errorLogFilePath).Dispose()
                Dim file As System.IO.StreamWriter
                file = My.Computer.FileSystem.OpenTextFileWriter(errorLogFilePath, True)
                file.WriteLine(Date.Now.ToString & " " & errorMessage)
                file.Close()
            End If
        Else
            System.IO.Directory.CreateDirectory(mainDir)
            System.IO.File.Create(errorLogFilePath).Dispose()
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(errorLogFilePath, True)
            file.WriteLine(Date.Now.ToString & " " & errorMessage)
            file.Close()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CheckForIllegalCrossThreadCalls = False
    End Sub
End Class
