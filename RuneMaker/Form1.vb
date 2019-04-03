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
    Dim WithEvents objManaEnforce1 As ManaEnforce1
    Dim WithEvents objManaEnforce2 As ManaEnforce2
    Private objLock As New Object
    Sub New()
        Try
            InitializeComponent()
            objManaEnforce1 = New ManaEnforce1
            objManaEnforce2 = New ManaEnforce2
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
            ManaEnforceTime2.Text = configValues(10)
            EnforceMana2CoordX.Text = configValues(11)
            EnforceMana2CoordY.Text = configValues(12)
        Catch ex As Exception
            Dim errormessage = "Filling the text box"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Button1.Enabled = False
            'TopMost = True
            If ManaEnforceCheckBox1.Checked = True Then
                Dim ManaEnforce1Trd As Thread
                ManaEnforce1Trd = New Thread(AddressOf ManaEnforce1CountDown)
                ManaEnforce1Trd.IsBackground = True
                ManaEnforce1Trd.Start()
            End If

            If ManaEnforceCheckBox2.Checked = True Then
                Dim ManaEnforce2Trd As Thread
                ManaEnforce2Trd = New Thread(AddressOf ManaEnforce2CountDown)
                ManaEnforce2Trd.IsBackground = True
                ManaEnforce2Trd.Start()
            End If

            Dim RuneMakerTrd As New Thread(New ThreadStart(Sub() RuneMakerMain()))
            RuneMakerTrd.Start()

        Catch ex As Exception
            Dim errormessage = "when i call the BackgroundWorker on the click event"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub


    Private Sub feed()
        Try
            For index As Integer = 1 To CInt(NumberOfClicksOnFood.Text)
                MasterClick(FoodCoordX.Text, FoodCoordY.Text, 500, "food")
                'Console.WriteLine("food")
                Thread.Sleep(500)
            Next
        Catch ex As Exception
            Dim errormessage = "while feed the char"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub

    Private Sub makeRune()
        Try
            For index As Integer = 1 To CInt(NumberOfClicksOnSpell.Text)
                MasterClick(RuneCoordX.Text, RuneCoordY.Text, 500, "spell")
                'Console.WriteLine("spell")
                Thread.Sleep(1600)
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
            objWriter.Write(FoodCoordX.Text & "*" & FoodCoordY.Text & "*" & RuneCoordX.Text & "*" & RuneCoordY.Text & "*" & RunEveryXMin.Text & "*" & NumberOfClicksOnFood.Text & "*" & NumberOfClicksOnSpell.Text & "*" & ManaEnforceTime1.Text & "*" & EnforceMana1CoordX.Text & "*" & EnforceMana1CoordY.Text & "*" & ManaEnforceTime2.Text & "*" & EnforceMana2CoordX.Text & "*" & EnforceMana2CoordY.Text)
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
            Dim errormessage = "ManaEnforceCoordButton1"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub

    Private Sub ManaEnforceCoordButton2_Click(sender As Object, e As EventArgs) Handles ManaEnforceCoordButton2.Click
        Try
            saveConfig()
            Windows.Forms.Cursor.Position = New Point(EnforceMana2CoordX.Text, EnforceMana2CoordY.Text)
        Catch ex As Exception
            Dim errormessage = "ManaEnforceCoordButton2"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub

    Private Sub ManaEnforce1CountDown()
        Try
            Dim sleepAmountTime = CInt(ManaEnforceTime1.Text * 60000)
            Do
                objManaEnforce1.LaunchManaEnforce1()
                Thread.Sleep(sleepAmountTime)
            Loop
        Catch ex As Exception
            Dim errormessage = "ManaEnforce1CountDown"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub

    Private Sub ManaEnforce2CountDown()
        Try
            Dim sleepAmountTime = CInt(ManaEnforceTime2.Text * 60000)
            Do
                objManaEnforce2.LaunchManaEnforce2()
                Thread.Sleep(sleepAmountTime)
            Loop
        Catch ex As Exception
            Dim errormessage = "ManaEnforce1CountDown"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub

    Private Delegate Sub RuneMakerMainUpdateDelegate()
    Private Sub RuneMakerMain()
        Try
            If InvokeRequired Then
                Invoke(New RuneMakerMainUpdateDelegate(AddressOf RuneMakerMain))
            Else
                Button1.Enabled = False
                BackgroundWorker1.RunWorkerAsync()
            End If

        Catch ex As Exception
            Dim errormessage = "RuneMakerMain"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub


    Private Sub MasterClick(ByVal CoordX As Double, ByVal Coordy As Double, ccTime As Double, source As String)
        Try
            SyncLock objLock
                Threading.Thread.Sleep(ccTime)
                Console.WriteLine(Date.Now & " : " & source)
                Windows.Forms.Cursor.Position = New Point(CoordX, Coordy)
                Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
            End SyncLock
        Catch ex As Exception
            Dim errormessage = "MasterClick"
            writeErrorLog(errormessage & " : " & ex.Message)
        End Try
    End Sub

    Private Sub manaEnforce1_ManaEnforce1Event() Handles objManaEnforce1.ManaEnforce1Event
        MasterClick(EnforceMana1CoordX.Text, EnforceMana1CoordY.Text, 1000, "mana1")
        'Console.WriteLine("mana1")
    End Sub

    Private Sub manaEnforce2_ManaEnforce2Event() Handles objManaEnforce2.ManaEnforce2Event
        MasterClick(EnforceMana2CoordX.Text, EnforceMana2CoordY.Text, 1000, "mana2")
        'Console.WriteLine("mana2")
    End Sub
End Class

Public Class ManaEnforce1
    Public Event ManaEnforce1Event()

    Public Sub LaunchManaEnforce1()
        RaiseEvent ManaEnforce1Event()
    End Sub
End Class

Public Class ManaEnforce2
    Public Event ManaEnforce2Event()

    Public Sub LaunchManaEnforce2()
        RaiseEvent ManaEnforce2Event()
    End Sub
End Class

