''' -----------------------------------------------------------------------------
''' Proyecto	 : ABASTECIMIENTOS
''' Clase	     : BL.cUTILERIAS
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase de Lógica de Negocios que utiliza la capa de Acceso a Datos y provee
''' las funciones para el manejo de las existencias para las diferentes tablas.
''' </summary>
''' <history>
''' 	Jose Chavez	17/01/2007	Creado
''' </history>
''' -----------------------------------------------------------------------------
Public Class cUTILERIAS

#Region " PRIVADAS "
    Private mCompLotes As New dbLOTES
    Private mEntLotes As New LOTES
    Private mCompExistenciasAlmacenes As New dbEXISTENCIASALMACENES
    Private mEntExistenciasAlmacenes As New EXISTENCIASALMACENES
    Private mCompTipoTransaccion As New cTIPOTRANSACCIONES
    Private mEntTipoTransaccion As New TIPOTRANSACCIONES
#End Region

    Public Function ActualizarCantidades(ByVal aEntidad As LOTES, Optional ByVal CANTIDADDISPONIBLE As Int16 = 0, Optional ByVal CANTIDADNODISPONIBLE As Int16 = 0, Optional ByVal CANTIDADRESERVADA As Int16 = 0, Optional ByVal CANTIDADVENCIDA As Int16 = 0, Optional ByVal CANTIDADTEMPORAL As Int16 = 0) As Int16

        Dim eL As New LOTES
        Dim eEA As New EXISTENCIASALMACENES

        eL.IDALMACEN = aEntidad.IDALMACEN
        eL.IDLOTE = aEntidad.IDLOTE

        mCompLotes.Recuperar(eL)

        eL.AUUSUARIOMODIFICACION = aEntidad.AUUSUARIOMODIFICACION
        eL.AUFECHAMODIFICACION = aEntidad.AUFECHAMODIFICACION

        If CANTIDADDISPONIBLE = 1 Then
            eL.CANTIDADDISPONIBLE += aEntidad.CANTIDADDISPONIBLE
        ElseIf CANTIDADDISPONIBLE = 2 Then
            eL.CANTIDADDISPONIBLE -= aEntidad.CANTIDADDISPONIBLE
        End If

        If CANTIDADNODISPONIBLE = 1 Then
            eL.CANTIDADNODISPONIBLE += aEntidad.CANTIDADNODISPONIBLE
        ElseIf CANTIDADNODISPONIBLE = 2 Then
            eL.CANTIDADNODISPONIBLE -= aEntidad.CANTIDADNODISPONIBLE
        End If

        If CANTIDADRESERVADA = 1 Then
            eL.CANTIDADRESERVADA += aEntidad.CANTIDADRESERVADA
        ElseIf CANTIDADRESERVADA = 2 Then
            eL.CANTIDADRESERVADA -= aEntidad.CANTIDADRESERVADA
        End If

        If CANTIDADVENCIDA = 1 Then
            eL.CANTIDADVENCIDA += aEntidad.CANTIDADVENCIDA
        ElseIf CANTIDADVENCIDA = 2 Then
            eL.CANTIDADVENCIDA -= aEntidad.CANTIDADVENCIDA
        End If

        If CANTIDADTEMPORAL = 1 Then
            eL.CANTIDADTEMPORAL += aEntidad.CANTIDADTEMPORAL
        ElseIf CANTIDADTEMPORAL = 2 Then
            eL.CANTIDADTEMPORAL -= aEntidad.CANTIDADTEMPORAL
        End If

        mCompLotes.Actualizar(eL) 'Invocación del método de actualización

        eEA.IDALMACEN = eL.IDALMACEN
        eEA.IDPRODUCTO = eL.IDPRODUCTO

        If mCompExistenciasAlmacenes.Recuperar(eEA) = 0 Then

            eEA.CANTIDADDISPONIBLE = eL.CANTIDADDISPONIBLE
            eEA.CANTIDADNODISPONIBLE = eL.CANTIDADNODISPONIBLE
            eEA.CANTIDADRESERVADA = eL.CANTIDADRESERVADA
            eEA.CANTIDADVENCIDA = eL.CANTIDADVENCIDA
            eEA.CANTIDADTEMPORAL = eL.CANTIDADTEMPORAL
            eEA.AUUSUARIOCREACION = aEntidad.AUUSUARIOMODIFICACION
            eEA.AUFECHACREACION = aEntidad.AUFECHAMODIFICACION

            mCompExistenciasAlmacenes.Agregar(eEA)
        Else

            eEA.AUUSUARIOMODIFICACION = aEntidad.AUUSUARIOMODIFICACION
            eEA.AUFECHAMODIFICACION = aEntidad.AUFECHAMODIFICACION

            If CANTIDADDISPONIBLE = 1 Then
                eEA.CANTIDADDISPONIBLE += aEntidad.CANTIDADDISPONIBLE
            ElseIf CANTIDADDISPONIBLE = 2 Then
                eEA.CANTIDADDISPONIBLE -= aEntidad.CANTIDADDISPONIBLE
            End If

            If CANTIDADNODISPONIBLE = 1 Then
                eEA.CANTIDADNODISPONIBLE += aEntidad.CANTIDADNODISPONIBLE
            ElseIf CANTIDADNODISPONIBLE = 2 Then
                eEA.CANTIDADNODISPONIBLE -= aEntidad.CANTIDADNODISPONIBLE
            End If

            If CANTIDADRESERVADA = 1 Then
                eEA.CANTIDADRESERVADA += aEntidad.CANTIDADRESERVADA
            ElseIf CANTIDADRESERVADA = 2 Then
                eEA.CANTIDADRESERVADA -= aEntidad.CANTIDADRESERVADA
            End If

            If CANTIDADVENCIDA = 1 Then
                eEA.CANTIDADVENCIDA += aEntidad.CANTIDADVENCIDA
            ElseIf CANTIDADVENCIDA = 2 Then
                eEA.CANTIDADVENCIDA -= aEntidad.CANTIDADVENCIDA
            End If

            If CANTIDADTEMPORAL = 1 Then
                eEA.CANTIDADTEMPORAL += aEntidad.CANTIDADTEMPORAL
            ElseIf CANTIDADTEMPORAL = 2 Then
                eEA.CANTIDADTEMPORAL -= aEntidad.CANTIDADTEMPORAL
            End If

            mCompExistenciasAlmacenes.Actualizar(eEA) 'Invocación del método de actualización
        End If

    End Function

    ''' <summary>
    ''' Actualiza la cantidad disponible de la tabla de SAB_ALM_LOTES y SAB_ALM_EXISTENCIASALMACENES.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacén.</param>
    ''' <param name="IDLOTE">Identificador del lote.</param>
    ''' <param name="TIPOMOV">Identificador del tipo de operación [0 = Suma] y [1 = Resta].</param>
    ''' <param name="CANTIDAD">Cantidad a afectar.</param>
    ''' <returns>Valor numerico que identifica si ha ocurrido un error durante la actualización de las cantidades.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>SAB_ALM_EXISTENCIASALMACENES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  17/01/2007    Creado
    ''' </history>
    Public Function ActualizarCantidadDisponible(ByVal IDALMACEN As Int32, ByVal IDLOTE As Int32, ByVal TIPOMOV As Int16, ByVal CANTIDAD As Decimal) As Int16
        Select Case TIPOMOV
            Case Is = 0 'Operacion de suma

                'Actualización de la tabla de lotes
                mEntLotes.IDALMACEN = IDALMACEN
                mEntLotes.IDLOTE = IDLOTE
                mCompLotes.Recuperar(mEntLotes)
                mEntLotes.CANTIDADDISPONIBLE = mEntLotes.CANTIDADDISPONIBLE + CANTIDAD
                mEntLotes.ESTADISPONIBLE = 1
                mEntLotes.AUFECHAMODIFICACION = Now()
                mCompLotes.Actualizar(mEntLotes) 'Invocación del método de actualización

                'Actualización de la tabla de existencias por almacén
                mEntExistenciasAlmacenes.IDALMACEN = IDALMACEN
                mEntExistenciasAlmacenes.IDPRODUCTO = mEntLotes.IDPRODUCTO
                If mCompExistenciasAlmacenes.Recuperar(mEntExistenciasAlmacenes) = 0 Then
                    mEntExistenciasAlmacenes.MAX = 0
                    mEntExistenciasAlmacenes.MIN = 0
                    mEntExistenciasAlmacenes.CANTIDADDISPONIBLE += mEntLotes.CANTIDADDISPONIBLE
                    mEntExistenciasAlmacenes.CANTIDADNODISPONIBLE = 0
                    mEntExistenciasAlmacenes.CANTIDADRESERVADA = 0
                    mEntExistenciasAlmacenes.CANTIDADVENCIDA = 0
                    mEntExistenciasAlmacenes.CANTIDADTEMPORAL = 0
                    mCompExistenciasAlmacenes.Agregar(mEntExistenciasAlmacenes)
                Else
                    mEntExistenciasAlmacenes.CANTIDADDISPONIBLE = mEntExistenciasAlmacenes.CANTIDADDISPONIBLE + CANTIDAD
                    mCompExistenciasAlmacenes.Actualizar(mEntExistenciasAlmacenes) 'Invocación del método de actualización
                End If

            Case Is = 1 'Operacion de resta

                'Actualización de la tabla de lotes
                mEntLotes.IDALMACEN = IDALMACEN
                mEntLotes.IDLOTE = IDLOTE
                mCompLotes.Recuperar(mEntLotes)
                mEntLotes.CANTIDADDISPONIBLE = mEntLotes.CANTIDADDISPONIBLE - CANTIDAD
                mEntLotes.ESTADISPONIBLE = 1
                mEntLotes.AUFECHAMODIFICACION = Now()
                mCompLotes.Actualizar(mEntLotes) 'Invocación del método de actualización

                'Actualización de la tabla de existencias por almacén
                mEntExistenciasAlmacenes.IDALMACEN = IDALMACEN
                mEntExistenciasAlmacenes.IDPRODUCTO = mEntLotes.IDPRODUCTO
                If mCompExistenciasAlmacenes.Recuperar(mEntExistenciasAlmacenes) = 0 Then
                    mEntExistenciasAlmacenes.MAX = 0
                    mEntExistenciasAlmacenes.MIN = 0
                    mEntExistenciasAlmacenes.CANTIDADDISPONIBLE -= mEntLotes.CANTIDADDISPONIBLE
                    mEntExistenciasAlmacenes.CANTIDADNODISPONIBLE = 0
                    mEntExistenciasAlmacenes.CANTIDADRESERVADA = 0
                    mEntExistenciasAlmacenes.CANTIDADVENCIDA = 0
                    mEntExistenciasAlmacenes.CANTIDADTEMPORAL = 0
                    mCompExistenciasAlmacenes.Agregar(mEntExistenciasAlmacenes)
                Else
                    mEntExistenciasAlmacenes.CANTIDADDISPONIBLE = mEntExistenciasAlmacenes.CANTIDADDISPONIBLE - CANTIDAD
                    mCompExistenciasAlmacenes.Actualizar(mEntExistenciasAlmacenes) 'Invocación del método de actualización
                End If

        End Select

    End Function

    ''' <summary>
    ''' Actualiza la cantidad no disponible de la tabla de SAB_ALM_LOTES y SAB_ALM_EXISTENCIASALMACENES.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacén.</param>
    ''' <param name="IDLOTE">Identificador del lote.</param>
    ''' <param name="TIPOMOV">Identificador del tipo de operación [0 = Suma] y [1 = Resta].</param>
    ''' <param name="CANTIDAD">Cantidad a afectar.</param>
    ''' <returns>Valor numerico que identifica si ha ocurrido un error durante la actualización de las cantidades.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>SAB_ALM_EXISTENCIASALMACENES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  17/01/2007    Creado
    ''' </history>
    Public Function ActualizarCantidadNoDisponible(ByVal IDALMACEN As Int32, ByVal IDLOTE As Int32, ByVal TIPOMOV As Int16, ByVal CANTIDAD As Decimal) As Int16
        Select Case TIPOMOV
            Case Is = 0 'Operacion de suma

                'Actualización de la tabla de lotes
                mEntLotes.IDALMACEN = IDALMACEN
                mEntLotes.IDLOTE = IDLOTE
                mCompLotes.Recuperar(mEntLotes)
                mEntLotes.CANTIDADNODISPONIBLE = mEntLotes.CANTIDADNODISPONIBLE + CANTIDAD
                mEntLotes.ESTADISPONIBLE = 1
                mEntLotes.AUFECHAMODIFICACION = Now()
                mCompLotes.Actualizar(mEntLotes) 'Invocación del método de actualización

                'Actualización de la tabla de existencias por almacén
                mEntExistenciasAlmacenes.IDALMACEN = IDALMACEN
                mEntExistenciasAlmacenes.IDPRODUCTO = mEntLotes.IDPRODUCTO
                If mCompExistenciasAlmacenes.Recuperar(mEntExistenciasAlmacenes) = 0 Then
                    mEntExistenciasAlmacenes.MAX = 0
                    mEntExistenciasAlmacenes.MIN = 0
                    mEntExistenciasAlmacenes.CANTIDADDISPONIBLE = 0
                    mEntExistenciasAlmacenes.CANTIDADNODISPONIBLE = CANTIDAD
                    mEntExistenciasAlmacenes.CANTIDADRESERVADA = 0
                    mEntExistenciasAlmacenes.CANTIDADVENCIDA = 0
                    mEntExistenciasAlmacenes.CANTIDADTEMPORAL = 0
                    mCompExistenciasAlmacenes.Agregar(mEntExistenciasAlmacenes)

                Else
                    mEntExistenciasAlmacenes.CANTIDADNODISPONIBLE = mEntExistenciasAlmacenes.CANTIDADNODISPONIBLE + CANTIDAD
                    mCompExistenciasAlmacenes.Actualizar(mEntExistenciasAlmacenes) 'Invocación del método de actualización

                End If

            Case Is = 1 'Operacion de resta

                'Actualización de la tabla de lotes
                mEntLotes.IDALMACEN = IDALMACEN
                mEntLotes.IDLOTE = IDLOTE
                mCompLotes.Recuperar(mEntLotes)
                mEntLotes.CANTIDADNODISPONIBLE = mEntLotes.CANTIDADNODISPONIBLE - CANTIDAD
                mEntLotes.ESTADISPONIBLE = 1
                mEntLotes.AUFECHAMODIFICACION = Now()
                mCompLotes.Actualizar(mEntLotes) 'Invocación del método de actualización

                'Actualización de la tabla de existencias por almacén
                mEntExistenciasAlmacenes.IDALMACEN = IDALMACEN
                mEntExistenciasAlmacenes.IDPRODUCTO = mEntLotes.IDPRODUCTO
                If mCompExistenciasAlmacenes.Recuperar(mEntExistenciasAlmacenes) = 0 Then
                    mEntExistenciasAlmacenes.MAX = 0
                    mEntExistenciasAlmacenes.MIN = 0
                    mEntExistenciasAlmacenes.CANTIDADDISPONIBLE = 0
                    mEntExistenciasAlmacenes.CANTIDADNODISPONIBLE = CANTIDAD * -1
                    mEntExistenciasAlmacenes.CANTIDADRESERVADA = 0
                    mEntExistenciasAlmacenes.CANTIDADVENCIDA = 0
                    mEntExistenciasAlmacenes.CANTIDADTEMPORAL = 0
                    mCompExistenciasAlmacenes.Agregar(mEntExistenciasAlmacenes)

                Else
                    mEntExistenciasAlmacenes.CANTIDADNODISPONIBLE = mEntExistenciasAlmacenes.CANTIDADNODISPONIBLE - CANTIDAD
                    mCompExistenciasAlmacenes.Actualizar(mEntExistenciasAlmacenes) 'Invocación del método de actualización

                End If

        End Select

    End Function

    ''' <summary>
    ''' Actualiza la cantidad vencida de la tabla de SAB_ALM_LOTES y SAB_ALM_EXISTENCIASALMACENES.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacén.</param>
    ''' <param name="IDLOTE">Identificador del lote.</param>
    ''' <param name="TIPOMOV">Identificador del tipo de operación [0 = Suma] y [1 = Resta].</param>
    ''' <param name="CANTIDAD">Cantidad a afectar.</param>
    ''' <returns>Valor numerico que identifica si ha ocurrido un error durante la actualización de las cantidades.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>SAB_ALM_EXISTENCIASALMACENES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  17/01/2007    Creado
    ''' </history>
    Public Function ActualizarCantidadVencida(ByVal IDALMACEN As Int32, ByVal IDLOTE As Int32, ByVal TIPOMOV As Int16, ByVal CANTIDAD As Decimal) As Int16
        Select Case TIPOMOV
            Case Is = 0 'Operacion de suma

                'Actualización de la tabla de lotes
                mEntLotes.IDALMACEN = IDALMACEN
                mEntLotes.IDLOTE = IDLOTE
                mCompLotes.Recuperar(mEntLotes)
                mEntLotes.CANTIDADVENCIDA = mEntLotes.CANTIDADVENCIDA + CANTIDAD
                mEntLotes.ESTADISPONIBLE = 1
                mEntLotes.AUFECHAMODIFICACION = Now()
                mCompLotes.Actualizar(mEntLotes) 'Invocación del método de actualización

                'Actualización de la tabla de existencias por almacén
                mEntExistenciasAlmacenes.IDALMACEN = IDALMACEN
                mEntExistenciasAlmacenes.IDPRODUCTO = mEntLotes.IDPRODUCTO
                If mCompExistenciasAlmacenes.Recuperar(mEntExistenciasAlmacenes) = 0 Then
                    mEntExistenciasAlmacenes.MAX = 0
                    mEntExistenciasAlmacenes.MIN = 0
                    mEntExistenciasAlmacenes.CANTIDADDISPONIBLE = 0
                    mEntExistenciasAlmacenes.CANTIDADNODISPONIBLE = 0
                    mEntExistenciasAlmacenes.CANTIDADRESERVADA = 0
                    mEntExistenciasAlmacenes.CANTIDADVENCIDA = CANTIDAD
                    mEntExistenciasAlmacenes.CANTIDADTEMPORAL = 0
                    mCompExistenciasAlmacenes.Agregar(mEntExistenciasAlmacenes)

                Else
                    mEntExistenciasAlmacenes.CANTIDADVENCIDA = mEntExistenciasAlmacenes.CANTIDADVENCIDA + CANTIDAD
                    mCompExistenciasAlmacenes.Actualizar(mEntExistenciasAlmacenes) 'Invocación del método de actualización

                End If

            Case Is = 1 'Operacion de resta

                'Actualización de la tabla de lotes
                mEntLotes.IDALMACEN = IDALMACEN
                mEntLotes.IDLOTE = IDLOTE
                mCompLotes.Recuperar(mEntLotes)
                mEntLotes.CANTIDADVENCIDA = mEntLotes.CANTIDADVENCIDA - CANTIDAD
                mEntLotes.ESTADISPONIBLE = 1
                mEntLotes.AUFECHAMODIFICACION = Now()
                mCompLotes.Actualizar(mEntLotes) 'Invocación del método de actualización

                'Actualización de la tabla de existencias por almacén
                mEntExistenciasAlmacenes.IDALMACEN = IDALMACEN
                mEntExistenciasAlmacenes.IDPRODUCTO = mEntLotes.IDPRODUCTO
                If mCompExistenciasAlmacenes.Recuperar(mEntExistenciasAlmacenes) = 0 Then
                    mEntExistenciasAlmacenes.MAX = 0
                    mEntExistenciasAlmacenes.MIN = 0
                    mEntExistenciasAlmacenes.CANTIDADDISPONIBLE = 0
                    mEntExistenciasAlmacenes.CANTIDADNODISPONIBLE = 0
                    mEntExistenciasAlmacenes.CANTIDADRESERVADA = 0
                    mEntExistenciasAlmacenes.CANTIDADVENCIDA = CANTIDAD * -1
                    mEntExistenciasAlmacenes.CANTIDADTEMPORAL = 0
                    mCompExistenciasAlmacenes.Agregar(mEntExistenciasAlmacenes)

                Else
                    mEntExistenciasAlmacenes.CANTIDADVENCIDA = mEntExistenciasAlmacenes.CANTIDADVENCIDA - CANTIDAD
                    mCompExistenciasAlmacenes.Actualizar(mEntExistenciasAlmacenes) 'Invocación del método de actualización

                End If

        End Select

    End Function

    ''' <summary>
    ''' Actualiza la cantidad reservada de la tabla de SAB_ALM_LOTES y SAB_ALM_EXISTENCIASALMACENES.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacén.</param>
    ''' <param name="IDLOTE">Identificador del lote.</param>
    ''' <param name="TIPOMOV">Identificador del tipo de operación [0 = Suma] y [1 = Resta].</param>
    ''' <param name="CANTIDAD">Cantidad a afectar.</param>
    ''' <returns>Valor numerico que identifica si ha ocurrido un error durante la actualización de las cantidades.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>SAB_ALM_EXISTENCIASALMACENES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  17/01/2007    Creado
    ''' </history>
    Public Function ActualizarCantidadReservada(ByVal IDALMACEN As Int32, ByVal IDLOTE As Int32, ByVal TIPOMOV As Int16, ByVal CANTIDAD As Decimal) As Int16
        Select Case TIPOMOV
            Case Is = 0 'Operacion de suma

                'Actualización de la tabla de lotes
                mEntLotes.IDALMACEN = IDALMACEN
                mEntLotes.IDLOTE = IDLOTE
                mCompLotes.Recuperar(mEntLotes)
                mEntLotes.CANTIDADRESERVADA = mEntLotes.CANTIDADRESERVADA + CANTIDAD
                mEntLotes.ESTADISPONIBLE = 1
                mEntLotes.AUFECHAMODIFICACION = Now()
                mCompLotes.Actualizar(mEntLotes) 'Invocación del método de actualización

                'Actualización de la tabla de existencias por almacén
                mEntExistenciasAlmacenes.IDALMACEN = IDALMACEN
                mEntExistenciasAlmacenes.IDPRODUCTO = mEntLotes.IDPRODUCTO
                If mCompExistenciasAlmacenes.Recuperar(mEntExistenciasAlmacenes) = 0 Then
                    mEntExistenciasAlmacenes.MAX = 0
                    mEntExistenciasAlmacenes.MIN = 0
                    mEntExistenciasAlmacenes.CANTIDADDISPONIBLE = 0
                    mEntExistenciasAlmacenes.CANTIDADNODISPONIBLE = 0
                    mEntExistenciasAlmacenes.CANTIDADRESERVADA = CANTIDAD
                    mEntExistenciasAlmacenes.CANTIDADVENCIDA = 0
                    mEntExistenciasAlmacenes.CANTIDADTEMPORAL = 0
                    mCompExistenciasAlmacenes.Agregar(mEntExistenciasAlmacenes)

                Else
                    mEntExistenciasAlmacenes.CANTIDADRESERVADA = mEntExistenciasAlmacenes.CANTIDADRESERVADA + CANTIDAD
                    mCompExistenciasAlmacenes.Actualizar(mEntExistenciasAlmacenes) 'Invocación del método de actualización

                End If

            Case Is = 1 'Operacion de resta

                'Actualización de la tabla de lotes
                mEntLotes.IDALMACEN = IDALMACEN
                mEntLotes.IDLOTE = IDLOTE
                mCompLotes.Recuperar(mEntLotes)
                mEntLotes.CANTIDADRESERVADA = mEntLotes.CANTIDADRESERVADA - CANTIDAD
                mEntLotes.ESTADISPONIBLE = 1
                mEntLotes.AUFECHAMODIFICACION = Now()
                mCompLotes.Actualizar(mEntLotes) 'Invocación del método de actualización

                'Actualización de la tabla de existencias por almacén
                mEntExistenciasAlmacenes.IDALMACEN = IDALMACEN
                mEntExistenciasAlmacenes.IDPRODUCTO = mEntLotes.IDPRODUCTO
                If mCompExistenciasAlmacenes.Recuperar(mEntExistenciasAlmacenes) = 0 Then
                    mEntExistenciasAlmacenes.MAX = 0
                    mEntExistenciasAlmacenes.MIN = 0
                    mEntExistenciasAlmacenes.CANTIDADDISPONIBLE = 0
                    mEntExistenciasAlmacenes.CANTIDADNODISPONIBLE = 0
                    mEntExistenciasAlmacenes.CANTIDADRESERVADA = CANTIDAD * -1
                    mEntExistenciasAlmacenes.CANTIDADVENCIDA = 0
                    mEntExistenciasAlmacenes.CANTIDADTEMPORAL = 0
                    mCompExistenciasAlmacenes.Agregar(mEntExistenciasAlmacenes)

                Else
                    mEntExistenciasAlmacenes.CANTIDADRESERVADA = mEntExistenciasAlmacenes.CANTIDADRESERVADA - CANTIDAD
                    mCompExistenciasAlmacenes.Actualizar(mEntExistenciasAlmacenes) 'Invocación del método de actualización

                End If

        End Select

    End Function

    ''' <summary>
    ''' Actualiza la cantidad temporal de la tabla de SAB_ALM_LOTES y SAB_ALM_EXISTENCIASALMACENES.
    ''' </summary>
    ''' <param name="IDALMACEN">Identificador del almacén.</param>
    ''' <param name="IDLOTE">Identificador del lote.</param>
    ''' <param name="TIPOMOV">Identificador del tipo de operación [0 = Suma] y [1 = Resta].</param>
    ''' <param name="CANTIDAD">Cantidad a afectar.</param>
    ''' <returns>Valor numerico que identifica si ha ocurrido un error durante la actualización de las cantidades.</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_ALM_LOTES</description></item>
    ''' <item><description>SAB_ALM_EXISTENCIASALMACENES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  17/01/2007    Creado
    ''' </history>
    Public Function ActualizarCantidadTemporal(ByVal IDALMACEN As Int32, ByVal IDLOTE As Int32, ByVal TIPOMOV As Int16, ByVal CANTIDAD As Decimal) As Int16

        Select Case TIPOMOV

            Case Is = 0 'Operacion de suma

                'Actualización de la tabla de lotes
                mEntLotes.IDALMACEN = IDALMACEN
                mEntLotes.IDLOTE = IDLOTE
                mCompLotes.Recuperar(mEntLotes)
                mEntLotes.CANTIDADTEMPORAL = mEntLotes.CANTIDADTEMPORAL + CANTIDAD
                mEntLotes.ESTADISPONIBLE = 1
                mEntLotes.AUFECHAMODIFICACION = Now()
                mCompLotes.Actualizar(mEntLotes) 'Invocación del método de actualización

                'Actualización de la tabla de existencias por almacén
                mEntExistenciasAlmacenes.IDALMACEN = IDALMACEN
                mEntExistenciasAlmacenes.IDPRODUCTO = mEntLotes.IDPRODUCTO

                If mCompExistenciasAlmacenes.Recuperar(mEntExistenciasAlmacenes) = 0 Then
                    mEntExistenciasAlmacenes.MAX = 0
                    mEntExistenciasAlmacenes.MIN = 0
                    mEntExistenciasAlmacenes.CANTIDADDISPONIBLE = 0
                    mEntExistenciasAlmacenes.CANTIDADNODISPONIBLE = 0
                    mEntExistenciasAlmacenes.CANTIDADRESERVADA = 0
                    mEntExistenciasAlmacenes.CANTIDADVENCIDA = 0
                    mEntExistenciasAlmacenes.CANTIDADTEMPORAL = CANTIDAD
                    mCompExistenciasAlmacenes.Agregar(mEntExistenciasAlmacenes)
                Else
                    mEntExistenciasAlmacenes.CANTIDADTEMPORAL = mEntExistenciasAlmacenes.CANTIDADTEMPORAL + CANTIDAD
                    mCompExistenciasAlmacenes.Actualizar(mEntExistenciasAlmacenes) 'Invocación del método de actualización
                End If

            Case Is = 1 'Operacion de resta

                'Actualización de la tabla de lotes
                mEntLotes.IDALMACEN = IDALMACEN
                mEntLotes.IDLOTE = IDLOTE
                mCompLotes.Recuperar(mEntLotes)
                mEntLotes.CANTIDADTEMPORAL = mEntLotes.CANTIDADTEMPORAL - CANTIDAD
                mEntLotes.ESTADISPONIBLE = 1
                mEntLotes.AUFECHAMODIFICACION = Now()
                mCompLotes.Actualizar(mEntLotes) 'Invocación del método de actualización

                'Actualización de la tabla de existencias por almacén
                mEntExistenciasAlmacenes.IDALMACEN = IDALMACEN
                mEntExistenciasAlmacenes.IDPRODUCTO = mEntLotes.IDPRODUCTO

                If mCompExistenciasAlmacenes.Recuperar(mEntExistenciasAlmacenes) = 0 Then
                    mEntExistenciasAlmacenes.MAX = 0
                    mEntExistenciasAlmacenes.MIN = 0
                    mEntExistenciasAlmacenes.CANTIDADDISPONIBLE = 0
                    mEntExistenciasAlmacenes.CANTIDADNODISPONIBLE = 0
                    mEntExistenciasAlmacenes.CANTIDADRESERVADA = 0
                    mEntExistenciasAlmacenes.CANTIDADVENCIDA = 0
                    mEntExistenciasAlmacenes.CANTIDADTEMPORAL = CANTIDAD * -1
                    mCompExistenciasAlmacenes.Agregar(mEntExistenciasAlmacenes)
                Else
                    mEntExistenciasAlmacenes.CANTIDADTEMPORAL = mEntExistenciasAlmacenes.CANTIDADTEMPORAL - CANTIDAD
                    mCompExistenciasAlmacenes.Actualizar(mEntExistenciasAlmacenes) 'Invocación del método de actualización
                End If

        End Select

    End Function

    ''' <summary>
    ''' Calcula la distribución de producto por número de entregas.
    ''' </summary>
    ''' <param name="CantidadTotal">cantidad total de producto.</param>
    ''' <param name="DistribucionProducto">Arreglo con los porcentajes de distribución.</param>
    ''' <returns>Arreglo con la distribución de producto de acuerdo a los porcentajes establecidos y al número de entrega</returns>
    ''' <remarks>
    ''' <list type="bullet">
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Juan José Rivas]  24/01/2007    Creado
    ''' </history>
    Public Function DistribuirProducto(ByVal CantidadTotal As Decimal, ByVal DistribucionProducto As ArrayList) As ArrayList

        Dim numeroEntregas As Integer
        Dim valorEntrega, sumaDistribucion As Decimal
        Dim distribucionEntregas As New ArrayList
        Dim valorAprox As Decimal
        Dim valor As Decimal
        numeroEntregas = DistribucionProducto.Count

        For i As Integer = 0 To numeroEntregas - 1

            If (CantidadTotal - sumaDistribucion) > 0 Then

                If i = numeroEntregas - 1 Then
                    valorEntrega = CantidadTotal - sumaDistribucion
                    distribucionEntregas.Add(valorEntrega)
                Else
                    valorAprox = Fix(CantidadTotal * (DistribucionProducto.Item(i) / 100))
                    valor = CantidadTotal * (DistribucionProducto.Item(i) / 100)

                    If (valor - valorAprox) >= 0.5 Then
                        valorEntrega = valorAprox + 1
                    Else
                        valorEntrega = valorAprox
                    End If

                    'valorEntrega = Math.Round(CantidadTotal * (DistribucionProducto.Item(i) / 100), 0, MidpointRounding.AwayFromZero)

                    distribucionEntregas.Add(valorEntrega)
                    sumaDistribucion += valorEntrega
                End If
            Else
                distribucionEntregas.Add(0)
            End If
        Next

        Return distribucionEntregas
    End Function

    Public Function distribuyeProductoAmpliacion(ByVal CantidadTotal As Decimal, ByVal DistribucionProducto As ArrayList) As ArrayList

        Dim numeroEntregas, i As Integer
        Dim valorEntrega, sumaDistribucion As Decimal
        Dim distribucionEntregas As New ArrayList
        Dim valorAprox As Decimal
        Dim valor As Decimal
        numeroEntregas = DistribucionProducto.Count

        For i = 0 To numeroEntregas - 1

            If (CantidadTotal - sumaDistribucion) > 0 Then
                If i <> numeroEntregas - 1 Then

                    valorAprox = Fix(CantidadTotal * (DistribucionProducto.Item(i) / 100))
                    valor = CantidadTotal * (DistribucionProducto.Item(i) / 100)
                    If (valor - valorAprox) >= 0.5 Then
                        valorEntrega = valorAprox + 1
                    Else
                        valorEntrega = valorAprox
                    End If

                    distribucionEntregas.Add(valorEntrega)
                    sumaDistribucion += valorEntrega

                Else

                    valorEntrega = CantidadTotal - sumaDistribucion
                    distribucionEntregas.Add(valorEntrega)
                End If
            Else
                distribucionEntregas.Add(0)
            End If
        Next

        Return distribucionEntregas
    End Function

    ''' <summary>
    ''' Recupera el tipo de operación a realizar sobre un tipo de transacción
    ''' </summary>
    ''' <param name="IDTIPOTRANSACCION">Identificador del tipo de transacción</param>
    ''' <returns>Valor numerico que representa el tipo de operación a realizar 0 = SUMA y 1 = RESTA</returns>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: José Alberto Chávez Loarca]  26/01/2007    Creado
    ''' </history>
    Public Function ObtenerTipoOperacion(ByVal IDTIPOTRANSACCION As Int16) As Int16
        mEntTipoTransaccion.IDTIPOTRANSACCION = IDTIPOTRANSACCION
        mCompTipoTransaccion.ObtenerTIPOTRANSACCIONES(mEntTipoTransaccion)
        If mEntTipoTransaccion.AFECTAINVENTARIO = 1 Then
            Return 1
        ElseIf mEntTipoTransaccion.AFECTAINVENTARIO = -1 Then
            Return 0
        End If
    End Function

    ''' <summary>
    ''' Realiza la distribución de productos a entregar por proveedor en cada almacen.
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO">Identificador del establecimiento.</param>
    ''' <param name="IDPROCESOCOMPRA">Identificador del proceso de compra.</param>
    ''' <param name="USUARIO">Usuario que realiza la modificación.</param>
    ''' <history>
    '''     [Autor: Juan José Rivas Angel]  02/02/2007    Creado
    ''' </history>
    Public Sub calcularDistribucionEntregas(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal USUARIO As String, ByVal MOMENTO As Integer)
        Dim PDO As Decimal ' Porcentaje de Distribución por Oferta

        Dim NoAlm As Integer 'Número de Almancenes
        Dim TD As Decimal 'Total distribución

        Dim i, j, k, m, n As Integer 'Contadores
        Dim arrPDO As New ArrayList
        Dim dsOfertas As DataSet
        Dim IDDETALLE As Integer

        'Obteniendo los renglones adjudicados para el proceso de compra
        Dim mComAdjudicacion As New cADJUDICACION
        Dim dsRenglonesAdjudicados As DataSet

        dsRenglonesAdjudicados = mComAdjudicacion.ObtenerRenglonesAdjudicados(IDESTABLECIMIENTO, IDPROCESOCOMPRA)

        'Obteniendo los montos de las ofertas por proveedor por renglon

        TD = 0

        Dim mComOferta As New cADJUDICACION
        Dim RENGLON As Integer = 0
        Dim IDALMACEN As Integer
        Dim IDFUENTEFINANCIAMIENTO As Integer
        Dim mComAlmacSol As New cPROGRAMADISTRIBUCION
        Dim dsSolAlmac As DataSet
        Try
            For i = 0 To dsRenglonesAdjudicados.Tables(0).Rows.Count - 1
                

                'If RENGLON <> dsRenglonesAdjudicados.Tables(0).Rows(i).Item("RENGLON") Then
                RENGLON = dsRenglonesAdjudicados.Tables(0).Rows(i).Item("RENGLON")
                dsOfertas = mComOferta.obtenerCantidadAdjudicadaProveedor(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON)
                dsSolAlmac = mComAlmacSol.ObtenerCantidadAdjudicadaAlmacenSolicitud(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON)
                'IDFUENTEFINANCIAMIENTO = dsRenglonesAdjudicados.Tables(0).Rows(i).Item("IDFUENTEFINANCIAMIENTO")

                'Obteniendo el total a entregar por renglon
                NoAlm = dsSolAlmac.Tables(0).Rows.Count

                'Select Case MOMENTO
                '    Case Is = 1
                '        'recomendacion
                For m = 0 To NoAlm - 1
                    TD += dsSolAlmac.Tables(0).Rows(m).Item("CANTIDADADJUDICADA")
                Next
                '    Case Is = 2
                ''adjudicacion
                'For m = 0 To NoAlm - 1
                '    TD += dsSolAlmac.Tables(0).Rows(m).Item("CANTIDADADJUDICADA")
                'Next
                '    Case Is = 3
                ''adjudicacion en firma
                'For m = 0 To NoAlm - 1
                '    TD += dsSolAlmac.Tables(0).Rows(m).Item("CANTIDADADJUDICADA")
                'Next
                'End Select

                'Obteniendo Porcentaje de distribucion por oferta
                

                Select Case MOMENTO

                    Case Is = 2
                        'adjudicacion
                        For j = 0 To dsOfertas.Tables(0).Rows.Count - 1

                            If dsOfertas.Tables(0).Rows(j).Item("CANTIDADADJUDICADA") Mod TD > 0 Then
                                PDO = ((dsOfertas.Tables(0).Rows(j).Item("CANTIDADADJUDICADA") / TD) * 100)
                            Else
                                PDO = ((dsOfertas.Tables(0).Rows(j).Item("CANTIDADADJUDICADA") / TD) * 100)
                            End If

                            arrPDO.Add(PDO)

                        Next
                    Case Is = 3
                        'adjudicacion en firmE
                        For j = 0 To dsOfertas.Tables(0).Rows.Count - 1

                            If dsOfertas.Tables(0).Rows(j).Item("CANTIDADFIRME") Mod TD > 0 Then
                                PDO = ((dsOfertas.Tables(0).Rows(j).Item("CANTIDADFIRME") / TD) * 100)
                            Else
                                PDO = ((dsOfertas.Tables(0).Rows(j).Item("CANTIDADFIRME") / TD) * 100)
                            End If

                            arrPDO.Add(PDO)

                        Next
                End Select

                Select Case MOMENTO
                    Case Is = 2
                        'ADJUDICACION
                        For m = 0 To NoAlm - 1

                            IDALMACEN = dsSolAlmac.Tables(0).Rows(m).Item("IDALMACEN")
                            IDFUENTEFINANCIAMIENTO = dsSolAlmac.Tables(0).Rows(m).Item("IDFUENTEFINANCIAMIENTO")
                            'Obteniendo la cantidad total a distribuir por Almacen por Oferta
                            Dim arrRespuesta As New ArrayList
                            arrRespuesta = Me.DistribuirProducto(dsSolAlmac.Tables(0).Rows(m).Item("CANTIDADADJUDICADA"), arrPDO)

                            'OBTENIENDO LA CANTIDAD PARA CADA ENTREGA POR OFERTA

                            'Primero : Obteniendo las entregas
                            Dim mComEntregas As New cENTREGAADJUDICACION
                            Dim dsEntregas As DataSet
                            Dim IDPROVEEDOR As Integer
                            Dim arrEntregas As New ArrayList
                            Dim arrCantEntrega As New ArrayList

                            For j = 0 To dsOfertas.Tables(0).Rows.Count - 1

                                IDPROVEEDOR = dsOfertas.Tables(0).Rows(j).Item("IDPROVEEDOR")
                                dsEntregas = mComEntregas.obtenerEntregasProveedor(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, RENGLON)

                                IDDETALLE = dsOfertas.Tables(0).Rows(j).Item("IDDETALLE")

                                For k = 0 To dsEntregas.Tables(0).Rows.Count - 1
                                    arrEntregas.Add(dsEntregas.Tables(0).Rows(k).Item("PORCENTAJE"))
                                Next

                                arrCantEntrega = Me.DistribuirProducto(arrRespuesta.Item(j), arrEntregas)

                                For n = 0 To arrCantEntrega.Count - 1
                                    guardarAlmacenEntregaAdjudicacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE, n, IDALMACEN, arrCantEntrega.Item(n), USUARIO, IDFUENTEFINANCIAMIENTO, 2)
                                Next

                                arrEntregas.Clear()

                            Next

                            arrRespuesta.Clear()

                            arrCantEntrega.Clear()

                        Next
                        arrPDO.Clear()
                        TD = 0
                        'End If
                    Case Is = 3
                        'ADJUDICACIONFIRME
                        For m = 0 To NoAlm - 1

                            IDALMACEN = dsSolAlmac.Tables(0).Rows(m).Item("IDALMACEN")
                            IDFUENTEFINANCIAMIENTO = dsSolAlmac.Tables(0).Rows(m).Item("IDFUENTEFINANCIAMIENTO")
                            'Obteniendo la cantidad total a distribuir por Almacen por Oferta
                            Dim arrRespuesta As New ArrayList
                            arrRespuesta = Me.DistribuirProducto(dsSolAlmac.Tables(0).Rows(m).Item("CANTIDADADJUDICADA"), arrPDO)

                            'OBTENIENDO LA CANTIDAD PARA CADA ENTREGA POR OFERTA

                            'Primero : Obteniendo las entregas
                            Dim mComEntregas As New cENTREGAADJUDICACION
                            Dim dsEntregas As DataSet
                            Dim IDPROVEEDOR As Integer
                            Dim arrEntregas As New ArrayList
                            Dim arrCantEntrega As New ArrayList

                            For j = 0 To dsOfertas.Tables(0).Rows.Count - 1

                                IDPROVEEDOR = dsOfertas.Tables(0).Rows(j).Item("IDPROVEEDOR")
                                dsEntregas = mComEntregas.obtenerEntregasProveedor(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, RENGLON)

                                IDDETALLE = dsEntregas.Tables(0).Rows(0).Item("IDDETALLE")

                                For k = 0 To dsEntregas.Tables(0).Rows.Count - 1
                                    arrEntregas.Add(dsEntregas.Tables(0).Rows(k).Item("PORCENTAJE"))
                                Next

                                arrCantEntrega = Me.DistribuirProducto(arrRespuesta.Item(j), arrEntregas)

                                For n = 0 To arrCantEntrega.Count - 1
                                    guardarAlmacenEntregaAdjudicacion(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, IDDETALLE, n, IDALMACEN, arrCantEntrega.Item(n), USUARIO, IDFUENTEFINANCIAMIENTO, 2)
                                Next

                                arrEntregas.Clear()

                            Next

                            arrRespuesta.Clear()

                            arrCantEntrega.Clear()

                        Next
                        arrPDO.Clear()
                        TD = 0
                        'End If
                End Select

                ' VALIDAR QUE LA SUMA DE LA DISTRIBUCION CUANDO SEAN > 2 PROVEEDORES SEA IGUAL
                ' A SU CANTIDAD ADJUDICADA GLOBAL A CADA PROVEEDOR.

                'paso 1: validar que este renglon este adjudicado a mas de un proveedor.
                If dsOfertas.Tables(0).Rows.Count > 1 Then

                    '
                    'obtener cantidad global adjudicada para el primer proveedor
                    Dim cantidadglobaladjudicada As Integer
                    cantidadglobaladjudicada = dsOfertas.Tables(0).Rows(0).Item("CANTIDADFIRME")

                    'obtener sumatoria del resultado prorrateado
                    Dim cAEA As New cALMACENESENTREGAADJUDICACION
                    Dim CantidadProrrateo As Integer
                    CantidadProrrateo = cAEA.obtenerSumatoriaxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, dsOfertas.Tables(0).Rows(0).Item("IDPROVEEDOR"), RENGLON)


                    'Comparacion de cantidades, si son iguales...todo bien.
                    If cantidadglobaladjudicada <> CantidadProrrateo Then
                        'hay que corregir la diferencia
                        If cantidadglobaladjudicada > CantidadProrrateo Then
                            ' hay que sumar la diferencia a un almacen de este proveedor y restar la diferencia en un almacen del otro proveedor

                            'obtener la cantidad para el primer almacen del primer proveedor.
                            Dim distri As New DataSet
                            Dim cantidad As Integer
                            distri = cAEA.obtenerCantidadxAlmacenxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, dsOfertas.Tables(0).Rows(0).Item("IDPROVEEDOR"), RENGLON)

                            'le sumamos la diferencia 
                            cantidad = distri.Tables(0).Rows(0).Item("CANTIDAD") + (cantidadglobaladjudicada - CantidadProrrateo)

                            'actualizamos el cambio
                            cAEA.ActualizarCantidadxAlmacenxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, dsOfertas.Tables(0).Rows(0).Item("IDPROVEEDOR"), distri.Tables(0).Rows(0).Item("IDDETALLE"), distri.Tables(0).Rows(0).Item("IDENTREGA"), distri.Tables(0).Rows(0).Item("IDALMACEN"), distri.Tables(0).Rows(0).Item("IDFUENTEFINANCIAMIENTO"), cantidad)

                            'obtener la cantidad para el primer almacen del segundo proveedor.
                            Dim distri2 As New DataSet
                            Dim cantidad2 As Integer
                            distri2 = cAEA.obtenerCantidadxAlmacenxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, dsOfertas.Tables(0).Rows(1).Item("IDPROVEEDOR"), RENGLON)

                            'le sumamos la diferencia 
                            cantidad2 = distri2.Tables(0).Rows(0).Item("CANTIDAD") - (cantidadglobaladjudicada - CantidadProrrateo)

                            'actualizamos el cambio
                            cAEA.ActualizarCantidadxAlmacenxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, dsOfertas.Tables(0).Rows(1).Item("IDPROVEEDOR"), distri2.Tables(0).Rows(0).Item("IDDETALLE"), distri2.Tables(0).Rows(0).Item("IDENTREGA"), distri2.Tables(0).Rows(0).Item("IDALMACEN"), distri2.Tables(0).Rows(0).Item("IDFUENTEFINANCIAMIENTO"), cantidad2)


                        Else
                            ' hay que restar la diferencia a un almacen de este proveedor y sumar la diferencia en un almacen del otro proveedor
                            'obtener la cantidad para el primer almacen del primer proveedor.
                            Dim distri As New DataSet
                            Dim cantidad As Integer
                            distri = cAEA.obtenerCantidadxAlmacenxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, dsOfertas.Tables(0).Rows(0).Item("IDPROVEEDOR"), RENGLON)

                            'le sumamos la diferencia 
                            cantidad = distri.Tables(0).Rows(0).Item("CANTIDAD") - (CantidadProrrateo - cantidadglobaladjudicada)

                            'actualizamos el cambio
                            cAEA.ActualizarCantidadxAlmacenxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, dsOfertas.Tables(0).Rows(0).Item("IDPROVEEDOR"), distri.Tables(0).Rows(0).Item("IDDETALLE"), distri.Tables(0).Rows(0).Item("IDENTREGA"), distri.Tables(0).Rows(0).Item("IDALMACEN"), distri.Tables(0).Rows(0).Item("IDFUENTEFINANCIAMIENTO"), cantidad)

                            'obtener la cantidad para el primer almacen del segundo proveedor.
                            Dim distri2 As New DataSet
                            Dim cantidad2 As Integer
                            distri2 = cAEA.obtenerCantidadxAlmacenxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, dsOfertas.Tables(0).Rows(1).Item("IDPROVEEDOR"), RENGLON)

                            'le sumamos la diferencia 
                            cantidad2 = distri2.Tables(0).Rows(0).Item("CANTIDAD") + (CantidadProrrateo - cantidadglobaladjudicada)

                            'actualizamos el cambio
                            cAEA.ActualizarCantidadxAlmacenxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, dsOfertas.Tables(0).Rows(1).Item("IDPROVEEDOR"), distri2.Tables(0).Rows(0).Item("IDDETALLE"), distri2.Tables(0).Rows(0).Item("IDENTREGA"), distri2.Tables(0).Rows(0).Item("IDALMACEN"), distri2.Tables(0).Rows(0).Item("IDFUENTEFINANCIAMIENTO"), cantidad2)

                        End If

                        If dsOfertas.Tables(0).Rows.Count > 2 Then

                            '
                            'obtener cantidad global adjudicada para el SEGUNDO proveedor
                            'Dim cantidadglobaladjudicada As Integer
                            cantidadglobaladjudicada = dsOfertas.Tables(0).Rows(1).Item("CANTIDADFIRME")

                            'obtener sumatoria del resultado prorrateado
                            ' Dim cAEA As New cALMACENESENTREGAADJUDICACION
                            ' Dim CantidadProrrateo As Integer
                            CantidadProrrateo = cAEA.obtenerSumatoriaxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, dsOfertas.Tables(0).Rows(1).Item("IDPROVEEDOR"), RENGLON)


                            'Comparacion de cantidades, si son iguales...todo bien.
                            If cantidadglobaladjudicada <> CantidadProrrateo Then
                                'hay que corregir la diferencia
                                If cantidadglobaladjudicada > CantidadProrrateo Then
                                    ' hay que sumar la diferencia a un almacen de este proveedor y restar la diferencia en un almacen del otro proveedor

                                    'obtener la cantidad para el primer almacen del SEGUNDO proveedor.
                                    Dim distri As New DataSet
                                    Dim cantidad As Integer
                                    distri = cAEA.obtenerCantidadxAlmacenxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, dsOfertas.Tables(0).Rows(1).Item("IDPROVEEDOR"), RENGLON)

                                    'le sumamos la diferencia 
                                    cantidad = distri.Tables(0).Rows(0).Item("CANTIDAD") + (cantidadglobaladjudicada - CantidadProrrateo)

                                    'actualizamos el cambio
                                    cAEA.ActualizarCantidadxAlmacenxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, dsOfertas.Tables(0).Rows(1).Item("IDPROVEEDOR"), distri.Tables(0).Rows(0).Item("IDDETALLE"), distri.Tables(0).Rows(0).Item("IDENTREGA"), distri.Tables(0).Rows(0).Item("IDALMACEN"), distri.Tables(0).Rows(0).Item("IDFUENTEFINANCIAMIENTO"), cantidad)

                                    'obtener la cantidad para el primer almacen del TERCER proveedor.
                                    Dim distri2 As New DataSet
                                    Dim cantidad2 As Integer
                                    distri2 = cAEA.obtenerCantidadxAlmacenxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, dsOfertas.Tables(0).Rows(2).Item("IDPROVEEDOR"), RENGLON)

                                    'le sumamos la diferencia 
                                    cantidad2 = distri2.Tables(0).Rows(0).Item("CANTIDAD") - (cantidadglobaladjudicada - CantidadProrrateo)

                                    'actualizamos el cambio
                                    cAEA.ActualizarCantidadxAlmacenxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, dsOfertas.Tables(0).Rows(2).Item("IDPROVEEDOR"), distri2.Tables(0).Rows(0).Item("IDDETALLE"), distri2.Tables(0).Rows(0).Item("IDENTREGA"), distri2.Tables(0).Rows(0).Item("IDALMACEN"), distri2.Tables(0).Rows(0).Item("IDFUENTEFINANCIAMIENTO"), cantidad2)


                                Else
                                    ' hay que restar la diferencia a un almacen de este proveedor y sumar la diferencia en un almacen del otro proveedor
                                    'obtener la cantidad para el primer almacen del SEGUNDO proveedor.
                                    Dim distri As New DataSet
                                    Dim cantidad As Integer
                                    distri = cAEA.obtenerCantidadxAlmacenxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, dsOfertas.Tables(0).Rows(1).Item("IDPROVEEDOR"), RENGLON)

                                    'le sumamos la diferencia 
                                    cantidad = distri.Tables(0).Rows(0).Item("CANTIDAD") - (CantidadProrrateo - cantidadglobaladjudicada)

                                    'actualizamos el cambio
                                    cAEA.ActualizarCantidadxAlmacenxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, dsOfertas.Tables(0).Rows(1).Item("IDPROVEEDOR"), distri.Tables(0).Rows(0).Item("IDDETALLE"), distri.Tables(0).Rows(0).Item("IDENTREGA"), distri.Tables(0).Rows(0).Item("IDALMACEN"), distri.Tables(0).Rows(0).Item("IDFUENTEFINANCIAMIENTO"), cantidad)

                                    'obtener la cantidad para el primer almacen del TERCER proveedor.
                                    Dim distri2 As New DataSet
                                    Dim cantidad2 As Integer
                                    distri2 = cAEA.obtenerCantidadxAlmacenxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, dsOfertas.Tables(0).Rows(2).Item("IDPROVEEDOR"), RENGLON)

                                    'le sumamos la diferencia 
                                    cantidad2 = distri2.Tables(0).Rows(0).Item("CANTIDAD") + (CantidadProrrateo - cantidadglobaladjudicada)

                                    'actualizamos el cambio
                                    cAEA.ActualizarCantidadxAlmacenxProveedorxRenglon(IDESTABLECIMIENTO, IDPROCESOCOMPRA, dsOfertas.Tables(0).Rows(2).Item("IDPROVEEDOR"), distri2.Tables(0).Rows(0).Item("IDDETALLE"), distri2.Tables(0).Rows(0).Item("IDENTREGA"), distri2.Tables(0).Rows(0).Item("IDALMACEN"), distri2.Tables(0).Rows(0).Item("IDFUENTEFINANCIAMIENTO"), cantidad2)

                                End If
                            End If
                        End If
                    End If
                End If
            Next
        Catch ex As Exception

        End Try


    End Sub

    Public Sub calcularDistribucionEntregasAmpliacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal PORCENTAJE As Decimal, ByVal USUARIO As String)
        Dim NoAlm As Integer 'Número de Almancenes
        Dim TD As Decimal 'Total distribución
        Dim i, j, k, m, n As Integer 'Contadores
        Dim arrPDO As New ArrayList
        Dim IDDETALLE As Integer

        'Obteniendo los renglones adjudicados para el proceso de compra

        Dim mComAmpliacionContrato As New cAMPLIACIONCONTRATO
        Dim dsRenglonesAmpliados As DataSet

        dsRenglonesAmpliados = mComAmpliacionContrato.obtenerRenglonesAmpliados(IDESTABLECIMIENTO, IDPROCESOCOMPRA)

        'Obteniendo los montos de las ofertas por proveedor por renglon

        TD = 0

        Dim mComOferta As New cADJUDICACION
        Dim RENGLON As Integer
        Dim IDALMACEN As Integer
        Dim mComAlmacSol As New cPROGRAMADISTRIBUCION
        Dim dsSolAlmac As DataSet
        Dim CANTIDADTOTALRENGLON As Decimal

        For i = 0 To dsRenglonesAmpliados.Tables(0).Rows.Count - 1

            RENGLON = dsRenglonesAmpliados.Tables(0).Rows(i).Item("RENGLON")
            CANTIDADTOTALRENGLON = dsRenglonesAmpliados.Tables(0).Rows(i).Item("CANTIDADAMPLIADA")
            'dsOfertas = mComOferta.obtenerCantidadAdjudicadaProveedor(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON)
            dsSolAlmac = mComAlmacSol.ObtenerCantidadAdjudicadaAlmacenSolicitud(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON)

            'Obteniendo el total a entregar por renglon

            NoAlm = dsSolAlmac.Tables(0).Rows.Count

            'CALCULANDO LAS CANTIDADES AMPLIADAS PARA CADA ALMACEN

            Dim arrALMAC As New ArrayList
            Dim cantAmp, fixCantAmp As Decimal
            Dim SUMACANTAMPALM As Decimal
            For m = 0 To NoAlm - 1

                If (CANTIDADTOTALRENGLON - SUMACANTAMPALM) > 0 Then
                    fixCantAmp = Fix(dsSolAlmac.Tables(0).Rows(m).Item("CANTIDADADJUDICADA") * (PORCENTAJE / 100))
                    cantAmp = dsSolAlmac.Tables(0).Rows(m).Item("CANTIDADADJUDICADA") * (PORCENTAJE / 100)
                    If (cantAmp - fixCantAmp) >= 0.051 Then
                        fixCantAmp = fixCantAmp + 1
                    End If
                    SUMACANTAMPALM += fixCantAmp
                    arrALMAC.Add(fixCantAmp)
                Else
                    fixCantAmp = CANTIDADTOTALRENGLON - SUMACANTAMPALM
                    arrALMAC.Add(fixCantAmp)
                End If
            Next

            'For m = 0 To NoAlm - 1
            '    TD += dsSolAlmac.Tables(0).Rows(m).Item("CANTIDADADJUDICADA") * (PORCENTAJE / 100)
            'Next

            ''Obteniendo Porcentaje de distribucion por oferta

            ''For j = 0 To dsRenglonesAmpliados.Tables(0).Rows.Count - 1

            'If dsRenglonesAmpliados.Tables(0).Rows(i).Item("CANTIDADAMPLIADA") Mod TD > 0 Then
            '    PDO = ((dsOfertas.Tables(0).Rows(i).Item("CANTIDADAMPLIADA") / TD) * 100)
            'Else
            '    PDO = ((dsOfertas.Tables(0).Rows(i).Item("CANTIDADAMPLIADA") / TD) * 100)
            'End If

            ''arrPDO.Add(PDO)

            ''Next

            For m = 0 To NoAlm - 1

                IDALMACEN = dsSolAlmac.Tables(0).Rows(m).Item("IDALMACEN")

                'Obteniendo la cantidad total a distribuir por Almacen por Oferta

                Dim arrRespuesta As New ArrayList

                arrRespuesta = arrALMAC

                'arrRespuesta = Me.distribuyeProductoAmpliacion(dsSolAlmac.Tables(0).Rows(m).Item("CANTIDADADJUDICADA"), arrALMAC)

                'OBTENIENDO LA CANTIDAD PARA CADA ENTREGA POR OFERTA

                'Primero : Obteniendo las entregas

                Dim mComEntregas As New cENTREGACONTRATO
                Dim dsEntregas As DataSet
                Dim IDPROVEEDOR As Integer
                Dim arrEntregas As New ArrayList
                Dim arrCantEntrega As New ArrayList

                For j = 0 To dsRenglonesAmpliados.Tables(0).Rows.Count - 1

                    IDPROVEEDOR = dsRenglonesAmpliados.Tables(0).Rows(j).Item("IDPROVEEDOR")
                    dsEntregas = mComEntregas.obtenerEntregasProveedorAmpliacion(IDESTABLECIMIENTO, dsRenglonesAmpliados.Tables(0).Rows(i).Item("IDCONTRATO"), IDPROVEEDOR, RENGLON)

                    IDDETALLE = dsEntregas.Tables(0).Rows(0).Item("IDDETALLE")

                    For k = 0 To dsEntregas.Tables(0).Rows.Count - 1
                        arrEntregas.Add(dsEntregas.Tables(0).Rows(k).Item("PORCENTAJEENTREGA"))
                    Next

                    arrCantEntrega = Me.DistribuirProducto(arrRespuesta.Item(j), arrEntregas)

                    For n = 0 To arrCantEntrega.Count - 1
                        guardarAlmacenEntregaContrato(IDESTABLECIMIENTO, IDPROCESOCOMPRA, IDPROVEEDOR, dsRenglonesAmpliados.Tables(0).Rows(i).Item("IDCONTRATO"), IDDETALLE, RENGLON, IDALMACEN, arrCantEntrega.Item(n), USUARIO)
                    Next

                    arrEntregas.Clear()

                Next

                arrRespuesta.Clear()

                arrCantEntrega.Clear()

            Next
            arrPDO.Clear()
            TD = 0
        Next

    End Sub

    Private Sub guardarAlmacenEntregaAdjudicacion(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer, ByVal IDENTREGA As Integer, ByVal IDALMACEN As Integer, ByVal CANTIDADENTREGAr As Decimal, ByVal USUARIO As String, ByVal IDFUENTEFINANCIAMIENTO As Integer, ByVal MOMENTO As Integer)

        Dim mComponente As New cALMACENESENTREGAADJUDICACION
        Dim lEntidad As New ALMACENESENTREGAADJUDICACION

        With lEntidad
            .AUFECHACREACION = Date.Today
            .AUUSUARIOCREACION = USUARIO
            .CANTIDAD = CANTIDADENTREGAr
            .ESTASINCRONIZADA = 0
            .IDALMACEN = IDALMACEN
            .IDDETALLE = IDDETALLE
            .IDENTREGA = IDENTREGA + 1
            .IDESTABLECIMIENTO = IDESTABLECIMIENTO
            .IDPROCESOCOMPRA = IDPROCESOCOMPRA
            .IDPROVEEDOR = IDPROVEEDOR
            .IDFUENTEFINANCIAMIENTO = IDFUENTEFINANCIAMIENTO
        End With
        mComponente.EliminarALMACENESENTREGAADJUDICACION(lEntidad.IDESTABLECIMIENTO, lEntidad.IDPROCESOCOMPRA, lEntidad.IDPROVEEDOR, lEntidad.IDDETALLE, lEntidad.IDENTREGA, lEntidad.IDALMACEN, lEntidad.IDFUENTEFINANCIAMIENTO)
        mComponente.AgregarALMACENESENTREGAADJUDICACION(lEntidad, MOMENTO)

    End Sub

    ''' <summary>
    ''' Realiza la distribución de productos a entregar por proveedor 
    ''' </summary>
    ''' <param name="IDESTABLECIMIENTO"></param>
    ''' <param name="IDPROCESOCOMPRA"></param>
    ''' <param name="USUARIO"></param>
    ''' <param name="IDPROVEEDOR"></param>
    ''' <param name="RENGLON"></param>
    ''' <param name="IDCONTRATO"></param>
    ''' <remarks>Lista de tablas utilizadas en está función:
    ''' <list type="bullet">
    ''' <item><description>SAB_CAT_TIPOTRANSACCIONES</description></item>
    ''' </list> 
    ''' </remarks>
    ''' <history>
    '''     [Autor: Juan José Rivas Angel]  02/02/2007    Creado
    ''' </history>
    Public Sub calcularDistribucionEntregasProveedor(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal USUARIO As String, ByVal IDPROVEEDOR As Integer, ByVal RENGLON As Integer, ByVal IDCONTRATO As Integer)
        Dim PDO As Decimal ' Porcentaje de Distribución por Oferta

        Dim NoAlm As Integer 'Número de Almancenes
        Dim TD As Decimal 'Total distribución

        Dim i, j, k, m, n As Integer 'Contadores
        Dim arrPDO As New ArrayList
        Dim dsOfertas As DataSet
        Dim IDDETALLE As Integer
        Dim CANTIDADFIRME As Decimal

        'Obteniendo los renglones adjudicados para el proceso de compra

        Dim cModContProd As New cMODIFICATIVASCONTRATOPRODUCTO

        Dim mComAdjudicacion As New cADJUDICACION
        Dim dsRenglonesAdjudicados As DataSet

        dsRenglonesAdjudicados = mComAdjudicacion.obtenerRenglonAdjudicadoProveedor(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON, IDPROVEEDOR)

        'Obteniendo los montos de las ofertas por proveedor por renglon

        TD = 0

        Dim mComOferta As New cADJUDICACION
        'Dim RENGLON As Integer
        Dim IDALMACEN As Integer
        Dim mComAlmacSol As New cPROGRAMADISTRIBUCION
        Dim dsSolAlmac As DataSet
        Dim dsModificativa As Data.DataSet

        For i = 0 To dsRenglonesAdjudicados.Tables(0).Rows.Count - 1

            'RENGLON = dsRenglonesAdjudicados.Tables(0).Rows(i).Item("RENGLON")

            dsOfertas = mComOferta.obtenerCantidadAdjudicadaProveedor(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON, IDPROVEEDOR)

            dsModificativa = cModContProd.obtenerCantidadModificativa(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON)

            dsSolAlmac = mComAlmacSol.ObtenerCantidadAdjudicadaAlmacenSolicitud(IDESTABLECIMIENTO, IDPROCESOCOMPRA, RENGLON) 'OJO OTRO MOMENTO se cambio ObtenerCantidadAdjudicadaAlmacen

            'Obteniendo el total a entregar por renglon
            NoAlm = dsSolAlmac.Tables(0).Rows.Count

            For m = 0 To NoAlm - 1
                TD += dsSolAlmac.Tables(0).Rows(m).Item("CANTIDADADJUDICADA")
            Next

            'Verificando si hay cantidades ya entregadas
            Dim mComEntregas As New cENTREGACONTRATO
            Dim sumaCantidadEntregada As Decimal
            sumaCantidadEntregada = mComEntregas.obtieneSumaCantidadEntregada(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON)

            'Obteniendo Porcentaje de distribucion por oferta
            For j = 0 To dsOfertas.Tables(0).Rows.Count - 1

                'obteniendo la cantidad modificada en la ultima modificativa

                If dsModificativa.Tables(0).Rows.Count > 0 Then
                    CANTIDADFIRME = dsModificativa.Tables(0).Rows(0).Item("CANTIDADCONTRATADA")
                Else
                    CANTIDADFIRME = dsOfertas.Tables(0).Rows(j).Item("CANTIDADFIRME")
                End If

                'CANTIDADFIRME = CANTIDADFIRME - sumaCantidadEntregada

                'dsOfertas.Tables(0).Rows(j).Item("CANTIDADFIRME")
                If CANTIDADFIRME Mod TD > 0 Then
                    PDO = ((CANTIDADFIRME / TD) * 100)
                Else
                    PDO = ((CANTIDADFIRME / TD) * 100)
                End If

                arrPDO.Add(PDO)

            Next

            For m = 0 To NoAlm - 1

                IDALMACEN = dsSolAlmac.Tables(0).Rows(m).Item("IDALMACEN")

                'Obteniendo la cantidad total a distribuir por Almacen por Oferta

                Dim arrRespuesta As New ArrayList
                arrRespuesta = Me.DistribuirProducto(dsSolAlmac.Tables(0).Rows(m).Item("CANTIDADADJUDICADA"), arrPDO)

                'OBTENIENDO LA CANTIDAD PARA CADA ENTREGA POR OFERTA

                'Primero : Obteniendo las entregas
                Dim dsEntregas As DataSet
                'Dim IDPROVEEDOR As Integer
                Dim arrEntregas As New ArrayList
                Dim arrCantEntrega As New ArrayList

                For j = 0 To dsOfertas.Tables(0).Rows.Count - 1

                    'IDPROVEEDOR = dsOfertas.Tables(0).Rows(j).Item("IDPROVEEDOR")
                    dsEntregas = mComEntregas.obtenerEntregasProveedor(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR, RENGLON)

                    'IDDETALLE = dsEntregas.Tables(0).Rows(0).Item("IDDETALLE")

                    For k = 0 To dsEntregas.Tables(0).Rows.Count - 1
                        arrEntregas.Add(dsEntregas.Tables(0).Rows(k).Item("PORCENTAJEENTREGA"))
                    Next

                    'arrCantEntrega = Me.distribuyeProducto(arrRespuesta.Item(j), arrEntregas)
                    arrCantEntrega = Me.DistribuirProducto(CANTIDADFIRME, arrEntregas)

                    For n = 0 To arrCantEntrega.Count - 1
                        IDDETALLE = dsEntregas.Tables(0).Rows(n).Item("IDDETALLE")
                        If mComEntregas.ValidarProductoEntregado(IDESTABLECIMIENTO, IDPROVEEDOR, IDCONTRATO, RENGLON, IDDETALLE) = 0 Then
                            guardarAlmacenEntregaContrato(IDESTABLECIMIENTO, IDCONTRATO, IDPROVEEDOR, IDDETALLE, n, IDALMACEN, arrCantEntrega.Item(n), USUARIO, RENGLON)
                        End If

                    Next

                    arrEntregas.Clear()

                Next

                arrRespuesta.Clear()

                arrCantEntrega.Clear()

            Next
            arrPDO.Clear()
            TD = 0
        Next

    End Sub

    Private Sub guardarAlmacenEntregaContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDCONTRATO As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDDETALLE As Integer, ByVal IDENTREGA As Integer, ByVal IDALMACEN As Integer, ByVal CANTIDADENTREGAr As Decimal, ByVal USUARIO As String, ByVal IDRENGLON As Integer)

        Dim mComponente As New cALMACENESENTREGACONTRATOS
        Dim lEntidad As New ALMACENESENTREGACONTRATOS

        With lEntidad
            .IDESTABLECIMIENTO = IDESTABLECIMIENTO
            .IDPROVEEDOR = IDPROVEEDOR
            .IDCONTRATO = IDCONTRATO
            .RENGLON = IDRENGLON
            .IDDETALLE = IDDETALLE
            .IDALMACENENTREGA = IDALMACEN
            .CANTIDAD = CANTIDADENTREGAr
            .CANTIDADENTREGADA = 0
            .AUUSUARIOCREACION = USUARIO
            .AUFECHACREACION = Date.Today
            .ESTASINCRONIZADA = 0
        End With

        mComponente.AgregarALMACENESENTREGACONTRATOS(lEntidad)

    End Sub

    Private Sub guardarAlmacenEntregaContrato(ByVal IDESTABLECIMIENTO As Integer, ByVal IDPROCESOCOMPRA As Integer, ByVal IDPROVEEDOR As Integer, ByVal IDCONTRATO As Integer, ByVal IDDETALLE As Integer, ByVal RENGLON As Integer, ByVal IDALMACEN As Integer, ByVal CANTIDADENTREGAr As Decimal, ByVal USUARIO As String)

        Dim mComponente As New cALMACENESENTREGACONTRATOS
        Dim lEntidad As New ALMACENESENTREGACONTRATOS

        With lEntidad
            .IDESTABLECIMIENTO = IDESTABLECIMIENTO
            .IDPROVEEDOR = IDPROVEEDOR
            .IDCONTRATO = IDCONTRATO
            .RENGLON = RENGLON
            .IDDETALLE = IDDETALLE
            .IDALMACENENTREGA = IDALMACEN
            .CANTIDAD = CANTIDADENTREGAr
            .ESTASINCRONIZADA = 0
            .AUFECHACREACION = Date.Today
            .AUUSUARIOCREACION = USUARIO
        End With

        mComponente.AgregarALMACENESENTREGACONTRATOS(lEntidad)

    End Sub

End Class
