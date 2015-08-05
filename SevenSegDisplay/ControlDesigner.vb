Imports System.Windows.Forms.Design
Imports System.ComponentModel.Design

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
