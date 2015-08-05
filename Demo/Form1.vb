Public Class Form1

    Private Sub ControlValue_ValueChanged(sender As Object, e As EventArgs) Handles ControlValue.ValueChanged
        'Changes the displayed value.
        SevenSegmentsDisplay1.Value = ControlValue.Value
    End Sub

    Private Sub Choose1_Click(sender As Object, e As EventArgs) Handles Choose1.Click
        'Opens the ColorDialog.
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            'When user clicks OK, we display the selected color on the UI,
            'and we change control's background color.
            ControlBackColor.BackColor = ColorDialog1.Color
            SevenSegmentsDisplay1.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub Choose2_Click(sender As Object, e As EventArgs) Handles Choose2.Click
        'Opens the ColorDialog.
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            'When user clicks OK, we display the selected color on the UI,
            'and we change the activated segments color.
            ControlSegmentsOnColor.BackColor = ColorDialog1.Color
            SevenSegmentsDisplay1.SegmentOnColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub Choose3_Click(sender As Object, e As EventArgs) Handles Choose3.Click
        'Opens the ColorDialog.
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            'When user clicks OK, we display the selected color on the UI,
            'and we change the deactivated segments color.
            ControlSegmentsOffColor.BackColor = ColorDialog1.Color
            SevenSegmentsDisplay1.SegmentOffColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub HideOffSegments_CheckedChanged(sender As Object, e As EventArgs) Handles HideOffSegments.CheckedChanged
        'Set the control's HideOffSegments property.
        SevenSegmentsDisplay1.HideOffSegments = HideOffSegments.Checked
    End Sub

    Private Sub Digits_ValueChanged(sender As Object, e As EventArgs) Handles Digits.ValueChanged
        'Set the control's Digits property.
        SevenSegmentsDisplay1.Digits = Digits.Value
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Default values for the control.
        ControlValue.Value = SevenSegmentsDisplay1.Value
        ControlBackColor.BackColor = SevenSegmentsDisplay1.BackColor
        ControlSegmentsOnColor.BackColor = SevenSegmentsDisplay1.SegmentOnColor
        ControlSegmentsOffColor.BackColor = SevenSegmentsDisplay1.SegmentOffColor
        HideOffSegments.Checked = SevenSegmentsDisplay1.HideOffSegments
        Digits.Value = SevenSegmentsDisplay1.Digits
    End Sub

    Private Sub SevenSegmentsDisplay1_BackColorChanged(sender As Object, e As EventArgs) Handles SevenSegmentsDisplay1.BackColorChanged
        Console.WriteLine("BackColor property changed.")
    End Sub

    Private Sub SevenSegmentsDisplay1_SegmentsOffColorChanged(sender As Object, e As EventArgs) Handles SevenSegmentsDisplay1.SegmentsOffColorChanged
        Console.WriteLine("SegmentsOffColor property changed.")
    End Sub

    Private Sub SevenSegmentsDisplay1_HideOffSegmentsChanged(sender As Object, e As EventArgs) Handles SevenSegmentsDisplay1.HideOffSegmentsChanged
        Console.WriteLine("HideOffSegments property changed.")
    End Sub

    Private Sub SevenSegmentsDisplay1_SegmentsOnColorChanged(sender As Object, e As EventArgs) Handles SevenSegmentsDisplay1.SegmentsOnColorChanged
        Console.WriteLine("SegmentsOnColor property changed.")
    End Sub

    Private Sub SevenSegmentsDisplay1_BorderStyleChanged(sender As Object, e As EventArgs) Handles SevenSegmentsDisplay1.BorderStyleChanged
        Console.WriteLine("BorderStyle property changed.")
    End Sub

    Private Sub SevenSegmentsDisplay1_DigitsChanged(sender As Object, e As EventArgs) Handles SevenSegmentsDisplay1.DigitsChanged
        Console.WriteLine("Digits property changed.")
    End Sub

    Private Sub SevenSegmentsDisplay1_ValueChanged(sender As Object, e As EventArgs) Handles SevenSegmentsDisplay1.ValueChanged
        Console.WriteLine("Value property changed.")
    End Sub
End Class
