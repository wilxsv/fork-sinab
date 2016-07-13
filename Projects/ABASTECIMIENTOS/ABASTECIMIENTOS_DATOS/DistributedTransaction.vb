Imports System.Configuration.ConfigurationSettings

Public Class DistributedTransaction
    Implements IDisposable

    Private _happy As Boolean = True
    Private _done As Boolean = False
    Private _sqlTransaction As SqlClient.SqlTransaction
    Private _connection As SqlClient.SqlConnection
    Private _disposed As Boolean = False

    Protected _connString As String = AppSettings("cnnString")

    Public ReadOnly Property Connection() As SqlClient.SqlConnection
        Get
            Return _connection
        End Get
    End Property

    Public ReadOnly Property SqlTransaction() As SqlClient.SqlTransaction
        Get
            If _disposed Then Throw New ObjectDisposedException("Transaccion")

            If _done Then Throw New InvalidOperationException("La transaccion se ha cerrado y no puede ser utilizada")

            Return _sqlTransaction
        End Get
    End Property

    Private Sub Dispose() Implements IDisposable.Dispose

    End Sub

    Private Sub Dispose(ByVal disposing As Boolean)

        If _disposed Then Exit Sub

        If disposing Then

            Try
                If Not _done Then
                    If _happy Then
                        _sqlTransaction.Commit()
                    Else
                        _sqlTransaction.Rollback()
                    End If
                End If
            Catch ex As Exception

            End Try

            Try
                _connection.Close()
                _connection.Dispose()
                _sqlTransaction.Dispose()
            Catch ex As Exception
                'Debug.WriteLine("Error al cerrar la transaccion: " & ex.Message)
            End Try

        End If

        _disposed = True

    End Sub

    Public Sub New()
        Try
            _connection = New SqlClient.SqlConnection(_connString)

            Try
                _connection.Open()
            Catch ex As Exception
                Throw New ApplicationException("Imposible abrir conexion.")
            End Try

            _sqlTransaction = _connection.BeginTransaction()

        Catch ex As Exception

            Try
                _connection.Close()
            Catch ex2 As Exception

            End Try

        End Try

    End Sub

    Public Sub DisableCommit()

        If _disposed Then Throw New ObjectDisposedException("SqlTransaction")

        _happy = False

    End Sub

    Public Sub Commit()

        If _disposed Then Throw New ObjectDisposedException("SqlTransaction")

        If _done Then Throw New InvalidOperationException("La transaccion se ha cerrado y no puede ser utilizada")

        If Not _happy Then Throw New InvalidOperationException("La transaccion se ha deshabilitado")

        Try
            _sqlTransaction.Commit()
        Catch ex As Exception
            Throw
        Finally

            _done = True

            If Not _sqlTransaction Is Nothing Then

                If Not _sqlTransaction.Connection Is Nothing Then

                    If _sqlTransaction.Connection.State = ConnectionState.Open Then
                        _sqlTransaction.Connection.Close()
                    End If

                    _sqlTransaction.Connection.Dispose()

                End If

                _sqlTransaction.Dispose()

            End If

        End Try

    End Sub

    Public Sub Abort()

        If _disposed Then Throw New ObjectDisposedException("Transaccion")

        If _done Then Throw New InvalidOperationException("La transaccion se ha cerrado y no puede ser utilizada")

        Try
            _sqlTransaction.Rollback()

            _happy = False

        Catch ex As Exception
            Throw
        Finally

            _done = True

            If Not _sqlTransaction Is Nothing Then

                If Not _sqlTransaction.Connection Is Nothing Then

                    If _sqlTransaction.Connection.State = ConnectionState.Open Then
                        _sqlTransaction.Connection.Close()
                    End If

                    _sqlTransaction.Connection.Dispose()

                End If

                _sqlTransaction.Dispose()

            End If

        End Try

    End Sub

End Class