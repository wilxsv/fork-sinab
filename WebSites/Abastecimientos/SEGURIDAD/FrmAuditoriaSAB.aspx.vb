Imports ABASTECIMIENTOS.NEGOCIO

Partial Class FrmAuditoriaSAB
    Inherits System.Web.UI.Page

    Protected Sub LnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False

            Dim c As New cUSUARIOS
            Dim ds As Data.DataSet
            ds = c.ObtenerEmpleadosUsuarios
            ds.Tables(0).TableName = "Tabla1"
            Dim item As ListItem
            item = New ListItem
            item.Text = "(Todos)"
            item.Value = "Todos"
            item.Selected = True

            Me.DropDownList4.Items(0).Selected = True

            Me.DropDownList1.DataSource = ds.Tables(0)
            Me.DropDownList1.DataTextField = "NOMBRE"
            Me.DropDownList1.DataValueField = "USUARIO"
            Me.DropDownList1.DataBind()
            Me.DropDownList1.Items.Insert(0, item)

            Me.DropDownList5.DataSource = ds.Tables(0)
            Me.DropDownList5.DataTextField = "NOMBRE"
            Me.DropDownList5.DataValueField = "USUARIO"
            Me.DropDownList5.DataBind()
            Me.DropDownList5.Items.Insert(0, item)

            ds.Tables.Add(c.ObtenerTablasBD.Tables(0).Copy)
            ds.Tables(1).TableName = "Tabla2"
            Me.DropDownList8.DataSource = ds.Tables(1)
            Me.DropDownList8.DataTextField = "table_name"
            Me.DropDownList8.DataValueField = "table_name"
            Me.DropDownList8.DataBind()
            Me.DropDownList8.Items.Insert(0, item)

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fechai, fechaf As String
        fechai = String.Format("{0:yyyy/MM/dd}", Me.CalendarPopup1.SelectedDate)
        fechaf = String.Format("{0:yyyy/MM/dd}", Me.CalendarPopup2.SelectedDate)
        ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptIngresoUsuarios.aspx?FechaI=" & fechai & "&FechaF=" & fechaf & "&Usuario=" & Me.DropDownList1.SelectedValue & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim fechai, fechaf As String
        fechai = String.Format("{0:yyyy/MM/dd}", Me.CalendarPopup3.SelectedDate)
        fechaf = String.Format("{0:yyyy/MM/dd}", Me.CalendarPopup4.SelectedDate)
        ClientScript.RegisterStartupScript(Me.Page.GetType, "VistaPrevia", "<script language='jscript'> window.open('" + Request.ApplicationPath + "/Reportes/frmRptBitacoraSAB.aspx?FechaI=" & fechai & "&FechaF=" & fechaf & "&Usuario=" & Me.DropDownList5.SelectedValue & "&mov=" & Me.DropDownList4.SelectedValue & "&tabla=" & Me.DropDownList8.SelectedValue & "', 'popup' ,'scrollbars= 1 ,resizable= 1 ,width= 800 ,height= 600 '); </script>")
    End Sub

End Class
