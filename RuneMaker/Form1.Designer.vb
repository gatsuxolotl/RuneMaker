<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.FoodCoordX = New System.Windows.Forms.TextBox()
        Me.FoodCoordY = New System.Windows.Forms.TextBox()
        Me.RuneCoordX = New System.Windows.Forms.TextBox()
        Me.RuneCoordY = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SpellCoordButton = New System.Windows.Forms.Button()
        Me.FoodCoordButton = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button4 = New System.Windows.Forms.Button()
        Me.StopAfterSS = New System.Windows.Forms.CheckBox()
        Me.ShutDawnAfterSS = New System.Windows.Forms.CheckBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RunEveryXMin = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumberOfClicksOnFood = New System.Windows.Forms.TextBox()
        Me.NumberOfClicksOnSpell = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ManaEnforceTime1 = New System.Windows.Forms.TextBox()
        Me.ManaReforceTime2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ManaEnforceCoordButton1 = New System.Windows.Forms.Button()
        Me.ManaEnforceCoordButton2 = New System.Windows.Forms.Button()
        Me.ManaEnforceCheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ManaEnforceCheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.EnforceMana1CoordY = New System.Windows.Forms.TextBox()
        Me.EnforceMana1CoordX = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.EnforceMana2CoordY = New System.Windows.Forms.TextBox()
        Me.EnforceMana2CoordX = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(533, 125)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(160, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Runear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FoodCoordX
        '
        Me.FoodCoordX.Location = New System.Drawing.Point(41, 76)
        Me.FoodCoordX.Name = "FoodCoordX"
        Me.FoodCoordX.Size = New System.Drawing.Size(100, 20)
        Me.FoodCoordX.TabIndex = 2
        '
        'FoodCoordY
        '
        Me.FoodCoordY.Location = New System.Drawing.Point(41, 102)
        Me.FoodCoordY.Name = "FoodCoordY"
        Me.FoodCoordY.Size = New System.Drawing.Size(100, 20)
        Me.FoodCoordY.TabIndex = 3
        '
        'RuneCoordX
        '
        Me.RuneCoordX.Location = New System.Drawing.Point(193, 76)
        Me.RuneCoordX.Name = "RuneCoordX"
        Me.RuneCoordX.Size = New System.Drawing.Size(100, 20)
        Me.RuneCoordX.TabIndex = 4
        '
        'RuneCoordY
        '
        Me.RuneCoordY.Location = New System.Drawing.Point(193, 102)
        Me.RuneCoordY.Name = "RuneCoordY"
        Me.RuneCoordY.Size = New System.Drawing.Size(100, 20)
        Me.RuneCoordY.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Coordenada de la comida"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(193, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Coordenada de la runa"
        '
        'SpellCoordButton
        '
        Me.SpellCoordButton.Location = New System.Drawing.Point(533, 60)
        Me.SpellCoordButton.Name = "SpellCoordButton"
        Me.SpellCoordButton.Size = New System.Drawing.Size(160, 23)
        Me.SpellCoordButton.TabIndex = 8
        Me.SpellCoordButton.Text = "Coordenada de el spell"
        Me.SpellCoordButton.UseVisualStyleBackColor = True
        '
        'FoodCoordButton
        '
        Me.FoodCoordButton.Location = New System.Drawing.Point(343, 60)
        Me.FoodCoordButton.Name = "FoodCoordButton"
        Me.FoodCoordButton.Size = New System.Drawing.Size(160, 23)
        Me.FoodCoordButton.TabIndex = 9
        Me.FoodCoordButton.Text = "Coordenada de la comida"
        Me.FoodCoordButton.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(576, 181)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 10
        Me.Button4.Text = "Stop"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'StopAfterSS
        '
        Me.StopAfterSS.AutoSize = True
        Me.StopAfterSS.Location = New System.Drawing.Point(193, 129)
        Me.StopAfterSS.Name = "StopAfterSS"
        Me.StopAfterSS.Size = New System.Drawing.Size(141, 17)
        Me.StopAfterSS.TabIndex = 11
        Me.StopAfterSS.Text = "Detener despues del SS"
        Me.StopAfterSS.UseVisualStyleBackColor = True
        '
        'ShutDawnAfterSS
        '
        Me.ShutDawnAfterSS.AutoSize = True
        Me.ShutDawnAfterSS.Location = New System.Drawing.Point(193, 152)
        Me.ShutDawnAfterSS.Name = "ShutDawnAfterSS"
        Me.ShutDawnAfterSS.Size = New System.Drawing.Size(137, 17)
        Me.ShutDawnAfterSS.TabIndex = 12
        Me.ShutDawnAfterSS.Text = "Apagar despues del SS"
        Me.ShutDawnAfterSS.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 12)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(699, 23)
        Me.ProgressBar1.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Correr cada X minutos"
        '
        'RunEveryXMin
        '
        Me.RunEveryXMin.Location = New System.Drawing.Point(41, 145)
        Me.RunEveryXMin.Name = "RunEveryXMin"
        Me.RunEveryXMin.Size = New System.Drawing.Size(100, 20)
        Me.RunEveryXMin.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Numero de clicks en comida"
        '
        'NumberOfClicksOnFood
        '
        Me.NumberOfClicksOnFood.Location = New System.Drawing.Point(41, 186)
        Me.NumberOfClicksOnFood.Name = "NumberOfClicksOnFood"
        Me.NumberOfClicksOnFood.Size = New System.Drawing.Size(100, 20)
        Me.NumberOfClicksOnFood.TabIndex = 17
        '
        'NumberOfClicksOnSpell
        '
        Me.NumberOfClicksOnSpell.Location = New System.Drawing.Point(196, 186)
        Me.NumberOfClicksOnSpell.Name = "NumberOfClicksOnSpell"
        Me.NumberOfClicksOnSpell.Size = New System.Drawing.Size(100, 20)
        Me.NumberOfClicksOnSpell.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(193, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Numero de clicks en spell"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(38, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(265, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Tiempo en minutos para cambiar el refuerzo de mana 1"
        '
        'ManaEnforceTime1
        '
        Me.ManaEnforceTime1.Location = New System.Drawing.Point(44, 248)
        Me.ManaEnforceTime1.Name = "ManaEnforceTime1"
        Me.ManaEnforceTime1.Size = New System.Drawing.Size(100, 20)
        Me.ManaEnforceTime1.TabIndex = 21
        '
        'ManaReforceTime2
        '
        Me.ManaReforceTime2.Location = New System.Drawing.Point(343, 248)
        Me.ManaReforceTime2.Name = "ManaReforceTime2"
        Me.ManaReforceTime2.Size = New System.Drawing.Size(100, 20)
        Me.ManaReforceTime2.TabIndex = 22
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(340, 232)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(265, 13)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Tiempo en minutos para cambiar el refuerzo de mana 2"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 79)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(14, 13)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "X"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(21, 105)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(14, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Y"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(173, 105)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(14, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Y"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(173, 79)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(14, 13)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "X"
        '
        'ManaEnforceCoordButton1
        '
        Me.ManaEnforceCoordButton1.Location = New System.Drawing.Point(343, 92)
        Me.ManaEnforceCoordButton1.Name = "ManaEnforceCoordButton1"
        Me.ManaEnforceCoordButton1.Size = New System.Drawing.Size(160, 23)
        Me.ManaEnforceCoordButton1.TabIndex = 28
        Me.ManaEnforceCoordButton1.Text = "Coordenada refuerzo mana 1"
        Me.ManaEnforceCoordButton1.UseVisualStyleBackColor = True
        '
        'ManaEnforceCoordButton2
        '
        Me.ManaEnforceCoordButton2.Location = New System.Drawing.Point(533, 92)
        Me.ManaEnforceCoordButton2.Name = "ManaEnforceCoordButton2"
        Me.ManaEnforceCoordButton2.Size = New System.Drawing.Size(160, 23)
        Me.ManaEnforceCoordButton2.TabIndex = 29
        Me.ManaEnforceCoordButton2.Text = "Coordenada refuerzo mana 2"
        Me.ManaEnforceCoordButton2.UseVisualStyleBackColor = True
        '
        'ManaEnforceCheckBox1
        '
        Me.ManaEnforceCheckBox1.AutoSize = True
        Me.ManaEnforceCheckBox1.Location = New System.Drawing.Point(40, 212)
        Me.ManaEnforceCheckBox1.Name = "ManaEnforceCheckBox1"
        Me.ManaEnforceCheckBox1.Size = New System.Drawing.Size(139, 17)
        Me.ManaEnforceCheckBox1.TabIndex = 30
        Me.ManaEnforceCheckBox1.Text = "Usar refuerzo de mana1"
        Me.ManaEnforceCheckBox1.UseVisualStyleBackColor = True
        '
        'ManaEnforceCheckBox2
        '
        Me.ManaEnforceCheckBox2.AutoSize = True
        Me.ManaEnforceCheckBox2.Location = New System.Drawing.Point(343, 212)
        Me.ManaEnforceCheckBox2.Name = "ManaEnforceCheckBox2"
        Me.ManaEnforceCheckBox2.Size = New System.Drawing.Size(139, 17)
        Me.ManaEnforceCheckBox2.TabIndex = 31
        Me.ManaEnforceCheckBox2.Text = "Usar refuerzo de mana2"
        Me.ManaEnforceCheckBox2.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(24, 316)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(14, 13)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "Y"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(24, 290)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(14, 13)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "X"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(38, 270)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(176, 13)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Coordenada del refuerzo de mana 1"
        '
        'EnforceMana1CoordY
        '
        Me.EnforceMana1CoordY.Location = New System.Drawing.Point(44, 313)
        Me.EnforceMana1CoordY.Name = "EnforceMana1CoordY"
        Me.EnforceMana1CoordY.Size = New System.Drawing.Size(100, 20)
        Me.EnforceMana1CoordY.TabIndex = 33
        '
        'EnforceMana1CoordX
        '
        Me.EnforceMana1CoordX.Location = New System.Drawing.Point(44, 287)
        Me.EnforceMana1CoordX.Name = "EnforceMana1CoordX"
        Me.EnforceMana1CoordX.Size = New System.Drawing.Size(100, 20)
        Me.EnforceMana1CoordX.TabIndex = 32
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(323, 319)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(14, 13)
        Me.Label15.TabIndex = 41
        Me.Label15.Text = "Y"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(323, 293)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(14, 13)
        Me.Label16.TabIndex = 40
        Me.Label16.Text = "X"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(337, 273)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(176, 13)
        Me.Label17.TabIndex = 39
        Me.Label17.Text = "Coordenada del refuerzo de mana 2"
        '
        'EnforceMana2CoordY
        '
        Me.EnforceMana2CoordY.Location = New System.Drawing.Point(343, 316)
        Me.EnforceMana2CoordY.Name = "EnforceMana2CoordY"
        Me.EnforceMana2CoordY.Size = New System.Drawing.Size(100, 20)
        Me.EnforceMana2CoordY.TabIndex = 38
        '
        'EnforceMana2CoordX
        '
        Me.EnforceMana2CoordX.Location = New System.Drawing.Point(343, 290)
        Me.EnforceMana2CoordX.Name = "EnforceMana2CoordX"
        Me.EnforceMana2CoordX.Size = New System.Drawing.Size(100, 20)
        Me.EnforceMana2CoordX.TabIndex = 37
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 384)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.EnforceMana2CoordY)
        Me.Controls.Add(Me.EnforceMana2CoordX)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.EnforceMana1CoordY)
        Me.Controls.Add(Me.EnforceMana1CoordX)
        Me.Controls.Add(Me.ManaEnforceCheckBox2)
        Me.Controls.Add(Me.ManaEnforceCheckBox1)
        Me.Controls.Add(Me.ManaEnforceCoordButton2)
        Me.Controls.Add(Me.ManaEnforceCoordButton1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ManaReforceTime2)
        Me.Controls.Add(Me.ManaEnforceTime1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.NumberOfClicksOnSpell)
        Me.Controls.Add(Me.NumberOfClicksOnFood)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.RunEveryXMin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ShutDawnAfterSS)
        Me.Controls.Add(Me.StopAfterSS)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.FoodCoordButton)
        Me.Controls.Add(Me.SpellCoordButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RuneCoordY)
        Me.Controls.Add(Me.RuneCoordX)
        Me.Controls.Add(Me.FoodCoordY)
        Me.Controls.Add(Me.FoodCoordX)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "RuneMaker"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button1 As Button
    Friend WithEvents FoodCoordX As TextBox
    Friend WithEvents FoodCoordY As TextBox
    Friend WithEvents RuneCoordX As TextBox
    Friend WithEvents RuneCoordY As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents SpellCoordButton As Button
    Friend WithEvents FoodCoordButton As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Button4 As Button
    Friend WithEvents StopAfterSS As CheckBox
    Friend WithEvents ShutDawnAfterSS As CheckBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label3 As Label
    Friend WithEvents RunEveryXMin As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents NumberOfClicksOnFood As TextBox
    Friend WithEvents NumberOfClicksOnSpell As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ManaEnforceTime1 As TextBox
    Friend WithEvents ManaReforceTime2 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents ManaEnforceCoordButton1 As Button
    Friend WithEvents ManaEnforceCoordButton2 As Button
    Friend WithEvents ManaEnforceCheckBox1 As CheckBox
    Friend WithEvents ManaEnforceCheckBox2 As CheckBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents EnforceMana1CoordY As TextBox
    Friend WithEvents EnforceMana1CoordX As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents EnforceMana2CoordY As TextBox
    Friend WithEvents EnforceMana2CoordX As TextBox
End Class
