Imports System.Runtime.CompilerServices
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

<Designer(GetType(Designer)), ToolboxBitmap(GetType(SevenSegmentsDisplay), "ControlIcon.ico")> _
Public Class SevenSegmentsDisplay
    'Inherits a empty UserControl.
    Inherits System.Windows.Forms.UserControl

    'Declares a few variables.
    Private _segmentOnColor, _segmentOffColor As Color
    Private _hideOffSegments As Boolean
    Private _borderStyle As BorderStyle
    Private _digits, _value As Integer
    Public _lockSize As Boolean = True
    Public Loaded As Boolean = False
    Private OldDigits As Integer

    Sub New()
        'Initializes the control.
        InitializeComponent()

        'Assigns values to variables.
        SegmentOffColor = Color.FromArgb(20, 20, 20)
        SegmentOnColor = Color.Red
        BackColor = Color.Black
        HideOffSegments = False
        Digits = 2
        Value = 42
    End Sub

    'Place values enumeration.
    Enum DigitType
        Units
        Tens
        Hundreds
        Thousands
    End Enum

    'Defines Loaded to True when the control is loaded. Avoids some bugs.
    Private Sub Me_Load() Handles Me.Load
        Loaded = True
    End Sub

    'Sets the control's size to see (or not) different digits.
    Private Sub SetSize()

        '74 pixels is the first digit width, and we add the number of digits - 1 (zero-based) * 80.
        'Illusatration :  - If 1 digit has to be displayed    --> 74 + (1 - 1) * 80 = 74
        '                 - Si 2 digits have to be displayed  --> 74 + (2 - 1) * 80 = 154
        '                 - Si 3 digits have to be displayed  --> 74 + (3 - 1) * 80 = 234
        '                 - Si 4 digits have to be displayed  --> 74 + (4 - 1) * 80 = 314
        Me.Size = New Size(74 + Digits.ZeroBased * 80, 132)

        'Executes following action only if the control is loaded.
        If Loaded Then

            ''Example 1 :
            '
            'Me.Location.X == 100
            'OldDigits = 2
            '_digits = 4
            '--> We go from 2 to 4 displayed digits : shift to the left.
            'Me.Location.X = 100 + (2 - 4) * 20 = 100 + (-2) * 20 = 60

            ''Example 2 :
            '
            'Me.Location.X == 100
            'OldDigits = 3
            '_digits = 1
            '--> We go from 3 to 1 displayed digit : shift to the right.
            'Me.Location.X = 100 + (3 - 1) * 20 = 100 + 2 * 20 = 140
            Me.Location = New Point(Me.Location.X + (OldDigits - _digits) * 40, Me.Location.Y)
        End If
    End Sub

    'If HideOffSegments is True,
    'then we change all segment's Backcolor property to given color,
    'else we take care to change only the activated segments color.
    Private Sub ChangeSegmentsOnColor(Color As Color)
        If HideOffSegments Then
            For Each Control In Me.Controls
                If Control.GetType() Is GetType(Panel) Then
                    CType(Control, Panel).BackColor = Color
                End If
            Next
        Else
            For Each Control In Me.Controls
                If Control.GetType() Is GetType(Panel) Then
                    Dim CurrentPanel As Panel = CType(Control, Panel)
                    If Not CurrentPanel.BackColor = _segmentOffColor Then
                        CurrentPanel.BackColor = Color
                    End If
                End If
            Next
        End If
    End Sub

    'Changes all segments' BackColor property.
    Private Sub ChangeSegmentsOffColor(Color As Color)
        For Each Control In Me.Controls
            If Control.GetType() Is GetType(Panel) Then
                CType(Control, Panel).BackColor = Color
            End If
        Next
    End Sub

    'Returns a formatted string of Value in the form "01" (not "1") according to the number of digits.
    Private Function FormatInteger(Value As Integer) As String
        Select Case _digits
            Case 1
                Return Format(Val(Value), "0")
            Case 2
                Return Format(Val(Value), "00")
            Case 3
                Return Format(Val(Value), "000")
            Case 4
                Return Format(Val(Value), "0000")
            Case Else
                Return Value
        End Select
    End Function

    'We verify whether Value is between 0 and 9 (or 99, 999, 9999, according to the number of digits).
    Private Sub SetValueProperty(Value As Integer)
        Select Case _digits
            Case 1
                _value = VerifyMinMax(Value, 0, 9)
            Case 2
                _value = VerifyMinMax(Value, 0, 99)
            Case 3
                _value = VerifyMinMax(Value, 0, 999)
            Case 4
                _value = VerifyMinMax(Value, 0, 9999)
        End Select
    End Sub

    'Verify whether Value is between MinValue and MaxValue then returns Value. Else returns a corrected value.
    Private Function VerifyMinMax(Value As Integer, MinValue As Integer, MaxValue As Integer) As Integer
        If Value < MinValue Then
            Return MinValue
        ElseIf Value > MaxValue Then
            Return MaxValue
        Else
            Return Value
        End If
    End Function

    'Set all segments' BorderStyle property.
    Private Sub SetBorderStyle(BorderStyle As BorderStyle)
        For Each Control In Me.Controls
            If Control.GetType() Is GetType(Panel) Then
                CType(Control, Panel).BorderStyle = BorderStyle
            End If
        Next
    End Sub

#Region " Events "

    Public Event SegmentsOffColorChanged As EventHandler
    Public Event SegmentsOnColorChanged As EventHandler
    Public Event HideOffSegmentsChanged As EventHandler
    Public Event BorderStyleChanged As EventHandler
    Public Event DigitsChanged As EventHandler
    Public Event ValueChanged As EventHandler

#End Region

#Region " Properties "

    <RefreshProperties(RefreshProperties.All)> <Description("Determines the number of digits displayed by the control."), Category("Appearence")> _
    Public Property Digits As Integer
        Get
            Return _digits
        End Get
        Set(digits As Integer)
            'We store the old value of Digits before changing it, to be able to move the control (See after).
            OldDigits = _digits

            'We set the new value to Digits (while checking it's between 1 and 4).
            _digits = VerifyMinMax(digits, 1, 4)

            'We update the displayed value while checking it's in the wanted frame, considering the new number of digits.
            SetValueProperty(Value)

            'We update the segments to display Value.
            ChangeValue()

            'We set the control's size.
            SetSize()

            'We raise DigitsChanged event., only if the control is loaded.
            If Loaded Then
                RaiseEvent DigitsChanged(Me, EventArgs.Empty)
            End If
        End Set
    End Property

    <Description("Indicates the segments' border style of the control."), Category("Appearence")> Public Overloads Property BorderStyle As BorderStyle
        Get
            Return _borderStyle
        End Get
        Set(value As BorderStyle)
            'We assign the new value to the property.
            _borderStyle = value

            'We set all segments' BorderStyle property.
            SetBorderStyle(value)

            'We raise BorderStyleChanged event., only if the control is loaded.
            If Loaded Then
                RaiseEvent BorderStyleChanged(Me, EventArgs.Empty)
            End If
        End Set
    End Property

    <Description("The displayed value on the control."), Category("Appearence")> Public Property Value As Integer
        Get
            Return _value
        End Get
        Set(value As Integer)
            'We update Value while checking it's in the framing.
            SetValueProperty(value)

            'We update the segments to display Value.
            ChangeValue()

            'We raise ValueChanged event., only if the control is loaded.
            If Loaded Then
                RaiseEvent ValueChanged(Me, EventArgs.Empty)
            End If
        End Set
    End Property

    <Description("Determines whether deactivated segments are hidden or not."), Category("Appearence")> Public Property HideOffSegments As Boolean
        Get
            Return _hideOffSegments
        End Get
        Set(value As Boolean)
            'We assign the new value to the property.
            _hideOffSegments = value

            'We update the segments to display Value.
            ChangeValue()

            'We raise HideOffSegmentsChanged event., only if the control is loaded.
            If Loaded Then
                RaiseEvent HideOffSegmentsChanged(Me, EventArgs.Empty)
            End If
        End Set
    End Property

    <Description("The activated segments' color of the control."), Category("Appearence")> Public Property SegmentOnColor As Color
        Get
            Return _segmentOnColor
        End Get
        Set(value As Color)
            'We assign the new value to the property.
            _segmentOnColor = value

            'We change activated segments' color.
            ChangeSegmentsOnColor(value)

            'We raise SegmentsOnColorChanged event., only if the control is loaded.
            If Loaded Then
                RaiseEvent SegmentsOnColorChanged(Me, EventArgs.Empty)
            End If
        End Set
    End Property

    <Description("The deactivated segments' color of the control."), Category("Appearence")> Public Property SegmentOffColor As Color
        Get
            Return _segmentOffColor
        End Get
        Set(value As Color)
            'We assign the new value to the property.
            _segmentOffColor = value

            'We change deactivated segments' color.
            ChangeSegmentsOffColor(value)

            'We update the segments to display Value.
            ChangeValue()

            'We raise SegmentsOffColorChanged event, only if the control is loaded.
            If Loaded Then
                RaiseEvent SegmentsOffColorChanged(Me, EventArgs.Empty)
            End If
        End Set
    End Property

    'Prevents resizing control in the designer.
    <DefaultValue(True)> Public ReadOnly Property LockSize() As Boolean
        Get
            Return _lockSize
        End Get
    End Property

#End Region

    'Sets color to a segment (Panel) and shows it (or not).
    Private Sub ShowSegment(Segment As Panel, Show As Boolean)
        If Show Then
            Segment.BackColor = SegmentOnColor
            Segment.Visible = Show
        Else
            If HideOffSegments Then
                Segment.BackColor = SegmentOnColor
                Segment.Visible = Show
            Else
                Segment.BackColor = SegmentOffColor
                Segment.Visible = Not Show
            End If
        End If
    End Sub

    Private Sub ChangeValue()
        'We declare a variable containing the formatted Value.
        Dim Numbers As String = FormatInteger(_value)

        'Loop flying over Numbers digit by digit.
        For i = 0 To Numbers.Length.ZeroBased

            'Condition that checks what number is the current digit, and calls the corresponding method to show the digit by activating this or that segment.
            'We pass the digit's index as argument to then convert it to "DigitType" (an enum).
            Select Case Val(Numbers(i))
                Case 0
                    Show0(i)
                Case 1
                    Show1(i)
                Case 2
                    Show2(i)
                Case 3
                    Show3(i)
                Case 4
                    Show4(i)
                Case 5
                    Show5(i)
                Case 6
                    Show6(i)
                Case 7
                    Show7(i)
                Case 8
                    Show8(i)
                Case 9
                    Show9(i)
            End Select
        Next
    End Sub

#Region " ShowNumbers "

    'A bit repetitive, but I didn't find any other way to do it! :D
    Private Sub Show0(DigitTypeInt As Integer)
        Dim DigitType As DigitType = CType(DigitTypeInt, DigitType)
        Select Case DigitType
            Case SevenSegmentsDisplay.DigitType.Units
                ShowSegment(Segment1_1, True)
                ShowSegment(Segment1_2, True)
                ShowSegment(Segment1_3, True)
                ShowSegment(Segment1_4, False)
                ShowSegment(Segment1_5, True)
                ShowSegment(Segment1_6, True)
                ShowSegment(Segment1_7, True)
            Case SevenSegmentsDisplay.DigitType.Tens
                ShowSegment(Segment2_1, True)
                ShowSegment(Segment2_2, True)
                ShowSegment(Segment2_3, True)
                ShowSegment(Segment2_4, False)
                ShowSegment(Segment2_5, True)
                ShowSegment(Segment2_6, True)
                ShowSegment(Segment2_7, True)
            Case SevenSegmentsDisplay.DigitType.Hundreds
                ShowSegment(Segment3_1, True)
                ShowSegment(Segment3_2, True)
                ShowSegment(Segment3_3, True)
                ShowSegment(Segment3_4, False)
                ShowSegment(Segment3_5, True)
                ShowSegment(Segment3_6, True)
                ShowSegment(Segment3_7, True)
            Case SevenSegmentsDisplay.DigitType.Thousands
                ShowSegment(Segment4_1, True)
                ShowSegment(Segment4_2, True)
                ShowSegment(Segment4_3, True)
                ShowSegment(Segment4_4, False)
                ShowSegment(Segment4_5, True)
                ShowSegment(Segment4_6, True)
                ShowSegment(Segment4_7, True)
        End Select
    End Sub

    Private Sub Show1(DigitTypeInt As Integer)
        Dim DigitType As DigitType = CType(DigitTypeInt, DigitType)
        Select Case DigitType
            Case SevenSegmentsDisplay.DigitType.Units
                ShowSegment(Segment1_1, False)
                ShowSegment(Segment1_2, False)
                ShowSegment(Segment1_3, True)
                ShowSegment(Segment1_4, False)
                ShowSegment(Segment1_5, False)
                ShowSegment(Segment1_6, True)
                ShowSegment(Segment1_7, False)
            Case SevenSegmentsDisplay.DigitType.Tens
                ShowSegment(Segment2_1, False)
                ShowSegment(Segment2_2, False)
                ShowSegment(Segment2_3, True)
                ShowSegment(Segment2_4, False)
                ShowSegment(Segment2_5, False)
                ShowSegment(Segment2_6, True)
                ShowSegment(Segment2_7, False)
            Case SevenSegmentsDisplay.DigitType.Hundreds
                ShowSegment(Segment3_1, False)
                ShowSegment(Segment3_2, False)
                ShowSegment(Segment3_3, True)
                ShowSegment(Segment3_4, False)
                ShowSegment(Segment3_5, False)
                ShowSegment(Segment3_6, True)
                ShowSegment(Segment3_7, False)
            Case SevenSegmentsDisplay.DigitType.Thousands
                ShowSegment(Segment4_1, False)
                ShowSegment(Segment4_2, False)
                ShowSegment(Segment4_3, True)
                ShowSegment(Segment4_4, False)
                ShowSegment(Segment4_5, False)
                ShowSegment(Segment4_6, True)
                ShowSegment(Segment4_7, False)
        End Select
    End Sub

    Private Sub Show2(DigitTypeInt As Integer)
        Dim DigitType As DigitType = CType(DigitTypeInt, DigitType)
        Select Case DigitType
            Case SevenSegmentsDisplay.DigitType.Units
                ShowSegment(Segment1_1, True)
                ShowSegment(Segment1_2, False)
                ShowSegment(Segment1_3, True)
                ShowSegment(Segment1_4, True)
                ShowSegment(Segment1_5, True)
                ShowSegment(Segment1_6, False)
                ShowSegment(Segment1_7, True)
            Case SevenSegmentsDisplay.DigitType.Tens
                ShowSegment(Segment2_1, True)
                ShowSegment(Segment2_2, False)
                ShowSegment(Segment2_3, True)
                ShowSegment(Segment2_4, True)
                ShowSegment(Segment2_5, True)
                ShowSegment(Segment2_6, False)
                ShowSegment(Segment2_7, True)
            Case SevenSegmentsDisplay.DigitType.Hundreds
                ShowSegment(Segment3_1, True)
                ShowSegment(Segment3_2, False)
                ShowSegment(Segment3_3, True)
                ShowSegment(Segment3_4, True)
                ShowSegment(Segment3_5, True)
                ShowSegment(Segment3_6, False)
                ShowSegment(Segment3_7, True)
            Case SevenSegmentsDisplay.DigitType.Thousands
                ShowSegment(Segment4_1, True)
                ShowSegment(Segment4_2, False)
                ShowSegment(Segment4_3, True)
                ShowSegment(Segment4_4, True)
                ShowSegment(Segment4_5, True)
                ShowSegment(Segment4_6, False)
                ShowSegment(Segment4_7, True)
        End Select
    End Sub

    Private Sub Show3(DigitTypeInt As Integer)
        Dim DigitType As DigitType = CType(DigitTypeInt, DigitType)
        Select Case DigitType
            Case SevenSegmentsDisplay.DigitType.Units
                ShowSegment(Segment1_1, True)
                ShowSegment(Segment1_2, False)
                ShowSegment(Segment1_3, True)
                ShowSegment(Segment1_4, True)
                ShowSegment(Segment1_5, False)
                ShowSegment(Segment1_6, True)
                ShowSegment(Segment1_7, True)
            Case SevenSegmentsDisplay.DigitType.Tens
                ShowSegment(Segment2_1, True)
                ShowSegment(Segment2_2, False)
                ShowSegment(Segment2_3, True)
                ShowSegment(Segment2_4, True)
                ShowSegment(Segment2_5, False)
                ShowSegment(Segment2_6, True)
                ShowSegment(Segment2_7, True)
            Case SevenSegmentsDisplay.DigitType.Hundreds
                ShowSegment(Segment3_1, True)
                ShowSegment(Segment3_2, False)
                ShowSegment(Segment3_3, True)
                ShowSegment(Segment3_4, True)
                ShowSegment(Segment3_5, False)
                ShowSegment(Segment3_6, True)
                ShowSegment(Segment3_7, True)
            Case SevenSegmentsDisplay.DigitType.Thousands
                ShowSegment(Segment4_1, True)
                ShowSegment(Segment4_2, False)
                ShowSegment(Segment4_3, True)
                ShowSegment(Segment4_4, True)
                ShowSegment(Segment4_5, False)
                ShowSegment(Segment4_6, True)
                ShowSegment(Segment4_7, True)
        End Select
    End Sub

    Private Sub Show4(DigitTypeInt As Integer)
        Dim DigitType As DigitType = CType(DigitTypeInt, DigitType)
        Select Case DigitType
            Case SevenSegmentsDisplay.DigitType.Units
                ShowSegment(Segment1_1, False)
                ShowSegment(Segment1_2, True)
                ShowSegment(Segment1_3, True)
                ShowSegment(Segment1_4, True)
                ShowSegment(Segment1_5, False)
                ShowSegment(Segment1_6, True)
                ShowSegment(Segment1_7, False)
            Case SevenSegmentsDisplay.DigitType.Tens
                ShowSegment(Segment2_1, False)
                ShowSegment(Segment2_2, True)
                ShowSegment(Segment2_3, True)
                ShowSegment(Segment2_4, True)
                ShowSegment(Segment2_5, False)
                ShowSegment(Segment2_6, True)
                ShowSegment(Segment2_7, False)
            Case SevenSegmentsDisplay.DigitType.Hundreds
                ShowSegment(Segment3_1, False)
                ShowSegment(Segment3_2, True)
                ShowSegment(Segment3_3, True)
                ShowSegment(Segment3_4, True)
                ShowSegment(Segment3_5, False)
                ShowSegment(Segment3_6, True)
                ShowSegment(Segment3_7, False)
            Case SevenSegmentsDisplay.DigitType.Thousands
                ShowSegment(Segment4_1, False)
                ShowSegment(Segment4_2, True)
                ShowSegment(Segment4_3, True)
                ShowSegment(Segment4_4, True)
                ShowSegment(Segment4_5, False)
                ShowSegment(Segment4_6, True)
                ShowSegment(Segment4_7, False)
        End Select
    End Sub

    Private Sub Show5(DigitTypeInt As Integer)
        Dim DigitType As DigitType = CType(DigitTypeInt, DigitType)
        Select Case DigitType
            Case SevenSegmentsDisplay.DigitType.Units
                ShowSegment(Segment1_1, True)
                ShowSegment(Segment1_2, True)
                ShowSegment(Segment1_3, False)
                ShowSegment(Segment1_4, True)
                ShowSegment(Segment1_5, False)
                ShowSegment(Segment1_6, True)
                ShowSegment(Segment1_7, True)
            Case SevenSegmentsDisplay.DigitType.Tens
                ShowSegment(Segment2_1, True)
                ShowSegment(Segment2_2, True)
                ShowSegment(Segment2_3, False)
                ShowSegment(Segment2_4, True)
                ShowSegment(Segment2_5, False)
                ShowSegment(Segment2_6, True)
                ShowSegment(Segment2_7, True)
            Case SevenSegmentsDisplay.DigitType.Hundreds
                ShowSegment(Segment3_1, True)
                ShowSegment(Segment3_2, True)
                ShowSegment(Segment3_3, False)
                ShowSegment(Segment3_4, True)
                ShowSegment(Segment3_5, False)
                ShowSegment(Segment3_6, True)
                ShowSegment(Segment3_7, True)
            Case SevenSegmentsDisplay.DigitType.Thousands
                ShowSegment(Segment4_1, True)
                ShowSegment(Segment4_2, True)
                ShowSegment(Segment4_3, False)
                ShowSegment(Segment4_4, True)
                ShowSegment(Segment4_5, False)
                ShowSegment(Segment4_6, True)
                ShowSegment(Segment4_7, True)
        End Select
    End Sub

    Private Sub Show6(DigitTypeInt As Integer)
        Dim DigitType As DigitType = CType(DigitTypeInt, DigitType)
        Select Case DigitType
            Case SevenSegmentsDisplay.DigitType.Units
                ShowSegment(Segment1_1, True)
                ShowSegment(Segment1_2, True)
                ShowSegment(Segment1_3, False)
                ShowSegment(Segment1_4, True)
                ShowSegment(Segment1_5, True)
                ShowSegment(Segment1_6, True)
                ShowSegment(Segment1_7, True)
            Case SevenSegmentsDisplay.DigitType.Tens
                ShowSegment(Segment2_1, True)
                ShowSegment(Segment2_2, True)
                ShowSegment(Segment2_3, False)
                ShowSegment(Segment2_4, True)
                ShowSegment(Segment2_5, True)
                ShowSegment(Segment2_6, True)
                ShowSegment(Segment2_7, True)
            Case SevenSegmentsDisplay.DigitType.Hundreds
                ShowSegment(Segment3_1, True)
                ShowSegment(Segment3_2, True)
                ShowSegment(Segment3_3, False)
                ShowSegment(Segment3_4, True)
                ShowSegment(Segment3_5, True)
                ShowSegment(Segment3_6, True)
                ShowSegment(Segment3_7, True)
            Case SevenSegmentsDisplay.DigitType.Thousands
                ShowSegment(Segment4_1, True)
                ShowSegment(Segment4_2, True)
                ShowSegment(Segment4_3, False)
                ShowSegment(Segment4_4, True)
                ShowSegment(Segment4_5, True)
                ShowSegment(Segment4_6, True)
                ShowSegment(Segment4_7, True)
        End Select
    End Sub

    Private Sub Show7(DigitTypeInt As Integer)
        Dim DigitType As DigitType = CType(DigitTypeInt, DigitType)
        Select Case DigitType
            Case SevenSegmentsDisplay.DigitType.Units
                ShowSegment(Segment1_1, True)
                ShowSegment(Segment1_2, False)
                ShowSegment(Segment1_3, True)
                ShowSegment(Segment1_4, False)
                ShowSegment(Segment1_5, False)
                ShowSegment(Segment1_6, True)
                ShowSegment(Segment1_7, False)
            Case SevenSegmentsDisplay.DigitType.Tens
                ShowSegment(Segment2_1, True)
                ShowSegment(Segment2_2, False)
                ShowSegment(Segment2_3, True)
                ShowSegment(Segment2_4, False)
                ShowSegment(Segment2_5, False)
                ShowSegment(Segment2_6, True)
                ShowSegment(Segment2_7, False)
            Case SevenSegmentsDisplay.DigitType.Hundreds
                ShowSegment(Segment3_1, True)
                ShowSegment(Segment3_2, False)
                ShowSegment(Segment3_3, True)
                ShowSegment(Segment3_4, False)
                ShowSegment(Segment3_5, False)
                ShowSegment(Segment3_6, True)
                ShowSegment(Segment3_7, False)
            Case SevenSegmentsDisplay.DigitType.Thousands
                ShowSegment(Segment4_1, True)
                ShowSegment(Segment4_2, False)
                ShowSegment(Segment4_3, True)
                ShowSegment(Segment4_4, False)
                ShowSegment(Segment4_5, False)
                ShowSegment(Segment4_6, True)
                ShowSegment(Segment4_7, False)
        End Select
    End Sub

    Private Sub Show8(DigitTypeInt As Integer)
        Dim DigitType As DigitType = CType(DigitTypeInt, DigitType)
        Select Case DigitType
            Case SevenSegmentsDisplay.DigitType.Units
                ShowSegment(Segment1_1, True)
                ShowSegment(Segment1_2, True)
                ShowSegment(Segment1_3, True)
                ShowSegment(Segment1_4, True)
                ShowSegment(Segment1_5, True)
                ShowSegment(Segment1_6, True)
                ShowSegment(Segment1_7, True)
            Case SevenSegmentsDisplay.DigitType.Tens
                ShowSegment(Segment2_1, True)
                ShowSegment(Segment2_2, True)
                ShowSegment(Segment2_3, True)
                ShowSegment(Segment2_4, True)
                ShowSegment(Segment2_5, True)
                ShowSegment(Segment2_6, True)
                ShowSegment(Segment2_7, True)
            Case SevenSegmentsDisplay.DigitType.Hundreds
                ShowSegment(Segment3_1, True)
                ShowSegment(Segment3_2, True)
                ShowSegment(Segment3_3, True)
                ShowSegment(Segment3_4, True)
                ShowSegment(Segment3_5, True)
                ShowSegment(Segment3_6, True)
                ShowSegment(Segment3_7, True)
            Case SevenSegmentsDisplay.DigitType.Thousands
                ShowSegment(Segment4_1, True)
                ShowSegment(Segment4_2, True)
                ShowSegment(Segment4_3, True)
                ShowSegment(Segment4_4, True)
                ShowSegment(Segment4_5, True)
                ShowSegment(Segment4_6, True)
                ShowSegment(Segment4_7, True)
        End Select
    End Sub

    Private Sub Show9(DigitTypeInt As Integer)
        Dim DigitType As DigitType = CType(DigitTypeInt, DigitType)
        Select Case DigitType
            Case SevenSegmentsDisplay.DigitType.Units
                ShowSegment(Segment1_1, True)
                ShowSegment(Segment1_2, True)
                ShowSegment(Segment1_3, True)
                ShowSegment(Segment1_4, True)
                ShowSegment(Segment1_5, False)
                ShowSegment(Segment1_6, True)
                ShowSegment(Segment1_7, True)
            Case SevenSegmentsDisplay.DigitType.Tens
                ShowSegment(Segment2_1, True)
                ShowSegment(Segment2_2, True)
                ShowSegment(Segment2_3, True)
                ShowSegment(Segment2_4, True)
                ShowSegment(Segment2_5, False)
                ShowSegment(Segment2_6, True)
                ShowSegment(Segment2_7, True)
            Case SevenSegmentsDisplay.DigitType.Hundreds
                ShowSegment(Segment3_1, True)
                ShowSegment(Segment3_2, True)
                ShowSegment(Segment3_3, True)
                ShowSegment(Segment3_4, True)
                ShowSegment(Segment3_5, False)
                ShowSegment(Segment3_6, True)
                ShowSegment(Segment3_7, True)
            Case SevenSegmentsDisplay.DigitType.Thousands
                ShowSegment(Segment4_1, True)
                ShowSegment(Segment4_2, True)
                ShowSegment(Segment4_3, True)
                ShowSegment(Segment4_4, True)
                ShowSegment(Segment4_5, False)
                ShowSegment(Segment4_6, True)
                ShowSegment(Segment4_7, True)
        End Select
    End Sub
#End Region

End Class

Public Class SmartTags
    Inherits DesignerActionList

    Private DesignerActionUISvc As DesignerActionUIService = Nothing

    'For more information, visit these links.
    'https://msdn.microsoft.com/en-us/library/aa302342.aspx?f=255&MSPPError=-2147217396
    'https://msdn.microsoft.com/en-us/library/ms171829.aspx?f=255&MSPPError=-2147217396

    Sub New(component As IComponent)
        MyBase.New(component)

        'Allow refresh the ActionList.
        DesignerActionUISvc = CType(GetService(GetType(DesignerActionUIService)), DesignerActionUIService)
    End Sub

#Region " Properties "

    Public Property Digits As Integer
        Get
            'We obtain the property value by casting.
            Return DirectCast(Me.Component, SevenSegmentsDisplay).Digits
        End Get
        Set(value As Integer)
            'We use reflection to access the property.
            Dim prop As PropertyDescriptor = TypeDescriptor.GetProperties(Me.Component)("Digits")

            'We define the property value.
            prop.SetValue(Me.Component, value)

            'We refresh the list.
            DesignerActionUISvc.Refresh(Me.Component)
        End Set
    End Property

    Public Property Value As Integer
        Get
            'We obtain the property value by casting.
            Return DirectCast(Me.Component, SevenSegmentsDisplay).Value
        End Get
        Set(value As Integer)
            'We use reflection to access the property.
            Dim prop As PropertyDescriptor = TypeDescriptor.GetProperties(Me.Component)("Value")

            'We define the property value.
            prop.SetValue(Me.Component, value)
        End Set
    End Property

    Public Property BorderStyle As BorderStyle
        Get
            'We obtain the property value by casting.
            Return DirectCast(Me.Component, SevenSegmentsDisplay).BorderStyle
        End Get
        Set(value As BorderStyle)
            'We use reflection to access the property.
            Dim prop As PropertyDescriptor = TypeDescriptor.GetProperties(Me.Component)("BorderStyle")

            'We define the property value.
            prop.SetValue(Me.Component, value)
        End Set
    End Property

    Public Property HideOffSegments As Boolean
        Get
            'We obtain the property value by casting.
            Return DirectCast(Me.Component, SevenSegmentsDisplay).HideOffSegments
        End Get
        Set(value As Boolean)
            'We use reflection to access the property.
            Dim prop As PropertyDescriptor = TypeDescriptor.GetProperties(Me.Component)("HideOffSegments")

            'We define the property value.
            prop.SetValue(Me.Component, value)
        End Set
    End Property

    Public Property SegmentOnColor As Color
        Get
            'We obtain the property value by casting.
            Return DirectCast(Me.Component, SevenSegmentsDisplay).SegmentOnColor
        End Get
        Set(value As Color)
            'We use reflection to access the property.
            Dim prop As PropertyDescriptor = TypeDescriptor.GetProperties(Me.Component)("SegmentOnColor")

            'We define the property value.
            prop.SetValue(Me.Component, value)
        End Set
    End Property

    Public Property SegmentOffColor As Color
        Get
            'We obtain the property value by casting.
            Return DirectCast(Me.Component, SevenSegmentsDisplay).SegmentOffColor
        End Get
        Set(value As Color)
            'We use reflection to access the property.
            Dim prop As PropertyDescriptor = TypeDescriptor.GetProperties(Me.Component)("SegmentOffColor")

            'We define the property value.
            prop.SetValue(Me.Component, value)
        End Set
    End Property

#End Region

    Public Overrides Function GetSortedActionItems() As DesignerActionItemCollection
        'We create an ItemCollection for our SmartTag.
        Dim items As New DesignerActionItemCollection()

        'We add properties to the collection.
        items.Add(New DesignerActionHeaderItem("Properties"))
        items.Add(New DesignerActionPropertyItem("Digits", "Number of digits"))
        items.Add(New DesignerActionPropertyItem("Value", "Value to display"))
        items.Add(New DesignerActionPropertyItem("BorderStyle", "Segments border style"))
        items.Add(New DesignerActionPropertyItem("HideOffSegments", "Hide deactivated segments"))
        items.Add(New DesignerActionPropertyItem("SegmentOnColor", "Activated segments' color"))
        items.Add(New DesignerActionPropertyItem("SegmentOffColor", "Deactivated segments' color"))

        'We return the filled collection.
        Return items
    End Function

End Class

Public Class Designer
    Inherits ControlDesigner

    Public Overrides ReadOnly Property SelectionRules() As SelectionRules
        Get
            Dim mc As SevenSegmentsDisplay = MyBase.Control

            If mc.LockSize Then
                Return MyBase.SelectionRules And Not SelectionRules.AllSizeable
            Else
                Return MyBase.SelectionRules
            End If
        End Get
    End Property

    Public Overrides ReadOnly Property ActionLists() As DesignerActionListCollection
        Get
            'Creates a new collection for our actions.
            Dim list As New DesignerActionListCollection()

            'Gets all the properties
            Dim designList As New SmartTags(Me.Control)

            'Adds the properties with designList.
            list.Add(designList)

            'Returns the filled collection.
            Return list
        End Get
    End Property

End Class

Module Extensions

    'Extension for the Integer datatype which returns the zero-based value.
    'This is far from complicated: you just subtract 1 to the value. But that facilitates understanding...
    <Extension> Public Function ZeroBased(value) As Integer
        Return value - 1
    End Function

End Module