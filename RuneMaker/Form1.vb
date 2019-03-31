Imports System.ComponentModel
Imports System.Threading

Public Class Form1

    Declare Function apimouse_event Lib "user32.dll" Alias "mouse_event" (ByVal dwFlags As Int32, ByVal dX As Int32, ByVal dY As Int32, ByVal cButtons As Int32, ByVal dwExtraInfo As Int32) As Boolean
    Public Const MOUSEEVENTF_LEFTDOWN = &H2
    Public Const MOUSEEVENTF_LEFTUP = &H4
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
            FoodCoordX.Text = configValues(0)
            FoodCoordY.Text = configValues(1)
            RuneCoordX.Text = configValues(2)
            RuneCoordY.Text = configValues(3)
            RunEveryXMin.Text = configValues(4)
            NumberOfClicksOnFood.Text = configValues(5)
            NumberOfClicksOnSpell.Text = configValues(6)
            ManaEnforceTime1.Text = configValues(7)
            EnforceMana1CoordX.Text = configValues(8)
            EnforceMana1CoordY.Text = configValues(9)

        Catch ex As Exception
            Dim errormessage = "Filling the text box"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Button1.Enabled = False

            Dim ManaEnforce1Trd As Thread
            ManaEnforce1Trd = New Thread(AddressOf ManaEnforce1CountDown)
            ManaEnforce1Trd.IsBackground = True
            ManaEnforce1Trd.Start()

            Dim RuneMakerTrd As Thread
            RuneMakerTrd = New Thread(AddressOf RuneMakerMain)
            RuneMakerTrd.IsBackground = True
            RuneMakerTrd.Start()


            'Dim ManaEnforce1Trd As New Thread(New ThreadStart(Sub() ManaEnforce1CountDown()))
            'ManaEnforce1Trd.Start()

            'Dim RuneMakerTrd As New Thread(New ThreadStart(Sub() RuneMakerMain()))
            'RuneMakerTrd.Start()

        Catch ex As Exception
            Dim errormessage = "when i call the BackgroundWorker on the click event"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub


    Private Sub feed()
        Try
            For index As Integer = 1 To CInt(NumberOfClicksOnFood.Text)
                Windows.Forms.Cursor.Position = New Point(FoodCoordX.Text, FoodCoordY.Text)
                Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
                writeErrorLog("comer")
                Thread.Sleep(1000)
            Next
        Catch ex As Exception
            Dim errormessage = "while feed the char"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub

    Private Sub makeRune()
        Try
            For index As Integer = 1 To CInt(NumberOfClicksOnSpell.Text)
                Windows.Forms.Cursor.Position = New Point(RuneCoordX.Text, RuneCoordY.Text)
                Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
                writeErrorLog("runa")
                Thread.Sleep(2300)
            Next
        Catch ex As Exception
            Dim errormessage = "making the rune"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try

    End Sub

    Private Sub SpellCoordButton_Click(sender As Object, e As EventArgs) Handles SpellCoordButton.Click
        Try
            saveConfig()
            Windows.Forms.Cursor.Position = New Point(RuneCoordX.Text, RuneCoordY.Text)
        Catch ex As Exception
            Dim errormessage = "checkin the rune cursor position"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try

    End Sub

    Private Sub FoodCoordButton_Click(sender As Object, e As EventArgs) Handles FoodCoordButton.Click
        Try
            saveConfig()
            Windows.Forms.Cursor.Position = New Point(FoodCoordX.Text, FoodCoordY.Text)
        Catch ex As Exception
            Dim errormessage = "checkin the food cursor position"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub

    Sub saveConfig()
        Try
            Dim objWriter As New System.IO.StreamWriter(configFilePath, False)
            objWriter.Write(FoodCoordX.Text & "*" & FoodCoordY.Text & "*" & RuneCoordX.Text & "*" & RuneCoordY.Text & "*" & RunEveryXMin.Text & "*" & NumberOfClicksOnFood.Text & "*" & NumberOfClicksOnSpell.Text & "*" & ManaEnforceTime1.Text & "*" & EnforceMana1CoordX.Text & "*" & EnforceMana1CoordY.Text)
            objWriter.Close()

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
            Dim sleepAmountTime As Double = CalculateSleepTime()
            saveConfig()
            Do
                If StopAfterSS.Checked = True Then
                    If startDate.Hour < 3 Then
                        If Date.Now.Hour >= 3 Then
                            Close()
                            If ShutDawnAfterSS.Checked = True Then
                                System.Diagnostics.Process.Start("shutdown", "-s -t 00")
                            End If
                        End If
                    End If
                End If

                feed()
                makeRune()
                'timer
                For i = 0 To 100
                    BackgroundWorker1.ReportProgress(i)
                    Thread.Sleep(sleepAmountTime)
                Next
            Loop
        Catch ex As Exception
            Dim errormessage = "runing the main program"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub

    Private Function CalculateSleepTime() As Integer
        Dim rValue As Integer
        Try
            Dim timeOnMin As Double = CDbl(RunEveryXMin.Text)
            Dim timeOnMilisecUp As Double = timeOnMin * 60000
            Dim timeOnMilisecDwn As Double = timeOnMilisecUp - 60000
            Dim Rnd As Random = New Random()
            rValue = Rnd.Next(timeOnMilisecDwn, timeOnMilisecUp)
            rValue = rValue / 100

        Catch ex As Exception
            Dim errormessage = "calculating the sleep thread time lapse"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
        Return rValue
    End Function

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

    Private Sub ManaEnforceCoordButton1_Click(sender As Object, e As EventArgs) Handles ManaEnforceCoordButton1.Click
        Try
            saveConfig()
            Windows.Forms.Cursor.Position = New Point(EnforceMana1CoordX.Text, EnforceMana1CoordY.Text)
        Catch ex As Exception
            Dim errormessage = "checkin the food cursor position"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub

    'Private Delegate Sub ManaEnforce1UpdateDelegate()
    Private Sub ManaEnforce1CountDown()
        Try
            'If InvokeRequired Then
            '    Invoke(New ManaEnforce1UpdateDelegate(AddressOf ManaEnforce1CountDown))
            'Else
            '    If ManaEnforceCheckBox1.Checked = True Then
            '        Dim sleepAmountTime = CInt(ManaEnforceTime1.Text * 60000)
            '        Do
            '            Windows.Forms.Cursor.Position = New Point(EnforceMana1CoordX.Text, EnforceMana1CoordY.Text)
            '            Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
            '            Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
            '            Thread.Sleep(sleepAmountTime)
            '        Loop
            '    End If
            'End If


            If ManaEnforceCheckBox1.Checked = True Then
                Dim sleepAmountTime = CInt(ManaEnforceTime1.Text * 60000)
                Do
                    Windows.Forms.Cursor.Position = New Point(EnforceMana1CoordX.Text, EnforceMana1CoordY.Text)
                    Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                    Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
                    Thread.Sleep(sleepAmountTime)
                Loop
            End If

        Catch ex As Exception
            Dim errormessage = "ManaEnforce1CountDown"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub

    'Private Delegate Sub RuneMakerMainUpdateDelegate()
    Private Sub RuneMakerMain()
        Try
            'If InvokeRequired Then
            '    Invoke(New RuneMakerMainUpdateDelegate(AddressOf RuneMakerMain))
            'Else
            '    Button1.Enabled = False
            '    'TopMost = True
            '    BackgroundWorker1.RunWorkerAsync()
            'End If
            'TopMost = True
            BackgroundWorker1.RunWorkerAsync()
        Catch ex As Exception
            Dim errormessage = "RuneMakerMain"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try

    End Sub

End Class
