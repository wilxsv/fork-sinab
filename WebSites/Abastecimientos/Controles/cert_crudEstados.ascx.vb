
Imports System.Linq
Imports SINAB_Entidades
Imports SINAB_Entidades.Helpers.CertificacionHelpers

Partial Class Controles_cert_crudEstados
    Inherits System.Web.UI.UserControl


    Public Property ProductoProveedor() As SAB_CP_PRODUCTOSPROVEEDORES
        Get
            Return CType(ViewState("pp"), SAB_CP_PRODUCTOSPROVEEDORES)
        End Get
        Set(value As SAB_CP_PRODUCTOSPROVEEDORES)
            ViewState("pp") = value
        End Set
    End Property

    Public Sub CardarDatos()
        Dim ds = EstadoProductos.ObtenerTodos(ProductoProveedor.Id)
        If ds.Any() Then
            Dim estado = ds.FirstOrDefault()
            Label7.Text = estado.Certificado & " - " & estado.Comentario
            GridView3.DataSource = ds
            GridView3.DataBind()
        Else
            Label7.Text = "No existen estados."
        End If
        
    End Sub

    Protected Sub btnAddStatus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddStatus.Click

        ' AgregarESTADOSPRODUCTOS(ByVal idproceso As Integer, ByVal idtipoproducto As Integer, ByVal idproveedor As Integer, ByVal idproducto As Integer, ByVal estado As Integer, ByVal fecha As DateTime, ByVal comentario As String, ByVal usuario As String, ByVal ID As Integer) As Integer

        Dim ep As New SAB_CP_ESTADOSPRODUCTOS
        With ep
           
            .IdProductoProveedor = ProductoProveedor.Id
            .estado = CType(RadioButtonList2.SelectedValue, Integer)
            .Fecha = (CDate(TextBox9.Text)).Add(Date.Now.TimeOfDay)
            .Comentario = TextBox10.Text
            .usuario = HttpContext.Current.User.Identity.Name
        End With
        EstadoProductos.Agregar(ep)



        ProveedoresProceso.Actualizar(ProductoProveedor.IdProveedorProceso, ep.estado) ', Proceso.IdProveedor, CType(RadioButtonList2.SelectedValue, Integer))
        


        CardarDatos()

        RadioButtonList2.SelectedIndex = -1
        TextBox9.Text = ""
        TextBox10.Text = ""
    End Sub

    Public Sub Limpiar()
        RadioButtonList2.SelectedIndex = -1
        TextBox9.Text = ""
        TextBox10.Text = ""
    End Sub
End Class
