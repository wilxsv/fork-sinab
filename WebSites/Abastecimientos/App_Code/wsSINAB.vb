Imports System.Web.Services
Imports AjaxControlToolkit
Imports System.Data
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports ABASTECIMIENTOS.NEGOCIO
Imports SINAB_Entidades.Helpers.CatalogoHelpers
Imports SINAB_Entidades.Helpers
Imports SladeHome.SimpleCrypto
Imports System.Linq
Imports System


<WebService(Namespace:="http://www.mspas.gob/sinab")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<System.Web.Script.Services.ScriptService()> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class wsSINAB
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function ObtenerListaProveedores(ByVal param As String) As List(Of ProveedorFiltrado)

        Dim lista = Proveedores.ObtenerTodos(param)
        Return lista
        
    End Function

    <WebMethod()> _
    Public Function ObtenerListaProductos(ByVal param As String) As List(Of ProductoFiltrado)
        Dim lista = Productos.Obtener()

        Dim listFiltrado = lista.Where(Function(p) p.Descripcion.ToLower().Contains(param.ToLower())).Take(20).OrderBy(Function(p) p.Correlativo)
        Return listFiltrado.ToList()
    End Function

    <WebMethod()> _
    Public Function ObtenerListaAlmacenes(ByVal param As String) As List(Of KeyValuePair(Of Integer, String))
        Dim lista = Almacenes.ObtenerTodos()

        Dim listFiltrado = lista.Where(Function(p) p.Value.ToLower().Contains(param.ToLower())).Take(20).OrderBy(Function(p) p.Value)
        Return listFiltrado.ToList()
    End Function

    <WebMethod()> _
    Public Function ObtenerListaProductosPorSuministro(ByVal param As String, ByVal pAlmacen As Integer, ByVal pTipoSuministro As Integer) As List(Of ProductoFiltrado)
        Dim lista = Productos.ObtenerPorSuministro(pAlmacen, pTipoSuministro)

        Dim listFiltrado = lista.Where(Function(p) p.Descripcion.ToLower().Contains(param.ToLower())).Take(20).OrderBy(Function(p) p.Correlativo)
        Return listFiltrado.ToList()
    End Function

    <WebMethod()> _
    Public Function ObtenerProducto(ByVal prefijo As String, ByVal areaTecnica As String, ByVal grupoUaci As String) As List(Of String)
        Dim miComponente As New cSUMINISTROS
        Dim dt As New DataTable
        Dim idUt, gu As Integer
        idUt = CType(areaTecnica, Integer)
        gu = CType(grupoUaci, Integer)
        dt = miComponente.obtenerSuministroPorUTyGUwithCorrProducto(idUt, gu, prefijo).Tables(0)


        Dim dv As New DataView(dt, "CORRPRODUCTO LIKE '%" & prefijo & "%'", "CORRPRODUCTO", DataViewRowState.CurrentRows)
        Dim uniqueTable As DataTable = dv.ToTable(True, "CORRPRODUCTO") ', "NOMBRE", "TextField")

        dv = New DataView(uniqueTable)
        dv.Sort = "CORRPRODUCTO"
        Dim items As New List(Of String)
        For Each dr As DataRowView In dv
            items.Add(prefijo & dr("CORRPRODUCTO").ToString.Substring(prefijo.Length))
        Next
        Return items
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function GetANIOProcesoCompra(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
        Dim objProcedoCompra As New cPROCESOCOMPRAS
        Dim dtProcesoCompra As DataTable
        Dim objIndices As New cIndices
        Dim dsIndice As New DataSet
        Dim values As New List(Of CascadingDropDownNameValue)()
        Try
            dtProcesoCompra = objProcedoCompra.ObtenerDataSetPorId("619").Tables(0)
            ' If IsNothing(Session("DSIndiceMR")) Then
            Session("DSIndiceMR") = objIndices.ObtenerDataSetPorId(619)
            dtProcesoCompra.Columns.Add("TextField")
            'dtProcesoCompra.Columns("TextField").Expression = " isnull(IdProcesoCompra,0) + '- ' + isnull(CODIGOLICITACION,0) + '- ' + isnull(TITULOLICITACION,'-')"
            CType(Session("DSIndiceMR"), DataSet).Tables.Add(dtProcesoCompra.Copy)
            CType(Session("DSIndiceMR"), DataSet).Relations.Add("ProcesoCompra_Indices", CType(Session("DSIndiceMR"), DataSet).Tables("Table").Columns("IdProcesoCompra"), CType(Session("DSIndiceMR"), DataSet).Tables("SP_GET_INFO_INDICADORES_MR").Columns("IdProcesoCompra"))
            ' End If
            dsIndice = CType(Session("DSIndiceMR"), DataSet)


            If Not dsIndice.Tables("SP_GET_INFO_INDICADORES_MR").Columns.Contains("TextField") Then
                dsIndice.Tables("SP_GET_INFO_INDICADORES_MR").Columns.Add("TextField")
            End If
            For Each fb As DataRow In dsIndice.Tables("SP_GET_INFO_INDICADORES_MR").Rows
                If IsDate(fb("AUFECHACREACION")) Then
                    fb.BeginEdit()
                    fb("TextField") = CDate(fb("AUFECHACREACION")).Year
                    fb.EndEdit()
                End If
                If fb("AUFECHACREACION").ToString = "" Then
                    fb.BeginEdit()
                    fb("TextField") = "SIN-FECHA"
                    fb.EndEdit()
                End If
            Next
            'dsIndice.Tables("Table").Columns("TextField").Expression = "date"
            Dim vista As New DataView(dsIndice.Tables("SP_GET_INFO_INDICADORES_MR"))



            ' vista.RowFilter = "YEAR(AUFECHACREACION)=" & iValor
            Dim uniqueTable As DataTable = vista.ToTable(True, "TextField")
            Dim FILAPRV As DataRow = uniqueTable.NewRow
            If Not uniqueTable.Rows.Count = 0 Then
                ' FILAPRV("IDPROVEEDOR") = "-1"
                'FILAPRV("NOMBREPRV") = "MOSTRAR TODOS LOS AÑOS"
                FILAPRV("TextField") = "TODOS"
                uniqueTable.Rows.Add(FILAPRV)
            End If
            vista = New DataView(uniqueTable)
            vista.Sort = "TextField"



            For Each dr As DataRowView In vista
                If Not dr("TextField").ToString() = "" Then
                    Dim sTextField As String = dr("TextField").ToString()
                    Dim iValue As String = dr("TextField").ToString()
                    values.Add(New CascadingDropDownNameValue(sTextField, iValue.ToString()))
                End If
            Next

        Catch ex As Exception
            values.Add(New CascadingDropDownNameValue(ex.ToString, "-1"))
        End Try
        Return values.ToArray()

    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function GetProcesoCompra(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
        Dim objProcedoCompra As New cPROCESOCOMPRAS
        'Dim dtProcesoCompra As DataTable
        Dim objIndices As New cIndices
        Dim dsIndice As New DataSet
        Dim values As New List(Of CascadingDropDownNameValue)()
        Try

            If Not CType(Session("DSIndiceMR"), DataSet).Tables("Table").Columns.Contains("TextField") Then
                CType(Session("DSIndiceMR"), DataSet).Tables("Table").Columns.Add("TextField")
            End If
            CType(Session("DSIndiceMR"), DataSet).Tables("Table").Columns("TextField").Expression = " isnull(IdProcesoCompra,0) + '- ' + isnull(CODIGOLICITACION,0) + '- ' + isnull(TITULOLICITACION,'-')"
            dsIndice = CType(Session("DSIndiceMR"), DataSet)


            Dim kv As StringDictionary = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)
            Dim iValor As String
            If Not kv.ContainsKey("ANIOPROCESOCOMPRA") Then
                Return Nothing
            End If
            iValor = kv("ANIOPROCESOCOMPRA")
            Dim CodTem As String = 0
            For Each drParen As DataRow In dsIndice.Tables("Table").Rows

                For Each drowIndi As DataRow In drParen.GetChildRows("ProcesoCompra_Indices")
                    If Not drParen("IdProcesoCompra") = CodTem Then
                        CodTem = drParen("IdProcesoCompra")
                        If iValor = "TODOS" Then
                            Dim sTextField As String = drParen("TextField").ToString()
                            Dim iIDProceso As Integer = CInt(drParen("IdProcesoCompra").ToString())
                            values.Add(New CascadingDropDownNameValue(sTextField, iIDProceso.ToString()))
                        ElseIf iValor = "SIN-FECHA" Then
                            If drParen("FECHAINICIOPROCESOCOMPRA").ToString = "" Then
                                Dim sTextField As String = drParen("TextField").ToString()
                                Dim iIDProceso As Integer = CInt(drParen("IdProcesoCompra").ToString())
                                values.Add(New CascadingDropDownNameValue(sTextField, iIDProceso.ToString()))
                            End If
                        ElseIf IsDate(drParen("FECHAINICIOPROCESOCOMPRA")) Then
                            If CDate(drParen("FECHAINICIOPROCESOCOMPRA")).Year.ToString = iValor.ToString Then
                                Dim sTextField As String = drParen("TextField").ToString()
                                Dim iIDProceso As Integer = CInt(drParen("IdProcesoCompra").ToString())
                                values.Add(New CascadingDropDownNameValue(sTextField, iIDProceso.ToString()))
                            End If
                        End If
                    End If
                Next
            Next


        Catch ex As Exception
            values.Add(New CascadingDropDownNameValue(ex.ToString, "-1"))
        End Try
        Return values.ToArray()

    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function GetProveedor(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()

        Dim objIndices As New cIndices
        Dim dtProveedor As DataTable
        Dim values As New List(Of CascadingDropDownNameValue)()
        Try
            If IsNothing(Session("DSIndiceMR")) Then
                Session("DSIndiceMR") = objIndices.ObtenerDataSetPorId(619)
            End If
            dtProveedor = CType(Session("DSIndiceMR"), DataSet).Tables("SP_GET_INFO_INDICADORES_MR")

            'dtProveedor = objIndices.ObtenerDataSetPorId(619).Tables(0)
            Dim kv As StringDictionary = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)
            Dim iValor As Integer
            If Not kv.ContainsKey("PROCESOCOMPRA") OrElse Not Int32.TryParse(kv("PROCESOCOMPRA"), iValor) Then
                Return Nothing
            End If
            If Not dtProveedor.Columns.Contains("TextField") Then
                dtProveedor.Columns.Add("TextField")
            End If
            dtProveedor.Columns("TextField").Expression = "isnull(IDPROVEEDOR,0) + '- ' + isnull(NOMBREPRV,'-')"
            ' dtProveedor.Columns("TextField").Expression = "isnull(IDPROVEEDOR,0) + '- ' + isnull(NOMBREPRV,'-')"
            Dim vista As New DataView(dtProveedor)



            vista.RowFilter = "IdProcesoCompra=" & iValor
            Dim uniqueTable As DataTable = vista.ToTable(True, "IDPROVEEDOR", "NOMBREPRV", "TextField")
            Dim FILAPRV As DataRow = uniqueTable.NewRow
            If Not uniqueTable.Rows.Count = 0 Then
                FILAPRV("IDPROVEEDOR") = "-1"
                FILAPRV("NOMBREPRV") = "MOSTRAR TODOS LOS PROVEEDORES"
                FILAPRV("TextField") = "-1- MOSTRAR TODOS LOS PROVEEDORES"
                uniqueTable.Rows.Add(FILAPRV)
            End If
            vista = New DataView(uniqueTable)
            vista.Sort = "IDPROVEEDOR"



            For Each dr As DataRowView In vista
                Dim sTextField As String = dr("TextField").ToString()
                Dim iValue As Integer = CInt(dr("IDPROVEEDOR").ToString())
                values.Add(New CascadingDropDownNameValue(sTextField, iValue.ToString()))
            Next
        Catch ex As Exception
            values.Add(New CascadingDropDownNameValue(ex.Message, "-1"))
        End Try
        Return values.ToArray()
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function GetAlmacen(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()


        Dim objIndices As New cIndices
        Dim dtAlmacen As DataTable
        Dim values As New List(Of CascadingDropDownNameValue)()
        Try


            'dtAlmacen = objIndices.ObtenerDataSetPorId(619).Tables(0)
            Dim kv As StringDictionary = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)
            Dim iValor, iValorPrv, iValorCtr As Integer
            If Not kv.ContainsKey("PROCESOCOMPRA") OrElse Not Int32.TryParse(kv("PROCESOCOMPRA"), iValor) Then
                Return Nothing
            End If
            If Not kv.ContainsKey("PROVEEDOR") OrElse Not Int32.TryParse(kv("PROVEEDOR"), iValorPrv) Then
                Return Nothing
            End If

            If Not kv.ContainsKey("CONTRATO") OrElse Not Int32.TryParse(kv("CONTRATO"), iValorCtr) Then
                Return Nothing
            End If

            If IsNothing(Session("DSIndiceMR")) Then
                Exit Try
                'Session("DSIndiceMR") = objIndices.ObtenerDataSetPorId(619)
            End If
            dtAlmacen = CType(Session("DSIndiceMR"), DataSet).Tables("SP_GET_INFO_INDICADORES_MR")
            If Not dtAlmacen.Columns.Contains("TextField") Then
                dtAlmacen.Columns.Add("TextField")
            End If
            dtAlmacen.Columns("TextField").Expression = "isnull(IDALMACEN,0) + '- ' + isnull(NOMBRE,'-')"

            Dim vista As New DataView(dtAlmacen)
            vista.RowFilter = "IdProcesoCompra=" & iValor & " and (IDPROVEEDOR=" & iValorPrv & " OR " & iValorPrv & "=-1) and (IDCONTRATO=" & iValorCtr & " OR " & iValorCtr & "=-1)"

            Dim uniqueTable As DataTable = vista.ToTable(True, "IDALMACEN", "NOMBRE", "TextField")
            Dim FILAALM As DataRow = uniqueTable.NewRow
            If Not uniqueTable.Rows.Count = 0 Then
                FILAALM("IDALMACEN") = "-1"
                FILAALM("NOMBRE") = "MOSTRAR TODOS LOS ALMACENES"
                FILAALM("TextField") = "-1- MOSTRAR TODOS LOS ALMACENES"
                uniqueTable.Rows.Add(FILAALM)
            End If
            vista = New DataView(uniqueTable)
            vista.Sort = "IDALMACEN"


            For Each dr As DataRowView In vista
                Dim sTextField As String = dr("TextField").ToString()
                Dim iValue As Integer = CInt(dr("IDALMACEN").ToString())
                values.Add(New CascadingDropDownNameValue(sTextField, iValue.ToString()))
            Next
        Catch ex As Exception
            values.Add(New CascadingDropDownNameValue(ex.Message, "-1"))
        End Try
        Return values.ToArray()

    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function GetContratos(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()


        Dim objIndices As New cIndices
        Dim dtAlmacen As DataTable
        Dim values As New List(Of CascadingDropDownNameValue)()
        Try
            If IsNothing(Session("DSIndiceMR")) Then
                Session("DSIndiceMR") = objIndices.ObtenerDataSetPorId(619)
            End If

            dtAlmacen = CType(Session("DSIndiceMR"), DataSet).Tables("SP_GET_INFO_INDICADORES_MR")
            'dtAlmacen = objIndices.ObtenerDataSetPorId(619).Tables(0)
            Dim kv As StringDictionary = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)
            Dim iValor, iValorPrv As Integer
            If Not kv.ContainsKey("PROCESOCOMPRA") OrElse Not Int32.TryParse(kv("PROCESOCOMPRA"), iValor) Then
                Return Nothing
            End If
            If Not kv.ContainsKey("PROVEEDOR") OrElse Not Int32.TryParse(kv("PROVEEDOR"), iValorPrv) Then
                Return Nothing
            End If



            If Not dtAlmacen.Columns.Contains("TextField") Then
                dtAlmacen.Columns.Add("TextField")
            End If
            dtAlmacen.Columns("TextField").Expression = "isnull(IDCONTRATO,0) + '- ' + isnull(NUMEROCONTRATO,'-')"

            Dim vista As New DataView(dtAlmacen)
            vista.RowFilter = "IdProcesoCompra=" & iValor & " and (IDPROVEEDOR=" & iValorPrv & " OR " & iValorPrv & "=-1)"

            Dim uniqueTable As DataTable = vista.ToTable(True, "IDCONTRATO", "NUMEROCONTRATO", "TextField")
            If Not uniqueTable.Rows.Count = 0 Then
                Dim FILAALM As DataRow = uniqueTable.NewRow
                FILAALM("IDCONTRATO") = "-1"
                FILAALM("NUMEROCONTRATO") = "MOSTRAR TODOS LOS CONTRATOS"
                FILAALM("TextField") = "-1- MOSTRAR TODOS LOS CONTRATOS"
                uniqueTable.Rows.Add(FILAALM)
            End If
            vista = New DataView(uniqueTable)
            vista.Sort = "IDCONTRATO"


            For Each dr As DataRowView In vista
                Dim sTextField As String = dr("TextField").ToString()
                Dim iValue As Integer = CInt(dr("IDCONTRATO").ToString())
                values.Add(New CascadingDropDownNameValue(sTextField, iValue.ToString()))
            Next
        Catch ex As Exception
            values.Add(New CascadingDropDownNameValue(ex.Message, "-1"))
        End Try
        Return values.ToArray()

    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function GetSuministros(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
        Dim miComponente As New cSUMINISTROS
        Dim dt As New DataTable
        Dim idUT, GU As Integer
        idUT = Session("IDSUMINISTROCDD")
        GU = Session("GRUPOUACICDD")
        dt = miComponente.obtenerSuministroPorUTyGU(idUT, GU).Tables(0)
        Dim values As New List(Of CascadingDropDownNameValue)()
        Try
            For Each dr As DataRow In dt.Rows
                Dim sTextField As String = dr("DESCSUMINISTRO").ToString()
                Dim iIDProceso As Integer = CInt(dr("IDSUMINISTRO").ToString())
                values.Add(New CascadingDropDownNameValue(sTextField, iIDProceso.ToString()))
            Next
        Catch ex As Exception
            values.Add(New CascadingDropDownNameValue(ex.ToString, "-1"))
        End Try
        Return values.ToArray()

    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function GetGrupo(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
        Dim miComponente As New cGRUPOS
        Dim objIndices As New cIndices
        Dim dt As DataTable
        'dt = objIndices.ObtenerDataSetPorId(619).Tables(0)
        Dim kv As StringDictionary = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)
        Dim iValor As Integer
        If Not kv.ContainsKey("SUMINISTROS") OrElse Not Int32.TryParse(kv("SUMINISTROS"), iValor) Then
            Return Nothing
        End If
        'dtProveedor.Columns.Add("TextField")
        'dtProveedor.Columns("TextField").Expression = "isnull(IDPROVEEDOR,0) + '- ' + isnull(NOMBREPRV,'-')"
        Dim idUT, GU As Integer
        idUT = Session("IDSUMINISTROCDD")
        GU = Session("GRUPOUACICDD")
        dt = miComponente.ObtenerListaPorUTyGU(iValor, idUT, GU).Tables(0)
        Dim values As New List(Of CascadingDropDownNameValue)()
        Try

            For Each dr As DataRow In dt.Rows
                Dim sTextField As String = dr("DESCGRUPO").ToString()
                Dim iValue As Integer = CInt(dr("IDGRUPO").ToString())
                values.Add(New CascadingDropDownNameValue(sTextField, iValue.ToString()))
            Next
        Catch ex As Exception
            values.Add(New CascadingDropDownNameValue(ex.Message, "-1"))
        End Try
        Return values.ToArray()
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function GetSubGrupo(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
        Dim objIndices As New cIndices
        Dim dt As DataTable
        'dt = objIndices.ObtenerDataSetPorId(619).Tables(0)
        Dim kv As StringDictionary = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)
        Dim iValor As Integer
        If Not kv.ContainsKey("GRUPO") OrElse Not Int32.TryParse(kv("GRUPO"), iValor) Then
            Return Nothing
        End If
        'dtProveedor.Columns.Add("TextField")
        'dtProveedor.Columns("TextField").Expression = "isnull(IDPROVEEDOR,0) + '- ' + isnull(NOMBREPRV,'-')"
        Dim idUT, GU As Integer
        idUT = Session("IDSUMINISTROCDD")
        GU = Session("GRUPOUACICDD")
        Dim miComponente As New cSUBGRUPOS
        dt = miComponente.ObtenerListaPorGrupoUTYGU(iValor, idUT, GU).Tables(0)
        Dim values As New List(Of CascadingDropDownNameValue)()
        Try

            For Each dr As DataRow In dt.Rows
                Dim sTextField As String = dr("DESCSUBGRUPO").ToString()
                Dim iValue As Integer = CInt(dr("IDSUBGRUPO").ToString())
                values.Add(New CascadingDropDownNameValue(sTextField, iValue.ToString()))
            Next
        Catch ex As Exception
            values.Add(New CascadingDropDownNameValue(ex.Message, "-1"))
        End Try
        Return values.ToArray()
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function GetCatalogoProducto(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
        Dim objIndices As New cIndices
        Dim dt As DataTable
        Dim kv As StringDictionary = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)
        Dim iValor As Integer
        If Not kv.ContainsKey("SUBGRUPO") OrElse Not Int32.TryParse(kv("SUBGRUPO"), iValor) Then
            Return Nothing
        End If
        Dim idUT, GU As Integer
        idUT = Session("IDSUMINISTROCDD")
        GU = Session("GRUPOUACICDD")
        Dim mComponente As New cCATALOGOPRODUCTOS
        dt = mComponente.ObtenerCatalogoProductosPorUTyGU(iValor, idUT, GU).Tables(0)
        Dim values As New List(Of CascadingDropDownNameValue)()
        Try

            For Each dr As DataRow In dt.Rows
                Dim sTextField As String = dr("DESCLARGO").ToString()
                Dim iValue As Integer = CInt(dr("IDPRODUCTO").ToString())
                values.Add(New CascadingDropDownNameValue(sTextField, iValue.ToString()))
            Next
        Catch ex As Exception
            values.Add(New CascadingDropDownNameValue(ex.Message, "-1"))
        End Try
        Return values.ToArray()
    End Function



    <WebMethod(EnableSession:=True)> _
    Public Function GetUnidadTecnica(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
        Dim objIndices As New cIndices
        '
        Dim miComponente As New cDEPENDENCIAS
        Dim Lista As ABASTECIMIENTOS.ENTIDADES.listaDEPENDENCIAS

        Lista = miComponente.ObtenerLista(1)

        Dim values As New List(Of CascadingDropDownNameValue)()
        Try

            For fila As Integer = 0 To Lista.Count - 1
                Dim sTextField As String = Lista(fila).NOMBRE.ToString()
                Dim iValue As String = Lista(fila).IDDEPENDENCIA.ToString()
                values.Add(New CascadingDropDownNameValue(sTextField, iValue.ToString()))
            Next
        Catch ex As Exception
            values.Add(New CascadingDropDownNameValue(ex.Message, "-1"))
        End Try
        Return values.ToArray()
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function GetUnidadTecnicaBySuministro(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
        Dim objIndices As New cIndices
        '
        'Dim miComponente As New cDEPENDENCIAS
        '

        'Dim Lista As ABASTECIMIENTOS.ENTIDADES.listaDEPENDENCIAS

        'Lista = miComponente.ObtenerLista()
        Dim kv As StringDictionary = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)
        Dim iValor As Integer
        If Not kv.ContainsKey("TIPOSUMINISTRO") OrElse Not Int32.TryParse(kv("TIPOSUMINISTRO"), iValor) Then
            Return Nothing
        End If
        Dim cc As New cCATALOGOPRODUCTOS
        Dim DT As New DataTable
        DT = cc.ObtenerAreaTecnicaByGRUPOUACI(-1).Tables(0)
        Dim values As New List(Of CascadingDropDownNameValue)()
        Try

            For fila As Integer = 0 To DT.Rows.Count - 1 'Lista.Count - 1
                Dim sTextField As String = DT.Rows(fila)("NOMBRE").ToString 'Lista(fila).NOMBRE.ToString()
                Dim iValue As String = DT.Rows(fila)("IDDEPENDENCIA").ToString 'Lista(fila).IDDEPENDENCIA.ToString()
                values.Add(New CascadingDropDownNameValue(sTextField, iValue.ToString()))
            Next
        Catch ex As Exception
            values.Add(New CascadingDropDownNameValue(ex.Message, "-1"))
        End Try
        Return values.ToArray()
    End Function


    <WebMethod(EnableSession:=True)> _
    Public Function GetGRUPOUACI(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
        Dim objIndices As New cIndices
        Dim dt As DataTable
        'dt = objIndices.ObtenerDataSetPorId(619).Tables(0)
        Dim kv As StringDictionary = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)
        Dim iValor As Integer
        If Not kv.ContainsKey("AREATECNICA") OrElse Not Int32.TryParse(kv("AREATECNICA"), iValor) Then
            Return Nothing
        End If
        Dim cc As New cCATALOGOPRODUCTOS
        'Dim DS As New Data.DataSet
        dt = cc.ObtenerTipoUACI(iValor).Tables(0)

        'dtProveedor.Columns.Add("TextField")
        'dtProveedor.Columns("TextField").Expression = "isnull(IDPROVEEDOR,0) + '- ' + isnull(NOMBREPRV,'-')"
        'Dim idUT, GU As Integer
        'idUT = Session("IDSUMINISTROCDD")
        'GU = Session("GRUPOUACICDD")

        'Dim mComponente As New cCATALOGOPRODUCTOS
        'dt = mComponente.ObtenerCatalogoProductosPorUTyGU(iValor, idUT, GU).Tables(0)
        Dim values As New List(Of CascadingDropDownNameValue)()
        Try

            For Each dr As DataRow In dt.Rows
                Dim sTextField As String = dr("GRUPOUACI").ToString()
                Dim iValue As Integer = CInt(dr("IDGRUPO").ToString())
                values.Add(New CascadingDropDownNameValue(sTextField, iValue.ToString()))
            Next
        Catch ex As Exception
            values.Add(New CascadingDropDownNameValue(ex.Message, "-1"))
        End Try
        Return values.ToArray()
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function GetGRUPOUACIALL(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
        Dim objIndices As New cIndices
        Dim dt As DataTable
        'dt = objIndices.ObtenerDataSetPorId(619).Tables(0)

        Dim cc As New cCATALOGOPRODUCTOS
        'Dim DS As New Data.DataSet
        dt = cc.ObtenerTipoUACI(-1).Tables(0)

        'dtProveedor.Columns.Add("TextField")
        'dtProveedor.Columns("TextField").Expression = "isnull(IDPROVEEDOR,0) + '- ' + isnull(NOMBREPRV,'-')"
        'Dim idUT, GU As Integer
        'idUT = Session("IDSUMINISTROCDD")
        'GU = Session("GRUPOUACICDD")

        'Dim mComponente As New cCATALOGOPRODUCTOS
        'dt = mComponente.ObtenerCatalogoProductosPorUTyGU(iValor, idUT, GU).Tables(0)
        Dim values As New List(Of CascadingDropDownNameValue)()
        Try

            For Each dr As DataRow In dt.Rows
                Dim sTextField As String = dr("GRUPOUACI").ToString()
                Dim iValue As Integer = CInt(dr("IDGRUPO").ToString())
                values.Add(New CascadingDropDownNameValue(sTextField, iValue.ToString()))
            Next
        Catch ex As Exception
            values.Add(New CascadingDropDownNameValue(ex.Message, "-1"))
        End Try
        Return values.ToArray()
    End Function



    <WebMethod(EnableSession:=True)> _
    Public Function CambiarClave(ByVal nuevaClave As String) As String()
        Dim clave As String
        Dim result As New List(Of String)
        Dim encrypted As String
        encrypted = Crypto.EncryptTripleDES(nuevaClave, "ABAS") 'encripta la clave ingresada en formato MD5
        clave = Crypto.GetMD5Hash(encrypted)
        Try
            If Membresia.CambiarClave(clave) Then
                result.Add("ok")
                result.Add("La contraseña ha sido actualizada. Intente ingresar nuevamente con su nueva contraseña.")
            Else
                result.Add("error")
                result.Add("Usuario no existe.")
            End If
        Catch ex As Exception
            result.Add("Ocurrio un error. Intente nuevamente. Mensaje: " + ex.Message)
        End Try

        Return result.ToArray()
    End Function
End Class
