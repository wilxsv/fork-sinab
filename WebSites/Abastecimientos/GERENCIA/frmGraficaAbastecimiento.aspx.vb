Imports System.Text
Imports SharpPieces.Web.Controls

Partial Class GERENCIA_frmGraficaAbastecimiento
    Inherits System.Web.UI.Page

    Dim mesesSP() As String = {"Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"}
    Dim mesesEN() As String = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Master.ControlMenu.Visible = False 'ocultar menu
        'JScript, CSS

        ClientScript.RegisterClientScriptBlock(Me.Master.GetType, "js0", "<!--[if IE]><script language='javascript' type='text/javascript' src='../Script/excanvas.js'></script><![endif]-->")
        ClientScript.RegisterClientScriptBlock(Me.Master.GetType, "js1", "<script language='javascript' type='text/javascript' src='../Script/jquery.js'></script>")
        ClientScript.RegisterClientScriptBlock(Me.Master.GetType, "js2", "<script language='javascript' type='text/javascript' src='../Script/jquery.jqplot.min.js'></script>")
        ClientScript.RegisterClientScriptBlock(Me.Master.GetType, "js3", "<script language='javascript' type='text/javascript' src='../Script/jqplot.dateAxisRenderer.min.js'></script>")
        ClientScript.RegisterClientScriptBlock(Me.Master.GetType, "js4", "<script type='text/javascript' src='../Script/jquery-ui-1.7.2.custom.min.js'></script>")
        ClientScript.RegisterClientScriptBlock(Me.Master.GetType, "js5", "<script type='text/javascript' src='../Script/selectToUISlider.jQuery.js'></script>")

        ClientScript.RegisterClientScriptBlock(Me.Master.GetType, "js8", "<script language='javascript' type='text/javascript' src='../Script/jqplot.canvasTextRenderer.min.js'></script>")
        ClientScript.RegisterClientScriptBlock(Me.Master.GetType, "js9", "<script language='javascript' type='text/javascript' src='../Script/jqplot.canvasAxisTickRenderer.min.js'></script>")
        ClientScript.RegisterClientScriptBlock(Me.Master.GetType, "js10", "<script language='javascript' type='text/javascript' src='../Script/jqplot.highlighter.min.js'></script>")
        ClientScript.RegisterClientScriptBlock(Me.Master.GetType, "js11", "<script language='javascript' type='text/javascript' src='../Script/jqplot.cursor.min.js'></script>")

        ClientScript.RegisterClientScriptBlock(Me.Master.GetType, "css1", "<link rel='stylesheet' href='../css/themes/redmond/jquery-ui-1.7.1.custom.css' type='text/css' />")
        ClientScript.RegisterClientScriptBlock(Me.Master.GetType, "css2", "<link rel='stylesheet' href='../css/ui.slider.extras.css' type='text/css' />")
        ClientScript.RegisterClientScriptBlock(Me.Master.GetType, "css3", "<link rel='stylesheet' type='text/css' href='../css/jquery.jqplot.css' />")

        Dim str As New StringBuilder

        str.Append("<style type='text/css'>")
        str.Append("p { clear:both; }")
        str.Append("fieldset { border:0; margin-top: 0.5em; margin-left: 20px; font-size:62.5%;}	")
        str.Append("label {font-weight: normal; float: left; margin-right: .5em; font-size: 1.1em;}")
        str.Append("select {margin-right: 1em; float: left;}")
        str.Append(".ui-slider {clear: both; top: 2.5em;}")
        str.Append("</style>")

        ClientScript.RegisterClientScriptBlock(Me.Master.GetType, "css4", str.ToString)

        str.Append("<script type='text/javascript'>")
        str.Append("$(function(){")
        str.Append("$('select').selectToUISlider({labels: 8}).hide(); ") '
        str.Append("});")
        str.Append("</script>")

        ClientScript.RegisterClientScriptBlock(Me.Master.GetType, "js6", str.ToString)

        

        If Not Page.IsPostBack Then

            Me.ucBarraNavegacion1.Navegacion = False
            Me.ucBarraNavegacion1.PermitirAgregar = False
            Me.ucBarraNavegacion1.PermitirEditar = False
            Me.ucBarraNavegacion1.PermitirConsultar = False
            Me.ucBarraNavegacion1.HabilitarEdicion(True)
            Me.ucBarraNavegacion1.PermitirImprimir = False
            Me.ucBarraNavegacion1.PermitirGuardar = False
            Me.ucBarraNavegacion1.PermitirCancelar = False

            Dim fechaInicio As New Date(2007, 9, 1)
            Dim fechaFin As New Date(Now.Year, Now.Month, 1)
            Dim anio As Integer = 0
            Dim f1 As String = String.Empty
            Dim f2 As String = String.Empty

            Do While fechaInicio <= fechaFin

                f1 = IIf(fechaInicio.Month < 10, "0" & fechaInicio.Month.ToString, fechaInicio.Month.ToString) & "/" & fechaInicio.Year
                f2 = mesesSP(fechaInicio.Month - 1) & "/" & fechaInicio.Year

                If anio <> fechaInicio.Year Then
                    anio = fechaInicio.Year
                    Me.valueA.ExtendedItems.Add(New ExtendedListItem(f2, f1, True, ListItemGroupingType.New, anio.ToString))
                    Me.valueB.ExtendedItems.Add(New ExtendedListItem(f2, f1, True, ListItemGroupingType.New, anio.ToString))
                Else
                    Me.valueA.ExtendedItems.Add(New ExtendedListItem(f2, f1, True, ListItemGroupingType.Inherit, anio.ToString))
                    Me.valueB.ExtendedItems.Add(New ExtendedListItem(f2, f1, True, ListItemGroupingType.Inherit, anio.ToString))
                End If

                fechaInicio = DateAdd(DateInterval.Month, 1, fechaInicio)
            Loop

            If Me.valueA.ExtendedItems.Count > 8 Then Me.valueA.SelectedIndex = Me.valueA.ExtendedItems.Count - 7
            If Me.valueB.ExtendedItems.Count > 0 Then Me.valueB.SelectedIndex = Me.valueB.ExtendedItems.Count - 1

        End If


    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim valA() As String = Me.valueA.SelectedItem.Value.Split("/")
        Dim valB() As String = Me.valueB.SelectedItem.Value.Split("/")

        Dim f1 As Date = New Date(valA(1), valA(0), 1)
        Dim f2 As Date = New Date(valB(1), valB(0), 1)
        Dim f3 As Date = DateAdd(DateInterval.Month, -1, f1)

        Dim diferencia As Integer = Math.Floor(DateDiff(DateInterval.Month, f1, f2) / 12) + 1

        Dim cEntidad As New ABASTECIMIENTOS.NEGOCIO.cCONSUMOS

        Dim abas As Boolean = True
        If Me.rd2.Checked = True Then abas = False

        'Regiones
        Dim arr As ArrayList = cEntidad.obtenerDesabastecimientoRegiones(f1, f2)

        Dim str2 As New StringBuilder

        If arr.Count > 0 Then
            For i As Integer = 0 To arr.Count - 1
                Dim s() As String
                s = arr(i)
                If i = 0 Then
                    str2.Append("['" & s(0) & "'," & IIf(Not abas, s(1), 100 - CDbl(s(1))) & "]")
                Else
                    str2.Append(",['" & s(0) & "'," & IIf(Not abas, s(1), 100 - CDbl(s(1))) & "]")
                End If
            Next
        End If

        'Hospitales

        arr = New ArrayList
        arr = cEntidad.obtenerDesabastecimientoHospitales(f1, f2)

        Dim str3 As New StringBuilder

        If arr.Count > 0 Then
            For i As Integer = 0 To arr.Count - 1
                Dim s() As String
                s = arr(i)
                If i = 0 Then
                    str3.Append("['" & s(0) & "'," & IIf(Not abas, s(1), 100 - CDbl(s(1))) & "]")
                Else
                    str3.Append(",['" & s(0) & "'," & IIf(Not abas, s(1), 100 - CDbl(s(1))) & "]")
                End If
            Next
        End If

        If str2.Length = 0 And str3.Length = 0 Then
            contenedor.InnerHtml = "La consulta no ha devuelto datos"
            Exit Sub
        Else
            contenedor.InnerHtml = "<div id='chartdiv' style='height:400px;width:600px'></div>"
        End If

        Dim str As New StringBuilder

        str = New StringBuilder

        str.Append("jQuery(document).ready(function(){")
        str.Append("$.jqplot('chartdiv', [[")

        If str2.Length > 0 And str3.Length = 0 Then
            str.Append(str2)
        ElseIf str3.Length > 0 And str2.Length = 0 Then
            str.Append(str3)
        Else
            str.Append(str2)
            str.Append("],[")
            str.Append(str3)
        End If

        str.Append("]],")
        str.Append("{")

        If abas Then
            str.Append("  title:  'Gráfica de Nivel de Abastecimiento',")
        Else
            str.Append("  title:  'Gráfica de Nivel de Desabastecimiento',")
        End If

        str.Append("  legend:{show:true}, ")
        str.Append("  axes:{")
        str.Append("    xaxis:{")
        str.Append("      renderer:$.jqplot.DateAxisRenderer,")
        str.Append("      rendererOptions:{tickRenderer:$.jqplot.CanvasAxisTickRenderer},")
        str.Append("      tickOptions:{formatString:'%b %y', angle:-30},")
        str.Append("      min:'" & mesesEN(f3.Month - 1) & " 1, " & f3.Year & "',")
        str.Append("      tickInterval:'" & diferencia & " month'")
        str.Append("    },")
        str.Append("    yaxis:{")
        str.Append("      min:0,")
        str.Append("      max:100,")
        str.Append("      tickOptions:{formatString:'%.2f%'}")
        str.Append("    }")
        str.Append("},")
        str.Append("  highlighter: {sizeAdjust: 7.5},")
        str.Append("  cursor: {show: false},")

        If str2.Length > 0 And str3.Length = 0 Then
            str.Append("  series:[{label:'Regiones', lineWidth:2}]")
        ElseIf str3.Length > 0 And str2.Length = 0 Then
            str.Append("  series:[{label:'Hospitales', lineWidth:2}]")
        Else
            str.Append("  series:[{label:'Regiones', lineWidth:2}, {label:'Hospitales', lineWidth:2}]")
        End If

        str.Append("});")
        str.Append("});")

        ClientScript.RegisterClientScriptBlock(Me.Master.GetType, "js7", str.ToString, True)


    End Sub

    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        'evento al presionar link menu
        Response.Redirect("~/FrmPrincipal.aspx", False) 'redirecciona a la pagina principal
    End Sub

End Class
