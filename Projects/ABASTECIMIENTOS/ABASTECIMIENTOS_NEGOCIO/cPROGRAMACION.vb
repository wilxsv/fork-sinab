Imports ABASTECIMIENTOS.ENTIDADES

Public Class cPROGRAMACION

    Inherits controladorBase

    Private mDb As New dbPROGRAMACION()

    Public Function obtenerDsProgramacion(Optional ByVal estado As Integer = 0)

        Try
            Return mDb.obtenerDsProgramacion(estado)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function obtenerDsProgramacionEstablecimiento(ByVal IDESTABLECIMIENTO As Integer, Optional ByVal estado As Integer = 0, Optional ByVal IdRol As Integer = 0, Optional IDPROGRAMA As Integer = 0)

        Try
            Return mDb.obtenerDsProgramacionEstablecimiento(IDESTABLECIMIENTO, estado, IdRol, IDPROGRAMA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    'mostramos para iniciar ajustes-21032012-Mayra Martínez

    Public Function obtenerDsProgramacionEstablecimientoOtros(ByVal IDESTABLECIMIENTO As Integer, Optional ByVal estado As Integer = 0, Optional ByVal IdRol As Integer = 0)

        Try
            Return mDb.obtenerDsProgramacionEstablecimientoOtros(IDESTABLECIMIENTO, estado, IdRol)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function


    Public Function Actualizar(ByVal aEntidad As PROGRAMACION) As Integer

        Dim tran As New DistributedTransaction
        Dim j As Integer
        'Dim dbEntidad As New dbDISTRIBUCIONDETALLE

        Try

            Dim IDPROGRAMACION As Integer = aEntidad.IDPROGRAMACION
            'Se crea o modifica la programación
            Dim i As Integer = mDb.actualizarProgramacion(aEntidad, tran)

            'En caso de ser una nueva programación, se crea la lista de productos para ella con sus respectivos precios
            If IDPROGRAMACION = 0 Then
                i = mDb.agregarProgramacionProducto(aEntidad, tran)
                j = mDb.agregarListaHospitalesRegionesParaiso(aEntidad.IDPROGRAMACION, aEntidad.AUUSUARIOCREACION, tran)
                '    'Y todos los datos de los productos por establecimiento
                '    i = dbEntidad.agregarDistribucionDetalle(aEntidad, tran)

                If i > 0 Then
                    tran.Commit()
                    Return i
                Else
                    tran.Abort()
                    Return -1
                End If

            End If

            tran.Commit()

            Return i

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function obtenerProgramacionPorID(ByVal IDPROGRAMACION As Integer) As PROGRAMACION
        Try
            Return mDb.obtenerProgramacionPorID(IDPROGRAMACION)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerTotalProductosCeros(ByVal idProgramacion As Integer) As Integer

        Try
            Return mDb.obtenerTotalProductosCeros(idProgramacion)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    Public Function obtenerEstablecimientosAbiertos(ByVal idProgramacion As Integer) As Integer

        Try
            Return mDb.obtenerEstablecimientosAbiertos(idProgramacion)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    Public Function actualizarEstadoProgramacion(ByVal idProgramacion As Integer, ByVal estado As Integer, ByVal usuario As String) As Integer

        Dim tran As New DistributedTransaction

        Try

            'Actualizamos la programación
            Dim i As Integer = mDb.actualizarEstadoProgramacion(idProgramacion, estado, usuario, tran)

            If estado = 3 Then 'Creamos el universo de los medicamentos, asignando automáticamente los renglones y no definiendo entregas para c/u

                i = mDb.ingresarConsolidadoProgramacion(idProgramacion, usuario, tran)

            End If

            tran.Commit()
            Return i

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    Public Function obtenerEstadoProgramacionEstablecimiento(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer
        Try
            Return mDb.obtenerEstadoProgramacionEstablecimiento(IDPROGRAMACION, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function detalleEstadoProgramacion(ByVal idProgramacion As Integer) As DataSet
        Try
            Dim ds As DataSet = mDb.detalleEstadoProgramacion(idProgramacion)
            ds.Tables(0).TableName = "tblProgramacion"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function obtenerTotalEntregas(ByVal idProgramacion As Integer, Optional ByVal tabla As String = "SAB_URMIM_PROGRAMACIONENTREGA", Optional ByVal campo As String = "IDENTREGA") As Integer
        Try
            Dim i As Integer = mDb.obtenerTotalEntregas(idProgramacion, tabla, campo)
            Return i
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return 0
        End Try
    End Function

    Public Function actualizarTotalEntregas(ByVal eEntidad As PROGRAMACION) As Integer

        Dim tran As New DistributedTransaction

        Try
            mDb.actualizarTotalEntregas(eEntidad, tran)
            mDb.borrarEntregas(eEntidad.IDPROGRAMACION, tran, eEntidad.ENTREGAS)

            tran.Commit()
            Return 1

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function actualizarEntregas(ByVal idProgramacion As Integer, ByVal arr As ArrayList) As Integer

        Dim tran As New DistributedTransaction

        Try

            'Borremos
            mDb.borrarEntregas(idProgramacion, tran)


            For i As Integer = 0 To arr.Count - 1
                Dim eEntidad As ENTREGAPROGRAMACION = arr.Item(i)

                mDb.ingresarEntregaProgramacion(eEntidad, tran)

            Next

            tran.Commit()

            Return 1

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try


    End Function

    Public Function obtenerEntregasProgramacion(ByVal idProgramacion As Integer) As ArrayList

        Try
            Return mDb.obtenerEntregasProgramacion(idProgramacion)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return New ArrayList
        End Try

    End Function

    Public Function actualizarEntregasProgramacionProducto(ByVal idProgramacion As Integer, ByVal arr As ArrayList) As Integer

        Dim tran As New DistributedTransaction

        Try

            For i As Integer = 0 To arr.Count - 1
                Dim eEntidad As ENTREGAPROGRAMACION = arr.Item(i)

                mDb.actualizarEntregaProductoProgramacion(eEntidad, tran)

            Next

            tran.Commit()

            Return 1

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try


    End Function

    Public Function obtenerRenglonesEntrega(ByVal idProgramacion As Integer) As Integer

        Try
            Return mDb.obtenerRenglonesEntrega(idProgramacion)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return 0
        End Try

    End Function

    Public Function agregarObservacion(ByVal eEntidad As PROGRAMACIONPRODUCTO) As Integer


        Try

            'Primero obtenemos el siguiente correlativo
            Dim i As Integer = mDb.obtenerIdObservacion(eEntidad)
            eEntidad.IDOBSERVACION = i

            Return mDb.agregarObservacion(eEntidad)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    Public Function obtenerListaObservaciones(ByVal eEntidad As PROGRAMACIONPRODUCTO) As DataSet

        Try
            Dim ds As DataSet = mDb.obtenerListaObservaciones(eEntidad)
            ds.Tables(0).TableName = "dsTabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    '***************************************************************

    Public Function obtenerEstablecimientosProgramacion(ByVal IDPROGRAMACION As Integer) As DataSet

        Try
            Dim ds As DataSet = mDb.obtenerEstablecimientosProgramacion(IDPROGRAMACION)
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function agregarProgramacionEstablecimientos(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer, ByVal USUARIO As String) As Integer

        Try

            mDb.agregarProgramacionEstablecimientos(IDPROGRAMACION, IDESTABLECIMIENTO, USUARIO)

        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    Public Function eliminarProgramacionEstablecimiento(ByVal IDPROGRAMACION As Integer, ByVal IDESTABLECIMIENTO As Integer) As Integer

        Try
            Return mdb.eliminarProgramacionEstablecimiento(IDPROGRAMACION, IDESTABLECIMIENTO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return 0
        End Try

    End Function

    Public Function obtenerTotalEstablecimientosProgramacion(ByVal idProgramacion As Integer) As Integer

        Try
            Return mDb.obtenerTotalEstablecimientosProgramacion(idProgramacion)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    Public Function obtenerDsProgramacionDisponibles()

        Try
            Return mDb.obtenerDsProgramacionDisponible()
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function obtenerDsProgramacionListaID(ByVal lista)

        Try
            Return mDb.obtenerDsProgramacionListaID(lista)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Sub obtenerListaInconsistenciasProgramacion(ByVal idSuministro As Integer, ByVal lista As ArrayList, ByRef precios As ArrayList, ByRef entregas As ArrayList)

        Try
            Dim productos As New ArrayList

            Dim matrix As Array = mDb.obtenerListaInconsistenciasProgramacion(idSuministro, lista, productos)

            'Verificamos que todo esta bien. Columnas pares son para los precios, impares para las entregas
            'Dos tipos de inconsistencias. Para precios y para entregas
            'Dos variables de conteo. Una para cada una

            For i As Integer = 0 To productos.Count - 1

                Dim inconPrecios As Boolean = False
                Dim inconEntregas As Boolean = False

                Dim pr As Decimal = -2
                Dim ent As Decimal = -2

                Dim contPrecios As Integer = 0
                Dim contEntregas As Integer = 0

                Dim PrimerPrecio As Decimal = 0
                Dim PrimerEntrega As Decimal = 0

                'Pares e impares
                'Pares multiplicamos * 2
                'Impares multiplicamos * 2, luego sumamos 1
                For k As Integer = 0 To lista.Count - 1

                    If pr = -2 Then pr = matrix(i, k * 2)
                    If ent = -2 Then ent = matrix(i, (k * 2) + 1)

                    If matrix(i, k * 2) <> -1 Then
                        If contPrecios = 0 Then
                            PrimerPrecio = matrix(i, k * 2)
                            contPrecios += 1
                        Else
                            If Not matrix(i, k * 2) = PrimerPrecio Then
                                contPrecios += 1
                            End If
                        End If


                    End If

                    If matrix(i, (k * 2) + 1) <> -1 Then
                        If contEntregas = 0 Then
                            PrimerEntrega = matrix(i, (k * 2) + 1)
                            contEntregas += 1
                        Else
                            If Not matrix(i, (k * 2) + 1) = PrimerEntrega Then
                                contEntregas += 1
                            End If
                        End If
                    End If

                    If pr <> matrix(i, k * 2) Then inconPrecios = True
                    If ent <> matrix(i, (k * 2) + 1) Then inconEntregas = True

                Next

                'Aqui hacemos todo el windup
                If contPrecios <> 1 And inconPrecios = True Then
                    precios.Add(productos(i))
                End If

                If contEntregas <> 1 And inconEntregas = True Then
                    entregas.Add(productos(i))
                End If

            Next

        Catch ex As Exception
            ExceptionManager.Publish(ex)
        End Try

    End Sub

    Public Sub obtenerListaInconsistenciasEntregasProgramacion(ByVal lista As ArrayList, ByRef inconsistencias As Boolean)

        Try

            Dim matrix As Array = mDb.obtenerListaEntregasProgramacion(lista)

            'Verificamos que todo esta bien. Columnas pares son para los precios, impares para las entregas
            'Dos tipos de inconsistencias. Para precios y para entregas
            'Dos variables de conteo. Una para cada una

            For i As Integer = 0 To UBound(matrix, 1)

                Dim inconPorcentaje As Boolean = False
                Dim inconDias As Boolean = False

                Dim pr As Decimal = -2
                Dim ent As Decimal = -2

                Dim contPorcentaje As Integer = 0
                Dim contDias As Integer = 0

                'Pares e impares
                'Pares multiplicamos * 2
                'Impares multiplicamos * 2, luego sumamos 1
                For k As Integer = 0 To lista.Count - 1

                    If pr = -2 Then pr = matrix(i, (k * 2) + 1)
                    If ent = -2 Then ent = matrix(i, (k * 2) + 2)

                    If matrix(i, (k * 2) + 1) <> -1 Then
                        contPorcentaje += 1
                    End If

                    If matrix(i, (k * 2) + 2) <> -1 Then
                        contDias += 1
                    End If

                    If pr <> matrix(i, (k * 2) + 1) Then inconPorcentaje = True
                    If ent <> matrix(i, (k * 2) + 2) Then inconDias = True

                Next

                'Aqui hacemos todo el windup
                If contPorcentaje <> 1 And inconPorcentaje = True Then
                    'Inconsistencias en los porcentajes
                    inconsistencias = True
                    Exit Sub
                End If

                If contDias <> 1 And inconDias = True Then
                    'Inconsistencias dias
                    inconsistencias = True
                    Exit Sub
                End If

            Next

        Catch ex As Exception
            ExceptionManager.Publish(ex)
        End Try

    End Sub

    Public Function insertarGrupoProgramacion(ByVal lista As ArrayList, ByVal usuario As String) As Integer

        Dim tran As New DistributedTransaction

        Try

            Dim grupo As Integer = mDb.obtenerMaxGrupo(tran)
            Dim i As Integer = 0

            mDb.insertarGrupo(grupo, usuario, tran)
            mDb.insertarGrupoEstablecimientos(grupo, usuario, lista, tran)

            For k As Integer = 0 To lista.Count - 1
                mDb.insertarGrupoProgramacion(grupo, lista(k), usuario, tran)
                mDb.actualizarEstadoProgramacion(lista(k), 5, usuario, tran)
            Next

            tran.Commit()
            Return 1
        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try


    End Function

    Public Function obtenerGrupos() As DataSet

        Try
            Return mDb.obtenerGrupos
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function obtenerProgramacionesGrupo(ByVal idGrupo As Integer) As ArrayList

        Try
            Return mDb.obtenerProgramacionesGrupo(idGrupo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return New ArrayList
        End Try
    End Function

    Public Function obtenerProgramacionesGrupoDs(ByVal idGrupo As Integer) As DataSet

        Try
            Return mDb.obtenerProgramacionesGrupoDs(idGrupo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function actualizarFuentesProgramacion(ByVal arr As ArrayList, ByVal usuario As String) As Integer

        Dim tran As New DistributedTransaction
        Dim k As Integer

        Try

            For i As Integer = 0 To arr.Count - 1
                Dim s() As Integer = arr.Item(i)
                k = mDb.actualizarFuenteProgramacion(s(0), s(1), s(2), usuario, tran)
            Next

            tran.Commit()
            Return 1

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    Public Function obtenerGrupoEstablecimientos(ByVal IDGRUPO As Integer) As DataSet

        Try
            Return mDb.obtenerGrupoEstablecimientos(IDGRUPO)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function actualizarAlmacenProgramacion(ByVal arr As ArrayList, ByVal usuario As String) As Integer

        Dim tran As New DistributedTransaction
        Dim k As Integer

        Try

            For i As Integer = 0 To arr.Count - 1
                Dim s() As Integer = arr.Item(i)
                k = mDb.actualizarAlmacenProgramacion(s(0), s(1), s(2), usuario, tran)
            Next

            tran.Commit()
            Return 1

        Catch ex As Exception
            tran.Abort()
            ExceptionManager.Publish(ex)
            Return -1
        End Try
    End Function

    'Inconsistencias *********

    Public Function inconsistenciasPrecios(ByVal IDPROGRAMACION1 As Integer, ByVal IDPROGRAMACION2 As Integer) As DataSet
        Try
            Return mDb.inconsistenciasPrecios(IDPROGRAMACION1, IDPROGRAMACION2)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function inconsistenciasEntregas(ByVal IDPROGRAMACION1 As Integer, ByVal IDPROGRAMACION2 As Integer) As DataSet
        Try
            Return mDb.inconsistenciasEntregas(IDPROGRAMACION1, IDPROGRAMACION2)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try
    End Function

    Public Function inconsistenciasTablaEntregas(ByVal IDPROGRAMACION1 As Integer, ByVal IDPROGRAMACION2 As Integer) As Integer
        Try
            Return mDb.inconsistenciasTablaEntregas(IDPROGRAMACION1, IDPROGRAMACION2)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return 0
        End Try
    End Function

    Public Function obtenerDsProgramacionFiltrada(ByVal idProgramacion As Integer)

        Try
            Return mDb.obtenerDsProgramacionFiltrada(idProgramacion)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function reporteFuentesProgramacion(ByVal idGrupo As Integer, ByVal lista As ArrayList) As DataSet

        Try
            Dim ds As DataSet = mDb.reporteFuentesProgramacion(idGrupo, lista)
            ds.Tables(0).TableName = "dsTabla"
            Return ds
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function

    Public Function obtenerProgramacionesGrupos2(ByVal idGrupo As Integer) As ArrayList

        Try
            Return mDb.obtenerProgramacionesGrupos2(idGrupo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return New ArrayList
        End Try

    End Function

    Public Function verificarCierreGrupo(ByVal idGrupo As Integer) As Integer

        Try
            Return mDb.verificarCierreGrupo(idGrupo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    Public Function verificarCierreGrupo(ByVal idGrupo As Integer, ByVal estado As Integer, ByVal usuario As String) As Integer

        Try
            Return mDb.actualizarGrupo(idGrupo, estado, usuario)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    Public Function obtenerEstadoGrupo(ByVal idGrupo As Integer) As Integer

        Try
            Return mDb.obtenerEstadoGrupo(idGrupo)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    Public Function actualizarGrupo(ByVal idGrupo As Integer, ByVal estado As Integer, ByVal usuario As String) As Integer

        Try
            Return mDb.actualizarGrupo(idGrupo, estado, usuario)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return -1
        End Try

    End Function

    '***************************************************************
    Public Function productosSeleccionables(ByVal IDALMACEN As Integer, ByVal IDSUMINISTRO As Integer, IDPROGRAMACION As Integer, Optional ByVal CORRPRODUCTO As String = "", Optional IDPROGRAMA As Integer = 0) As DataSet

        Try
            Return mDb.productosSeleccionables(IDALMACEN, IDSUMINISTRO, IDPROGRAMACION, CORRPRODUCTO, IDPROGRAMA)
        Catch ex As Exception
            ExceptionManager.Publish(ex)
            Return Nothing
        End Try

    End Function
End Class
