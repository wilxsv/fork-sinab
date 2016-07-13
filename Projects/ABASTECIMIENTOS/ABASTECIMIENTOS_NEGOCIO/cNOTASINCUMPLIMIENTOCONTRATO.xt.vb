Partial Class cNOTASINCUMPLIMIENTOCONTRATO

    ''' <summary>
    ''' recupera la informacion necesaria a mostrar en la elaboracion de la nota de incumplimiento
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad del tipo NOTASINCUMPLIMIENTOSCONTRATOS
    ''' <returns>
    ''' Numero de registros afectados por la operacion
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function RecuperarInformacionNotas(ByRef aEntidad As NOTASINCUMPLIMIENTOCONTRATO) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.RecuperarInformacionNota(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Agregar nota de incumplimiento nueva
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad de tipo NOTAINCUMPLIMIENTOCONTRATO
    ''' <returns>
    ''' numero de registros afectados con la transacion
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history>
    Public Function AgregarNOTAINCUMPLIMIENTOCONTRATO(ByVal aEntidad As NOTASINCUMPLIMIENTOCONTRATO) As Integer
        Try
            Return mDb.Agregar(aEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' valida la existencia de notas de incumplimiento de contrato
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDCONTRATO"></param> identificador de contrato
    ''' <param name="IDPROVEEDOR"></param> identificador de proveedor
    ''' <returns>
    ''' verdadero si existe la nota
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ValidarExistenciaNotaContrato(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONTRATO As Int32, ByVal IDPROVEEDOR As Int32) As Boolean
        Try
            Return mDb.ValidarExistenciaNotaContrato(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' obtener identificador de nota nueva
    ''' </summary>
    ''' <param name="aEntidad"></param> entidad tipo NOTASINCUMPLIMIENTOCONTRATO
    ''' <returns>
    ''' Identificador de nota 
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' '''  <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ObtenerIdNota(ByRef aEntidad As NOTASINCUMPLIMIENTOCONTRATO) As Integer
        Try
            Dim liRet As Integer
            liRet = mDb.ObtenerID(aEntidad)
            Return liRet
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Dataset con los renglones del contrato
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDCONTRATO"></param> identificador de contrato
    ''' <param name="IDPROVEEDOR"></param> identificador de proveedor
    ''' <returns>
    ''' Dataset con la informacion solicitada
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function DatasetRenglonesContrato(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONTRATO As Int32, ByVal IDPROVEEDOR As Int32) As DataSet
        Return mDb.DatasetRenglonesContrato(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR)
    End Function

    ''' <summary>
    ''' dataset con los renglones de la modificativa de contrato
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <param name="IDCONTRATO"></param> identificador de contrato
    ''' <param name="IDPROVEEDOR"></param> identificdor de proveedor
    ''' <returns>
    ''' dataset con la informacion solicitado
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: ]      Creado
    ''' </history> 
    Public Function DatasetRenglonesModificativaContrato(ByVal IDESTABLECIMIENTO As Int32, ByVal IDCONTRATO As Int32, ByVal IDPROVEEDOR As Int32) As DataSet
        Return mDb.DatasetRenglonesModificativaContrato(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR)
    End Function

    ''' <summary>
    ''' crea la estructura del dataset de incumplimiento de contratos necesaria para el reporte
    ''' </summary>
    ''' <returns>
    ''' Estructura de dataset vacia
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: ]      Creado
    ''' </history> 
    Public Function CreacionDataSetIncumplimientoContrato() As DataSet
        Dim dst As New DataSet
        Dim dt As New DataTable

        'creando tabla del dataset
        dt = New DataTable("INCUMPLIMIENTOCONTRATO")
        'creando etructura de tabla
        dt.Columns.Add("IDESTABLECIMIENTO", System.Type.GetType("System.Int32"))
        dt.Columns.Add("IDCONTRATO", System.Type.GetType("System.Int32"))
        dt.Columns.Add("IDPROVEEDOR", System.Type.GetType("System.Int32"))
        dt.Columns.Add("IDRENGLON", System.Type.GetType("System.Int32"))
        dt.Columns.Add("IDPROCESO", System.Type.GetType("System.Int32"))
        dt.Columns.Add("TITULONOTA", System.Type.GetType("System.String"))
        dt.Columns.Add("NOMBREDIRIGIDO", System.Type.GetType("System.String"))
        dt.Columns.Add("CARGODIRIGIDO", System.Type.GetType("System.String"))
        dt.Columns.Add("NOMBREENVIA", System.Type.GetType("System.String"))
        dt.Columns.Add("CARGOENVIA", System.Type.GetType("System.String"))
        dt.Columns.Add("FECHAENTREGA", System.Type.GetType("System.DateTime"))
        dt.Columns.Add("IDNOTA", System.Type.GetType("System.Int32"))
        dt.Columns.Add("NUMEROCONTRATO", System.Type.GetType("System.String"))
        dt.Columns.Add("TIPOLICITACION", System.Type.GetType("System.String"))
        dt.Columns.Add("MONTOCONTRATO", System.Type.GetType("System.Double"))
        dt.Columns.Add("CODIGOLICITACION", System.Type.GetType("System.String"))
        dt.Columns.Add("DESCRIPCIONLICITACION", System.Type.GetType("System.String"))
        dt.Columns.Add("PROVEEDOR", System.Type.GetType("System.String"))
        dt.Columns.Add("ENTREGA", System.Type.GetType("System.Int16"))
        dt.Columns.Add("ALMACEN", System.Type.GetType("System.String"))
        dt.Columns.Add("CANTIDADNOENTREGADA", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("CANTIDADCONATRASO", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("DIASATRASO", System.Type.GetType("System.Int16"))
        dt.Columns.Add("IDPRODUCTO", System.Type.GetType("System.Int32"))
        dt.Columns.Add("CODIGOPRODUCTO", System.Type.GetType("System.String"))
        dt.Columns.Add("LOTE", System.Type.GetType("System.String"))
        dt.Columns.Add("EXPIRA", System.Type.GetType("System.DateTime"))
        dt.Columns.Add("PRECIO", System.Type.GetType("System.Double"))
        dt.Columns.Add("MONTONOENTREGADO", System.Type.GetType("System.Double"))
        dt.Columns.Add("MONTOCONATRASO", System.Type.GetType("System.Double"))

        'creando dataset
        dst.Tables.Add(dt)

        Return dst

    End Function

    ''' <summary>
    ''' agrega fila a la estructura de dataset creada
    ''' </summary>
    ''' <param name="dstt"></param> estructura de dataset
    ''' <param name="dtb"></param> estrucutra de datatale
    ''' <param name="mEntidad"></param> entidad tipo INCUMPLIMINEOTCONTRATO
    ''' <returns>
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: ]      Creado
    ''' </history> 

    Public Function CrearEntregaIncumplimiento(ByRef dstt As DataSet, ByRef dtb As DataTable, ByRef mEntidad As INCUMPLIMIENTOCONTRATO) As DataSet
        Dim nr As DataRow
        Dim dt As DataTable
        Dim dst As DataSet

        dst = dstt
        dt = dtb
        'creando y gregando nueva fila
        nr = dt.NewRow
        nr("IDESTABLECIMIENTO") = mEntidad.IDESTABLECIMIENTO
        nr("IDCONTRATO") = mEntidad.IDCONTRATO
        nr("IDPROVEEDOR") = mEntidad.IDPROVEEDOR
        nr("IDRENGLON") = mEntidad.IDRENGLON
        nr("IDPROCESO") = mEntidad.IDPROCESO
        nr("TITULONOTA") = mEntidad.TITULONOTA
        nr("NOMBREDIRIGIDO") = mEntidad.NOMBREDIRIGIDO
        nr("CARGODIRIGIDO") = mEntidad.CARGODIRIGIDO
        nr("NOMBREENVIA") = mEntidad.NOMBREENVIA
        nr("CARGOENVIA") = mEntidad.CARGOENVIA
        nr("FECHAENTREGA") = mEntidad.FECHAENTREGA
        nr("IDNOTA") = mEntidad.IDNOTA
        nr("NUMEROCONTRATO") = mEntidad.NUMEROCONTRATO
        nr("TIPOLICITACION") = mEntidad.TIPOLICITACION
        nr("MONTOCONTRATO") = mEntidad.MONTOCONTRATO
        nr("CODIGOLICITACION") = mEntidad.CODIGOLICITACION
        nr("DESCRIPCIONLICITACION") = mEntidad.DESCRIPCIONLICITACION
        nr("PROVEEDOR") = mEntidad.PROVEEDOR
        nr("ENTREGA") = mEntidad.ENTREGA
        nr("ALMACEN") = mEntidad.ALMACEN
        nr("CANTIDADNOENTREGADA") = mEntidad.CANTIDADNOENTREGADA
        nr("CANTIDADCONATRASO") = mEntidad.CANTIDADCONATRASO
        nr("DIASATRASO") = mEntidad.DIASATRASO
        nr("IDPRODUCTO") = mEntidad.IDPRODUCTO
        nr("CODIGOPRODUCTO") = mEntidad.CODIGOPRODUCTO
        nr("LOTE") = mEntidad.LOTE
        nr("EXPIRA") = mEntidad.EXPIRA
        nr("PRECIO") = mEntidad.PRECIO
        nr("MONTONOENTREGADO") = mEntidad.MONTONOENTREGADO
        nr("MONTOCONATRASO") = mEntidad.MONTOCONATRASO
        dt.Rows.Add(nr)
        'creando dataset
        Return dstt
    End Function

    ''' <summary>
    ''' Validar el numero de informe si existe
    ''' </summary>
    ''' <param name="NUMEROINFORME"></param> numero de informe
    ''' <param name="IDESTABLECIMIENTO"></param> identificador de establecimiento
    ''' <returns>
    ''' verdadero si existe
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    '''     [Autor: Yessenia Henriquez]      Creado
    ''' </history> 
    Public Function ValidarNumeroInforme(ByVal NUMEROINFORME As String, ByVal IDESTABLECIMIENTO As Int32) As Boolean
        Return mDb.ValidarNumeroInforme(NUMEROINFORME, IDESTABLECIMIENTO)
    End Function

End Class
