<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ControlValue = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Choose1 = New System.Windows.Forms.Button()
        Me.ControlBackColor = New System.Windows.Forms.TextBox()
        Me.HideOffSegments = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ControlSegmentsOnColor = New System.Windows.Forms.TextBox()
        Me.ControlSegmentsOffColor = New System.Windows.Forms.TextBox()
        Me.Choose2 = New System.Windows.Forms.Button()
        Me.Choose3 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Digits = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SevenSegmentsDisplay1 = New SevenSegDisplay.SevenSegmentsDisplay()
        CType(Me.ControlValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Digits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ControlValue
        '
        Me.ControlValue.Location = New System.Drawing.Point(221, 19)
        Me.ControlValue.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.ControlValue.Name = "ControlValue"
        Me.ControlValue.Size = New System.Drawing.Size(52, 20)
        Me.ControlValue.TabIndex = 1
        Me.ControlValue.Value = New Decimal(New Integer() {42, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(128, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Value to display :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(80, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Background color :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Activated segments color :"
        '
        'ColorDialog1
        '
        Me.ColorDialog1.AnyColor = True
        '
        'Choose1
        '
        Me.Choose1.Location = New System.Drawing.Point(309, 46)
        Me.Choose1.Name = "Choose1"
        Me.Choose1.Size = New System.Drawing.Size(59, 21)
        Me.Choose1.TabIndex = 4
        Me.Choose1.Text = "Choose..."
        Me.Choose1.UseVisualStyleBackColor = True
        '
        'ControlBackColor
        '
        Me.ControlBackColor.Location = New System.Drawing.Point(183, 47)
        Me.ControlBackColor.Name = "ControlBackColor"
        Me.ControlBackColor.ReadOnly = True
        Me.ControlBackColor.Size = New System.Drawing.Size(120, 20)
        Me.ControlBackColor.TabIndex = 3
        '
        'HideOffSegments
        '
        Me.HideOffSegments.AutoSize = True
        Me.HideOffSegments.Location = New System.Drawing.Point(38, 127)
        Me.HideOffSegments.Name = "HideOffSegments"
        Me.HideOffSegments.Size = New System.Drawing.Size(155, 17)
        Me.HideOffSegments.TabIndex = 11
        Me.HideOffSegments.Text = "Hide deactivated segments"
        Me.HideOffSegments.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(145, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Deactivated segments color :"
        '
        'ControlSegmentsOnColor
        '
        Me.ControlSegmentsOnColor.Location = New System.Drawing.Point(183, 73)
        Me.ControlSegmentsOnColor.Name = "ControlSegmentsOnColor"
        Me.ControlSegmentsOnColor.ReadOnly = True
        Me.ControlSegmentsOnColor.Size = New System.Drawing.Size(120, 20)
        Me.ControlSegmentsOnColor.TabIndex = 6
        '
        'ControlSegmentsOffColor
        '
        Me.ControlSegmentsOffColor.Location = New System.Drawing.Point(183, 98)
        Me.ControlSegmentsOffColor.Name = "ControlSegmentsOffColor"
        Me.ControlSegmentsOffColor.ReadOnly = True
        Me.ControlSegmentsOffColor.Size = New System.Drawing.Size(120, 20)
        Me.ControlSegmentsOffColor.TabIndex = 9
        '
        'Choose2
        '
        Me.Choose2.Location = New System.Drawing.Point(309, 72)
        Me.Choose2.Name = "Choose2"
        Me.Choose2.Size = New System.Drawing.Size(59, 21)
        Me.Choose2.TabIndex = 7
        Me.Choose2.Text = "Choose..."
        Me.Choose2.UseVisualStyleBackColor = True
        '
        'Choose3
        '
        Me.Choose3.Location = New System.Drawing.Point(309, 97)
        Me.Choose3.Name = "Choose3"
        Me.Choose3.Size = New System.Drawing.Size(59, 21)
        Me.Choose3.TabIndex = 10
        Me.Choose3.Text = "Choose..."
        Me.Choose3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.HideOffSegments)
        Me.GroupBox1.Controls.Add(Me.ControlSegmentsOffColor)
        Me.GroupBox1.Controls.Add(Me.Digits)
        Me.GroupBox1.Controls.Add(Me.ControlValue)
        Me.GroupBox1.Controls.Add(Me.ControlSegmentsOnColor)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ControlBackColor)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Choose3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Choose2)
        Me.GroupBox1.Controls.Add(Me.Choose1)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 158)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Properties"
        '
        'Digits
        '
        Me.Digits.Location = New System.Drawing.Point(329, 126)
        Me.Digits.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.Digits.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Digits.Name = "Digits"
        Me.Digits.Size = New System.Drawing.Size(33, 20)
        Me.Digits.TabIndex = 13
        Me.Digits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Digits.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(234, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Number of digits :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.SevenSegmentsDisplay1)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 170)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(400, 174)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Viewer"
        '
        'SevenSegmentsDisplay1
        '
        Me.SevenSegmentsDisplay1.BackColor = System.Drawing.Color.Black
        Me.SevenSegmentsDisplay1.Digits = 4
        Me.SevenSegmentsDisplay1.HideOffSegments = False
        Me.SevenSegmentsDisplay1.Location = New System.Drawing.Point(43, 26)
        Me.SevenSegmentsDisplay1.Name = "SevenSegmentsDisplay1"
        Me.SevenSegmentsDisplay1.SegmentOffColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.SevenSegmentsDisplay1.SegmentOnColor = System.Drawing.Color.Red
        Me.SevenSegmentsDisplay1.Size = New System.Drawing.Size(314, 132)
        Me.SevenSegmentsDisplay1.TabIndex = 0
        Me.SevenSegmentsDisplay1.Value = 42
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 356)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Demo - Using the control"
        CType(Me.ControlValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Digits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ControlValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents Choose1 As System.Windows.Forms.Button
    Friend WithEvents ControlBackColor As System.Windows.Forms.TextBox
    Friend WithEvents HideOffSegments As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ControlSegmentsOnColor As System.Windows.Forms.TextBox
    Friend WithEvents ControlSegmentsOffColor As System.Windows.Forms.TextBox
    Friend WithEvents Choose2 As System.Windows.Forms.Button
    Friend WithEvents Choose3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Digits As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SevenSegmentsDisplay1 As SevenSegDisplay.SevenSegmentsDisplay

End Class
