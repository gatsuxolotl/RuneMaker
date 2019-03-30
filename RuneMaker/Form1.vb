Imports System.Threading

Public Class Form1

    Declare Function apimouse_event Lib "user32.dll" Alias "mouse_event" (ByVal dwFlags As Int32, ByVal dX As Int32, ByVal dY As Int32, ByVal cButtons As Int32, ByVal dwExtraInfo As Int32) As Boolean
    Public Const MOUSEEVENTF_LEFTDOWN = &H2
    Public Const MOUSEEVENTF_LEFTUP = &H4
    Public nextInt As Integer
    Dim configPath = "C:\RuneMaker\config.txt"
    Dim stopOnSS As Boolean
    'Private Shared WithEvents myTimer As New System.Windows.Forms.Timer()

    Sub New()
        Try
            ' This call is required by the designer.
            InitializeComponent()
            stopOnSS = CheckBox1.Checked
            Dim configDir = "C:\RuneMaker\"
            If System.IO.Directory.Exists(configDir) Then

                If System.IO.File.Exists(configPath) Then
                    'The file exists
                    Dim fileReader As String
                    fileReader = My.Computer.FileSystem.ReadAllText(configPath)
                    fillvalues(fileReader)
                Else
                    'the file doesn't exist
                    System.IO.File.Create(configPath).Dispose()
                End If
            Else
                System.IO.Directory.CreateDirectory(configDir)
                System.IO.File.Create(configPath).Dispose()
            End If

            ' Add any initialization after the InitializeComponent() call.
        Catch ex As Exception

        End Try


    End Sub

    Private Sub fillvalues(fileReader As String)
        Try

            Dim configValues = fileReader.Split(New Char() {"*"c})
            TextBox1.Text = configValues(0)
            TextBox2.Text = configValues(1)
            TextBox3.Text = configValues(2)
            TextBox4.Text = configValues(3)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            'Dim bnext As Boolean = True
            'BackgroundWorker1.WorkerReportsProgress = True
            addConfigLine()
            Do
                'If stopOnSS Then
                '    If Date.Now < System.DateTime(3, 0) Then

                '    End If
                'End If

                feed()
                makeRune()
                Dim rnd As Random = New Random()
                nextInt = CInt(rnd.Next(840000, 870000))
                'BackgroundWorker1.RunWorkerAsync()
                Threading.Thread.SpinWait(nextInt)

            Loop
        Catch ex As Exception
            Dim XD = "ooopsy popsy"
        End Try

    End Sub

    'Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    '    Timer1.Enabled = True
    '    Timer1.Interval = 1000
    '    Timer1.Start()

    '    'For x As Integer = 0 To 99
    '    '    Threading.Thread.Sleep(100)
    '    '    Me.BackgroundWorker1.ReportProgress(1)
    '    'Next


    'End Sub

    Private Sub feed()
        For index As Integer = 1 To 5
            Windows.Forms.Cursor.Position = New Point(TextBox1.Text, TextBox2.Text)
            Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
            Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
            Thread.Sleep(1000)
        Next
    End Sub

    Private Sub makeRune()
        For index As Integer = 1 To 4
            Windows.Forms.Cursor.Position = New Point(TextBox3.Text, TextBox4.Text)
            Call apimouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
            Call apimouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
            Thread.Sleep(2300)
        Next
    End Sub

    'Private Sub BackgroundWorker_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

    '    Me.ProgressBar1.Value += e.ProgressPercentage

    'End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        addConfigLine()
        Windows.Forms.Cursor.Position = New Point(TextBox3.Text, TextBox4.Text)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        addConfigLine()
        Windows.Forms.Cursor.Position = New Point(TextBox1.Text, TextBox2.Text)
    End Sub

    Sub addConfigLine()
        System.IO.File.WriteAllText(configPath, String.Empty)
        Dim file As System.IO.StreamWriter
         file = My.Computer.FileSystem.OpenTextFileWriter(configPath, True)
        file.WriteLine(TextBox1.Text & "*" & TextBox2.Text & "*" & TextBox3.Text & "*" & TextBox4.Text)
        file.Close()
    End Sub

    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    Me.BackgroundWorker1.ReportProgress(1)
    'End Sub

    'Private Sub BackgroundWorker_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

    '    If e.Cancelled Then
    '        MessageBox.Show("La operación ha sido cancelada.")
    '    ElseIf e.Error IsNot Nothing Then
    '        MessageBox.Show("Se ha producido un error durante la ejecución: " & e.Error.Message)
    '    Else
    '        MessageBox.Show("La operación en segundo plano ha finalizado con éxito.")
    '    End If

    'End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub
End Class
