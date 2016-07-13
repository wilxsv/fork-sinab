Imports System.Linq
Imports System.ComponentModel.Design
Imports SINAB_Entidades.Helpers

Partial Class FrmReporteIngresosGenerales
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            With ucFiltrosReportesAlmacen1
                  .VerDocumento = ""
                
            .VerFechaDesde = True
            .VerFechaHasta = True
            .FechasRequeridas = True
            .VerFuenteFinanciamiento = True
            .VerGrupoFuenteFinanciamiento = True
            .VerResponsableDistribucion = True
            .VerTipoSuministro = True
            .VerGrupo = True
            .VerAgruparPor = True
            .b = 1
            .VerEspecificoGasto = True
            .TipoSuministroTodos = True
            .VerTransferencia = True

                 If Membresia.EsUsuarioRol("AdministracionAlmacenes") Then

                    .VerEstablecimientoTodos = True
                    .VerAlmacen = True
                End If

                .IniciarDatos()
            End With

          
        End If

    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub ucFiltrosReportesAlmacen1_Consultar() Handles ucFiltrosReportesAlmacen1.Consultar
        Dim idA As Integer 
        Dim idE As Integer
        With ucFiltrosReportesAlmacen1
          If Membresia.EsUsuarioRol("AdministracionAlmacenes") Then
                idA = .IDALMACEN
                idE =.IDESTABLECIMIENTO2
          '      ds = AlmacenHelpers.RecibosRecepcion.ObtenerTodos(.IDALMACEN, .IDESTABLECIMIENTO2, .IDPROVEEDOR, CType(.FECHADESDE, Date), CType(.FECHAHASTA, Date), .IDGRUPOFUENTEFINANCIAMIENTO, .IDFUENTEFINANCIAMIENTO, .IDRESPONSABLEDISTRIBUCION, .IDESTADO, CType(.Documento, Integer), 0, .IDSUMINISTRO)
            Else
                idA = Membresia.ObtenerUsuario().Almacen.IDALMACEN
                idE= 0
          '      ds = AlmacenHelpers.RecibosRecepcion.ObtenerTodos(Membresia.ObtenerUsuario().ALMACEN.IDALMACEN, 0, .IDPROVEEDOR, CType(.FECHADESDE, Date), CType(.FECHAHASTA, Date), .IDGRUPOFUENTEFINANCIAMIENTO, .IDFUENTEFINANCIAMIENTO, .IDRESPONSABLEDISTRIBUCION, .IDESTADO, CType(.Documento, Integer), 0, .IDSUMINISTRO)
            End If
        
        
            Dim fd = .FECHADESDE
        Dim fh = .FECHAHASTA
        Dim  idFf = .IDFUENTEFINANCIAMIENTO
        Dim idGf = .IDGRUPOFUENTEFINANCIAMIENTO
        Dim idRd = .IDRESPONSABLEDISTRIBUCION
        Dim idS = .IDSUMINISTRO
        Dim idG = .IDGRUPO
        Dim ag = .AgruparPor
        Dim fos = .FOS
        Dim idEg = .IDESPECIFICOGASTO
        Dim transf =.Transf
        
        
        dim cad = String.Format("/Reportes/FrmRptIngresosGenerales.aspx?idA={0}&fd={1}&fh={2}&idFF={3}&idGF={4}&idRD={5}&idS={6}&idG={7}&Ag={8}&fos={9}&idEG={10}&Transf={11}", idA, fd, fh, idFf, idGf, idRd, idS, idG, ag, fos, idEg, transf)

       
        SINAB_Utils.Utils.MostrarVentana(cad)
 End With
    End Sub

End Class
