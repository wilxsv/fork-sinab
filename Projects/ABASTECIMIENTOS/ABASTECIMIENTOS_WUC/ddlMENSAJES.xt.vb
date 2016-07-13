Partial Public Class ddlMENSAJES

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="tipo"></param>
    ''' <remarks></remarks>
    ''' <history>
    '''     []    Creado
    ''' </history>
    Public Sub RecuperarListaOrdenada(Optional ByVal tipo As Integer = 0)

        Dim miComponente As New cMENSAJES
        Dim lista As listaMENSAJES

        lista = miComponente.ObtenerListaOrden(tipo)

        If IsNothing(lista) Then
            Return
        End If

        Me.DataSource = lista
        Me.DataTextField = "MENSAJE"
        Me.DataValueField = "IDMENSAJE"
        Me.DataBind()
    End Sub

End Class
