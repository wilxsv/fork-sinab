Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.VisualBasic

Public Class CustomEventArgs
    Inherits EventArgs
    Public Property Key() As Integer
    Public Property Value() As String

    Public Sub New(key As Integer, value As String)
        MyBase.New()
        Me.Key = key
        Me.Value = value
    End Sub
End Class
