Partial Public Class ddlCATALOGOPRODUCTOS

    Private mComponente As New cCATALOGOPRODUCTOS

    Public Sub Recuperar2()
        Me.DataSource = mComponente.ObtenerCatalogoProductosCompleto()
        Me.DataTextField = "DESCLARGO"
        Me.DataValueField = "IDPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub Recuperar3()
        Me.DataSource = mComponente.ObtenerCatalogoProductosCompleto()
        Me.DataTextField = "CODIGONOMBRE"
        Me.DataValueField = "IDPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarHabilitados(ByVal IDESTABLECIMIENTO As Int32)
        Me.DataSource = mComponente.ObtenerCatalogoProductosCompletoHabilitadoEstablecimiento(IDESTABLECIMIENTO)
        Me.DataTextField = "DESCLARGO"
        Me.DataValueField = "IDPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaXSuministro(ByVal IDSUMINISTRO As Int32)
        Me.DataSource = mComponente.ObtenerCatalogoProductosCompletoXsuministro(IDSUMINISTRO)
        Me.DataTextField = "DESCLARGO"
        Me.DataValueField = "IDPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaXSuministroDistro(ByVal IDSUMINISTRO As Integer, ByVal IDALMACEN As Integer, Optional IDPROGRAMA As Integer = 0)
        Dim cEntidad As New cDISTRIBUCIONPRODUCTO
        Me.DataSource = cEntidad.productosSeleccionables(IDALMACEN, IDSUMINISTRO, "", IDPROGRAMA)
        Me.DataTextField = "DESCLARGO"
        Me.DataValueField = "IDPRODUCTO"
        Me.DataBind()
    End Sub
    Public Sub RecuperarListaXSuministroProgra(ByVal IDSUMINISTRO As Integer, ByVal IDALMACEN As Integer, IDPROGRAMACION As Integer, Optional IDPROGRAMA As Integer = 0)
        Dim cEntidad As New cPROGRAMACION
        Me.DataSource = cEntidad.productosSeleccionables(IDALMACEN, IDSUMINISTRO, IDPROGRAMACION, IDPROGRAMA)
        Me.DataTextField = "DESCLARGO"
        Me.DataValueField = "IDPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaHabilitadosXSuministro(ByVal IDSUMINISTRO As Int32, ByVal IDESTABLECIMIENTO As Int32)
        Me.DataSource = mComponente.ObtenerCatalogoProductosCompletoHabilitadoXsuministro(IDSUMINISTRO, IDESTABLECIMIENTO)
        Me.DataTextField = "DESCLARGO"
        Me.DataValueField = "IDPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaXGrupo(ByVal IDGRUPO As Int32)
        Me.DataSource = mComponente.ObtenerCatalogoProductosCompletoXgrupo(IDGRUPO)
        Me.DataTextField = "DESCLARGO"
        Me.DataValueField = "IDPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaHabilitadosXGrupo(ByVal IDGRUPO As Int32, ByVal IDESTABLECIMIENTO As Int32)
        Me.DataSource = mComponente.ObtenerCatalogoProductosCompletoHabilitadoXgrupo(IDGRUPO, IDESTABLECIMIENTO)
        Me.DataTextField = "DESCLARGO"
        Me.DataValueField = "IDPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaXSubgrupo(ByVal IDSUBGRUPO As Int32)
        Me.DataSource = mComponente.ObtenerCatalogoProductosCompletoPorSubgrupo(IDSUBGRUPO)
        Me.DataTextField = "DESCLARGO"
        Me.DataValueField = "IDPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaXSubgrupo2(ByVal IDSUBGRUPO As Int32)
        Me.DataSource = mComponente.ObtenerCatalogoProductosCompletoPorSubgrupo2(IDSUBGRUPO)
        Me.DataTextField = "CORRELATIVODESCRIPCION"
        Me.DataValueField = "IDPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaHabilitadoXSubgrupo(ByVal IDSUBGRUPO As Int32, ByVal IDESTABLECIMIENTO As Int32)
        Me.DataSource = mComponente.ObtenerCatalogoProductosCompletoHabilitadoXsubgrupo(IDSUBGRUPO, IDESTABLECIMIENTO)
        Me.DataTextField = "DESCLARGO"
        Me.DataValueField = "IDPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaXCodigoMSPAS()
        Me.DataSource = mComponente.ObtenerCatalogoProductosCompleto()
        Me.DataTextField = "DESCLARGO"
        Me.DataValueField = "CORRPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaNoMedicosXCodigoMSPAS(ByVal IDSUMINISTRO As Int32)
        Me.DataSource = mComponente.ObtenerCatalogoProductosCompleto(IDSUMINISTRO)
        Me.DataTextField = "DESCLARGO"
        Me.DataValueField = "CORRPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaNoMedicosConHomogeneos(ByVal IDSUMINISTRO As Int32)
        Me.DataSource = mComponente.ObtenerCatalogoProductosCompletoNoMedicoConHomogeneos(IDSUMINISTRO)
        Me.DataTextField = "DESCLARGO"
        Me.DataValueField = "CORRPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaHabilitadoXCodigoMSPAS(ByVal IDESTABLECIMIENTO As Int32)
        Me.DataSource = mComponente.ObtenerCatalogoProductosCompletoHabilitadoEstablecimiento(IDESTABLECIMIENTO)
        Me.DataTextField = "DESCLARGO"
        Me.DataValueField = "CORRPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaXCodigoMSPASxGrupo(ByVal IDGRUPO As Int32)
        Me.DataSource = mComponente.ObtenerCatalogoProductosCompletoXgrupo(IDGRUPO)
        Me.DataTextField = "DESCLARGO"
        Me.DataValueField = "CORRPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaXCodigoMSPASxgrupoNoMedico(ByVal IDGRUPO As Int32, ByVal IDTIPOSUMINISTRO As Int32)
        Me.DataSource = mComponente.ObtenerCatalogoProductosCompletoXgrupoNoMedico(IDGRUPO, IDTIPOSUMINISTRO)
        Me.DataTextField = "DESCLARGO"
        Me.DataValueField = "CORRPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarHabilitadosxCodigoXSuministro(ByVal IDSUMINISTRO As Int32, ByVal IDESTABLECIMIENTO As Int32)
        Me.DataSource = mComponente.ObtenerCatalogoProductosCompletoHabilitadoXsuministro(IDSUMINISTRO, IDESTABLECIMIENTO)
        Me.DataTextField = "DESCLARGO"
        Me.DataValueField = "CORRPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaHabilitadoXCodigoMSPASxGrupo(ByVal IDGRUPO As Int32, ByVal IDESTABLECIMIENTO As Int32)
        Me.DataSource = mComponente.ObtenerCatalogoProductosCompletoHabilitadoXgrupo(IDGRUPO, IDESTABLECIMIENTO)
        Me.DataTextField = "DESCLARGO"
        Me.DataValueField = "CORRPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaDescripcionLargaTodos()
        Me.DataSource = mComponente.ObtenerListaDescripcionLarga()
        Me.DataTextField = "DESCLARGO"
        Me.DataValueField = "IDPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarDescripcionLargo(Optional ByVal IDSUMINISTRO As Integer = 0)
        Me.DataSource = mComponente.ObtenerListaDescripcionLarga(IDSUMINISTRO)
        Me.DataTextField = "CORRELATIVODESCRIPCION"
        Me.DataValueField = "IDPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarProductosConExistencia(ByVal IDALMACEN As Int32, Optional ByVal IDSUMINISTRO As Int32 = 0, Optional ByVal IDSUBGRUPO As Int32 = 0)
        Me.DataSource = mComponente.FiltrarProductosConExistencia(IDALMACEN, IDSUMINISTRO, IDSUBGRUPO)
        Me.DataTextField = "CORRELATIVODESCRIPCION"
        Me.DataValueField = "IDPRODUCTO"
        Me.DataBind()
    End Sub

    Public Sub RecuperarListaXUT(ByVal IDSUBGRUPO As Int32, ByVal AREATECNICA As Integer)
        Me.DataSource = mComponente.ObtenerCatalogoProductosPorUT(IDSUBGRUPO, AREATECNICA)
        Me.DataTextField = "DESCLARGO"
        Me.DataValueField = "IDPRODUCTO"
        Me.DataBind()
    End Sub

End Class
