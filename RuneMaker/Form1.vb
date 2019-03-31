Imports System.Threading

Public Class Form1

    Declare Function apimouse_event Lib "user32.dll" Alias "mouse_event" (ByVal dwFlags As Int32, ByVal dX As Int32, ByVal dY As Int32, ByVal cButtons As Int32, ByVal dwExtraInfo As Int32) As Boolean
    Public Const MOUSEEVENTF_LEFTDOWN = &H2
    Public Const MOUSEEVENTF_LEFTUP = &H4
    Public nextInt As Integer
    Dim configPath = "C:\RuneMaker\config.txt"
    Dim startDate As Date = Date.Now

    Sub New()
        Try
            InitializeComponent()
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
                Dim rnd As Random = New Random()
                nextInt = CInt(rnd.Next(840000, 870000))
                Thread.Sleep(nextInt)
            Loop
        Catch ex As Exception
            Dim XD = "ooopsy popsy"
        End Try
    End Sub


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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub
End Class
